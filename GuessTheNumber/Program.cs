using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Guess the Number!");
            Console.WriteLine("-----------------------------");

            do
            {
                Console.WriteLine("I'm thinking of a number between 1 and 100.");
                Console.WriteLine("--------------------------------------------");

                int number = Game.GetRandomNumber();
                int guess = 0;
                int attempts = 0;

                do
                {
                    guess = Game.GetUserGuess();
                    attempts++;
                    Game.CheckGuess(guess, number);
                } while (guess != number);

                Console.WriteLine($"Congratulations! You guessed the number in {attempts} attempts.");
                Console.WriteLine("Thanks for playing!");

            } while (Game.PlayAgain());
        }
    }

    class Game
    {
        // Random number generator
        private static readonly Random random = new Random();

        public static int GetRandomNumber()
        {
            return random.Next(1, 101);
        }

        public static int GetUserGuess()
        {
            int guess = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter your guess: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out guess) && guess >= 1 && guess <= 100)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                }
            }

            return guess;
        }

        public static void CheckGuess(int guess, int number)
        {
            if (guess == number)
            {
                Console.WriteLine("You guessed the number!");
            }
            else if (guess > number)
            {
                Console.WriteLine("The number is lower than your guess.");
            }
            else
            {
                Console.WriteLine("The number is higher than your guess.");
            }
        }

        public static bool PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again? (y/n): ");
                string? input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    return true;
                }
                else if (input == "n" || input == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                }
            }
        }
    }
}
