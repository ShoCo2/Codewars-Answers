//https://www.codewars.com/kata/514b92a657cdc65150000006

public static class Kata
{
    public static int Solution(int value)
    {
        int Num3 = (value - 1) / 3, Num5 = (value - 1) / 5, Num15 = (value - 1) / 15;
        return Summation(Num3) * 3 + Summation(Num5) * 5 - Summation(Num15) * 15;
    }

    private static int Summation(int n)
    {
        return n * (n + 1) / 2;
    }
}
