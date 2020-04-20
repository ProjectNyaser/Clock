using System;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ShowMezu = true;
        int HeightMinimun = 2333;
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer
            {
                Interval = 1,
                Enabled = true
            };
            string Date;
            string Time;
            string Millisecond;
            string TextTemp;
            timer.Tick += (object a, EventArgs b) =>
              {
                  Date = DateTime.Now.Date.ToString();
                  Date = Date.Substring(0, Date.Length - 8);
                  Time = DateTime.Now.ToString().Substring(Date.Length + 1);
                  Millisecond = DateTime.Now.Millisecond.ToString();
                  Millisecond = "000".Substring(0, 3 - Millisecond.Length) + Millisecond;
                  TextTemp = $"Clock:";
                  if (checkBox4.Checked)
                  {
                      if (checkBox2.Checked)
                      {
                          TextTemp += $" {Time}";
                          if (checkBox3.Checked)
                          {
                              TextTemp += $".{Millisecond}";
                          }
                      }
                      if (checkBox1.Checked)
                      {
                          TextTemp += $" {Date}";
                      }
                  }
                  else
                  {
                      if (checkBox1.Checked)
                      {
                          TextTemp += $" {Date}";
                      }
                      if (checkBox2.Checked)
                      {
                          TextTemp += $" {Time}";
                          if (checkBox3.Checked)
                          {
                              TextTemp += $".{Millisecond}";
                          }
                      }
                  }
                  Text = TextTemp;
              };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMezu = false;
            Opacity = (double)trackBar1.Value / 100;
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            checkBox4.Hide();
            checkBox5.Hide();
            trackBar1.Hide();
            button1.Hide();
            Height = 0;
            HeightMinimun = Height;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!ShowMezu && Height > HeightMinimun)
            {
                ShowMezu = true;
                Opacity = 1;
                checkBox1.Show();
                checkBox2.Show();
                checkBox3.Show();
                checkBox4.Show();
                checkBox5.Show();
                trackBar1.Show();
                button1.Show();
                Height = 0;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ShowInTaskbar = checkBox5.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Opacity = (double)trackBar1.Value / 100;
        }
    }
}
