using FigureCalc;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1 - Круг");
        Console.WriteLine("2 - Треугольник");
        Console.Write("Введите номер фигуры: ");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Введите радиус круга: ");
            if (double.TryParse(Console.ReadLine(), out double _circleRadius) && _circleRadius > 0)
            {
                Circle circle = new Circle("Circle", _circleRadius);
                Console.WriteLine($"Площадь круга: {circle.FigureCalc()}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Радиус должен быть положительным числом.");
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введите первую сторону треугольника: ");
            double one = double.Parse(Console.ReadLine());

            Console.Write("Введите вторую сторону треугольника: ");
            double two = double.Parse(Console.ReadLine());

            Console.Write("Введите третью сторону треугольника: ");
            double three = double.Parse(Console.ReadLine());

            try
            {
                Triangle triangle = new Triangle("Triangle", one, two, three);
                Console.WriteLine($"Площадь треугольника: {triangle.FigureCalc()}");

                if (triangle.IsRightTriangle())
                {
                    Console.WriteLine("Этот треугольник является прямоугольным.");
                }
                else
                {
                    Console.WriteLine("Этот треугольник не является прямоугольным.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, выберите 1 или 2.");
        }
    }
}
