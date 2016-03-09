using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.BackColor = Color.White;
            //textBox2.ForeColor = Color.Gray;
            textBox2.BackColor = Color.White;
            textBox1.Text = Form1.backgroundColor;
            textBox3.Text = Form1.foreColor;
            textBox6.Text = Form1.backgroundColorCheck;
            textBox8.Text = Form1.foreColorCheck;
            textBox2.Text = "#";
            textBox4.Text = "#";
            textBox5.Text = "#";
            textBox7.Text = "#";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = "";
            textBox1.ForeColor = Color.Black;
            Form1.backgroundColor = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // textBox1.Text = "";
            textBox2.ForeColor = Color.Black;
            Form1.backgroundColor = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // textBox4.Text = "";
            
            Form1.foreColor = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           // textBox3.Text = "";
            Form1.foreColor = textBox4.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // textBox5.Text = "";
            
            Form1.backgroundColorCheck = textBox6.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Form1.backgroundColorCheck = textBox5.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Form1.foreColorCheck = textBox8.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Form1.foreColorCheck = textBox7.Text;
        }
    }

}
