using System;
using System.Linq;
using System.Collections.Generic;
public class Codetree
{   

    static int N;
    static List<List<int>> Graph;
    static List<int> colList;

    static int Answer;
    public static void Main()
    {   
        N=int.Parse(Console.ReadLine());
        Graph=new List<List<int>>();
        

        colList=Enumerable.Repeat(0,N).ToList();

        Answer=0;

        for(int i=0;i<N;i++)
        {
            var Line=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToList();
            Graph.Add(Line);
        }
        Dfs();
        Console.WriteLine(Answer);
    }

    static void Dfs(int cur_ans=0,int curDepth=0)
    {
        if(curDepth==N)
        {   

            Answer=Math.Max(Answer,cur_ans);

            return;
        }


        for(int c=0;c<N;c++)
        {   
            if(colList[c]==0)
            {   
                
                colList[c]=1;
                Dfs(cur_ans+Graph[curDepth][c],curDepth+1);
                colList[c]=0;
            }


        }
    
    }
}
