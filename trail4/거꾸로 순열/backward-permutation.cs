using System;
using System.Collections.Generic;

public class Codetree
{  
    static int n;
    public static void Main()
    {
        n=int.Parse(Console.ReadLine());
        Dfs(new List<int>());
    }
    static void Dfs(List<int> curNums)
    {
        if(curNums.Count==n)
        {
            Console.WriteLine(string.Join(" ",curNums));
            return;
        }

        for(int i=n;i>0;i--)
        {
            if(curNums.Contains(i))
            {
                continue;
            }
            curNums.Add(i);
            Dfs(curNums);
            curNums.RemoveAt(curNums.Count-1);
        }


    }
}
