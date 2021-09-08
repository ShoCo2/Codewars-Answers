//https://www.codewars.com/kata/57658bfa28ed87ecfa00058a

using System.Collections.Generic;
using System.Linq;
using System;

public class Finder 
{
    public static int PathFinder(string Input)
    {
        if (Input.Length == 1) return 0;
        int MazeSize = Input.IndexOf("\n");
        int HeightDelta = MazeSize + 1;
        Node[,] Maze = new Node[MazeSize, MazeSize];

        HashSet<Vector2Int> Positions = new HashSet<Vector2Int>();
        Vector2Int EndPos = new Vector2Int(MazeSize - 1, MazeSize - 1);
        List<Vector2Int> Neighbors = new List<Vector2Int>();
        Neighbors.Add(new Vector2Int(0, 1));
        Neighbors.Add(new Vector2Int(0, -1));
        Neighbors.Add(new Vector2Int(1, 0));
        Neighbors.Add(new Vector2Int(-1, 0));

        Positions.Add(new Vector2Int(0, 0));
        Maze[0, 0] = new Node();
        Maze[0, 0].SetCost(0, 0, EndPos);
        Maze[0, 0].G = 0;
        Vector2Int Current;

        while (Positions.Count > 0)
        {
            Current = new Vector2Int(-1, -1);
            Current = Positions.Aggregate(new Vector2Int(-1, -1), (Shortest, Next) =>
            Shortest.x != -1 && Maze[Shortest.x, Shortest.y].F < Maze[Next.x, Next.y].F ? Shortest : Next);
            Positions.Remove(Current);

            Maze[Current.x, Current.y].Evaluated = true;
            if (Current.Equals(EndPos)) return Maze[Current.x, Current.y].G;

            foreach (Vector2Int Dir in Neighbors)
            {
                Vector2Int P = Dir + Current;
                if (P.x < 0 || P.y < 0 || P.x >= MazeSize || P.y >= MazeSize) continue;

                char t = Input[P.x + P.y * HeightDelta];
                if (Maze[P.x, P.y] == null) Maze[P.x, P.y] = new Node();
                Node n = Maze[P.x, P.y];
                if (t == 'W' || n.Evaluated) continue;
                n.G = Maze[Current.x, Current.y].G + 1;
                Positions.Add(P);
            }
        }
        return -1;
    }

    public struct Vector2Int
    {
        public int x, y;
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            a.x += b.x;
            a.y += b.y;
            return a;
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            a.x -= b.x;
            a.y -= b.y;
            return a;
        }

        public bool Equals(Vector2Int a) => (x == a.x) && (y == a.y);
    }

    public class Node
    {
        private int g;
        public int G
        {
            get => g;
            set
            {
                g = value;
                F = g + H;
            }
        }
        public int H, F;
        public bool Evaluated = false;

        public void SetCost(int x, int y, Vector2Int EndPos) => H = Math.Abs(EndPos.x - x) + Math.Abs(EndPos.y - y);
    }
}