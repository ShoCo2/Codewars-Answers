//https://www.codewars.com/kata/546d15cebed2e10334000ed9

using System.Collections.Generic;
using System.Linq;
using System;

public class Runes
{
    public static int solveExpression(string expression)
    {
        char[] Operators = { '+', '-', '*' };
        int OperatorPos = expression.Substring(1).IndexOfAny(Operators) + 1;
        string fNum = expression.Substring(0, OperatorPos);
        string sNum = expression.Substring(OperatorPos + 1, expression.IndexOf('=') - OperatorPos - 1);
        string result = expression.Substring(expression.IndexOf('=') + 1, expression.Length - expression.IndexOf('=') - 1);

        List<int> UsedInts = expression.ToCharArray().Where(c => Char.IsNumber(c)).Select(c => Convert.ToInt32(c.ToString())).Distinct().ToList();

        for (int i = 0; i < 10; i++)
        {
            if (UsedInts.Contains(i)) continue;

            long FirstNum, SecondNum, ResultNum;
            if (Int64.TryParse(ReplaceChars(fNum, i), out FirstNum) &&
                Int64.TryParse(ReplaceChars(sNum, i), out SecondNum) &&
                Int64.TryParse(ReplaceChars(result, i), out ResultNum))
            {
                switch (expression[OperatorPos])
                {
                    case '+':
                        if (FirstNum + SecondNum == ResultNum) return i;
                        break;

                    case '-':
                        if (FirstNum - SecondNum == ResultNum) return i;
                        break;

                    case '*':
                        if (FirstNum * SecondNum == ResultNum) return i;
                        break;
                }
            }
        }
        return -1;
    }

    private static string ReplaceChars(string s, int number)
    {
        char[] chars = s.ToCharArray();
        bool IsFirstChar = false;
        bool EncounteredDigit = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (IsFirstChar) return null;
            if (s[i] == '?')
            {
                if (!EncounteredDigit && number == 0) IsFirstChar = true;

                chars[i] = (char)(number + '0');
            }
            else if (Char.IsNumber(s[i]))
            {
                EncounteredDigit = true;
            }
        }
        return new string(chars);
    }
}