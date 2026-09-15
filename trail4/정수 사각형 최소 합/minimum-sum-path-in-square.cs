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
        N=int.Parse(Console.ReadLine());
        Dp=new int[N,N];

        Graph=new int[N][];
        for(int i=0;i<N;i++)
        {
            var line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[i]=line;
        }
        Calculate();
        Console.WriteLine(Dp[N-1,N-1]);

    }
    static void Calculate()
    {
        Dp[0,0]=Graph[0][N-1];
        for(int c=1;c<N;c++)
        {
            Dp[0,c]=Dp[0,c-1]+Graph[0][N-(c+1)];
        }
        for(int r=1;r<N;r++)
        {
            Dp[r,0]=Dp[r-1,0]+Graph[r][N-1];
        }

        for(int r=1;r<N;r++)
        {
            for(int c=1;c<N;c++)
            {
                Dp[r,c]=Math.Min(Dp[r-1,c]+Graph[r][N-(c+1)],Dp[r,c-1]+Graph[r][N-(c+1)]);
            }
        }

    }
}
