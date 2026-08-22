using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   

    static int N;
    static int[][] Graph;
    static int[,] Visited;
    static int tmpDepth;
    static int blockNum;
    static int maxDepth;

    static int[] dr;
    static int[] dc;
    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        Graph=new int[N][];
        Visited=new int[N,N];

        dr=new int[]{-1,1,0,0};
        dc=new int[]{0,0,-1,1};

        for(int i=0; i<N;i++)
        {
            int[] line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }

        for(int r=0;r<N;r++)
        {
            for(int c=0;c<N;c++)
            {
                if(Visited[r,c]==0)
                {   
                    tmpDepth=1;
                    Visited[r,c]=1;
                    Dfs(r,c);

                    if(tmpDepth>=4)
                    {
                        blockNum+=1;
                    }
                    maxDepth=Math.Max(maxDepth,tmpDepth);
                }
            }
        }

        Console.WriteLine($"{blockNum} {maxDepth}");
    }
    static void Dfs(int curR,int curC)
    {

        for(int i=0;i<4;i++)
        {
            (int nextR,int nextC)=(curR+dr[i],curC+dc[i]);
            if(0<=nextR && nextR<N && 0<=nextC && nextC<N)
            {
                if(Visited[nextR,nextC]==0 && Graph[nextR][nextC]==Graph[curR][curC])
                {
                    Visited[nextR,nextC]=1;
                    tmpDepth+=1;
                    Dfs(nextR,nextC);
                }
            }
        }
        
    }
}
