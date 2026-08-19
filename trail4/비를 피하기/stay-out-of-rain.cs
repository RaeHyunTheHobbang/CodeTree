using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static (int N, int H, int M) curInput;
    static int[][] Graph;
    public static void Main()
    {
        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        curInput.N=input[0];
        curInput.H=input[1];
        curInput.M=input[2];

        Graph=new int[curInput.N][];
        
        for(int i=0;i<curInput.N;i++)
        {
            int[] line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }


        for(int r=0;r<curInput.N;r++)
        {   
            int[] printLine=new int[curInput.N];
            for(int c=0;c<curInput.N;c++)
            {
                if(Graph[r][c]==2)
                {
                    printLine[c]=Bfs(r,c);
                }
                else
                {
                    printLine[c]=0;    
                }

            }
            Console.WriteLine(string.Join(" ",printLine));
        }

    }

    static int Bfs(int startR,int startC)
    {
        Queue<(int R,int C,int Cost)> Q=new Queue<(int R,int C,int Cost)>();
        int[,] Visited=new int[curInput.N,curInput.N];
        int[] dr=new int[]{-1,1,0,0};
        int[] dc=new int[]{0,0,-1,1};

        Q.Enqueue((startR,startC,0));
        Visited[startR,startC]=1;
        while(Q.Count>0)
        {
            var curNode=Q.Dequeue();
            if(Graph[curNode.R][curNode.C]==3)
            {
                return curNode.Cost;
            }
            for(int i=0;i<4;i++)
            {
                int tr=curNode.R+dr[i];
                int tc=curNode.C+dc[i];
                if(0<=tr&& tr<curInput.N && 0<=tc && tc<curInput.N)
                {
                    if(Visited[tr,tc]==0 && Graph[tr][tc]!=1)
                    {       
                        Visited[tr,tc]=1;
                        Q.Enqueue((tr,tc,curNode.Cost+1));
                    }
                }
            }
        }

        return -1;
        

    }
}
