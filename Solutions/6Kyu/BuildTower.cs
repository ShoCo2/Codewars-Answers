//https://www.codewars.com/kata/576757b1df89ecf5bd00073b

public class Kata
{
    public static string[] TowerBuilder(int nFloors)
    {
        string[] t = new string[nFloors];
        int spaces = 0;
        for (int i = nFloors - 1; i >= 0; i--)
        {
            int sCount = 1 + i * 2;
            t[i] = "";
            for (int x = 0; x < sCount; x++) t[i] += "*";
            for (int y = 0; y < spaces; y++) t[i] = " " + t[i] + " ";
            spaces++;
        }
        return t;
    }
}