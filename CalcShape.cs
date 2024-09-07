namespace FigureCalc
{
    public abstract class Shape
    {
        public string FigureName { get; set; }

        public Shape(string figureName)
        {
            FigureName = figureName;
        }

        public abstract double FigureCalc();
    }

    public class Circle : Shape
    {
        public double CircleRadius { get; set; }

        public Circle(string figureName, double _circleRadius) : base(figureName)
        {
            CircleRadius = _circleRadius;
        }

        public override double FigureCalc()
        {
            return Math.Round(Math.PI * Math.Pow(CircleRadius, 2), 2);
        }
    }

    public class Triangle : Shape
    {
        public double One { get; private set; }
        public double Two { get; private set; }
        public double Three { get; private set; }

        public Triangle(string figureName, double _one, double _two, double _three) : base(figureName)
        {
            if (IsValidTriangle(_one, _two, _three))
            {
                One = _one;
                Two = _two;
                Three = _three;
            }
            else
            {
                throw new ArgumentException("Неверные данные.");
            }
        }

        private bool IsValidTriangle(double one, double two, double three)
        {
            return (one + two > three) && (one + three > two) && (two + three > one) && (one > 0) && (two > 0) && (three > 0);
        }

        public override double FigureCalc()
        {
            double p = (One + Two + Three) / 2;
            double result = Math.Sqrt(p * (p - One) * (p - Two) * (p - Three));
            return Math.Round(result, 2);
        }

        public bool IsRightTriangle()
        {
            double maxSide = Math.Max(One, Math.Max(Two, Three));
            double otherSide1, otherSide2;

            if (maxSide == One)
            {
                otherSide1 = Two;
                otherSide2 = Three;
            }
            else if (maxSide == Two)
            {
                otherSide1 = One;
                otherSide2 = Three;
            }
            else
            {
                otherSide1 = One;
                otherSide2 = Two;
            }

            return Math.Abs(Math.Pow(maxSide, 2) - (Math.Pow(otherSide1, 2) + Math.Pow(otherSide2, 2))) < 0.0001;
        }
    }
}
