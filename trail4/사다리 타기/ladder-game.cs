using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int M;
    static List<List<int>> Info;
    static List<int> Nums;
    static List<List<int>> currentNums;

    static List<int> Target;
    static int Answer=int.MaxValue;

    public static void Main()
    {   

        var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToList();
        N=input[0];
        M=input[1];

        Nums=Enumerable.Range(1,N).ToList();
        Info=new List<List<int>>();
        currentNums=new List<List<int>>();

        for(int i=0;i<M;i++)
        {
            input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToList();
            Info.Add(input);
        }
        
        foreach(List<int> curInput in Info.OrderBy(x=>x[1]).ToList())
        {
            int startCol=curInput[0]-1;
            int temp=Nums[startCol];
            Nums[startCol]=Nums[startCol+1];
            Nums[startCol+1]=temp;
        }

        Target=new List<int>(Nums);
        if(Target.SequenceEqual(Enumerable.Range(1,N).ToList()))
        {
            Console.WriteLine(0);
        }
        else
        {
            foreach(List<int> curInput in Info.OrderByDescending(x=>x[1]).ToList())
            {
                int startCol=curInput[0]-1;
                int temp=Nums[startCol];
                Nums[startCol]=Nums[startCol+1];
                Nums[startCol+1]=temp;
            }

            Dfs(0);
            Console.WriteLine(Answer);
        }

    }

    static void Dfs(int curDepth)
    {   
        if(curDepth>0)
        {
            foreach(List<int> curInput in currentNums.OrderBy(x=>x[1]).ToList())
            {
                int startCol=curInput[0]-1;
                int temp=Nums[startCol];
                Nums[startCol]=Nums[startCol+1];
                Nums[startCol+1]=temp;
            }

            if(Nums.SequenceEqual(Target))
            {
                Answer=Math.Min(Answer,currentNums.Count);
            }

            foreach(List<int> curInput in currentNums.OrderByDescending(x=>x[1]).ToList())
            {
                int startCol=curInput[0]-1;
                int temp=Nums[startCol];
                Nums[startCol]=Nums[startCol+1];
                Nums[startCol+1]=temp;
            }

        }
        for(int i=curDepth;i<M; i++)
        {
            currentNums.Add(Info[i]);
            Dfs(i+1);
            currentNums.RemoveAt(currentNums.Count-1);
        }
    }


}
