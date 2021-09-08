//https://www.codewars.com/kata/52685f7382004e774f0001f7

public static class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        int h = 0, m = 0;
        while (seconds >= 60)
        {
            m++;
            seconds -= 60;
        }
        while (m >= 60)
        {
            h++;
            m -= 60;
        }
        return $"{h:00}:{m:00}:{seconds:00}";
    }
}