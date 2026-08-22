using System;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int Answer;
    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        Answer=0;
        Dfs();
        Console.WriteLine(Answer);
    }

    static void Dfs(int curDepth=0)
    {   
        if(curDepth>N)
        {
            return;
        }
        else if(curDepth==N)
        {
            Answer+=1;
            return;
        }

        for(int i=1;i<=4;i++)
        {
            Dfs(curDepth+i);
        }
    }
}
