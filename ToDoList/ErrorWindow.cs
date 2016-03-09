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
    public partial class ErrorWindow : Form
    {
        public static string s = " ";
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            label1.Text = s;
        }
    }
}
