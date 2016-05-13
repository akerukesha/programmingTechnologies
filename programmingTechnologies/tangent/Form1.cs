using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tangent
{
    public partial class Form1 : Form
    {
        //Bitmap bmp;
        Timer t = new Timer();
        //Graphics g;

        List<PointF> arr = new List<PointF>();

        Pen pen = new Pen(Color.Red);
        public static int x = -89;
        public static double y;
        public static float px, py;

        public Form1()
        {
            InitializeComponent();
            //bmp = new Bitmap(200, 200);
            y = Math.Tan(x * (3.14159265359 / 180));
            px = (float)x + 50;
            py = -(float)y * 100 + 200;
            arr.Add(new PointF(px, py));
            arr.Add(new PointF(px, py));
            t.Tick += T_Tick;
            t.Interval = 100;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            x++;
            if ((x % 90 == 0) && (x % 180 != 0))
            {
                arr = new List<PointF>();
                x++;
                y = Math.Tan(x * (3.14159265359 / 180));
                px = (float)x + 50;
                py = -(float)y * 100 + 200;
                arr.Add(new PointF(px, py));
                arr.Add(new PointF(px, py));
                x++;
            }
            y = Math.Tan(x * (3.14159265359/180));
            px = (float)x + 50;
            py = -(float)y * 100 + 200;
            arr.Add(new PointF(px, py));
            if (x <= 540)
            {
                this.Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 20, 50, 400);
            e.Graphics.DrawLine(new Pen(Color.Black), 0, 200, 650, 200);
            e.Graphics.DrawLine(new Pen(Color.Black), 650, 200, 645, 195);
            e.Graphics.DrawLine(new Pen(Color.Black), 650, 200, 645, 205);
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 20, 55, 25);
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 20, 45, 25);
            DrawWithCurve(e);
            using (Font font1 = new Font("Times New Roman", 9, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                for (int i = 0; i < 4; i++)
                {
                    PointF pointF1 = new PointF(50 + 180 * i, 200);
                    string s = "";
                    if (i == 0)
                    {
                        s = 0 + "";
                    }
                    else if (i == 1)
                    {
                        s = "π";
                    }
                    else
                    {
                        s = i + "π";
                    }
                    e.Graphics.DrawString(s, font1, Brushes.Black, pointF1);
                }
                e.Graphics.DrawString("X", font1, Brushes.Black, 650, 200);
                e.Graphics.DrawString("Y", font1, Brushes.Black, 40, 25);
                e.Graphics.DrawString("1", font1, Brushes.Black, 40, 300);
                e.Graphics.DrawString("-1", font1, Brushes.Black, 40, 100);
            }
        }

        private void DrawWithCurve(PaintEventArgs e)
        {
            e.Graphics.DrawCurve(pen, arr.ToArray());
        }
    }
}
