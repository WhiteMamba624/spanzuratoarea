using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spanzuratoarea
{
    public partial class Form1 : Form
    {
        private string cuvantDeGhicit;
        private string litereDeAles;
        private string litereAlese;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 6;
            List <string >cuvinte= PuzzlewordsDAO.findAll();
            Random rand = new Random();
            int index = rand.Next(cuvinte.Count);
            string cuvantAscuns = "";
            for(int i=0;i<cuvinte[index].Length;i++)
            {
                if (cuvinte[index][i] == ' ')
                {
                    cuvantAscuns +="  ";
                }
                else
                    cuvantAscuns += " _";
            }
            textBox1.Text = cuvantAscuns;
            cuvantDeGhicit = cuvinte[index];
            litereDeAles="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            litereAlese = "";
            comboBox1.Items.Clear();
            for(int i=0;i<litereDeAles.Length;i++)
            {
                comboBox1.Items.Add(litereDeAles[i]);
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            char caracter = comboBox1.SelectedItem.ToString()[0];
            litereAlese += caracter;
            litereDeAles=litereDeAles.Replace("" + caracter, "");
            comboBox1.Items.Clear();
            for (int i = 0; i < litereDeAles.Length; i++)
            {
                comboBox1.Items.Add(litereDeAles[i]);
            }
            string cuvantAscuns = "";
            for (int i = 0; i < cuvantDeGhicit.Length; i++)
            {
                if (cuvantDeGhicit[i] == ' ')
                {
                    cuvantAscuns += "  ";
                }
                else
                    if (litereAlese.IndexOf(cuvantDeGhicit[i].ToString().ToUpper()) != -1)
                {
                    cuvantAscuns += " " + cuvantDeGhicit[i];

                }
                else
                    cuvantAscuns += " _";
            }
            textBox1.Text = cuvantAscuns;
            if(cuvantDeGhicit.ToUpper().IndexOf(caracter)==-1)
            {
                progressBar1.Value--;
            }
            if(progressBar1.Value==0)
            {
                MessageBox.Show("Ai pierdut");
                Form1_Load(this,null);
            }
            if(cuvantAscuns.IndexOf('_')==-1)
            {
                MessageBox.Show("Ai castigat");
                Form1_Load(this, null);
            }

        }
    }
}
