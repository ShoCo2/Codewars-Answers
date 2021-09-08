//https://www.codewars.com/kata/5254ca2719453dcc0b00027d

using System.Collections.Generic;
using System.Linq;

class Permutations
{
    public static List<string> SinglePermutations(string s)
    {
        return Permute(s, 0).Distinct().ToList();
    }

    public static List<string> Permute(string s, int n)
    {
        if (s.Length == n) return new List<string>() { s };
        List<string> Res = new List<string>();

        for (int i = n; i < s.Length; i++)
        {
            char[] chars = s.ToCharArray();
            char c = s[0];
            chars[0] = s[i];
            chars[i] = c;
            s = new string(chars);
            Res.AddRange(Permute(s, n + 1));
        }
        return Res;
    }
}