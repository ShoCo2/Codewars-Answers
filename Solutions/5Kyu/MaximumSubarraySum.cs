//https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c

using System.Linq;
using System;

public static class Kata
{
    public static int MaxSequence(int[] arr)
    {
        if (arr.Length == 0) return 0;

        int MaxSum = 0, CurrentSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            int n = arr[i];
            if (n > 0 && n > (n + CurrentSum)) CurrentSum = n;
            else CurrentSum += n;
            MaxSum = CurrentSum > MaxSum ? CurrentSum : MaxSum;
        }
        return MaxSum;
    }
}