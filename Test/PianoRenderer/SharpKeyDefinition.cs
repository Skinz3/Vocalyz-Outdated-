using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoTabs.PianoGraphics
{
    public class SharpKeyDefinition
    {
        BasicPianoKey Betwenn1 { get; set; }
        BasicPianoKey Betwenn2 { get; set; }
        public SharpKeyDefinition(BasicPianoKey betwenn1,BasicPianoKey betwenn2)
        {
            this.Betwenn1 = betwenn1;
            this.Betwenn2 = betwenn2;
        }
        public SharpNoteEnum GetSharpNoteEnum()
        {
            return (SharpNoteEnum)Enum.Parse(typeof(SharpNoteEnum), Betwenn1.Note + "Sharp");
        }
        public SharpPianoKey GetSharpNote()
        {
            return new SharpPianoKey(new Rectangle(Betwenn1.Rectangle.X + Betwenn1.Rectangle.Width - 40 / 2, 0,PianoKey.SharpKeyWidth,PianoKey.SharpKeyHeight),GetSharpNoteEnum(),Betwenn1.Octave);
        }
       
        
    }
}
