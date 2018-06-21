using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ControlsCollections
{
    public partial class IRI2CView : UserControl
    {
        GDIIR m_irView;
        List<float> m_temp = new List<float>();
        Random rnd = new Random();
        public IRI2CView()
        {
            InitializeComponent();
            
            
            m_irView = new GDIIR(80);
            m_irView.SetPanel(panel1);
            timer1.Interval = 500;
            timer1.Enabled = true;
            for (int i = 0 ; i < 64 ; i++)
            {
                m_temp.Add((float)(rnd.NextDouble() * 100));
            }
        }
         

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0 ; i < 64 ; i++)
            {
                m_temp[i] = (float)(rnd.NextDouble() * 100);
            }
            m_irView.SetTemeratures(m_temp);
            m_irView.Draw();
            
        }
        public void ResizeControl()
        {
            m_irView.Draw();
        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            m_irView.Draw();
        }        
    }
}
