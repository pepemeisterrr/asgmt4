using System;

namespace asgmt4
{
    internal class Program
    {
        public static int InputInt() //ввод целых чисел с обработкой исключений
        {
            string input = Console.ReadLine();
            int output = 0;
            bool parsed = int.TryParse(input, out output);
            while (!parsed)
            {
                Log.Error($"Invalid input. Entered \"{input}\" Try again...", 1);
                Log.Error("Please enter an integer", 1);
                Log.Input();
                input = Console.ReadLine();
                parsed = int.TryParse(input, out output);
            }
            return output;
        }
        public static void Task1() 
        {
            Log.Info("Task #1", 1);
            int size = 0;
            do
            {
                Log.Info("Input the size of array", 1);
                Log.Input();
                size = InputInt();
                if (size < 1) Log.Error($"{size} should be bigger than 0", 1);
            } while (size < 1);
            int n = 7;
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = n;
                Log.Num($"{n}", i, 1);
                n += 5;
            }

        }
        public static void Task2() 
        {
            Log.Info("Task #2", 1);
            int[] array1 = new int[11];
            int n = 1;
            for (int i = 0; i < 11; i++)
            {
                array1[i] = n;
                n *= 2;
            }
            Log.Info("Direct order", 1);
            for (int i = 0; i < 11; i++)
            {
                Log.Num($"{array1[i]}", i, 1);
            }
            Log.Info("Reverse order", 1);
            for (int i = 10; i >= 0; i--)
            {
                Log.Num($"{array1[i]}", i, 1);
            }
        }
        public static void Task3() 
        {
            Log.Info("Task #3", 1);
            int size = 0;
            do
            {
                Log.Info("Input the size of the char array", 1);
                Log.Input();
                size = InputInt();
                if (size < 1) Log.Error($"{size} should be bigger than 0", 1);
            } while (size < 1);
            char[] array = new char[size];
            string input;
            for (int i = 0; i < size; i++)
            {
                Log.Info($"#{i + 1}", 1);
                do 
                {
                    Log.Input();
                    input = Console.ReadLine();
                    if (input.Length != 1) Log.Error($"Input 1 character at time", 1);
                } while (input.Length != 1);

                array[i] = char.Parse(input);
            }
            char temp;
            for (int i = 0; i < (array.Length/2); i++)
            {
                temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
            Log.Info("Result", 1);
            for (int i = 0; i < size; i++)
                Log.Num($"{array[i]}", i, 1);
        }

        public static void Task4()
        {
            Log.Info("Task #4", 1);
            int size = 0;
            do
            {
                Log.Info("Input the size of the integer array", 1);
                Log.Input();
                size = InputInt();
                if (size < 1) Log.Error($"{size} should be bigger than 0", 1);
            } while (size < 1);
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Log.Info($"#{i + 1}", 1);
                Log.Input();
                array[i] = InputInt();
            }
            int positive = 0;
            int negative = 0;
            for (int i = 0;i < size; i++)
            {
                if (array[i] < 0) { negative++; }
                else { positive++;}
            }
            Log.Info($"{negative} negative elements", 1);
            Log.Info($"{positive} positive elements", 1);
        }

        public static void Main(string[] args)
        {
            ConsoleKeyInfo option;
            do
            {
                Log.Input("Select Task [1] - [4] or [esc] to exit >", 0);
                option = Console.ReadKey(true);
                Console.WriteLine();
                switch (option.Key)
                {
                    case ConsoleKey.D1: Task1(); break;
                    case ConsoleKey.D2: Task2(); break;
                    case ConsoleKey.D3: Task3(); break;
                    case ConsoleKey.D4: Task4(); break;

                    case ConsoleKey.NumPad1: Task1(); break;
                    case ConsoleKey.NumPad2: Task2(); break;
                    case ConsoleKey.NumPad3: Task3(); break;
                    case ConsoleKey.NumPad4: Task4(); break;

                    default:
                        if (option.Key != ConsoleKey.Escape)
                        {
                            Log.Error($"[{option.Key}] is out of range [1] to [4]", 1);
                        }
                        break;
                }
            } while (option.Key != ConsoleKey.Escape);
            Log.Info("Goodbye", 1);
        }   
    }
}
