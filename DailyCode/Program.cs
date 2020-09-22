﻿using System;
using System.Windows.Forms;

namespace ShortestPathAlgorithim
{
	static class Program
	{
		static int V = 9;
		static int minDistance(int[] dist, bool[] sptSet) {
			int min = int.MaxValue, min_index = -1;

			for (int v = 0; v < V; v++)
			{
				if (sptSet[v] == false && dist[v] <= min) {
					min = dist[v];
					min_index = v;
				}
			}
			
			return min_index;
		}

		static void Dijkstra(int[,] graph, int src)
		{
			int[] dist = new int[V]; // The output array. dist[i]
									 // will hold the shortest 
									 // distance from src to i

			// sptSet[i] will true if vertex 
			// i is included in shortest path 
			// tree or shortest distance from 
			// src to i is finalized 
			bool[] sptSet = new bool[V];

			// Initialize all distances as 
			// INFINITE and stpSet[] as false 
			for (int i = 0; i < V; i++)
			{
				dist[i] = int.MaxValue;
				sptSet[i] = false;
			}

			// Distance of source vertex 
			// from itself is always 0 
			dist[src] = 0;

			// Find shortest path for all vertices 
			for (int count = 0; count < V - 1; count++)
			{
				// Pick the minimum distance vertex 
				// from the set of vertices not yet 
				// processed. u is always equal to 
				// src in first iteration. 
				int u = minDistance(dist, sptSet);

				// Mark the picked vertex as processed
				sptSet[u] = true;

				// Update dist value of the adjacent 
				// vertices of the picked vertex. 
				for (int v = 0; v < V; v++)
				{
					// Update dist[v] only if is not in 
					// sptSet, there is an edge from u 
					// to v, and total weight of path 
					// from src to v through u is smaller 
					// than current value of dist[v] 
					if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v];

				}
			}

		}

		/// <summary>
		/// Ponto de entrada principal para o aplicativo.
		/// </summary>
		/// 
		[STAThread]
		static void Main()
		{
			int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
									    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
									    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
									    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
									    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
									    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
									    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
									    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
									    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } 
									  };
		
			Dijkstra(graph, 0);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
