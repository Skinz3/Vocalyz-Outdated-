using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoTabs.PianoGraphics
{
    public class BasicPianoKey : PianoKey
    {
        public NoteEnum Note { get; set; }
        public BasicPianoKey(NoteEnum note, Rectangle rectangle,short octave)
            : base(rectangle,octave)
        {
            this.Note = note;
            this.FillColor = Brushes.White;
            this.BaseFillColor = FillColor;
        }
        public override void Draw(Graphics g, Pen pen)
        {
            g.FillRectangle(FillColor, Rectangle);
            g.DrawRectangle(pen, Rectangle);
        }
        public override string GetNoteAsString()
        {
            return Note.ToString();
        }
    }
}
