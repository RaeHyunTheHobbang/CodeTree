using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{  

    static (int N, int K) input;
    static (int R,int C) Start;
    static (int R,int C) End;
    static int[][] Graph;
    public static void Main()
    {
        // Please write your code here.
        var tmp=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
        input.N=tmp[0];
        input.K=tmp[1];
        Graph=new int[input.N][];
        
        for(int i=0;i<input.N;i++)
        {
            var line=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }
        tmp=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
        Start.R=tmp[0]-1;
        Start.C=tmp[1]-1;

        tmp=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
        End.R=tmp[0]-1;
        End.C=tmp[1]-1;
        int Answer=Bfs();
        Console.WriteLine(Answer);
        
    }

    static int Bfs()
    {


            bool[,,] Visited=new bool[input.K+1,input.N,input.N];
            Queue<(int R,int C,int Cost,int K)> Q=new Queue<(int R,int C,int Cost,int K)>();

            int[] dr=new int[]{-1,1,0,0};
            int[] dc=new int[]{0,0,-1,1};

            Q.Enqueue((Start.R,Start.C,0,input.K));
            Visited[input.K,Start.R,Start.C]=true;

            while(Q.Count>0)
            {
                (int curR,int curC,int curCost,int curK)=Q.Dequeue();

                if(curR==End.R && curC==End.C)
                {
                    return curCost;
                }

                for(int i=0;i<4;i++)
                {
                    int tr=curR+dr[i];
                    int tc=curC+dc[i];
                    if(0<=tr && tr<input.N && 0<=tc && tc<input.N)
                    {   

                        //벽이 있는 경우 
                        if(Graph[tr][tc]==1)
                        {
                            if(curK>0 && Visited[curK-1,tr,tc]==false)
                            {
                                Visited[curK-1,tr,tc]=true;
                                Q.Enqueue((tr,tc,curCost+1,curK-1));
                            }
                        }
                        else
                        {
                            if(Visited[curK,tr,tc]==false)
                            {
                                Visited[curK,tr,tc]=true;
                                Q.Enqueue((tr,tc,curCost+1,curK));
                            }
                        }
                    }
                }

            }

            return -1;
        



    }
}
