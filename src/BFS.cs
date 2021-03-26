using System;
using System.Collections.Generic;
using System.Text;

namespace Zref
{
    class BFS : Graph  //Child dari class Graph
    {
        //----------------ATRIBUT-------------
        private List<string> Ans;
        private Queue<List<string>> antrian;
        private Queue<string> antrian_pair; //berpasangan dengan atribut antrian

        //----------------METHOD-------------
        public BFS() : base()
        {
            antrian = new Queue<List<string>>();
            antrian_pair = new Queue<string>();
            Ans = new List<string>();
        }

        public void copyGraf(Graph g1)
        {
            this.graphDict = g1.getGraph();
        }

        private void empty_antrian()
        {
            this.antrian.Clear();
            this.antrian_pair.Clear();
        }

        private void Enqueue(List<string> kandidatSolusi, string node)
        {
            List<string> p1 = new List<string>();
            foreach (var item in kandidatSolusi)
            {
                p1.Add(item);
            }
            p1.Add(node);
            this.antrian.Enqueue(p1);
            this.antrian_pair.Enqueue(node);
        }

        private void Dequeue()
        {
            if (this.antrian.Count != 0 && this.antrian_pair.Count != 0)
            {
                List<string> dummy1 = new List<string>();
                dummy1 = this.antrian.Dequeue();
                string dummy2 = this.antrian_pair.Dequeue();
            }
        }

        public List<string> GetBFSAnswer(string from, string goals)
        {
            this.empty_antrian();
            List<string> temp_path;
            //List<string> temp_sol = new List<string>();
            string curr_node;

            //initialize
            List<string> first = new List<string>();
            this.Enqueue(first, from);

            //process
            while (!antrian.Count.Equals(0))
            {
                temp_path = this.antrian.Dequeue();
                curr_node = this.antrian_pair.Dequeue();

                foreach (var node in graphDict[curr_node])
                {
                    /*
                    temp_sol.Clear();
                    
                    foreach (var item in temp_path)
                    {
                        temp_sol.Add(item);
                    }
                    temp_sol.Add(node);
                    */
                    if (temp_path.Contains(node))
                    {
                        Dequeue();
                        continue;
                    }
                    if (node.Equals(goals))
                    {
                        foreach (var item in temp_path)
                        {
                            this.Ans.Add(item);
                        }
                        this.Ans.Add(node);
                        return this.Ans;
                    }

                    Enqueue(temp_path, node);
                }
            }

            return new List<string>();//Tidak ada jalur/koneksi
        }
    }
}