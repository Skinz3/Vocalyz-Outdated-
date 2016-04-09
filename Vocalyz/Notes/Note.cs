using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocalyz.Notes
{
    public class Note
    {
        /// <summary>
        /// Vitesse du son , en mètres par secondes
        /// </summary>
        public const int SOUND_SPEED = 345; 

        public string SymbolUS { get; set; }

        public string SymbolFR { get; set; }
        /// <summary>
        /// Frequence de la note, en hertz
        /// </summary>
        public double Frequency { get; set; }
        /// <summary>
        /// Longueur d'onde de la note en cm
        /// </summary>
        public double WaveLenght { get; set; }
        /// <summary>
        /// Octave de la note
        /// </summary>
        public short Octave { get; set; }

        public Note(string symbolus,string symbolfr,short octave,double frequency,double wavelenght)
        {
            this.SymbolUS = symbolus;
            this.SymbolFR = symbolfr;
            this.Octave = octave;
            this.Frequency = frequency;
            this.WaveLenght = wavelenght;
        }
    }
}
