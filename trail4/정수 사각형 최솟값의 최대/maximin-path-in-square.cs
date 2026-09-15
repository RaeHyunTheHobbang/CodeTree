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
        for(int r=0;r<N;r++)
        {
            var line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Graph[r]=line;
        }
        Calculate();
        Console.WriteLine(Dp[N-1,N-1]);
    }

    static void Calculate()
    {
        Dp[0,0]=Graph[0][0];
        for(int r=1;r<N;r++)
        {
            Dp[r,0]=Math.Min(Dp[r-1,0],Graph[r][0]);
        }
        for(int c=1;c<N;c++)
        {
            Dp[0,c]=Math.Min(Dp[0,c-1],Graph[0][c]);
        }

        for(int r=1;r<N;r++)
        {
            for(int c=1;c<N;c++)
            {
                Dp[r,c]=Math.Min(Math.Max(Dp[r-1,c],Dp[r,c-1]),Graph[r][c]);
            }
        }

    }
}
