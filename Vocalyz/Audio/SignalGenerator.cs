/* Copyright (C) 2007 Jeff Morton (jeffrey.raymond.morton@gmail.com)

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA */

using System;
using System.Collections.Generic;
using System.Text;

namespace FlowView.Audio
{
    class SignalGenerator
    {
        private string _waveForm = "Sine";
        private double _amplitude = 128.0;
        private double _samplingRate = 44100;
        private double _frequency = 5000.0;
        private double _dcLevel = 0.0;
        private double _noise = 0.0;
        private int _samples = 16384;
        private bool _addDCLevel = false;
        private bool _addNoise = false;

        public SignalGenerator()
        {
        }

        public void SetWaveform(string waveForm)
        {
            _waveForm = waveForm;
        }

        public String GetWaveform()
        {
            return _waveForm;
        }

        public void SetAmplitude(double amplitude)
        {
            _amplitude = amplitude;
        }

        public double GetAmplitude()
        {
            return _amplitude;
        }

        public void SetFrequency(double frequency)
        {
            _frequency = frequency;
        }

        public double GetFrequency()
        {
            return _frequency;
        }

        public void SetSamplingRate(double rate)
        {
            _samplingRate = rate;
        }

        public double GetSamplingRate()
        {
            return _samplingRate;
        }

        public void SetSamples(int samples)
        {
            _samples = samples;
        }

        public int GetSamples()
        {
            return _samples;
        }

        public void SetDCLevel(double dc)
        {
            _dcLevel = dc;
        }

        public double GetDCLevel()
        {
            return _dcLevel;
        }

        public void SetNoise(double noise)
        {
            _noise = noise;
        }

        public double GetNoise()
        {
            return _noise;
        }

        public void SetDCLevelState(bool dcstate)
        {
            _addDCLevel = dcstate;
        }

        public bool IsDCLevel()
        {
            return _addDCLevel;
        }

        public void SetNoiseState(bool noisestate)
        {
            _addNoise = noisestate;
        }

        public bool IsNoise()
        {
            return _addNoise;
        }

        public double[] GenerateSignal()
        {
            double[] values = new double[_samples];
            if (_waveForm.Equals("Sine"))
            {
                double theta = 2.0 * Math.PI * _frequency / _samplingRate;
                for (int i = 0; i < _samples; i++)
                {
                    values[i] = _amplitude * Math.Sin(i * theta);
                }
            }
            if (_waveForm.Equals("Cosine"))
            {
                double theta = 2.0f * (double)Math.PI * _frequency / _samplingRate;
                for (int i = 0; i < _samples; i++)
                    values[i] = _amplitude * Math.Cos(i * theta);
            }
            if (_waveForm.Equals("Square"))
            {
                double p = 2.0 * _frequency / _samplingRate;
                for (int i = 0; i < _samples; i++)
                    values[i] = Math.Round(i * p) % 2 == 0 ? _amplitude : -_amplitude;
            }
            if (_waveForm.Equals("Triangular"))
            {
                double p = 2.0 * _frequency / _samplingRate;
                for (int i = 0; i < _samples; i++)
                {
                    int ip = (int)Math.Round(i * p);
                    values[i] = 2.0 * _amplitude * (1 - 2 * (ip % 2)) * (i * p - ip);
                }
            }
            if (_waveForm.Equals("Sawtooth"))
            {
                for (int i = 0; i < _samples; i++)
                {
                    double q = i * _frequency / _samplingRate;
                    values[i] = 2.0 * _amplitude * (q - Math.Round(q));
                }
            }
            if (_addDCLevel)
            {
                for (int i = 0; i < _samples; i++)
                    values[i] += _dcLevel;
            }
            if (_addNoise)
            {
                Random r = new Random();
                for (int i = 0; i < _samples; i++)
                    values[i] += _noise * r.Next();
            }
            return values;
        }
    }
}
