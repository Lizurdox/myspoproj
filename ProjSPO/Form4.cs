using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjSPO
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                double temp1,temp2;
                temp1 = (double)performanceCounter1.NextValue();
                temp2 = (double)performanceCounter2.NextValue();
            if(temp1 > 100)
                temp1=100;
            if(temp2 >100)  
                temp2=100;
            label1.Text = "Загрузка ЦП  " + ((int)temp1).ToString() + " %";
            label2.Text = "Загрузка ОП  " + ((int)temp2).ToString() + " %";
            }
            catch (Exception) 
            {
                label1.Text = "Error !";
                label2.Text = "Error !";
            };
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Size.Width, Screen.PrimaryScreen.Bounds.Height - this.Size.Height-30);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Enabled = false;
            this.Hide();
            this.Text = "Hidden";
        }
    }
}
