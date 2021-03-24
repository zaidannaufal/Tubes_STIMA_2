using System;
using System.Collections.Generic;
using System.Text;

namespace Zref
{
    class Graph
    {
        protected SortedDictionary<string, List<string>> graphDict;

        public Graph()
        {
            graphDict = new SortedDictionary<string, List<string>>();
        }
        public void AddEdge(string v1, string v2)
        {
            if (graphDict.ContainsKey(v1))
            {
                List<string> listOfVertices = graphDict[v1];
                listOfVertices.Add(v2);
                graphDict[v1] = listOfVertices;
                if (!(graphDict.ContainsKey(v2)))
                {
                    List<string> listOfVertices_v2 = new List<string>();
                    listOfVertices_v2.Add(v1);
                    graphDict.Add(v2, listOfVertices_v2);
                }
                else
                {
                    List<string> listOfVertices_add = graphDict[v2];
                    listOfVertices_add.Add(v1);
                    graphDict[v2] = listOfVertices_add;
                }
            }
            else
            {
                List<string> listOfVertices_v1 = new List<string>();

                /*if (v2!= null)
                {
                    
                    listOfVertices_v1.Add(v2);
                    listOfVertices_v2.Add(v1);
                    
                }
                */

                listOfVertices_v1.Add(v2);
                graphDict.Add(v1, listOfVertices_v1);

                if (!(graphDict.ContainsKey(v2)))
                {
                    List<string> listOfVertices_v2 = new List<string>();
                    listOfVertices_v2.Add(v1);
                    graphDict.Add(v2, listOfVertices_v2);
                }
                else
                {
                    List<string> listOfVertices_add = graphDict[v2];
                    listOfVertices_add.Add(v1);
                    graphDict[v2] = listOfVertices_add;
                }

            }
        }
        // overload AddEdge ketika v2 ga ada
        public void AddEdge(string v1)
        {
            if (!(graphDict.ContainsKey(v1)))
            {
                List<string> listOfVertices = new List<string>();

                graphDict.Add(v1, listOfVertices);
            }
            //else {do nothing} karna udh ada & value jg tidak ada
        }

        public void sorting_value()
        {
            foreach (KeyValuePair<string, List<string>> entry in graphDict)
            {
                entry.Value.Sort();
            }
        }

        /*public void sorting_key()
        {
            foreach (KeyValuePair<string, List<string>> entry in graphDict.OrderBy(key => key.Key))
            {
                
            }
        }
        */



        public void PrintGraph()
        {
            foreach (KeyValuePair<string, List<string>> entry in graphDict)
            {
                Console.WriteLine("Vertices " + entry.Key + ":");
                Console.WriteLine("Edge to:");
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + entry.Value[i]);
                }
            }
        }
        public int GetTotalVertices()
        {
            return graphDict.Keys.Count;
        }

        public int GetDegree(string vertices)
        {
            return graphDict[vertices].Count;
        }

        public List<string> GetVertices()
        {
            List<string> listOfVertices = new List<string>();
            foreach (string keys in graphDict.Keys)
            {
                listOfVertices.Add(keys);
            }
            return listOfVertices;
        }

        public List<string> GetListOfEdgesFrom(string vertices)
        {
            return graphDict[vertices];
        }
    }
}

