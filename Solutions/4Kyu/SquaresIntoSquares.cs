//https://www.codewars.com/kata/54eb33e5bc1a25440d000891

using System;
using System.Collections.Generic;
using System.Linq;

public class Decompose
{
    public string decompose(long n)
    {
        List<long> Longs = Decomp((long)Math.Pow(n, 2), n, new List<long>());
        if (Longs == null) return null;
        Longs.Sort();
        return String.Join(" ", Longs);
    }

    private List<long> Decomp(long ResultNum, long n, List<long> Nums)
    {
        long CurrentSum = (long)Nums.Select(x => Math.Pow(x, 2)).Sum();
        Console.WriteLine(CurrentSum);

        while (n > 0)
        {
            n--;
            long Sum = (long)(CurrentSum + Math.Pow(n, 2));
            if (ResultNum - Sum > 0)
            {
                Nums.Add(n);
                List<long> Longs = Decomp(ResultNum, n, Nums);
                if (Longs != null) return Longs;
                else Nums.Remove(n);
            }
            else if (ResultNum == Sum)
            {
                Nums.Add(n);
                return Nums;
            }
        }
        return null;
    }
}