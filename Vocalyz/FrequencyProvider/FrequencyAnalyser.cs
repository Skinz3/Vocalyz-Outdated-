using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocalyz.Notes;

namespace FlowView.Audio.FrequencyProvider
{
    public class FrequencyAnalyser
    {
        public const int NullFrequency = -9999;
        List<FrequencyData> Frequencies = new List<FrequencyData>();
        public FrequencyAnalyser(FrequencyData[] fqs)
        {
            this.Frequencies = fqs.ToList();
        }
        /// <summary>
        /// Trie les informations de frequence dans l'ordre décroissant en fonction de l'intensité, il permet donc de récuperer les frequence la plus fortes
        /// </summary>
        /// <returns></returns>
        public List<FrequencyData> GetMastersFrequencies()
        {
            var datas = Frequencies.OrderBy(o => o.Intensity);
            var datas2 = datas.Reverse().ToList(); 
            datas2.RemoveAll(x => x.Frequency <= 100); // indétéctable
            datas2.RemoveAll(x => x.Intensity <= 54); // bruit de fond
            return datas2.ToList();
        }
        /// <summary>
        /// Permet de récuperer la fréquence la plus forte, ou la fondamentale d'un accord par exemple
        /// </summary>
        /// <returns></returns>
        public FrequencyData GetMasterFrequency()
        {
            var masters = GetMastersFrequencies();
            if (masters.Count() == 0)
                return new FrequencyData(NullFrequency,0); 
            var t = masters.First();
            if (t == null || t.Frequency <= 100 || double.IsInfinity(t.Intensity))
                return new FrequencyData(NullFrequency,0); // frequence ventilo, process
            else
                return t;
        }
        public Note GetEventualPitch()
        {
            var master= GetMasterFrequency().Frequency;
            if (master != NullFrequency)
                return NotesManager.GetNoteByFrequency(master);
            else
                return null;
        }
        /// <summary>
        /// Recupere les pics de fréquence
        /// </summary>
        /// <param name="precision"></param>
        /// <returns></returns>
        public List<int> GetFPics(int precision)
        {
            var masters = GetMastersFrequencies();
            if (masters.Count == 0)
                return new List<int>();
            var first = masters.First();
            var bestI = masters.ConvertAll<FrequencyData>(x => new FrequencyData(x.Frequency, (int)x.Intensity));
            var selected = bestI.Take(precision);
            List<int> knownBest = new List<int>();
            bool add = true;
            foreach (var best in selected.ToList())
            {
                for (int i = 0; i < 20; i++)
                {
                    if (knownBest.Contains(best.Frequency + i) || knownBest.Contains(best.Frequency - i) || knownBest.Contains(best.Frequency))
                    {
                        add = false;
                        break;
                    }

                }
                if (add)
                    knownBest.Add(best.Frequency);
            }
            return knownBest;
        }
    }
}
