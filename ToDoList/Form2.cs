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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form1.addToDoList = textBox1.Text;
                textBox1.Text = "";
                Form1.todoList.Add(Form1.addToDoList);
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = "* " + textBox1.Text;
            }
        }
        private void Form2_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)

            {
                // Then Enter key was pressed
                Console.WriteLine("Enter Was Pressed");
                button1.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form2_KeyDown);
        }
    }
}
