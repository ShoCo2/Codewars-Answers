//https://www.codewars.com/kata/557f6437bf8dcdd135000010

using System.Collections.Generic;

public class Kata
{
    public static string Factorial(int n)
    {
        if (n < 1) return null;
        BigInt Result = new BigInt(1);

        while (n > 1) Result *= n--;

        return Result.ToString();
    }

    private struct BigInt
    {
        public int Size;
        public int[] Number;

        public BigInt(int n)
        {
            Size = 1;
            Number = new int[999];
            Number[0] = n;
        }

        public static BigInt operator *(BigInt b, int n)
        {
            int Carry = 0;
            for (int i = 0; i < b.Size; i++)
            {
                int Product = b.Number[i] * n + Carry;
                b.Number[i] = Product % 10;
                Carry = Product / 10;
            }

            while (Carry > 0)
            {
                b.Number[b.Size] = Carry % 10;
                Carry /= 10;
                b.Size++;
            }

            return b;
        }

        public override string ToString()
        {
            string Res = "";
            for (int i = Size - 1; i >= 0; i--) Res += Number[i].ToString();
            return Res;
        }
    }
}