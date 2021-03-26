using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Zref
{
	class DFS : Graph
	{
		private List<string> visited;
		private List<string> visited_temp;
		private List<string> ans;
		private List<string> ans_temp;
		//private SortedDictionary<string, List<string>> grafDFS;

		public DFS() : base()
        {
			visited = new List<string>();
			visited_temp = new List<string>();
			ans = new List<string>();
			ans_temp = new List<string>();
			//grafDFS = new SortedDictionary<string, List<string>>();
			/*string[] test = File.ReadAllLines(@"..\test\" + namaFile);
			Graph grafDFS = new Graph();
			for (int i = 1; i < test.Length; i++)
            {
                // string[] input = test[i].split(" ");
                //string[] separator = {" "}
                string[] input = test[i].Split(' ');

                //Console.WriteLine(input[0]);
                //Console.WriteLine(input[1]);
                if (input.Length == 2)
                {
                    grafDFS.AddEdge(input[0], input[1]);	
                }
                else
                {
                    grafDFS.AddEdge(input[0]);
                }

            }
            grafDFS.sorting_value();
			*/

			//grafDFS = new SortedDictionary<string, List<string>>(graf); //copy graph dict karna mau dihapus2 
		}


		/*public void PrintGraphDFS()
        {
            foreach (KeyValuePair<string, List<string>> entry in grafDFS)
            {
                Console.WriteLine("Vertices "+entry.Key+":");
                Console.WriteLine("Edge to:");
                for (int i =0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + entry.Value[i]);
                }
            }
        }
		*/
		/*
		public class CloneableDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : ICloneable
		{
		public CloneableDictionary<TKey, TValue> Clone()
			{
			CloneableDictionary<TKey, TValue> clone = new CloneableDictionary<TKey, TValue>();
			foreach (KeyValuePair<TKey, TValue> kvp in this)
				{
				clone.Add(kvp.Key, (TValue) kvp.Value.Clone());
				}
			return clone;
			}
		}*/
		public void copyGraf(Graph g1)
		{
			this.graphDict = g1.getGraph();
		}


		public bool isExist(string vertex, List<string> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
				if (vertex == list[i])
                {
					return true;
                }
            }
			return false;
        }

        public void GetAnswerFR(string vertex)
        {

			List<string> list_goal = this.graphDict[vertex];

			int idx_ahirkhir = 
			string goal = list_goal[].Count; 
            GetAnswer(vertex,goal);
        }

		public void GetAnswer(string vertex, string goal) // friend recom
        {
			int iterasi = 0;
			List<string> neighbour_vertex = this.graphDict[vertex];
			SortedDictionary<string, List<string>> graphDFS;
			graphDFS = new SortedDictionary<string, List<string>>();

			foreach (KeyValuePair<string, List<string>> entry in this.graphDict)
            {
                
                for (int i =0; i < entry.Value.Count; i++)
                {
					if (graphDFS.ContainsKey(entry.Key))
                    {
						List<string> listOfVertices_add = graphDFS[entry.Key];
						listOfVertices_add.Add(entry.Value[i]);
						graphDFS[entry.Key] = listOfVertices_add;
                    }
                    else
                    {
						List<string> listOfVertices_add = new List<string>();
						listOfVertices_add.Add(entry.Value[i]);
						graphDFS.Add(entry.Key,listOfVertices_add);
                    }
                    
                }
            }
			/*graphDFS = this.graphDict.ToDictionary(
				entry => entry.Key, 
				entry => (SortedDictionary<string,List<string>>) entry.Value.Clone());*/


			Console.WriteLine("NJIIIIIIIIIIIIII");

			foreach (KeyValuePair<string, List<string>> entry in graphDFS)
            {
                Console.WriteLine("Vertices "+entry.Key+":");
                Console.WriteLine("Edge to:");
                for (int i =0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + entry.Value[i]);
                }
            }

			neighbour_vertex.Add(vertex);
				foreach (var v in neighbour_vertex)
            {
                Console.Write(v + " | ");
            }



			Console.WriteLine();
			
			recursiff(vertex,goal, this.visited_temp, iterasi, neighbour_vertex, graphDFS);
        }

		public void GetDFSAnswer(string vertex, string goal) // explore
        {
			int iterasi = 0;
			recursive(vertex,goal,this.visited, iterasi);
        }

		public void recursiff(string vertex,string goal, List<string> visited, int iterasi, List<string> neighbour_vertex, SortedDictionary<string, List<string>> graphDFS)
        {
			Console.WriteLine("iterasi : " +iterasi);
			this.visited_temp.Add(vertex);

			Console.WriteLine("Before");
			Console.WriteLine("Print ANS TEMP");
			foreach (var v in ans_temp)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine();

			Console.WriteLine("Print ANS");

			foreach (var v in ans)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine();

			if (!(this.ans.Contains(vertex)))
            {
				this.ans.Add(vertex);
            }	

			Console.WriteLine("after print Ans");

			foreach (var v in ans)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine();

			Console.WriteLine("Vertex :"+vertex);

			List<string> node_vertex = new List<string>();
			node_vertex = graphDFS[vertex]; // [A C E F] skrg di node B 

			if (iterasi != 0 && node_vertex[0] != "dummy") { 
				Console.WriteLine("Masuk sini");
				Console.WriteLine("iterasi " +iterasi);
				if ((isExist(vertex, neighbour_vertex))) // jika ada vertex di neighbour maka masukin aja semua kecuali yg isinya ada jg di neighbour
				{
					Console.WriteLine("HALO DI IFF");
					for (int i = 0; i < node_vertex.Count(); i++)
					{
						foreach (var v in node_vertex)
                        {
							Console.Write(v + "|");
                        }
						Console.WriteLine();
						
						if (!(isExist(node_vertex[i], neighbour_vertex)))
						{
							Console.WriteLine("No NODE VERTEX");
							Console.WriteLine("Hoi "+node_vertex[i]);
							this.ans_temp.Add(node_vertex[i]);
							this.ans_temp.Add(vertex);
							
							List<string> temp_node_vertex = new List<string>();

							temp_node_vertex.AddRange(node_vertex);
							temp_node_vertex.Remove(node_vertex[i]); // hapus yg ditambahkan (E)

							if (temp_node_vertex.Count == 0)
                            {
								temp_node_vertex.Add("dummy");
                            }

							List<string> temp_node_vertex_i = new List<string>();
							temp_node_vertex_i = graphDFS[node_vertex[i]];  // E [B F H]
							temp_node_vertex_i.Remove(vertex); // E [F H]

							if (temp_node_vertex_i.Count == 0)
                            {
								temp_node_vertex_i.Add("dummy");
                            }


							graphDFS[vertex] = temp_node_vertex;// update dictionary (A C  F)
							graphDFS[node_vertex[i]] = temp_node_vertex_i; // update dictionaru E [F H]
						}
					}
				}
				else // seperti vertex F / E
				{
					Console.WriteLine("HALO DI ELSE");
					for (int i = 0; i < node_vertex.Count(); i++)
					{
						if (!(isExist(node_vertex[i], neighbour_vertex))) // misal [D E H] D nya ga masuk & kyk E [C D G H] C D nya ga masuk
						{
							List<string> node_vertex_advanced = new List<string>(); // sisi2 si node vertex[i] seperti F [E H] 
							node_vertex_advanced = graphDFS[node_vertex[i]]; // F [D E H] / G [C E] // node_vertex[i] = E ; node_vertex[i] = G
						
							for (int j = 0; j < node_vertex_advanced.Count(); j++) 
							{ 
								if (isExist(node_vertex_advanced[j], neighbour_vertex)) // klw ada 
								{


									Console.WriteLine("NODE VERTEX");
									Console.WriteLine("HOI : "+node_vertex[i]);
									this.ans_temp.Add(node_vertex[i]); // add kyk G 
									this.ans_temp.Add(vertex);
							
									List<string> temp_node_vertex = new List<string>();

									temp_node_vertex.AddRange(node_vertex); // kyk F ; E
									temp_node_vertex.Remove(node_vertex[i]); // hapus yg ditambahkan (G) 
									if (temp_node_vertex.Count == 0)
									{
										temp_node_vertex.Add("dummy");
									}

									List<string> temp_node_vertex_i = new List<string>();
									temp_node_vertex_i = graphDFS[node_vertex[i]];  // E[H] ; G [C E]
									temp_node_vertex_i.Remove(vertex); // E [F H] (tetap) ; G [C]

									if (temp_node_vertex_i.Count == 0)
									{
										temp_node_vertex_i.Add("dummy");
									}

									graphDFS[vertex] = temp_node_vertex;// update dictionary E (C D __ H)
									graphDFS[node_vertex[i]] = temp_node_vertex_i; // update dictionary E [F H]
								}
							}

							//this.ans_temp.Add(node_vertex[i]);
						}
                        /*else
                        {

                        }
						*/

					}

				}
			}

			foreach (KeyValuePair<string, List<string>> entry in graphDFS)
            {
                Console.WriteLine("Vertices "+entry.Key+":");
                Console.WriteLine("Edge to:");
                for (int i =0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + entry.Value[i]);
                }
            }

			Console.WriteLine("------------------------------");

			/*foreach (KeyValuePair<string, List<string>> entry in this.graphDict)
            {
                Console.WriteLine("Vertices "+entry.Key+":");
                Console.WriteLine("Edge to:");
                for (int i =0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + entry.Value[i]);
                }
            }*/

			Console.WriteLine("PRINT ANS TEMP after");

			foreach (var v in ans_temp)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine();

			Console.WriteLine(vertex);
			if (this.graphDict.ContainsKey(vertex) && (this.ans.Count() > 0 || iterasi == 0)){
				Console.WriteLine("AUOOOOOOOOO");
				iterasi ++;
				Console.WriteLine("HMMMM");
				foreach (string next_vertex in this.graphDict[vertex].Where(vertex => !visited_temp.Contains(vertex))){
					if (this.ans.Contains(goal))
					{
						Console.WriteLine("Skrg di sini" + vertex);
						return;
					}
					Console.WriteLine("Skrg di siniiiiiiiiiiiii " + vertex);
					recursiff(next_vertex,goal,visited, iterasi, neighbour_vertex, graphDFS);
                }


				if (this.ans.Contains(goal))
                {
					Console.WriteLine("Skrg di " + vertex);
					return;
                }

				//Console.WriteLine("DI SINI GMN");
                
				//int last_idx = this.ans.Count() - 1;
				//string temp = this.ans[this.ans.Count() -1];
				Console.WriteLine("Count ans " + this.ans.Count());
				
				
				//this.ans.RemoveAt(this.ans.Count() - 1);
				//int new_last_idx = this.ans.Count() - 1;

				if (this.ans.Count > 0)
                {
					//string temp = this.ans[this.ans.Count() -1];
					this.ans.RemoveAt(this.ans.Count() - 1);
					//Console.WriteLine("Sudah kehapus" + temp);
					Console.WriteLine("Count ans " + this.ans.Count());
					
                }
				if (this.ans.Count != 0)
                {
					Console.WriteLine("BLM NOL");
					recursiff(this.ans[this.ans.Count() - 1], goal, visited,iterasi,neighbour_vertex,graphDFS);

                }
                
                
				

				Console.WriteLine("HALO");
				Console.WriteLine("KOK HALO");
				foreach (var v in ans)
				{
					Console.Write(v + " | ");
				}
				
				

				Console.WriteLine("HALO");
				Console.WriteLine("SKRG NGPAIAN SIH" + vertex);

				

            }
            else
            {
				Console.WriteLine("HALO DI WELSE");
				return;
            }
			
        }
		public void recursive(string vertex,string goal, List<string> visited, int iterasi)
        {
			Console.WriteLine("iterasi : " +iterasi);
			this.visited.Add(vertex);

			foreach (var v in ans)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine("Before");

			if (!(this.ans.Contains(vertex)))
            {
				this.ans.Add(vertex);
            }	

			Console.WriteLine("after");

			foreach (var v in ans)
            {
                Console.Write(v + " | ");
            }

			Console.WriteLine();


			Console.WriteLine(vertex);
			if (this.graphDict.ContainsKey(vertex) && (this.ans.Count() > 0 || iterasi == 0)){
				Console.WriteLine("AUOOOOOOOOO");
				iterasi ++;
				Console.WriteLine("HMMMM");
				foreach (string next_vertex in this.graphDict[vertex].Where(vertex => !visited.Contains(vertex))){
					if (this.ans.Contains(goal))
					{
						Console.WriteLine("Skrg di sini" + vertex);
						return;
					}
					Console.WriteLine("HOOHOHOHOHOH");
					recursive(next_vertex,goal,visited, iterasi);
                }

				Console.WriteLine("HONJIIIIIIIIIIIROHOHOHOHOH");

				if (this.ans.Contains(goal))
                {
					//Console.WriteLine("Skrg di " + vertex);
					return;
                }

				Console.WriteLine("DI SINI GMN");
                
				//int last_idx = this.ans.Count() - 1;
				//string temp = this.ans[this.ans.Count() -1];
				Console.WriteLine("Count ans " + this.ans.Count());
				
				
				//this.ans.RemoveAt(this.ans.Count() - 1);
				//int new_last_idx = this.ans.Count() - 1;

				if (this.ans.Count > 0)
                {
					//string temp = this.ans[this.ans.Count() -1];
					this.ans.RemoveAt(this.ans.Count() - 1);
					//Console.WriteLine("Sudah kehapus" + temp);
					Console.WriteLine("Count ans " + this.ans.Count());
					
                }
				if (this.ans.Count != 0)
                {
					Console.WriteLine("BLM NOL");
					recursive(this.ans[this.ans.Count() - 1], goal, visited,iterasi);
                }
                
                
				

				Console.WriteLine("HALO");
				//Console.WriteLine("KOK HALO");
				/*foreach (var v in ans)
				{
					Console.Write(v + " | ");
				}
				*/
				

				//Console.WriteLine("HALO");
				//Console.WriteLine("SKRG NGPAIAN SIH" + vertex);

            }
            else
            {
				Console.WriteLine("HALO DI WELSE");
				return;
            }
			
        }

		public string print_ans_explore()
		{
			string ans_explore = "";
			if (this.ans.Count != 0)
			{
				for (int i = 0; i < this.ans.Count; i++)
				{
					if (i == (this.ans.Count - 1))
					{
						ans_explore += (this.ans[i] + "\n");
					}
					else
					{
						ans_explore += (this.ans[i] + " -> ");
					}

				}

				int degree = this.ans.Count - 2;
				if ((degree % 10) == 2)
				{
					ans_explore += (degree + "nd-degree connection" + "\n");
				}
				else if ((degree % 10) == 3)
				{
					ans_explore += (degree + "rd-degree connection" + "\n");
				}
				else
				{
					ans_explore += (degree + "th-degree connection" + "\n");
				}
			}
            else
            {
				ans_explore += ("Tidak ada jalur koneksi yang tersedia" + "\n");
				ans_explore += ("Anda harus memulai koneksi baru itu sendiri.");
            }

			return ans_explore;
		}

		public string print_ans_recommendation()
		{
			//List<string> ans_temp = new List<string>() {"E", "B", "F","B","F","C", "G","C", "F", "D", "G", "D"};
			string ans_rec = "";

			//this.ans_temp .AddRange(ans_temp);
			if (this.ans_temp.Count != 0) { 
				List<string> temp = new List<string>(); // exclude B C D (neighbour A)
            

				for (int i = 0; i < this.ans_temp.Count(); i++)
				{
					if ((i % 2) == 0)
					{
						temp.Add(this.ans_temp[i]);
					} 
				}
            
				/*foreach (var v in temp)
				{
                
					Console.Write(v + " | "); // E F  F G F G
				}*/

				var no_Duplicate = new HashSet<string>(temp).ToList();
				ans_rec+=("------" +"\n");

				/*foreach (var v in no_Duplicate)
				{
                
					Console.Write(v + " | "); // E F  F G F G
				}*/
            
				Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

				for (int i = 0; i < no_Duplicate.Count();i++)
				{
					List<string> list = new List<string>();
					dict.Add(no_Duplicate[i],list);
          
				}


				for (int j = 0; j < this.ans_temp.Count(); j++)
				{
					if (dict.ContainsKey(ans_temp[j]))
					{
						if (!(isExist(ans_temp[j+1],dict[ans_temp[j]]))) { 
							List<string> listOfVertices_add = dict[ans_temp[j]];
							listOfVertices_add.Add(this.ans_temp[j+1]);
							graphDict[this.ans_temp[j]] = listOfVertices_add;
						}
					}            
				}
        
				var neo = dict.OrderByDescending(x => x.Value.Count()); // order by yg plg banyak value.Count listnya

				Dictionary<string, List<String>> final = new Dictionary<string, List<string>>();

		

				foreach (KeyValuePair<string, List<string>> entry in neo)
				{
					ans_rec += ("Nama Akun : "+entry.Key +"\n");
					ans_rec += (entry.Value.Count+" mutual friends : " + "\n");

					for (int i =0; i < entry.Value.Count; i++)
					{

						ans_rec += (entry.Value[i]);
					}
				}
			}
            else
            {
				ans_rec += ("Tidak ada yang bisa kami rekomendasikan." + "\n");
            }

			return ans_rec;
		}
	}


}