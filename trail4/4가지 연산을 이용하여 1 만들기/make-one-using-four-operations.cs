using System;
using System.Collections.Generic;

public class Codetree
{   

    static int N;
    static List<int> Visited;
    public static void Main()
    {
        N=int.Parse(Console.ReadLine());
        Visited=new List<int>();
        Console.WriteLine(Bfs());
    }
    static int Bfs()
    {   
        Queue<(int,int)> Q=new Queue<(int,int)>();
        Q.Enqueue((N,0));
        Visited.Add(N);
        while(Q.Count>0)
        {
            (int curNum, int curCost)=Q.Dequeue();
            if(curNum==1)
            {
                return curCost;
            }
            for(int i=0;i<4;i++)
            {   
                if(i==2)
                {
                    if(curNum%2>0)
                    {
                        continue;
                    }
                }
                else if(i==3)
                {
                    if(curNum%3>0)
                    {
                        continue;
                    }
                }

                int tmp=calCase(i,curNum);
                if(!Visited.Contains(tmp))
                {
                    Visited.Add(tmp);
                    Q.Enqueue((tmp,curCost+1));
                }
            }
        }
        return -1;
        

    }
    static int calCase(int curCase,int curNum)
    {
        switch(curCase)
        {
            case 0:
                return curNum-1;
                
            case 1:
                return curNum+1;
            case 2:
                if(curNum%2==0)
                {
                    return curNum/2;
                }
                return 0;
                
            case 3:
                if(curNum%3==0)
                {
                    return curNum/3;
                }
                return 0;
            default:
                return -1;
        }
    }
}
