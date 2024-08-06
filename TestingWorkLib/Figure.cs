
namespace TestingWorkLib
{
    /*
     Расчет площади фигур на координатной плоскости.
    Причем для задания круга первая точка - это центр круга, а вторая лежит на окружности

    Настолько легко добавлять фигуры, что их не нужно добавлять ;)
    */

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Point(double x, double y) 
        {
            X = (float)x;
            Y = (float)y;
        }
    }

    public abstract class FigureBase
    {
        public List<Point> Points { get; set; }

        public abstract double GetSquare();
        public abstract bool IsRightTriangle();
        public abstract string GetFigureName();
    }

    public class Figure : FigureBase
    {
        public Figure(List<Point> points)
        {
            Points = points;
        }

        public override double GetSquare()
        {
            var pointsCount = Points.Count;
            double area = 0;
            if (pointsCount < 2)
            {
                throw new ArgumentException("Невозможно вычислить площадь точки");
            }
            // фигура - круг, где вторая точка лежит на окружности
            if (pointsCount == 2)
            {
                var radius = Math.Sqrt(DistanceSquared(Points[0], Points[1]));
                area = Math.PI * (radius * radius);
                return area;
            }

            for (int i = 0; i < pointsCount; i++)
            {
                var currentPoint = Points[i];
                var nextPoint = Points[(i + 1) % pointsCount];

                area += currentPoint.X * nextPoint.Y - nextPoint.X * currentPoint.Y;
            }

            return Math.Abs(area) / 2.0;
        }
        public override bool IsRightTriangle()
        {
            var count = Points.Count;
            if (count != 3)
            {
                return false;
            }

            double AB2 = DistanceSquared(Points[0], Points[1]);
            double BC2 = DistanceSquared(Points[1], Points[2]);
            double AC2 = DistanceSquared(Points[0], Points[2]);
            return IsPythagoreanTriplet(AB2, BC2, AC2);
        }

        public override string GetFigureName()
        {
            switch (Points.Count)
            {
                case 0:
                    return "Не фигура";
                case 1:
                    return "Точка";
                case 2:
                    return "Круг";
                case 3:
                    return "Треугольник";
                case 4:
                    return "Четырехугольник";
                default:
                    return $"{Points.Count}-тиугольник";
            }
        }
        private double DistanceSquared(Point p1, Point p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            return dx * dx + dy * dy;
        }
        private bool IsPythagoreanTriplet(double a2, double b2, double c2)
        {
            return (a2 + b2 == c2) || (a2 + c2 == b2) || (b2 + c2 == a2);
        }
    }

}
