//https://www.codewars.com/kata/530e15517bc88ac656000716

using System.Linq;

public class Kata
{
    public static string Rot13(string message)
    {
        return new string(message.ToCharArray().Select(
          c => c = ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) ?
            ((c >= 'A' && c <= 'Z') ? (char)(((c - 52) % 26) + 65) : (char)(((c - 84) % 26) + 97)) : c).ToArray());
    }
}
