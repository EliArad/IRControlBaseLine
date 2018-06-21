using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsCollections
{
    public class GDIText : IGDI
    {
        Font drawFont;

        float x;
        float y;

        public GDIText()
        {
            drawFont = new System.Drawing.Font("Arial", 16);
        }

        public GDIText(float x , float y) : base(x , y)
        {
            drawFont = new System.Drawing.Font("Arial", 16);
            this.x = x;
            this.y = y;
        }

        public override void Draw(float x , float y, string text)
        {
 
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(text, drawFont, lBrush, x, y, drawFormat);

        }

        public override void Draw(string text)
        {

            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(text, drawFont, lBrush, x, y, drawFormat);

        }
    }
}
