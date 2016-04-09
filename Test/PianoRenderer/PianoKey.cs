using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoTabs.PianoGraphics
{
    public abstract class PianoKey
    {
        public int Id { get; set; }

        public const int BasicKeyWidth = 65;

        public const int BasicKeyHeight = 318;

        public const int SharpKeyWidth = 40;

        public const int SharpKeyHeight = 159;

        public Rectangle Rectangle = new Rectangle();

        public Brush FillColor { get; set; }

        public Brush BaseFillColor { get; set; }

        public short Octave { get; set; }

        public PianoKey(Rectangle rectangle,short octave)
        {
            this.Rectangle = rectangle;
            this.Octave = octave;
        }
        public void Unfill(Piano piano)
        {
            this.Fill(BaseFillColor,piano);
        }
        public static PianoKey FromPiano(int id,Piano piano)
        {
           return piano.Keys.Find(x => x.Id == id);
        }
        public void Fill(Brush brush,Piano piano)
        {
            var g = piano.CreateGraphics();
            FillColor = brush;
            if (GetNoteAsString().Contains("Sharp"))
            {
                Draw(g, Piano.Pen);
                return;
            }
            else
            {
                var notes = piano.Keys.FindAll(x => x.GetNoteAsString() == GetNoteAsString() + "Sharp");
  
                Draw(g, Piano.Pen);
                notes.ForEach(x => x.Draw(g, Piano.Pen));
                var a = GetNoteAsString();
                if (GetNoteAsString()== "A")
                {
                    var tep = piano.Keys.FindAll(x => x.GetNoteAsString() == "GSharp");
                    tep.ForEach(x => x.Draw(g, Piano.Pen));
                }
                if (GetNoteAsString() == "G")
                {
                    var tep = piano.Keys.FindAll(x => x.GetNoteAsString() == "FSharp");
                    tep.ForEach(x => x.Draw(g, Piano.Pen));
                }
                if (GetNoteAsString() == "D")
                {
                    var tep = piano.Keys.FindAll(x => x.GetNoteAsString() == "CSharp");
                    tep.ForEach(x => x.Draw(g, Piano.Pen));
                }
                if (GetNoteAsString() == "E")
                {
                    var tep = piano.Keys.FindAll(x => x.GetNoteAsString() == "DSharp");
                    tep.ForEach(x => x.Draw(g, Piano.Pen));
                }
                if (GetNoteAsString() == "B")
                {
                    var tep = piano.Keys.FindAll(x => x.GetNoteAsString() == "ASharp");
                    tep.ForEach(x => x.Draw(g, Piano.Pen));
                }

            }
        }
        public abstract void Draw(Graphics g, Pen pen);
        public void DrawOctave(Graphics g)
        {
            g.DrawString("Otv:" + Octave, Piano.DefaultFont, Brushes.Blue, new PointF(Rectangle.X,Rectangle.Height-30));
        }
        public abstract string GetNoteAsString();
        

    }
}
