using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2k2semLabs_1
{
    public partial class Form1 : Form
    {
        internal const int countDats = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsLong(TextBox a)
        {
           
            if (a.Text.Length < countDats)
                return true;
            else return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text += text[i];
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 7;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(IsLong(textBox1))
            textBox1.Text += 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (string Standart, string Gender, float Siz) Dates = (null, null, 0);
     
            foreach (RadioButton rdbut in panel1.Controls)
                if (rdbut.Checked) Dates.Gender = rdbut.Text;

            if (Dates.Gender == null) { panel1.BackColor = ColorTranslator.FromHtml("#FFCBCD"); return; }
            else { panel1.BackColor = Color.LightGray; }

            foreach (RadioButton rdbut in panel2.Controls)
                if (rdbut.Checked) Dates.Standart = rdbut.Text;

            if (Dates.Standart == null) { panel2.BackColor = ColorTranslator.FromHtml("#FFCBCD"); return; }
            else { panel2.BackColor = Color.LightGray; }

            try
            {
                Dates.Siz = Convert.ToSingle(textBox1.Text);
                textBox1.BackColor = Color.White;
                label1.BackColor = Color.White;
               
            }
            catch (FormatException)
            {
                textBox1.BackColor = ColorTranslator.FromHtml("#FFCBCD");
                label1.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            textBox2.Text = Result(Dates);
           // MessageBox.Show($"{Dates.Gender}{Dates.Siz}{Dates.Standart}");
        }

        private string Result( (string Standart, string Gender, float Siz) Dates)
        {
            //мужское
            if(Dates.Gender == "Мужской размер")
            switch (Dates.Standart)
            {
                    case "BY":
                        if (Dates.Siz >= 24.5 && Dates.Siz < 25.5) return "40";
                        if (Dates.Siz >= 25.5 && Dates.Siz < 26.5) return "41";
                        if (Dates.Siz >= 26.5 && Dates.Siz < 27.5) return "42";
                        if (Dates.Siz >= 27.5 && Dates.Siz < 28) return "43";
                        if (Dates.Siz >= 28 && Dates.Siz < 28.5) return "44";
                        if (Dates.Siz >= 28.5 && Dates.Siz < 29.5) return "45";
                        if (Dates.Siz >= 29.5 && Dates.Siz < 30) return "46";
                        break; 
                    case "USA": 
                        if (Dates.Siz >= 24.5 && Dates.Siz < 25) return "7";
                        if (Dates.Siz >= 25 && Dates.Siz < 25.5) return "7,5";
                        if (Dates.Siz >= 25.5 && Dates.Siz < 26) return "8";
                        if (Dates.Siz >= 26 && Dates.Siz < 26.5) return "8,5";
                        if (Dates.Siz >= 26.5 && Dates.Siz < 27) return "9";
                        if (Dates.Siz >= 27 && Dates.Siz < 27.5) return "9,5";
                        if (Dates.Siz >= 27.5 && Dates.Siz < 28) return "10";
                        if (Dates.Siz >= 28 && Dates.Siz < 28.5) return "10,5";
                        if (Dates.Siz >= 28.5 && Dates.Siz < 29) return "11";
                        if (Dates.Siz >= 29 && Dates.Siz < 29.5) return "11.5";
                        if (Dates.Siz >= 29.5 && Dates.Siz < 30) return "12";
                        break;
                    case "EU":
                        if (Dates.Siz >= 24.5 && Dates.Siz < 25.5) return "40";
                        if (Dates.Siz >= 25.5 && Dates.Siz < 26.5) return "41";
                        if (Dates.Siz >= 26.5 && Dates.Siz < 27.5) return "42";
                        if (Dates.Siz >= 27.5 && Dates.Siz < 28) return "43";
                        if (Dates.Siz >= 28 && Dates.Siz < 28.5) return "44";
                        if (Dates.Siz >= 28.5 && Dates.Siz < 29.5) return "45";
                        if (Dates.Siz >= 29.5 && Dates.Siz < 30) return "46"; 
                        break; 
                    case "UK":
                        if (Dates.Siz >= 24.5 && Dates.Siz < 25.5) return "6";
                        if (Dates.Siz >= 25.5 && Dates.Siz < 26.5) return "7";
                        if (Dates.Siz >= 26.5 && Dates.Siz < 27.5) return "8";
                        if (Dates.Siz >= 27.5 && Dates.Siz < 28) return "9";
                        if (Dates.Siz >= 28 && Dates.Siz < 28.5) return "10";
                        if (Dates.Siz >= 28.5 && Dates.Siz < 29.5) return "11";
                        if (Dates.Siz >= 29.5 && Dates.Siz < 30) return "12";
                        break; 

                default: break;
            }

            if (Dates.Gender == "Женский размер")
                switch (Dates.Standart)
                {
                    case "BY":
                        if (Dates.Siz >= 22.5 && Dates.Siz < 23) return "36";
                        if (Dates.Siz >= 23 && Dates.Siz < 23.5) return "37";
                        if (Dates.Siz >= 23.5 && Dates.Siz < 24.3) return "38";
                        if (Dates.Siz >= 24.3 && Dates.Siz < 24.7) return "39";
                        if (Dates.Siz >= 24.7 && Dates.Siz < 25.5) return "40";
                     
                        break;
                    case "USA":
                        if (Dates.Siz >= 22.5 && Dates.Siz < 23) return "5";
                        if (Dates.Siz >= 23 && Dates.Siz < 23.5) return "6";
                        if (Dates.Siz >= 23.5 && Dates.Siz < 24.3) return "7";
                        if (Dates.Siz >= 24.3 && Dates.Siz < 24.7) return "8";
                        if (Dates.Siz >= 24.7 && Dates.Siz < 25.5) return "9";
                        break;
                    case "EU":
                        if (Dates.Siz >= 22.5 && Dates.Siz < 23) return "36";
                        if (Dates.Siz >= 23 && Dates.Siz < 23.5) return "37";
                        if (Dates.Siz >= 23.5 && Dates.Siz < 24.3) return "38";
                        if (Dates.Siz >= 24.3 && Dates.Siz < 24.7) return "39";
                        if (Dates.Siz >= 24.7 && Dates.Siz < 25.5) return "40";
                        break;
                    case "UK":
                        if (Dates.Siz >= 22.5 && Dates.Siz < 23) return "4";
                        if (Dates.Siz >= 23 && Dates.Siz < 23.5) return "4,5";
                        if (Dates.Siz >= 23.5 && Dates.Siz < 24.3) return "5";
                        if (Dates.Siz >= 24.3 && Dates.Siz < 24.7) return "5,5";
                        if (Dates.Siz >= 24.7 && Dates.Siz < 25.5) return "6";
                        break;

                    default: break;
                }
            //женское

            return "Не найдено";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 4;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 9;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1) & textBox1.Text.Length!= countDats-1 & textBox1.Text.IndexOf(',')==-1 & textBox1.Text.Length!=0)
                textBox1.Text += ',';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsLong(textBox1))
                textBox1.Text += 3;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
