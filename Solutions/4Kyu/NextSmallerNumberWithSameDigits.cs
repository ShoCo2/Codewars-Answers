//https://www.codewars.com/kata/5659c6d896bc135c4c00021e

using System;
using System.Linq;

public class Kata
{
    public static long NextSmaller(long number)
    {
        if (number < 10) return -1;
        string s = number.ToString();
        int Smallest = 9, Largest = -1;
        int x = -1, y = -1;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] - '0' > Smallest)
            {
                x = i;
                break;
            }
            else
            {
                Smallest = s[i] - '0' < Smallest ? s[i] - '0' : Smallest;
            }
        }
        if (x == -1) return -1;

        for (int i = x + 1; i < s.Length; i++)
        {
            if (s[i] - '0' > Largest && s[i] - '0' < s[x] - '0')
            {
                Largest = s[i] - '0';
                y = i;
            }
        }
        if (y == -1 || (x == 0 && s[y] - '0' == 0)) return -1;

        char Temp = s[x];
        char[] TempString = s.ToCharArray();
        TempString[x] = s[y];
        TempString[y] = Temp;
        s = new string(TempString);

        char[] Sorted = s.ToCharArray().Skip(x + 1).OrderByDescending(c => c).ToArray();
        s = s.Substring(0, x + 1) + new string(Sorted);

        return Int64.Parse(s) != number ? Int64.Parse(s) : -1;
    }
}