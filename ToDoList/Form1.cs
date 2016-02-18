using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        const string ipLocation = "ToDoList.txt";
        List<String> todoList = new List<string>();
        String addToDoList = " ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (!File.Exists(ipLocation))
            {
                Console.WriteLine("Creating ToDo File...");
                File.Create(ipLocation).Dispose();
            }
            else
            {
                using (StreamReader r = new StreamReader(ipLocation))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        todoList.Add(line);
                        checkedListBox1.Items.Add(line);

                        Console.Out.Write("Loading Ips");
                    }
                }
            }

        }

        private void saveData()
        {
            TextWriter tw = new StreamWriter(ipLocation);

            foreach (String s in todoList)
                tw.WriteLine(s);
            Console.Out.Write("Saving Ips");
            tw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                addToDoList = textBox1.Text;
                textBox1.Text = "";
                todoList.Add(addToDoList);
                refreshList();
            }
        }

        private void refreshList()
        {
            checkedListBox1.Items.Clear();
            foreach (String s in todoList)
            {
                checkedListBox1.Items.Add(s);
            }
        }

        private void removeItem()
        {
           var d = checkedListBox1.SelectedItem;
            todoList.Remove(d.ToString());
            //checkedListBox1.Items.Remove(d);
            refreshList();
           saveData();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeItem();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }
    }
}
