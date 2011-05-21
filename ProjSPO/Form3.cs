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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1.SinCalculator Test = new Form1.SinCalculator(2000);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int u = 0; u < 500; u++)
            {
                label1.Text = sw.ToString();
                Random rand = new Random();
                int[] mas1 = new int[1000];
                double[] mas2 = new double[1000];
                for (int i = 0; i < 1000; i++)
                {
                    mas1[i] = rand.Next();
                    mas2[i] = rand.NextDouble();
                }

                for (int i = mas1.Length - 1; i > 0; i--)
                    for (int j = 0; j < i; j++)
                        if (mas1[j] > mas1[j + 1])
                        {
                            double t = mas2[i];
                            mas2[i] = mas2[mas2.Length - i];
                            mas2[mas2.Length - i] = t;
                            int tmp = mas1[j];
                            mas1[j] = mas1[j + 1];
                            mas1[j + 1] = tmp;
                        }
                ///////////////

                for (int i = 0; i < 200; i++)
                    Test.Sin(20).ToString(); 
            }
            sw.Stop();
            TimeSpan ts;
            ts = sw.Elapsed;
            label1.Text = "Ваш компьютер справился с этим за " + ts.Seconds.ToString() +"." + ts.Milliseconds.ToString() + " секунд. Нелохо.";
            label2.Text = "Более точный результат: " + ts.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
