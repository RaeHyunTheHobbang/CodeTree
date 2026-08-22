using System;
using System.Linq;
using System.Collections.Generic;

public class Codetree
{   
    static int N;
    static int Answer;
    static List<int[]> Lines;
    public static void Main()
    {
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        Lines=new List<int[]>();
        for(int i=0;i<N;i++)
        {
            var input=Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            Lines.Add(input);
        }

        List<int[]> curList=new List<int[]>();
        for(int i=0;i<N;i++)
        {   
            curList.Add(Lines[i]);
            Dfs(curList,i);
            curList.RemoveAt(0);
        }

        Console.WriteLine(Answer);
        
    }
    static void Dfs(List<int[]> curList,int lastIdx)
    {   
        Answer=Math.Max(curList.Count,Answer);
        for(int i=lastIdx+1;i<N;i++)
        {   

            if(CanInput(curList,Lines[i]))
            {
                curList.Add(Lines[i]);
                Dfs(curList,i);
                curList.RemoveAt(curList.Count-1);
            }

        }
    }

    static bool CanInput(List<int[]> curList ,int[] newCur)
    {
        foreach(int[] cur in curList)
        {
            if(!Check(cur,newCur))
            {
                return false;
            }
        }
        return true;
    }
    static bool Check(int[] c1,int[] c2)
    {
        (int x1,int y1)=(c1[0],c1[1]);
        (int x2,int y2)=(c2[0],c2[1]);       

        //안겹치는 경우
        if(y1<x2 || y2<x1)
        {
            return true;
        }

        return false;
    }
}
