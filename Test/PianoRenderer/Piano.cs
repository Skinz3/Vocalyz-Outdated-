using PianoTabs.PianoGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoTabs
{
    public class Piano : UserControl
    {
        public List<PianoKey> UsedKeys = new List<PianoKey>();                                                                                                                                                                                                                                                                                                                
        public List<PianoKey> Keys = new List<PianoKey>();
        public List<SharpKeyDefinition> SharpDefinitions = new List<SharpKeyDefinition>();
        public const int OctaveKeysCount = 7;
        public static Pen Pen = new Pen(Color.Black, 2);
        Graphics G { get { return CreateGraphics(); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            Size = new Size(914, 324);
            DrawPiano();
            base.OnPaint(e);
        }
        public Piano()
        {
            BuildPiano();
          
        }
        public void DrawPiano()
        {
            Keys.ForEach(x =>x.Draw(G,Pen));
        }  
        protected void DefineSharps()
        {
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[0], (BasicPianoKey)Keys[1]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[1], (BasicPianoKey)Keys[2]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[3], (BasicPianoKey)Keys[4]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[4], (BasicPianoKey)Keys[5]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[5], (BasicPianoKey)Keys[6]));


            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[7], (BasicPianoKey)Keys[8]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[8], (BasicPianoKey)Keys[9]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[10], (BasicPianoKey)Keys[11]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[11], (BasicPianoKey)Keys[12]));
            SharpDefinitions.Add(new SharpKeyDefinition((BasicPianoKey)Keys[12], (BasicPianoKey)Keys[13]));
        }
        public PianoKey GetKey(NoteEnum note,short octave)
        {
            return Keys.Find(x => x.GetNoteAsString() == note.ToString() && x.Octave == octave);
        }
        public PianoKey GetKey(SharpNoteEnum note,short octave)
        {
            return Keys.Find(x => x.GetNoteAsString() == note.ToString() && x.Octave == octave);
        }
        public PianoKey[] GetNotes(NoteEnum note)
        {
            return Keys.FindAll(x => x.GetNoteAsString() == note.ToString()).ToArray();
        }
        public void UnFillNotes()
        {
            Keys.ForEach(x => x.Unfill(this));
        }
        public PianoKey[] GetNotes(SharpNoteEnum note)
        {
            return Keys.FindAll(x => x.GetNoteAsString() == note.ToString()).ToArray();
        }
        public PianoKey GetKey(Point pos)
        {
            var potential =  Keys.FindAll(x => x.Rectangle.Contains(new Rectangle(pos.X, pos.Y, 5,5)));
            if (potential.Count == 1)
                return potential[0];
            else
                return potential.Find(x=>x is SharpPianoKey);
           

        }
        public void FillNote(SharpNoteEnum note,Brush brush)
        {
            var notes = Keys.FindAll(x => x.GetNoteAsString() == note.ToString());
            notes.ForEach(x=>x.Fill(brush,this));
        }
        public void FillNote(NoteEnum note, Brush brush)
        {
            var notes = Keys.FindAll(x => x.GetNoteAsString() == note.ToString());
            notes.ForEach(x => x.Fill(brush, this));
        }
        protected void BuildPiano()
        {
                var notes = (NoteEnum[])Enum.GetValues(typeof(NoteEnum));
                var sharpNotes = new NoteEnum[] { NoteEnum.C, NoteEnum.D, NoteEnum.F, NoteEnum.G, NoteEnum.A };
                int maxX = (OctaveKeysCount * PianoKey.BasicKeyWidth);
                int maxY = PianoKey.BasicKeyHeight;
                int id = 0;
                short octave = 1;
                int i = 0;
                for (int y = 0; y < maxY; y += PianoKey.BasicKeyHeight)
                {
                    for (int x = 0; x < maxX*2; x += PianoKey.BasicKeyWidth)
                    {
                        
                        Keys.Add(new BasicPianoKey(notes[i], new Rectangle(x, y, PianoKey.BasicKeyWidth, PianoKey.BasicKeyHeight),octave));
                        i++;
                        id++;
                        if (id == 7)
                        {
                            octave++;
                        }
                        if (i == 7)
                            i = 0;
                    }
                   
                }
                DefineSharps();
                
                SharpDefinitions.ForEach(x => Keys.Add(x.GetSharpNote()));
                Keys.ForEach(x => x.Id = Keys.IndexOf(x));
        } 
    }
    
   
}
