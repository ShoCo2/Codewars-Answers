//https://www.codewars.com/kata/551f23362ff852e2ab000037

using System;

public class PyramidSlideDown
{
    public static int LongestSlideDown(int[][] pyramid)
    {
        int LevelIndex = pyramid.Length - 1;
        int[] MaxRow = pyramid[LevelIndex];

        while (LevelIndex > 0)
        {
            int[] NewRow = new int[pyramid[LevelIndex - 1].Length];
            for (int i = 0; i < pyramid[LevelIndex - 1].Length; i++)
            {
                NewRow[i] = Math.Max(MaxRow[i], MaxRow[i + 1]);
                NewRow[i] += pyramid[LevelIndex - 1][i];
            }
            MaxRow = NewRow;
            LevelIndex--;
        }
        return MaxRow[0];
    }
}