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
    public abstract class IGDI
    {
        protected Brush lBrush;
        protected Panel m_panel;
        protected Graphics g;
        protected Rectangle rect;
               
        public IGDI()
        {
            
        }
        
        public IGDI(float x , float y)
        {

        }
        public IGDI(int x, int y, int width, int height)             
        {
            
        }
        public IGDI(int size)
        {

        }
        void Init()
        {
            g = m_panel.CreateGraphics();
        }   
        public virtual void SetPanel(Panel panel)
        {
            m_panel = panel;
            Init();
        }
        protected void Brush(Color a, Color b, LinearGradientMode mode = LinearGradientMode.BackwardDiagonal)
        {
            lBrush = new LinearGradientBrush(rect, a, b, mode);
        }

        public void Brush(Color a)
        {
            lBrush = new SolidBrush(a);
        }
        public virtual void Draw()
        {

        }
        public virtual void Draw(string text)
        {

        }
        public virtual void  Draw(float x , float y, string text)
        {

        }

    }
}
