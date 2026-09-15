using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{  

    static int N;
    static int[][] Graph;
    static int[,] Dp;

    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        Graph=new int[N][];
        Dp=new int[N,N];

        for(int i=0;i<N;i++)
        {
            var cur=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=cur;
        }
        Calculate();
        Console.WriteLine(Dp[N-1,N-1]);
    }


    static void Calculate()
    {   
        Dp[0,0]=Graph[0][0];
        for(int r=1;r<N;r++)
        {
            Dp[r,0]=Dp[r-1,0]+Graph[r][0];
        }
        for(int c=1;c<N;c++)
        {
            Dp[0,c]=Dp[0,c-1]+Graph[0][c];
        }

        for(int r=1;r<N;r++)
        {
            for(int c=1;c<N;c++)
            {
                Dp[r,c]=Math.Max(Dp[r-1,c]+Graph[r][c],Dp[r,c-1]+Graph[r][c]);
            }
        }
    }
    

    
}
