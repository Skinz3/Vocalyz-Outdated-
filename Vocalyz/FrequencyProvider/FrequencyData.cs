using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowView.Audio.FrequencyProvider
{
    public class FrequencyData
    {
        /// <summary>
        /// Fréquence en Hertz
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Intensité Sonore, en décibels
        /// </summary>
        public double Intensity { get; set; }

        public FrequencyData(int frequency,double db)
        {
            this.Frequency = frequency;
            this.Intensity = db;
        }

        public override string ToString()
        {
            return string.Format("Frequency : {0} Intensity : {1}", Frequency, Intensity);
        }
    }
}
