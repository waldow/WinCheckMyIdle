using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCheckMyIdle
{
    public partial class Form1 : Form
    {
        int _breakCount = 0;
        bool _Onbreak = false;
        int _minWorking = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDisableSS_Click(object sender, EventArgs e)
        {
            PowerHelper.ForceSystemAwake();
        }

        private void buttonEnableSS_Click(object sender, EventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var ticks = IdleTimeFinder.GetLastInputTime();
            TimeSpan timespent = TimeSpan.FromMilliseconds(ticks);
            //listBox1.Items.Add(timespent.ToString());


            //listBox1.Items.Add(IdleTimeFinder.IdleTime());

            TimeSpan timespent1 = TimeSpan.FromSeconds(IdleTimeFinder.IdleTime());
            textBox1.Text = timespent1.ToString();


            if (!_Onbreak && timespent1.TotalMinutes > (double)numericUpDown1.Value)
            {
                _breakCount++;
                _Onbreak = true;
                textBox3.Text = "Yes";
                _minWorking = 0;

            }
            if (timespent1.TotalMinutes > (double)numericUpDown1.Value)
            {
                if (checkBoxMoveMouse.Checked)
                {
                    MouseHelper.MoveMouse();
                    textBox3.Text = "Mouse moved";
                }
            }

            if (timespent1.TotalMinutes < (double)numericUpDown1.Value)
            {
                _Onbreak = false;
                textBox3.Text = "No";
            }

            textBox2.Text = _breakCount.ToString();
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void checkBoxMoveMouse_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
