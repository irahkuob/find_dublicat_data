using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace data_base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int debut=8;
        int fin=10;
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "SELECT A TXT FILE";
            opf.Filter = "TXT files|*.txt";
           
            if (opf.ShowDialog() == DialogResult.OK) {
                textBox1.Text = opf.FileName.ToString();
                // StreamReader sr = new StreamReader(fline);
                // line = sr.ReadLine();
                
            }
        }
        public void calculate(string path, string echan, StreamWriter myStream)
        {string fline=path, line;
             StreamReader sr = new StreamReader(fline);
            bool trouv = true;int i = 0;
           // StreamWriter myStream = new StreamWriter(dir,true) ;
            while (((line = sr.ReadLine()) != null)&&(trouv))
            {if (progressBar1.Value == 100) i = 0;i++;
                progressBar1.Value = i;
                if (echan == line.Substring(debut, fin))
                {
                    
                    myStream.WriteLine(line);
                    trouv = false;
                    //MessageBox.Show(echan + "||"+line.Substring(debut, fin));
                }
            }sr.Close();
            

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "SELECT A TXT FILE";
            opf.Filter = "TXT files|*.txt";
            
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = opf.FileName.ToString();
                


            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text) && File.Exists(textBox2.Text))
            {
                // timer1.Start();
               
                string path = textBox1.Text, line;
                StreamReader sr_base = new StreamReader(textBox1.Text);
                StreamReader sr_echa = new StreamReader(textBox2.Text);
                string dir = Path.GetDirectoryName(path) + @"\result.txt";
                File.Delete(dir);
                StreamWriter myStream = new StreamWriter(File.Open(dir, System.IO.FileMode.Append));
                while ((line = sr_echa.ReadLine()) != null)
                {
                    
                    calculate(textBox1.Text, line.Substring(debut, fin), myStream);
                    
                 
                }
                myStream.Close();
                MessageBox.Show("Succée");
                Process.Start("notepad.exe",dir);
              //  timer1.Stop();
            } else MessageBox.Show("One of the Tow files Dosen't Exxist !!!","Error !!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (Path.IsPathRooted(textBox2.Text)) { start_b.Enabled = true; }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (Path.IsPathRooted(textBox1.Text)) { start_b.Enabled = true; }
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            debut = 8;
            fin = 10;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            debut = 0;
            fin = 20;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100) progressBar1.Value = 0;
            progressBar1.Increment(1);
        }
    }
}
