//https://www.codewars.com/kata/51fda2d95d6efda45e00004e

using System;
using System.Linq;

public class User
{
    private static readonly int[] Ranks = Enumerable.Range(-8, 17).Where(n => n != 0).ToArray();
    private int rankIndex;

    public int rank
    {
        get => Ranks[rankIndex];
        set
        {
            rankIndex = Array.IndexOf(Ranks, value);
            if (rankIndex == -1) throw new ArgumentException();
        }
    }

    private int Progress;
    public int progress
    {
        get => Progress;
        set
        {
            Progress = value;
            if (Progress >= 100)
            {
                while (Progress >= 100)
                {
                    Progress -= 100;
                    rankIndex = Math.Clamp(rankIndex + 1, 0, Ranks.Length - 1);
                }
            }
            if (rankIndex == Ranks.Length - 1) Progress = 0;
        }
    }

    public User()
    {
        rankIndex = 0;
    }

    public void incProgress(int compRank)
    {
        int compIndex = Array.IndexOf(Ranks, compRank);
        if (compIndex == -1) throw new ArgumentException();
        int rankDiff = compIndex - rankIndex;
        if (rankDiff <= -2) return;
        else if (rankDiff == -1) progress += 1;
        else if (rankDiff == 0) progress += 3;
        else
        {
            progress += 10 * rankDiff * rankDiff;
        }
    }
}