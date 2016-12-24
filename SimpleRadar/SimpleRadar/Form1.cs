using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRadar
{
    public partial class Form1 : Form
    {
        Timer T = new Timer();
        int HEIGHT = 300;
        int WIDTH = 300;
        int HAND = 150;
        int u;   //In degree
        int cx, cy; //Center of the circle
        int x, y; //Hands Cordanate
        int tx, ty, lim = 20;
        Bitmap bmp;
        Pen p;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Create Bitmap
            bmp = new Bitmap(HEIGHT + 1, WIDTH + 1);
            //background color
            this.BackColor = Color.Black;
            //center
            cx = WIDTH / 2;
            cy = HEIGHT / 2;
            //Initial degree of hand
            u = 0;
            //timer
            T.Interval = 1; //in Milisecond
            T.Tick += new EventHandler(this.T_TICK);
            T.Start();
        }

        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }
        private void T_TICK(object sender,EventArgs e)
        {
            //pen
            p = new Pen(Color.Green, 1f);
            //graphics
            g = Graphics.FromImage(bmp);

            int tu = (u - lim) % 360;
            if(u>=0&&u<=180)
            {
                x = cx + (int)(HAND * Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }
            else
            {
                x = cx - (int)(HAND * -Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }

            if (tu >= 0 && tu <= 180)
            {
                tx = cx + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }
            else
            {
                tx = cx - (int)(HAND * -Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }

            //Draw circle
            g.DrawEllipse(p, 0, 0, WIDTH, HEIGHT);
            g.DrawEllipse(p, 80, 80, WIDTH - 160, HEIGHT - 160);

            g.DrawLine(p, new Point(cx, 0), new Point(cx, HEIGHT));
            g.DrawLine(p, new Point(0, cy), new Point(WIDTH, cy));

            g.DrawLine(new Pen(Color.Black, 1f), new Point(cx, cy), new Point(tx, ty));
            g.DrawLine(p, new Point(cx, cy), new Point(x, y));

            pictureBox1.Image = bmp;
            p.Dispose();
            g.Dispose();
            u++;
            if(u==360)
            {
                u = 0;
            }
        }
    }
}
