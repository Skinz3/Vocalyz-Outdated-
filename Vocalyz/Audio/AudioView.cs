using FlowView.Audio.FrequencyProvider;
using SoundViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlowView.Audio
{
    public class AudioViewer
    {
        public delegate void OnDataArrivedDel(FrequencyData[] frequencies);

        public event OnDataArrivedDel OnDataArrived;

        private WaveInRecorder _recorder;

        private byte[] _recorderBuffer;

        private WaveOutPlayer _player;

        private byte[] _playerBuffer;

        private FifoStream _stream;

        private WaveFormat _waveFormat;

        private AudioFrame _audioFrame;

        private int _audioSamplesPerSecond = 44100;

        private int _audioFrameSize = 16384;

        private byte _audioBitsPerSample = 16;

        private byte _audioChannels = 2;

        private bool _isPlayer = false;


   

        public AudioViewer()
        {
           
            if (WaveNative.waveInGetNumDevs() == 0)
            {
                throw new Exception(DateTime.Now.ToString() + " : There are no audio devices available\r\n");
            }
            else
            {
                if (_isPlayer == true)
                    _stream = new FifoStream();
                _audioFrame = new AudioFrame();
            
            }
        }
        public void StartAnalysis(int device)
        {
            Start(device);
        }
        public void StopAnalysis()
        {
            Stop();
        }
        private void Start(int device)
        {
            Stop();
            try
            {
                _waveFormat = new WaveFormat(_audioFrameSize, _audioBitsPerSample, _audioChannels);
                _recorder = new WaveInRecorder(device, _waveFormat, _audioFrameSize * 2,3, new BufferDoneEventHandler(DataArrived));
                if (_isPlayer == true)
                    _player = new WaveOutPlayer(-1, _waveFormat, _audioFrameSize * 2, 3, new BufferFillEventHandler(Filler));
            }
            catch (Exception ex)
            {
                 throw new Exception(DateTime.Now + " : Audio exception\r\n" + ex.ToString() + "\r\n");
            }
        }
        private void Stop()
        {
            if (_recorder != null)
                try
                {
                    _recorder.Dispose();
                }
                finally
                {
                    _recorder = null;
                }
            if (_isPlayer == true)
            {
                if (_player != null)
                    try
                    {
                        _player.Dispose();
                    }
                    finally
                    {
                        _player = null;
                    }
                _stream.Flush(); // clear all pending data
            }
        }
        private void Filler(IntPtr data, int size)
        {
            if (_isPlayer == true)
            {
                if (_playerBuffer == null || _playerBuffer.Length < size)
                    _playerBuffer = new byte[size];
                if (_stream.Length >= size)
                    _stream.Read(_playerBuffer, 0, size);
                else
                    for (int i = 0; i < _playerBuffer.Length; i++)
                        _playerBuffer[i] = 0;
                System.Runtime.InteropServices.Marshal.Copy(_playerBuffer, 0, data, size);
            }
        }

        public void DataArrived(IntPtr data, int size)
        {
            if (_recorderBuffer == null || _recorderBuffer.Length < size)
                _recorderBuffer = new byte[size];
            if (_recorderBuffer != null)
            {
                Marshal.Copy(data, _recorderBuffer, 0, size);
                if (_isPlayer == true)
                    _stream.Write(_recorderBuffer, 0, _recorderBuffer.Length);
                _audioFrame.Process(ref _recorderBuffer);
            }
            if (OnDataArrived != null)
                OnDataArrived(_audioFrame.GetSortedDatas());
        }
    }
}
