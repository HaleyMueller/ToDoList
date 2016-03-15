using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        const string ipLocation = "ToDoList.txt";
        const string colorLocation = "Colors.txt";
        public static List<String> todoList = new List<string>();
        public static String addToDoList = " ";
        public static string backgroundColor = "Green";
        public static string foreColor = "Gray";
        public static string foreColorCheck = "Blue";
        public static string backgroundColorCheck = "Red";
        public static Boolean Mlg = false;

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
            if (!File.Exists(colorLocation))
            {
                Console.Write("Creating Color File...");
                File.Create(colorLocation).Dispose();
            }
            else
            {
                using (StreamReader r = new StreamReader(colorLocation))
                {
                    string line;
                    var tests = 1;
                    for (var i = 1; i < 5; i++)
                    {
                        while ((line = r.ReadLine()) != null)
                        {
                            switch (tests)
                            {
                                case 1:
                                    backgroundColor = line; tests++;
                                    break;
                                case 2:
                                    foreColor = line; tests++;
                                    break;
                                case 3:
                                    backgroundColorCheck = line; tests++;
                                    break;
                                case 4:
                                    foreColorCheck = line; tests++;
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
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

            TextWriter tr = new StreamWriter(colorLocation);
            var tests = 1;
            for (var i = 1; i < 5; i++)
            {
                switch (tests)
                {
                    case 1:
                        tr.WriteLine(backgroundColor); tests++;
                        break;
                    case 2:
                        tr.WriteLine(foreColor); tests++;
                        break;
                    case 3:
                        tr.WriteLine(backgroundColorCheck); tests++;
                        break;
                    case 4:
                        tr.WriteLine(foreColorCheck); tests++;
                        break;
                    default:
                        break;
                }
            }
            Console.Out.Write("Saving Colors");
            tr.Close();
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
                todoList.Insert(index + 1, d.ToString());
                refreshList();
                saveData();
            }
            catch { }
        }

        private void removeItem()
        {
            var d = checkedListBox1.SelectedItem;
            todoList.Remove(d.ToString());
            refreshList();
            saveData();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                this.checkedListBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form1_KeyDown);
            }
            for (var i = 0; i < checkedListBox1.Items.Count - 1; i++)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*   if (textBox1.Text != "")
               {
                   addToDoList = textBox1.Text;
                   textBox1.Text = "";
                   todoList.Add(addToDoList);
                   refreshList();
               }*/
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
            try {
                this.BackColor = ColorTranslator.FromHtml(backgroundColor);
            }
            catch(Exception t)
            {
                this.BackColor = System.Drawing.Color.White;
            }
            try
            {
                this.ForeColor = ColorTranslator.FromHtml(foreColor);
            }
            catch (Exception t)
            {
                this.ForeColor = System.Drawing.Color.White;
            }
            try
            {
                checkedListBox1.BackColor = ColorTranslator.FromHtml(backgroundColorCheck);
            }
            catch (Exception t)
            {
                checkedListBox1.BackColor = System.Drawing.Color.White;
            }
            try
            {
                checkedListBox1.ForeColor = ColorTranslator.FromHtml(foreColorCheck);
            }
            catch (Exception t)
            {
                checkedListBox1.ForeColor = System.Drawing.Color.White;
            }

            if (Mlg)
            {
                // Add Background
            }
        }

        private void whenClicked(object sender, EventArgs e)
        {
           
            if (Mlg)
            {
                System.Reflection.Assembly thisExe;
                thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream file =
                    thisExe.GetManifestResourceStream("ToDoList.Hitmarker.wav");
                System.IO.Stream file1 =
                   thisExe.GetManifestResourceStream("ToDoList.HITMARKER.png");

                Random random = new Random();
                int randomNumberX = random.Next(0, this.Width);
                int randomNumberY = random.Next(0, this.Height);
                //Adds Sound
                SoundPlayer simpleSound = new SoundPlayer(ToDoList.Properties.Resources.hitmarkerSound);
                simpleSound.Play();
                //Adds Image
                this.Cursor = new Cursor(Cursor.Current.Handle);
                int xCoordinate = randomNumberX;
                int yCoordinate = randomNumberY;
                PictureBox pic = new PictureBox();
                pic.Image = Properties.Resources.hitmarkerImage; 
                pic.Location = new Point(xCoordinate, yCoordinate);
                pic.BringToFront();
                this.Controls.Add(pic);
                pic.BringToFront();
            }
        }

        private void Form1_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)

            {
                // Then Enter key was pressed
                Console.WriteLine("Enter Was Pressed");
                // button1.PerformClick();
            }
            if (e.KeyChar == (char)43)
            {
                Console.WriteLine("Plus Was Pressed");
                moveItemUp();
            }
            if (e.KeyChar == (char)61)
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
            if (e.KeyChar == (char)46)
            {
                Console.WriteLine("Delete Was Pressed");
                removeItem();
            }
            if (e.KeyChar == (char)8)
            {
                Console.WriteLine("BackSpace Was Pressed");
                removeItem();
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
            //   this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form1_KeyDown);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 addItemForm = new Form2();
            addItemForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Settings addItemForm = new Settings();
            addItemForm.Show();
        }
    }
}
