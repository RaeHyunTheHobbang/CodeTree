using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   static int N;
    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        
        Console.WriteLine(Fibonacci());
    }

    static int Fibonacci()
    {
        
        if(N==1)
        {
            return 1;
        }
        else if(N==2)
        {
            return 1;
        }
        List<int> Info=new List<int>(){0,1,1};

        for(int i=3;i<=N;i++)
        {
            Info.Add(Info[i-2]+Info[i-1]);
        }

        return Info[Info.Count-1];


        
    }
}
