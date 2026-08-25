using System;

//(a+b)modM=((amodM)+(bmodM))modM

public class Codetree
{   static int N;
    public static void Main()
    {       
        // Please write your code here.
        N=int.Parse(Console.ReadLine());
        
        Console.WriteLine(Dfs(N)%10007);
    }

    static int Dfs(int curStep)
    {   
        if(curStep<=1)
        {
            return 0;
        }
        else if(curStep<=3)
        {
            return 1;
        }

        int[] stepNums=new int[curStep+1];
        
        stepNums[2]=1;
        stepNums[3]=1;

        for(int i=4;i<=curStep;i++)
        {
            stepNums[i]=stepNums[i-2]%10007+stepNums[i-3]%10007;
        }

        return stepNums[curStep]%10007;
    }
}
