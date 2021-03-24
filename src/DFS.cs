using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zref
{
    class DFS: Graph
    {
		private List<string> visited;
		private List<string> ans;
		private List<string> temp_ans;

		public DFS() : base()
		{
			visited = new List<string>();
			ans = new List<string>();
			temp_ans = new List<string>();
		}


		/*public void AddVisited(string vertex)
        {
			this.visited.Add(vertex);
			List<string> unique = visited.Distinct().ToList();
			CopyList(unique);
        }
		public void CopyList(List<string> source)
        {
			this.visited.AddRange(source);
        }
		*/

		public void GetDFSAnswer(string vertex, string goal)
		{
			int iterasi = 0;
			recursive(vertex, goal, this.visited, iterasi);
		}
		public void recursive(string vertex, string goal, List<string> visited, int iterasi)
		{
			Console.WriteLine("iterasi : " + iterasi);
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
			if (this.graphDict.ContainsKey(vertex) && (this.ans.Count() > 0 || iterasi == 0))
			{
				Console.WriteLine("AUOOOOOOOOO");
				iterasi++;
				Console.WriteLine("HMMMM");
				foreach (string next_vertex in this.graphDict[vertex].Where(vertex => !visited.Contains(vertex)))
				{
					if (this.ans.Contains(goal))
					{
						Console.WriteLine("Skrg di sini" + vertex);
						return;
					}
					recursive(next_vertex, goal, visited, iterasi);
				}

				if (this.ans.Contains(goal))
				{
					//Console.WriteLine("Skrg di " + vertex);
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
					recursive(this.ans[this.ans.Count() - 1], goal, visited, iterasi);
				}




				//Console.WriteLine("HALO");
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

		public void print_ans()
		{
			if (this.ans.Count != 0)
			{
				for (int i = 0; i < this.ans.Count; i++)
				{
					if (i == (this.ans.Count - 1))
					{
						Console.Write(this.ans[i] + "\n");
					}
					else
					{
						Console.Write(this.ans[i] + " -> ");
					}

				}

				int degree = this.ans.Count - 2;
				if ((degree % 10) == 2)
				{
					Console.WriteLine(degree + "nd-degree connection");
				}
				else if ((degree % 10) == 3)
				{
					Console.WriteLine(degree + "rd-degree connection");
				}
				else
				{
					Console.WriteLine(degree + "th-degree connection");
				}
			}
			else
			{
				Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
				Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
			}


		}
	}
}

