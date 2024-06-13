using System;

namespace Calculator
{
   class Program
   {
        static void Main(string[] args)
        {
            try
            {
                float firstNumber = GetNumberFromUser();
                char operation = GetOperationFromUser();
                float secondNumber = GetNumberFromUser();

                float result = operation switch
                {
                '+' => BasicCalculator.Add(firstNumber, secondNumber),
                '-' => BasicCalculator.Subtract(firstNumber, secondNumber),
                '*' => BasicCalculator.Multiply(firstNumber, secondNumber),
                '/' => BasicCalculator.Divide(firstNumber, secondNumber),
                _ => throw new InvalidOperationException("Invalid operation")
                };

                Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static float GetNumberFromUser()
        {
            while (true)
            {
                Console.Write("Please enter a number: ");
                string? userInput = Console.ReadLine();

                if (float.TryParse(userInput, out float number))
                {
                return number;
                }
                else
                {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public static char GetOperationFromUser()
        {
            while (true)
            {
                Console.Write("Please enter an operation (+, -, *, /): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
                {
                return operation;
                }
                else
                {
                Console.WriteLine("Invalid input. Please enter a valid operation.");
                }
            }
        }
   }

   class BasicCalculator
    {
        public static float Add(float a, float b)
        {
            return a + b;
        }

        public static float Subtract(float a, float b)
        {
            return a - b;
        }

        public static float Multiply(float a, float b)
        {
            return a * b;
        }

        public static float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by zero", nameof(b));
            }
            return a / b;
        }
    }
}
