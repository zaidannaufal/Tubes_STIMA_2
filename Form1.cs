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

namespace Zref
{
    public partial class Form1 : Form
    {
        Graph grafGlobal = new Graph();
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

        public Form1()
        {
            InitializeComponent();
        }
        static OpenFileDialog ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //label1.Text = ofd.SafeFileName;
                string[] test = File.ReadAllLines(@ofd.FileName);
                label2.Text = ofd.FileName;
                loadGraf(test);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        public void gambar()
        {
           // Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            
            //create the graph content 
            /*
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            */
            Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graph);
            renderer.CalculateLayout();
            int width = 200;
            Bitmap bitmap = new Bitmap(width, (int)(graph.Height * (width / graph.Width)));
            renderer.Render(bitmap);
            if (bitmap.Height > bitmap.Width)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            pictureBox1.Image = bitmap;
            

            //bind the graph to the viewer 
            //viewer.Graph = graph;
            //associate the viewer with the form 
            //this.SuspendLayout();
            //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //pictureBox1.Contains(viewer);
            //this.Controls.Add(viewer);
            //this.Controls.Add(viewer);
            //this.ResumeLayout();

            //show the form 
            //this.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = (comboBox1.SelectedItem).ToString();
            if (radioButton1.Checked)
            {
                richTextBox1.Text = "THOU SUCCED";
                //Dobfs();
                label2.Text = "BFS " + x;
            }else
            {
                //dodfs();
                label2.Text = "DFS " + x;
            }
            gambar();
        }

        private void Dobfs()
        {
            BFS current = new BFS();
            current.copyGraf(grafGlobal);
            List<string> solution = current.GetBFSAnswer(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            string sol = "";

            if (solution.Count() != 0)
            {
                sol += "Nama akun: " + comboBox1.SelectedItem.ToString() + " dan " + comboBox2.SelectedItem.ToString() + "\n";
                sol += "Connection Degree : " + (solution.Count() - 1).ToString() + "\n";
                int i = 0;
                foreach (var item in solution)
                {
                    graph.FindNode(item).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                    if(i != 0)
                    {
                        sol += " --> ";
                    }
                    sol += item;
                    i++;
                }
            }
            //richTextBox1.Text = sol;
        }

        private void dodfs()
        {

        }

        //----------------FIX-------------------
        private string getFriendRec (string node)
        {
            string solution = "";
            List<string> perantara = grafGlobal.GetListOfEdgesFrom(node);
            List<string> friendrec = new List<string>();
            Dictionary<string, List<string>> final = new Dictionary<string, List<string>>();

            solution += "Daftar rekomendasi teman untuk akun " + node + ":\n";

            foreach (var item in perantara)
            {
                foreach (var item2 in grafGlobal.GetListOfEdgesFrom(item))
                {
                    if (!perantara.Contains(item2) && !friendrec.Contains(item2) && !item2.Equals(node))
                    {
                        friendrec.Add(item2);
                    }
                }
            }
            
            foreach (var item in friendrec)
            {
                int count = 0;
                List<string> buff2 = new List<string>();
                foreach (var item2 in grafGlobal.GetListOfEdgesFrom(item))
                {
                    if (perantara.Contains(item2) && !item2.Equals(item))
                    {
                        count++;
                        buff2.Add(item2);
                    }
                }
                final.Add(item, buff2);
            }

            final = final.OrderByDescending(x => x.Value.Count()).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in final.Keys)
            {
                string buffer = "";
                buffer += "Nama Akun: " + item + "\n";
                buffer += final[item].Count().ToString() + " mutual friends:\n";
                foreach (var item2 in final[item])
                {
                    buffer += item2 + "\n"; 
                }
                solution += buffer + "\n";
            }

            if (friendrec.Count() == 0)
            {
                return "";
            }
            

            return solution;
        }

        //----------------FIX-------------------
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = getFriendRec(comboBox1.Text);
        }

        //----------------FIX-------------------
        private void loadGraf(string[] test)
        {
            for (int i = 1; i < test.Length; i++)
            {
                string[] input = test[i].Split(' ');

                if (input.Length == 2)
                {
                    grafGlobal.AddEdge(input[0], input[1]);
                    graph.AddEdge(input[0], input[1]);
                }
                else
                {
                    grafGlobal.AddEdge(input[0]);
                    graph.AddNode(input[0]);
                }
            }

            gambar();

            List<string> vertices = grafGlobal.GetVertices();
            comboBox1.BeginUpdate();
            foreach (var v in vertices)
            {
                comboBox1.Items.Add(v);
            }
            comboBox1.EndUpdate();
            comboBox2.BeginUpdate();
            foreach (var v in vertices)
            {
                comboBox2.Items.Add(v);
            }
            comboBox2.EndUpdate();
        }
    }
}