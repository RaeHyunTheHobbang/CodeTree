using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int K;
    static int r;
    static int c;

    static int[][] Graph;

    public static void Main()
    {
        // Please write your code here.

        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        N=input[0];
        K=input[1];

        Graph=new int[N][];

        for(int i=0;i<N;i++)
        {
            var line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }
        input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        r=input[0];
        c=input[1];



        (int nextR,int nextC)=(r-1,c-1);
        for(int i=0;i<K;i++)
        {
            (int tmpR,int tmpC)=Bfs(nextR,nextC);
            if(tmpR==-1 && tmpC==-1)
            {   
                Console.WriteLine($"{nextR+1} {nextC+1}");
                return;
            }
            nextR=tmpR;
            nextC=tmpC;
        }
        Console.WriteLine($"{nextR+1} {nextC+1}");
    }

    static (int,int) Bfs(int startR,int startC)
    {   

        Queue<(int,int)> Q=new Queue<(int,int)>();

        int[] dx=new int[]{-1,1,0,0};
        int[] dy=new int[]{0,0,-1,1};
        
        List<(int,int)> visited=new List<(int,int)>();

        Q.Enqueue((startR,startC));
        visited.Add((startR,startC));

        int curMax=0;
        (int targetR,int targetC)=(-1,-1);
        while(Q.Count>0)
        {
            (int curR,int curC)=Q.Dequeue();
            for(int i=0;i<4;i++)
            {
                int tmpX=curR+dx[i];
                int tmpY=curC+dy[i];

                if(0<=tmpX && tmpX<N && 0<=tmpY && tmpY<N)
                {
                    if(!visited.Contains((tmpX,tmpY)) && Graph[tmpX][tmpY]<Graph[startR][startC])
                    {
                        visited.Add((tmpX,tmpY));
                        Q.Enqueue((tmpX,tmpY));          
                        if(Graph[tmpX][tmpY]>curMax)
                        {
                            targetR=tmpX;
                            targetC=tmpY;
                            curMax=Graph[tmpX][tmpY];

                        }
                        else if(Graph[tmpX][tmpY]==curMax)
                        {
                            if(tmpX<targetR)
                            {
                                targetR=tmpX;
                                targetC=tmpY;

                            }
                            else if(tmpX==targetR)
                            {
                                if(tmpY<targetC)
                                {
                                    targetR=tmpX;
                                    targetC=tmpY;

                                }
                            }
                        }
                        
                    }
                }
            }

        }

        return (targetR,targetC);
    }


}
