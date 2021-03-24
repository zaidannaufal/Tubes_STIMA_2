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
        public Form1()
        {
            InitializeComponent();
        }
        static OpenFileDialog ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label1.Text = ofd.SafeFileName;
                string[] test = File.ReadAllLines(@ofd.FileName);
                label2.Text = ofd.FileName;
                mainmain(test);
            }
        }
        public void mainmain(string[] test)
        {
            DFS graf = new DFS();
            gambar();
            for (int i = 1; i < test.Length; i++)
            {
                // string[] input = test[i].split(" ");
                //string[] separator = {" "}
                string[] input = test[i].Split(' ');

                Console.WriteLine(input[0]);
                Console.WriteLine(input[1]);
                if (input.Length == 2)
                {
                    graf.AddEdge(input[0], input[1]);
                }
                else
                {
                    graf.AddEdge(input[0]);
                }


                //graf.sorting_key();


            }

            //graf.AddEdge("J","I");

            graf.sorting_value();


            /*foreach(var v in graf["A"])
            {
                Console.WriteLine(v + " | ");
            }
            */
            string[] print = new string[10000];

            print.Append("PRINT DFS GRAF");
            //graf.PrintGraph();
            print.Append("total simpul = " + graf.GetTotalVertices());
            List<string> listOfVertices = graf.GetVertices();
            print.Append("derajat dari " + listOfVertices[0] + " adalah " + graf.GetDegree(listOfVertices[0]));


            graf.GetDFSAnswer("A", "J");

            graf.print_ans();

            //Console.ReadLine();
            richTextBox1.Text = print[0];
            List<string> vertices = graf.GetVertices();
            comboBox1.BeginUpdate();
            foreach (var v in vertices){
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void gambar()
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
            //show the form 
            //this.ShowDialog();
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = (comboBox1.SelectedItem).ToString();
            if (radioButton1.Checked)
            {
                // do bfs
                label2.Text = "BFS " + x;
            }else
            {
                // do dfs
                label2.Text = "DFS " + x;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
