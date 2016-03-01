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
        public static List<String> todoList = new List<string>();
        public static String addToDoList = " ";

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

        public void refreshList()
        {
            checkedListBox1.Items.Clear();
            foreach (String s in todoList)
            {
                checkedListBox1.Items.Add(s);
            }
        }

        private void moveItemUp()
        {
            var d = checkedListBox1.SelectedItem; try
            {
                int index = todoList.FindIndex(x => x.StartsWith(d.ToString()));
           
            
                todoList.Remove(d.ToString());
                todoList.Insert(index - 1, d.ToString());
                refreshList();
                saveData();
            }
            catch { }
        }

        private void moveItemDown()
        {
            var d = checkedListBox1.SelectedItem; try
            {
                int index = todoList.FindIndex(x => x.StartsWith(d.ToString()));


                todoList.Remove(d.ToString());
                todoList.Insert(index +1, d.ToString());
                refreshList();
                saveData();
            }
            catch { }
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
            if (checkedListBox1.SelectedItem != null)
            {
                this.checkedListBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form1_KeyDown);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            removeItem();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }
        private void Form2_FormActivated(object sender, EventArgs e)
        {
            refreshList();
        }

        private void Form1_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)

            {
                // Then Enter key was pressed
                Console.WriteLine("Enter Was Pressed");
                button1.PerformClick();
            }
            if(e.KeyChar == (char)43)
            {
                Console.WriteLine("Plus Was Pressed");
                moveItemUp();
            }
            if(e.KeyChar == (char)61)
            {
                Console.WriteLine("Equals Was Pressed");
                moveItemUp();
            }
            if (e.KeyChar == (char)45)
            {
                Console.WriteLine("Minus Was Pressed");
                moveItemDown();
            }
            if (e.KeyChar == (char)95)
            {
                Console.WriteLine("Dash Was Pressed");
                moveItemDown();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveItemUp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveItemDown();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form1_KeyDown);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 addItemForm = new Form2();
            addItemForm.Show();
        }
    }
}
