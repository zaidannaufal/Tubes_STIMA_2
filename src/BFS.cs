using System;
using System.Collections.Generic;
using System.Text;

namespace Zref
{
    class BFS : Graph  //Child dari class Graph
    {
        //----------------ATRIBUT-------------
        private List<string> Ans;
        Queue<List<string>> antrian;
        Queue<string> antrian_pair; //berpasangan dengan atribut antrian

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
            this.antrian.Enqueue(kandidatSolusi);
            this.antrian_pair.Enqueue(node);
        }

        private void Dequeue()
        {
            List<string> dummy1 = this.antrian.Dequeue();
            string dummy2 = this.antrian_pair.Dequeue();
        }

        public List<string> GetBFSAnswer(string from, string goals)
        {
            this.empty_antrian();
            List<string> temp_path;
            List<string> temp_sol;
            int count = 1;

            //initialize
            List<string> first = new List<string>();
            first.Add(from);
            this.Enqueue(first, from);

            //process
            while (!antrian.Count.Equals(0))
            {
                temp_path = this.antrian.Peek();

                foreach (var next_node in temp_path)
                {
                    count++;
                    foreach (var node in graphDict[next_node])
                    {
                        temp_sol = new List<string>();
                        temp_sol.AddRange(temp_path);
                        if (temp_sol.Contains(node))
                        {
                            Dequeue();
                            break;
                        }
                        temp_sol.Add(node);

                        if (temp_sol.Contains(goals))
                        {
                            this.Ans = temp_sol;
                            return Ans;
                        }

                        Enqueue(temp_sol, next_node);
                    }
                }

                Dequeue();
            }

            return new List<string>();//Tidak ada jalur/koneksi
        }
    }
}
