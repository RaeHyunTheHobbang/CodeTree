using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int M;
    static int[][] Graph;
    static int answer=0;

    public static void Main()
    {
        // Please write your code here.
        int[] tmp=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        N=tmp[0];
        M=tmp[1];

        Graph=new int[N][];

        for(int i=0;i<N;i++)
        {
            var line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }

        int maxK=N;

        for(int r=0;r<N;r++)
        {
            for(int c=0;c<N;c++)
            {
 
                for(int k=0;k<=maxK;k++)
                {   
                    
                    Calculate(k,r,c);
                    
                }
                    
            }
        }
        Console.WriteLine(answer);
    }


    static void Calculate(int k,int r,int c)
    {

        if(k==0)
        {   
            if(0<=r && r<N && 0<=c && c<N)
            {
                if(Graph[r][c]==1)
                {   
                    
                    answer=Math.Max(answer,1);
                    
                    
                }
            }

        }
        else
        {   
            int curNum=0;

            for(int tr=-k;tr<=k;tr++)
            {
                if(tr<0)
                {
                    for(int tc=-1*(tr+k);tc<=tr+k ;tc++)
                    {   

                        int curR=r+tr;
                        int curC=c+tc;
                        if(0<=curR && curR<N && 0<=curC && curC<N)
                        {   

                            if(Graph[curR][curC]==1)
                            {
                                curNum+=1;
                            }
                        }
                    }
                }
                else
                {
                    for(int tc=(tr-k);tc<=-1*(tr-k);tc++)
                    {   

                        int curR=r+tr;
                        int curC=c+tc;
                        if(0<=curR && curR<N && 0<=curC && curC<N)
                        {   

                            if(Graph[curR][curC]==1)
                            {
                                curNum+=1;
                            }
                        }
                    }
                }

            }

            if(CostCal(k,curNum))
            {
                answer=Math.Max(answer,curNum);
            }
        }
    }

    static bool CostCal(int k,int goldNum)
    {
        double cost=Math.Pow(k,2)+Math.Pow((k+1),2);
        double benefit=goldNum*M;

        return (benefit-cost)>=0;
    }
}
