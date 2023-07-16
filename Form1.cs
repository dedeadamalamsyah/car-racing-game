using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace pertemuan3_desktop
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            over.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            line(kecepatan);
            musuh(kecepatan);
            coins(kecepatan);
            gameover();
            scores();
            restart();
        }

        Random r = new Random();
        int x;
        void musuh(int speed)
        {
            if (musuh1.Top >= 700)
            {
                x = r.Next(0, 400);
                musuh1.Location = new Point(x, 0);
            }
            else
            {
                musuh1.Top += speed;
            }

            if (musuh2.Top >= 700)
            {
                x = r.Next(0, 400);
                musuh2.Location = new Point(x, 0);
            }
            else
            {
                musuh2.Top += speed;
            }

            if (musuh3.Top >= 700)
            {
                x = r.Next(0, 400);
                musuh3.Location = new Point(x, 0);
            }
            else
            {
                musuh3.Top += speed;
            }
        }

        void coins(int speed)
        {
            if (gold.Top >= 700)
            {
                x = r.Next(0, 400);
                gold.Location = new Point(x, 0);
            }
            else
            {
                gold.Top += speed;
            }

            if (silver.Top >= 700)
            {
                x = r.Next(0, 400);
                silver.Location = new Point(x, 0);
            }
            else
            {
                silver.Top += speed;
            }

            if (bronze.Top >= 700)
            {
                x = r.Next(0, 400);
                bronze.Location = new Point(x, 0);
            }
            else
            {
                bronze.Top += speed;
            }
        }

        void gameover()
        {
            if (adx.Bounds.IntersectsWith(musuh1.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (adx.Bounds.IntersectsWith(musuh2.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (adx.Bounds.IntersectsWith(musuh3.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
        }

        int score = 0;
        void scores()
        {
            if (adx.Bounds.IntersectsWith(gold.Bounds))
            {
                score += 35;

                x = r.Next(0, 400);
                gold.Location = new Point(x, 0);
            }
            if (adx.Bounds.IntersectsWith(silver.Bounds))
            {
                score += 20;

                x = r.Next(0, 400);
                silver.Location = new Point(x, 0);
            }
            if (adx.Bounds.IntersectsWith(bronze.Bounds))
            {
                score += 10;

                x = r.Next(0, 400);
                bronze.Location = new Point(x, 0);
            }
            label1.Text = "Score: " + score.ToString();
        }



        void line(int speed)
        {
            if (pictureBox1.Top >= 700)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= 700)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 700)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }

            if (pictureBox4.Top >= 700)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }
        }

        int kecepatan = 5;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (adx.Left > 0)
                    adx.Left -= kecepatan;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (adx.Right < 480)
                    adx.Left += kecepatan;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (kecepatan < 20)
                {
                    kecepatan++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (kecepatan > 0)
                {
                    kecepatan--;
                }
            }

        }

        void restart()
        {
            if(over.Visible)
            {
                button1.Visible = true;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
