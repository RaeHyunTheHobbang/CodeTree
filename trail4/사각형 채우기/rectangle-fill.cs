using System;

public class Codetree
{  

    static int N;
    static int[] DP;
    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        if(N<=3)
        {
            Console.WriteLine(N);
            return;
        }
        DP=new int[N];
        for(int i=0;i<=3;i++)
        {
            DP[i]=i+1;
        }


        Calculate();

        Console.WriteLine(DP[N-1]);
        

    }

    static void Calculate()
    {
        for(int i=3;i<N;i++)
        {
            DP[i]=(DP[i-1]+DP[i-2])%10007;
        }
        
        return;
    }
}
