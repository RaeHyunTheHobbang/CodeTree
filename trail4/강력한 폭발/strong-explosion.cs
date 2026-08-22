using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int Answer=0;
    static int [][] Graph;
    static List<(int,int)> BombList;

    public static void Main()
    {
        N=int.Parse(Console.ReadLine());
        Graph=new int[N][];
        BombList=new List<(int,int)>();
        for(int r=0;r<N;r++)
        {
            var line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            for(int c=0;c<N;c++)
            {
                if(line[c]==1)
                {
                    BombList.Add((r,c));
                }
            }
            
            Graph[r]=line;
        }
        Dfs();
        Console.WriteLine(Answer);
    }
    static void Dfs(int curDepth=0)
    {
        if(curDepth==BombList.Count)
        {   
            int tmp=0;
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if(Graph[i][j]>=1)
                    {
                        tmp+=1;
                    }
                }
            }
            Answer=Math.Max(Answer,tmp);
            return;
        }

        (int curR,int curC)=BombList[curDepth];

        for(int curCase=0;curCase<3;curCase++)
        {
            SetBomb(curR,curC,curCase,true);
            Dfs(curDepth+1);
            SetBomb(curR,curC,curCase,false);
        }

    }

    static void SetBomb(int r,int c,int curCase,bool isSet=true)
    {               
        int[] tmpR;
        int[] tmpC;
        switch(curCase)
        {   
            case 0:
                foreach(int dr in new int[]{-2,-1,1,2})
                {
                    if(0<=r+dr && r+dr<N)
                    {
                        Graph[r+dr][c]+=isSet? 1:-1;
                    }
                }
                return;
            case 1:
                tmpR=new int[]{-1,1,0,0};
                tmpC=new int[]{0,0,-1,1};
                for(int i=0;i<4;i++)
                {

                    (int dr,int dc)=(tmpR[i],tmpC[i]);
                    if(0<=r+dr && r+dr<N && 0<=c+dc && c+dc<N)
                    {
                        Graph[r+dr][c+dc]+=isSet? 1:-1;
                    }
                    
                }
                return;
            case 2:
                tmpR=new int[]{-1,-1,1,1};
                tmpC=new int[]{-1,1,-1,1};
                for(int i=0;i<4;i++)
                {

                    (int dr,int dc)=(tmpR[i],tmpC[i]);
                    if(0<=r+dr && r+dr<N && 0<=c+dc && c+dc<N)
                    {
                        Graph[r+dr][c+dc]+=isSet? 1:-1;
                    }
                    
                }
                return;

            default:

                return;

        }

    }


}
