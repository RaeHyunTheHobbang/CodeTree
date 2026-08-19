using System;
using System.Linq;
using System.Collections.Generic;


public class Codetree
{   

    static int N;
    static int M;
    static int K;
    static int[][] Graph;
    public static void Main()
    {

        // Please write your code here.
        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToList();
        N=input[0];
        M=input[1];
        Graph=new int[N][];
        K=0;
        
        for(int r=0;r<N;r++)
        {
            int[] line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[r]=line;
            K=Math.Max(K,line.Max());
        }

        (int,int) Answer=Solver();
        Console.WriteLine($"{Answer.Item1} {Answer.Item2}");
    }

    static (int,int) Solver()
    {   
        int[,] visited;
        int tmp;
        (int,int) answer=(1,0);
        for(int k=1 ;k<=K;k++)
        {   
            visited=new int[N,M];
            tmp=0;
            for(int r=0;r<N;r++)
            {
                for(int c=0;c<M;c++)
                {
                    if(Graph[r][c]>k && visited[r,c]==0)
                    {   
                        visited[r,c]=1;
                        tmp+=Dfs(r,c,k,visited);
                    }
                }
            }
            if(answer.Item2<tmp)
            {
                answer=(k,tmp);
            }
        }
        return answer;
            
    }
    static int Dfs(int curR,int curC,int k,int[,] visited)
    {
        
        Stack<(int,int)> stack=new Stack<(int,int)>();
        stack.Push((curR,curC));

        int[] dr=new int[]{-1,1,0,0};
        int[] dc=new int[]{0,0,-1,1};

        while(stack.Count>0)
        {
            (int cur_r,int cur_c) =stack.Pop();
            
            for(int idx=0;idx<4;idx++)
            {
                int tr=dr[idx];
                int tc=dc[idx];
                int nextR=cur_r+tr;
                int nextC=cur_c+tc;
                if(0<=nextR && nextR<N && 0<=nextC && nextC<M)
                {
                    if(Graph[nextR][nextC]>k && visited[nextR,nextC]==0)
                    {
                        visited[nextR,nextC]=1;
                        stack.Push((nextR,nextC));
                    }

                }
            }
        }
        
        return 1;
        


    }
}
