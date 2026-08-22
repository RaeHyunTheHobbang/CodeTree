using System;
using System.Linq;
using System.Collections.Generic;
public class Codetree
{   
    static int N;
    static int M;
    static Dictionary<int,List<int>> Graph;
    static List<int> Visited;
    static int answer=0;
    public static void Main()
    {
        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        Graph=new Dictionary<int,List<int>>();
        Visited=new List<int>();

        N=input[0];
        M=input[1];
        for(int i=0;i<M;i++)
        {
            input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            int x=input[0];
            int y=input[1];
            if(!Graph.Keys.Contains(x))
            {
                Graph[x]=new List<int>();
            }

            if(!Graph.Keys.Contains(y))
            {
                Graph[y]=new List<int>();
            }

            Graph[x].Add(y);
            Graph[y].Add(x);
        }

        Visited.Add(1);
        Dfs(1);
        Console.WriteLine(answer);
    }

    static void Dfs(int node)
    {   
        if(Graph.Keys.Contains(node))
        {
            foreach(int nextNode in Graph[node])
            {
                if(!Visited.Contains(nextNode))
                {   
                    Visited.Add(nextNode);
                    answer+=1;
                    Dfs(nextNode);
                }
            }    
        }
        

    }
}
