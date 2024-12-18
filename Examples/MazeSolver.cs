
namespace DSA_Examples.Examples
{
    internal class MazeSolver : Example
    {
        private enum Cell { Empty = ' ', Wall = '#', Start = 'S', End = 'E' }
        private Cell[,] maze;
        private int width => (int)Math.Sqrt(maze.Length);
        private int height => width;

        private struct Coord { public int x; public int y; }

        public Coord[] Solve()
        {
            Coord[] path = new Coord[width*height];
            Coord[] seen = new Coord[width*height];
            Coord start = new Coord { x=0,y=0 };

            bool walk(Coord pos)
            {
                if (seen.Contains(pos)) return false;

                seen.Append(pos);
                path.Append(pos);

                if (maze[pos.x, pos.y] == Cell.End) return true;
                if (maze[pos.x, pos.y] == Cell.Wall) return false;


            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (maze[j, i] == Cell.Start) start = new Coord { x = j, y = i };
                }
            }

            walk(start);
            return path;
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
                new Test<object?>("ToString",() => ToString(),null)
            };
        }
    }
}
