using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoTabs.PianoGraphics
{
    public class SharpPianoKey : PianoKey
    {
        public SharpNoteEnum SharpNote { get; set; }
        public SharpPianoKey(Rectangle rectangle,SharpNoteEnum snote,short octave):base(rectangle,octave)
        {
            this.SharpNote = snote;
            this.FillColor = Brushes.Black;
            this.BaseFillColor = FillColor;
        }
        public override void Draw(Graphics g,Pen pen)
        {
            g.FillRectangle(FillColor, Rectangle);
            g.DrawRectangle(pen, Rectangle);
        }
        public override string GetNoteAsString()
        {
            return SharpNote.ToString();
        }
    }
}
