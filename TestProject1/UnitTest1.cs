using System.Diagnostics;
using TestingWorkLib;

namespace TestProject1
{
    public class Tests
    {
        List<List<Point>> polygons = new List<List<Point>>
        {
            new List<Point> { new Point(0, 0), new Point(3, 0) },
            new List<Point> { new Point(0, 0), new Point(3, 0), new Point(0, 4) },
            new List<Point> { new Point(0, 0), new Point(2, (float)Math.Sqrt(3)), new Point(4, 0) },
            new List<Point> { new Point(0, 0), new Point(4, 0), new Point(4, 3), new Point(0, 3) },
            new List<Point> { new Point(0, 0), new Point(4, 0), new Point(5, 3), new Point(1, 3) },
            new List<Point> { new Point(0, 0), new Point(2, 1), new Point(3, 3), new Point(1, 4), new Point(-1, 3) },
            new List<Point> { new Point(1, 0), new Point(2, (float)Math.Sqrt(3)), new Point(1, 2 * (float)Math.Sqrt(3)), new Point(-1, 2 * (float)Math.Sqrt(3)), new Point(-2, (float)Math.Sqrt(3)), new Point(-1, 0) },
            new List<Point> { new Point(0, 0), new Point(2, 1), new Point(4, 0), new Point(5, 2), new Point(3, 4), new Point(1, 3), new Point(-1, 2) },
            new List<Point> { new Point(1, 0), new Point((float)Math.Sqrt(2)/2, (float)Math.Sqrt(2)/2), new Point(0, 1), new Point(-(float)Math.Sqrt(2)/2, (float)Math.Sqrt(2)/2), new Point(-1, 0), new Point(-(float)Math.Sqrt(2)/2, -(float)Math.Sqrt(2)/2), new Point(0, -1), new Point((float)Math.Sqrt(2)/2, -(float)Math.Sqrt(2)/2) },
            new List<Point> { new Point(0, 0), new Point(1, 2), new Point(3, 1), new Point(4, 3), new Point(6, 4), new Point(5, 6), new Point(3, 5), new Point(1, 4), new Point(-1, 3) },
            new List<Point> { new Point(0, 0), new Point(2, 1), new Point(3, 3), new Point(4, 5), new Point(3, 7), new Point(1, 8), new Point(-1, 7), new Point(-2, 5), new Point(-3, 3), new Point(-2, 1) },
        };



        [SetUp]
        public void Setup()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        public void Test1()
        {
            foreach (var poly in polygons)
            {
                var figure = new Figure(poly);

                var name = figure.GetFigureName();
                var square = Math.Round(figure.GetSquare(),3);
                var isRigth = figure.IsRightTriangle();

                Console.WriteLine($"Фигура:{name}\tПлощадь:{square}\tПрямоугольный треугольник:{isRigth}");
            }
            Assert.Pass();
        }
    }
}