namespace ConsoleApp26
{
    using System;

    namespace UniversalDelegateCalculator
    {
        class Program
        {
            // Універсальний делегат для арифметичних операцій
            delegate T ArithmeticOperation<T>(T a, T b);

            // Метод для додавання
            static T Add<T>(T a, T b) where T : struct
            {
                dynamic x = a;
                dynamic y = b;
                return x + y;
            }

            // Метод для віднімання
            static T Subtract<T>(T a, T b) where T : struct
            {
                dynamic x = a;
                dynamic y = b;
                return x - y;
            }

            // Метод для множення
            static T Multiply<T>(T a, T b) where T : struct
            {
                dynamic x = a;
                dynamic y = b;
                return x * y;
            }

            // Метод для ділення
            static T Divide<T>(T a, T b) where T : struct
            {
                if (b.Equals(0))
                {
                    throw new DivideByZeroException("Ділення на нуль неможливе.");
                }
                dynamic x = a;
                dynamic y = b;
                return x / y;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Введіть перше число:");
                string input1 = Console.ReadLine();
                Console.WriteLine("Введіть друге число:");
                string input2 = Console.ReadLine();
                Console.WriteLine("Виберіть операцію (+, -, *, /):");
                string operation = Console.ReadLine();

                if (double.TryParse(input1, out double num1) && double.TryParse(input2, out double num2))
                {
                    ArithmeticOperation<double> selectedOperation;

                    switch (operation)
                    {
                        case "+":
                            selectedOperation = Add;
                            break;
                        case "-":
                            selectedOperation = Subtract;
                            break;
                        case "*":
                            selectedOperation = Multiply;
                            break;
                        case "/":
                            selectedOperation = Divide;
                            break;
                        default:
                            Console.WriteLine("Некоректна операція.");
                            return;
                    }

                    try
                    {
                        double result = selectedOperation(num1, num2);
                        Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Потрібно було ввести коректні числа.");
                }
            }
        }
    }

}
