//https://www.codewars.com/kata/546f922b54af40e1e90001da

using System;
using System.Linq;

public static class Kata
{
    public static string AlphabetPosition(string text)
    {
        return string.Join(" ", text.ToLower().Where(Char.IsLetter).Select(x => x - 'a' + 1));
    }
}