
using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class MazeSolver : Example
    {
        private enum Cell { Empty = ' ', Wall = '#', Start = 'S', End = 'E' } // Symbol definitions for Cell types
        private Cell[,] maze;
        private int width => (int)Math.Sqrt(maze.Length);
        private int height => width;

        public struct Coord 
        { 
            public int x; public int y;

            public override string ToString()
            {
                return $"[{x}, {y}]";
            }
        }

        public Coord[] Solve() // Finds a valid path from start to end for maze, returns path as array of Coords        O(n^2)   
        {
            Stack<Coord> path = new Stack<Coord>();
            Stack<Coord> seen = new Stack<Coord>();
            Coord start = new Coord { x = 0, y = 0 };
            Coord[] dirs = new Coord[4] { new Coord { x = 0, y = 1 }, new Coord { x = 1, y = 0 }, new Coord { x = 0, y = -1 }, new Coord { x = -1, y = 0 } };

            bool walk(Coord pos) // Recursive function to walk the maze - Returns false for dead ends
            {
                if (seen.Contains(pos)) return false;

                seen.Push(pos);
                path.Push(pos);

                if (maze[pos.x, pos.y] == Cell.End) return true;
                if (maze[pos.x, pos.y] == Cell.Wall)
                {
                    path.Pop();
                    return false;
                }
                    
                foreach (Coord dir in dirs)
                {
                    if (walk(new Coord() { x = pos.x + dir.x, y = pos.y + dir.y })) return true;
                }

                return false;
            }

            for (int i = 0; i < height; i++) // Find start position
            {
                for (int j = 0; j < width; j++)
                {
                    if (maze[j, i] == Cell.Start) start = new Coord { x = j, y = i };
                }
            }

            walk(start);
            return path.Reverse().ToArray();
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < height; i++) 
            {
                str += "\n";
                for (int j = 0; j < width; j++) 
                {
                    str += (char)maze[j, i];
                }
            }

            return str;
        }
        public MazeSolver()
        {
            maze = new Cell[10,10]
            {
                { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall },
                { Cell.Wall, Cell.Start, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall },
                { Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.End, Cell.Wall },
                { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall }
            };

            Tests = new Test<object?>[]
            {
                new Test<object?>("ToString",() => ToString(),null),
                new Test<object?>("Solve",() => Solve(), new Coord[]
                {
                    new Coord { x = 1, y = 1 },
                    new Coord { x = 1, y = 2 },
                    new Coord { x = 1, y = 3 },
                    new Coord { x = 2, y = 3 },
                    new Coord { x = 3, y = 3 },
                    new Coord { x = 3, y = 4 },
                    new Coord { x = 3, y = 5 },
                    new Coord { x = 4, y = 5 },
                    new Coord { x = 5, y = 5 },
                    new Coord { x = 5, y = 6 },
                    new Coord { x = 5, y = 7 },
                    new Coord { x = 5, y = 8 },
                    new Coord { x = 6, y = 8 },
                    new Coord { x = 7, y = 8 },
                    new Coord { x = 8, y = 8 }
                }),
            };
        }
    }
}
