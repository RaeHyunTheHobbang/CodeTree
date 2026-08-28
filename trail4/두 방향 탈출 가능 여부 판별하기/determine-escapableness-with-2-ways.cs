using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   

    static int N;
    static int M;
    static int[][] Graph;
    static List<(int,int)> Visited;
    static int Answer;

    public static void Main()
    {
        // Please write your code here.
        Answer=0;
        Visited=new List<(int,int)>();
        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        N=input[0];
        M=input[1];
        Graph= new int[N][];
        
        for(int r=0;r<N;r++)
        {
            var line = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[r]=line;   
        }

        Dfs();
        Console.WriteLine(Answer);
    }


    static void Dfs()
    {
        
        int[] dr=new int[]{0,1};
        int[] dc=new int[]{1,0};
        
        Stack<(int,int)> stack=new Stack<(int,int)>();
        stack.Push((0,0));
        Visited.Add((0,0));
        while(stack.Count>0)
        {

            (int curR,int curC)=stack.Pop();
            if(curR==N-1 && curC==M-1)
            {
                Answer=1;
                return;
            }

            for(int i=0;i<2;i++)
            {
                (int tmpR,int tmpC)=(curR+dr[i],curC+dc[i]);
                if(0<=tmpR && tmpR<N && 0<=tmpC && tmpC<M)
                {
                    if(!Visited.Contains((tmpR,tmpC)) && Graph[tmpR][tmpC]==1)
                    {
                        Visited.Add((tmpR,tmpC));
                        stack.Push((tmpR,tmpC));
                    }
                }
            }
        }

        

    }
}
