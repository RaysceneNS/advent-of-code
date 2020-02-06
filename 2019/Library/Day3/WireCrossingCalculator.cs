using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library.Day3
{
    public class WireCrossingCalculator
    {
        public static int MinDistance(string path1, string path2)
        {
            var wire1Points = TracePath(path1);
            var wire2Points = TracePath(path2);
            
            var crossings = new List<Point>();
            System.Threading.Tasks.Parallel.ForEach(wire1Points, i =>
            {
                if (wire2Points.Contains(i))
                {
                    crossings.Add(i);
                }
            });


            int min = int.MaxValue;
            foreach (var p in crossings)
            {
                min = Math.Min(min, Math.Abs(p.X) + Math.Abs(p.Y));
            }
            return min;
        }


        public static int MinSteps(string path1, string path2)
        {
            var wire1Points = TracePath(path1);
            var wire2Points = TracePath(path2);

            var crossings = new List<Point>();
            System.Threading.Tasks.Parallel.ForEach(wire1Points, i =>
            {
                if (wire2Points.Contains(i))
                {
                    crossings.Add(i);
                }
            });



            int min = int.MaxValue;
            foreach (var p in crossings)
            {
                //calculate steps to reach crossing from either side
                var wire1Steps = wire1Points.IndexOf(p)+1;
                var wire2Steps = wire2Points.IndexOf(p)+1;

                min = Math.Min(min, wire1Steps+wire2Steps);
            }
            return min;
        }

        public static List<Point> TracePath(string path)
        {
            int x = 0, y = 0;

            var points = new List<Point>();

            foreach (var ipath in EnumeratePath(path))
            {
                switch (ipath.Item1)
                {
                    case Direction.Down:
                        {
                            var steps = y - ipath.Item2;
                            for (; y > steps; y--)
                            {
                                points.Add(new Point(x, y));
                            }
                        }
                        break;
                    case Direction.Up:
                        {
                            var steps = y + ipath.Item2;
                            for (; y < steps; y++)
                            {
                                points.Add(new Point(x, y));
                            }
                        }
                        break;
                    case Direction.Left:
                        {
                            var steps = x - ipath.Item2;
                            for (; x > steps; x--)
                            {
                                points.Add(new Point(x, y));
                            }
                        }
                        break;
                    case Direction.Right:
                        {
                            var steps = x + ipath.Item2;
                            for (; x < steps; x++)
                            {
                                points.Add(new Point(x, y));
                            }
                        }
                        break;
                }
            }

            //remove the central port point
            points.RemoveAt(0);

            return points;
        }

        private static IEnumerable<Tuple<Direction, int>> EnumeratePath(string path)
        {
            string[] parts = path.Split(',');
            foreach (string part in parts)
            {
                Direction direction;
                switch (part[0])
                {
                    case 'D':
                        direction = Direction.Down;
                        break;
                    case 'U':
                        direction = Direction.Up;
                        break;
                    case 'L':
                        direction = Direction.Left;
                        break;
                    case 'R':
                        direction = Direction.Right;
                        break;
                    default:
                        throw new ArgumentException("");
                }

                int distance = int.Parse(part.Substring(1));

                yield return new Tuple<Direction, int>(direction, distance);
            }
        }

        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
