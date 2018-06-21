using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsCollections
{
    public class GDIIR : GDIRectangle
    {
        List<GDIRectangle> myRect = new List<GDIRectangle>();
        Random rnd = new Random();

        struct RGB
        {
            public byte R;
            public byte G;
            public byte B;
        }

        RGB[] m_jetMap = new RGB[256];

        List<GDIText> m_text = new List<GDIText>();
        List<float> m_temperatures = new List<float>();
        
        int m_rectSize = 100;
        public GDIIR(int x, int y, int width, int height)
            : base(x, y, width, height)
        {

            InitializeColotMap();
        }
        public GDIIR(int size) : base(size)
        {
            m_rectSize = size;
            InitializeColotMap();
        }
        public override void SetPanel(Panel panel) 
        {
            base.SetPanel(panel);
            Create();
        }
        void InitializeColotMap()
        {

            string line;
            using (StreamReader sr = new StreamReader("jet_colormap"))
            {
                for (int i = 0; i < 256; i++)
                {
                    line = sr.ReadLine();
                    string[] sdata = line.Split(new Char[] { ' ' });
                    m_jetMap[i].R = byte.Parse(sdata[0]);
                    m_jetMap[i].G = byte.Parse(sdata[1]);
                    m_jetMap[i].B = byte.Parse(sdata[2]);
                }
            }
        }

        Color GetColorFromMap(float temperature)
        {
            int index = (int)(Math.Floor(255 * (temperature / 100)));
            Color c = Color.FromArgb(255, m_jetMap[index].R, m_jetMap[index].G, m_jetMap[index].B);
            return c;
        }

        void Create()
        {

            m_panel.Width = m_rectSize * 8;
            m_panel.Height = m_rectSize * 8;
            int k = 0;
            for (int j = 0; j < 8; j++)
            for (int i = 0; i < 8; i++)
            {
                GDIRectangle r = new GDIRectangle(i * m_rectSize, j * m_rectSize, m_rectSize, m_rectSize);
                GDIText text = new GDIText(i * m_rectSize, j * m_rectSize);
                m_text.Add(text);
                r.SetPanel(m_panel);
                text.SetPanel(m_panel);
                m_temperatures.Add(0f);
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));                
                r.Brush(randomColor);
                text.Brush(Color.Black);
                myRect.Add(r);                
            }
        }
        public void SetTemeratures(List<float> t)
        {
            m_temperatures = t;
        }
        public override void Draw()
        {
            int i = 0;
            foreach (GDIRectangle r in myRect)
            {
                r.Brush(GetColorFromMap(m_temperatures[i++]));
                r.Draw();
            }
            i = 0;
            foreach (GDIText r in m_text)
            {                
                r.Draw(m_temperatures[i++].ToString("0.0"));
            }
        }
    }
}
