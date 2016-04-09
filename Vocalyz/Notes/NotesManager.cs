using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocalyz.Notes
{
    class NotesManager
    {
        /// <summary>
        /// Répertoire de notes
        /// </summary>
        public static List<Note> Notes = new List<Note>();
        static NotesManager()
        {
            Notes.Add(new Note("C", string.Empty, 0, 16.35, 2109.89));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 17.32, 1991.47));
            Notes.Add(new Note("D", string.Empty, 0, 18.35, 1879.69));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 19.45, 1774.2));
            Notes.Add(new Note("E", string.Empty, 0, 20.6, 1674.62));
            Notes.Add(new Note("F", string.Empty, 0, 21.83, 1580.63));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 23.12, 1491.91));
            Notes.Add(new Note("G", string.Empty, 0, 24.5, 1408.18));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 25.96, 1329.14));
            Notes.Add(new Note("A", string.Empty, 0, 27.5, 1254.55));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 29.14, 1184.13));
            Notes.Add(new Note("B", string.Empty, 0, 30.87, 1117.67));
            Notes.Add(new Note("C", string.Empty, 1, 32.7, 1054.94));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 34.65, 995.73));
            Notes.Add(new Note("D", string.Empty, 1, 36.71, 939.85));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 38.89, 887.1));
            Notes.Add(new Note("E", string.Empty, 1, 41.2, 837.31));
            Notes.Add(new Note("F", string.Empty, 1, 43.65, 790.31));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 46.25, 745.96));
            Notes.Add(new Note("G", string.Empty, 1, 49, 704.09));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 51.91, 664.57));
            Notes.Add(new Note("A", string.Empty, 1, 55, 627.27));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 58.27, 592.07));
            Notes.Add(new Note("B", string.Empty, 1, 61.74, 558.84));
            Notes.Add(new Note("C", string.Empty, 2, 65.41, 527.47));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 69.3, 497.87));
            Notes.Add(new Note("D", string.Empty, 2, 73.42, 469.92));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 77.78, 443.55));
            Notes.Add(new Note("E", string.Empty, 2, 82.41, 418.65));
            Notes.Add(new Note("F", string.Empty, 2, 87.31, 395.16));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 92.5, 372.98));
            Notes.Add(new Note("G", string.Empty, 2, 98, 352.04));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 103.83, 332.29));
            Notes.Add(new Note("A", string.Empty, 2, 110, 313.64));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 116.54, 296.03));
            Notes.Add(new Note("B", string.Empty, 2, 123.47, 279.42));
            Notes.Add(new Note("C", string.Empty, 3, 130.81, 263.74));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 138.59, 248.93));
            Notes.Add(new Note("D", string.Empty, 3, 146.83, 234.96));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 155.56, 221.77));
            Notes.Add(new Note("E", string.Empty, 3, 164.81, 209.33));
            Notes.Add(new Note("F", string.Empty, 3, 174.61, 197.58));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 185, 186.49));
            Notes.Add(new Note("G", string.Empty, 3, 196, 176.02));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 207.65, 166.14));
            Notes.Add(new Note("A", string.Empty, 3, 220, 156.82));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 233.08, 148.02));
            Notes.Add(new Note("B", string.Empty, 3, 246.94, 139.71));
            Notes.Add(new Note("C", string.Empty, 4, 261.63, 131.87));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 277.18, 124.47));
            Notes.Add(new Note("D", string.Empty, 4, 293.66, 117.48));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 311.13, 110.89));
            Notes.Add(new Note("E", string.Empty, 4, 329.63, 104.66));
            Notes.Add(new Note("F", string.Empty, 4, 349.23, 98.79));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 369.99, 93.24));
            Notes.Add(new Note("G", string.Empty, 4, 392, 88.01));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 415.3, 83.07));
            Notes.Add(new Note("A", string.Empty, 4, 440, 78.41));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 466.16, 74.01));
            Notes.Add(new Note("B", string.Empty, 4, 493.88, 69.85));
            Notes.Add(new Note("C", string.Empty, 5, 523.25, 65.93));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 554.37, 62.23));
            Notes.Add(new Note("D", string.Empty, 5, 587.33, 58.74));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 622.25, 55.44));
            Notes.Add(new Note("E", string.Empty, 5, 659.25, 52.33));
            Notes.Add(new Note("F", string.Empty, 5, 698.46, 49.39));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 739.99, 46.62));
            Notes.Add(new Note("G", string.Empty, 5, 783.99, 44.01));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 830.61, 41.54));
            Notes.Add(new Note("A", string.Empty, 5, 880, 39.2));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 932.33, 37));
            Notes.Add(new Note("B", string.Empty, 5, 987.77, 34.93));
            Notes.Add(new Note("C", string.Empty, 6, 1046.5, 32.97));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 1108.73, 31.12));
            Notes.Add(new Note("D", string.Empty, 6, 1174.66, 29.37));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 1244.51, 27.72));
            Notes.Add(new Note("E", string.Empty, 6, 1318.51, 26.17));
            Notes.Add(new Note("F", string.Empty, 6, 1396.91, 24.7));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 1479.98, 23.31));
            Notes.Add(new Note("G", string.Empty, 6, 1567.98, 22));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 1661.22, 20.77));
            Notes.Add(new Note("A", string.Empty, 6, 1760, 19.6));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 1864.66, 18.5));
            Notes.Add(new Note("B", string.Empty, 6, 1975.53, 17.46));
            Notes.Add(new Note("C", string.Empty, 7, 2093, 16.48));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 2217.46, 15.56));
            Notes.Add(new Note("D", string.Empty, 7, 2349.32, 14.69));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 2489.02, 13.86));
            Notes.Add(new Note("E", string.Empty, 7, 2637.02, 13.08));
            Notes.Add(new Note("F", string.Empty, 7, 2793.83, 12.35));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 2959.96, 11.66));
            Notes.Add(new Note("G", string.Empty, 7, 3135.96, 11));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 3322.44, 10.38));
            Notes.Add(new Note("A", string.Empty, 7, 3520, 9.8));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 3729.31, 9.25));
            Notes.Add(new Note("B", string.Empty, 7, 3951.07, 8.73));
            Notes.Add(new Note("C", string.Empty, 8, 4186.01, 8.24));
            Notes.Add(new Note(" C#/Db  ", string.Empty, 0, 4434.92, 7.78));
            Notes.Add(new Note("D", string.Empty, 8, 4698.63, 7.34));
            Notes.Add(new Note(" D#/Eb  ", string.Empty, 0, 4978.03, 6.93));
            Notes.Add(new Note("E", string.Empty, 8, 5274.04, 6.54));
            Notes.Add(new Note("F", string.Empty, 8, 5587.65, 6.17));
            Notes.Add(new Note(" F#/Gb  ", string.Empty, 0, 5919.91, 5.83));
            Notes.Add(new Note("G", string.Empty, 8, 6271.93, 5.5));
            Notes.Add(new Note(" G#/Ab  ", string.Empty, 0, 6644.88, 5.19));
            Notes.Add(new Note("A", string.Empty, 8, 7040, 4.9));
            Notes.Add(new Note(" A#/Bb  ", string.Empty, 0, 7458.62, 4.63));
            Notes.Add(new Note("B", string.Empty, 8, 7902.13, 4.37));
        }

        public static Note GetNoteByFrequency(double frequency)
        {
            if (frequency== 524)
            {

            }
            return Notes.Find(x => x.Frequency == frequency -1 || x.Frequency == frequency+1 || x.Frequency == frequency);
        }
      
      
    }
    
}
