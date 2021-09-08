//https://www.codewars.com/kata/523a86aa4230ebb5420001e1

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static List<string> Anagrams(string Orig, List<string> Inputs)
    {
        char[] Original = Orig.ToCharArray();
        Array.Sort(Original);
        List<string> Result = new List<string>();

        foreach (string word in Inputs)
        {
            char[] Arr = word.ToCharArray();
            Array.Sort(Arr);
            if (Enumerable.SequenceEqual(Original, Arr)) Result.Add(word);
        }
        return Result;
    }
}