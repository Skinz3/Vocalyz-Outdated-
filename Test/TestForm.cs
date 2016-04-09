using PianoTabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vocalyz;

namespace Test
{
    public partial class TestForm : Form
    {
        VocalyzAnalyser analyser = new VocalyzAnalyser();

       

        public TestForm()
        {
            InitializeComponent();
           analyser.RecordUpdated += analyser_RecordUpdated;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            analyser.Start();
           
        }

        void analyser_RecordUpdated(FlowView.Audio.FrequencyProvider.FrequencyData[] frequencies)
        {
            //lock (this)
            //piano1.UnFillNotes();

            //if (analyser.m_Playing_Notes[0] != null)
            //{
            //    piano1.FillNote((NoteEnum)Enum.Parse(typeof(NoteEnum),analyser.m_Playing_Notes[0].SymbolUS), Brushes.Blue);
            //}
            
        }

        private void piano1_Load(object sender, EventArgs e)
        {

        }

     
    }
}
