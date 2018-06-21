using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsCollections
{
    public class GDIRectangle : IGDI
    {
       
        public GDIRectangle(int x, int y, int width, int height) : base(x, y, width, height)
        {
             rect = new Rectangle(x, y, width, height);
        }
               
        public GDIRectangle(int size) : base(size)
        {

        }

        public override void Draw()
        {
            g.FillRectangle(lBrush, rect);
        }
        
    }
}
