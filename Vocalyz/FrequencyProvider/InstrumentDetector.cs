using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocalyz.Notes;

namespace FlowView.Audio.FrequencyProvider
{
    class InstrumentDetector
    {
        static InstrumentDetector()
        {
            Handlers.Add(InstrumentTypeEnum.Guitar, Guitar);
            Handlers.Add(InstrumentTypeEnum.PureSound, PureSound);
        }
        public delegate bool InstrumentParserDelegate(Note detectedPitch,int masterFrequency, int[] mastersFrequency);
        static Dictionary<InstrumentTypeEnum, InstrumentParserDelegate> Handlers = new Dictionary<InstrumentTypeEnum, InstrumentParserDelegate>();
        public static InstrumentTypeEnum Handle(Note detectedPitch,int masterFrequency, int[] mastersFrequency)
        {
            foreach (var handler in Handlers)
            {
                if (handler.Value(detectedPitch, masterFrequency, mastersFrequency))
                {
                    return handler.Key;
                }
            }
            return InstrumentTypeEnum.None;
        }
        static List<int> GetAprox(int frequency)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                if (!result.Contains(frequency+i))
                result.Add(frequency+i);
            }
            for (int i = 0; i < 15; i++)
            {
                if (!result.Contains(frequency - i))
                    result.Add(frequency - i);
            }
            return result;
        }
        static bool DetectFromPitchAndMaster(double pitchFr,int[] mastersFr,int pitchTheorical,int FrMasterThéorical)
        {
            if (pitchFr == pitchTheorical && mastersFr.Count() > 1) // La note la plus aigue de la guitare 
            {
                foreach (var frq in mastersFr)
                {
                    if (mastersFr.Last() != frq)
                    {
                        if (GetAprox(FrMasterThéorical).Contains(frq))
                            return true;
                    }
                }
            }
            return false;
        }
        static bool Guitar(Note detectedPitch,int masterFrequency,int[] mastersFrequency)
        {
            if (DetectFromPitchAndMaster(detectedPitch.Frequency, mastersFrequency, 311, 940))
                return true;
            if (DetectFromPitchAndMaster(detectedPitch.Frequency, mastersFrequency, 312, 940))
                return true;
            if (DetectFromPitchAndMaster(detectedPitch.Frequency, mastersFrequency, 311, 605))
                return true;
            if (DetectFromPitchAndMaster(detectedPitch.Frequency, mastersFrequency, 156, 236))
                return true;
            return false;
        }
        static bool PureSound(Note detectedPitch,int masterFrequency,int[] mastersFrequency)
        {
            if (mastersFrequency.Length == 1)
                return true;
            return false;
        }
    }
}
