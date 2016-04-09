using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using FlowView.Audio.FrequencyProvider;
using FlowView.Audio;
namespace FlowView.Audio
{
    public class AudioFrame
    {
        private FrequencyData[] m_datas;

        private double[] m_waveLeft;

        private double[] m_waveRight;

        private double[] m_fftLeft;

        private double[] m_fftRight;


        public AudioFrame()
        {

        }

        /// <summary>
        /// Process 16 bit sample
        /// </summary>
        /// <param name="wave"></param>
        public void Process(ref byte[] wave)
        {
            m_waveLeft = new double[wave.Length / 4];
            m_waveRight = new double[wave.Length / 4];
            m_datas = new FrequencyData[wave.Length / 8];

            // Split out channels from sample
            int h = 0;
            for (int i = 0; i < wave.Length; i += 4)
            {
                m_waveLeft[h] = (double)BitConverter.ToInt16(wave, i);
                m_waveRight[h] = (double)BitConverter.ToInt16(wave, i + 2);
                h++;
            }
            lock (this)
            {
                // Generate frequency domain data in decibels
                m_fftLeft = FourierTransform.FFTDb(ref m_waveLeft);
                m_fftRight = FourierTransform.FFTDb(ref m_waveRight);
            }
        }

        public FrequencyData[] GetSortedDatas()
        {
          
            int frequency = 0;

            for (int i = 0; i < m_fftRight.Length; i++)
            {
                double decibels = m_fftRight[i];
                m_datas[i] = new FrequencyData(frequency * 2, decibels);
                frequency++;
            }
            return m_datas.OrderByDescending(x => x.Intensity).ToArray();
        }

    }
}
