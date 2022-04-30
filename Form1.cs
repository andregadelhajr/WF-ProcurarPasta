using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace Aula30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pastaEscolhida = new FolderBrowserDialog();
            //
            pastaEscolhida.ShowNewFolderButton = true;

            DialogResult result = pastaEscolhida.ShowDialog();
            if(result == DialogResult.OK)
            {
                textBox1.Text = pastaEscolhida.SelectedPath;
                Environment.SpecialFolder root = pastaEscolhida.RootFolder;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            string pathText = textBox1.Text;
            DirectoryInfo directory = new DirectoryInfo($@"{ pathText }");
            FileInfo[] arquivos = directory.GetFiles("*");
            foreach (FileInfo file in arquivos)
            {
                listBox1.Items.Add(file);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathText = textBox1.Text;
            pictureBox1.Image = Image.FromFile($@"{pathText}\" + listBox1.Text);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
