using FlowView.Audio;
using FlowView.Audio.FrequencyProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocalyz.Notes;

namespace Vocalyz
{
    /// <summary>
    /// Marius Lumbroso 2016 , Pitch Analysis
    /// All rights reserved
    /// </summary>
    public class VocalyzAnalyser
    {
        public List<Note> m_Playing_Notes = new List<Note>();

        public delegate void OnDataArrived(FrequencyData[] frequencies);

        public AudioViewer Viewer = new AudioViewer();

        public event OnDataArrived RecordUpdated;

        public FrequencyData FundamentalFrequency { get; set; }

        public VocalyzAnalyser()
        {
            Viewer.OnDataArrived += Viewer_OnDataArrived;
        }

        void Viewer_OnDataArrived(FrequencyData[] frequencies)
        {
  
        


                m_Playing_Notes.Clear();

                FundamentalFrequency = frequencies.First();
                m_Playing_Notes.Add(NotesManager.GetNoteByFrequency(FundamentalFrequency.Frequency));
                if (m_Playing_Notes[0] != null)
                    Console.WriteLine(m_Playing_Notes[0].SymbolUS);


                if (RecordUpdated != null)
                    RecordUpdated(frequencies);
                Console.WriteLine(FundamentalFrequency.Frequency);
            
         
        }
        public void Start()
        {
            Viewer.StartAnalysis(0);
        }
        public void Stop()
        {
            Viewer.StopAnalysis();
        }


    }
}
