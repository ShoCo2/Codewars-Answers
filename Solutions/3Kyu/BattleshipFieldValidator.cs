//https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7

namespace Solution
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            if (field.Cast<int>().Where(x => x == 1).Count() != 20) return false;
            List<Vector2Int> CheckedTiles = new List<Vector2Int>();
            List<int> ShipSizes = new List<int>();

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (CheckedTiles.Any(v => v.x == x && v.y == y)) continue;
                    CheckedTiles.Add(new Vector2Int(x, y));
                    if (field[x, y] == 0) continue;

                    int ShipLength = 1;
                    List<Vector2Int> FoundTiles = new List<Vector2Int>();
                    FoundTiles.Add(new Vector2Int(x, y));

                    do
                    {
                        Vector2Int Current = FoundTiles[0];
                        FoundTiles.Clear();
                        for (int iY = Current.y; iY <= Current.y + 1; iY++)
                        {
                            for (int iX = Current.x - 1; iX <= Current.x + 1; iX++)
                            {
                                if (iX != x && iY != y && ValidateIndex(iX, iY) && field[iX, iY] == 1) return false;
                                if (ValidateIndex(iX, iY) && field[iX, iY] == 1 && !CheckedTiles.Contains(new Vector2Int(iX, iY))) FoundTiles.Add(new Vector2Int(iX, iY));
                                CheckedTiles.Add(new Vector2Int(iX, iY));
                            }
                        }
                        if (FoundTiles.Count > 1) return false;
                        else if (FoundTiles.Count == 1)
                        {
                            ShipLength++;
                        }
                        else if (FoundTiles.Count == 0)
                        {
                            ShipSizes.Add(ShipLength);
                        }
                    } while (FoundTiles.Count == 1);
                }
            }

            int ShipCount = 1;
            for (int i = 4; i > 0; i--)
            {
                if (ShipSizes.Count(x => x == i) != ShipCount) return false;
                ShipCount++;
            }

            return true;
        }

        private static bool ValidateIndex(int x, int y) => !(x < 0 || x > 9 || y < 0 || y > 9);
    }

    public struct Vector2Int
    {
        public int x, y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}