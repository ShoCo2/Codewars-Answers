//https://www.codewars.com/kata/53d40c1e2f13e331fc000c26

using System.Numerics;
using System.Collections.Generic;
using System;
using System.Linq;

public class Fibonacci
{
    public static BigInteger fib(int n)
    {
        if (n == 0) return 0;
        List<BigInteger[,]> MatriceResults = new List<BigInteger[,]>();
        BigInteger[,] Initial = new BigInteger[,] { { 1, 0 } };
        MatriceResults.Add(new BigInteger[,] { { 1, 1 }, { 1, 0 } });

        int exp = (int)Math.Floor(Math.Log2(Math.Abs(n)));
        int Sign = n < 0 ? (n % 2 == 0 ? -1 : 1) : 1;
        n = Math.Abs(n);
        int m;
        List<int> Exponents = new List<int>();

        while (n != 0)
        {
            m = (int)Math.Pow(2, exp);
            if (m <= n)
            {
                Exponents.Add(exp);
                n -= m;
            }
            exp--;
        }
        exp = 0;

        int ResExp = Exponents.Max();

        while (exp != ResExp)
        {
            exp++;
            MatriceResults.Add(Multiply2Matrice(MatriceResults[exp - 1], MatriceResults[exp - 1]));
        }

        BigInteger[,] Sq = null;
        foreach (int i in Exponents)
        {
            if (Sq == null) Sq = MatriceResults[i];
            else Sq = Multiply2Matrice(MatriceResults[i], Sq);
        }

        Initial = Multiply2Matrice(Sq, Initial);

        return Initial[0, 1] * Sign;
    }

    private static BigInteger[,] Multiply2Matrice(BigInteger[,] a, BigInteger[,] b)
    {
        int bX = b.GetLength(0);
        BigInteger[,] Result = new BigInteger[bX, 2];
        for (int y = 0; y < a.GetLength(1); y++)
        {
            for (int x = 0; x < bX; x++)
            {
                for (int i = 0; i < 2; i++) Result[x, y] += a[i, y] * b[x, i];
            }
        }
        return Result;
    }
}