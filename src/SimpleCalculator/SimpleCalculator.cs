using System;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static double first_number_input;
        static double second_number_input;
        static double result;
        static bool check_action_symbol;

        static void Main(string[] args)
        {

            Console.WriteLine("Input the first number"); //ввод первого числа с проверкой на подлинность числа
            while (!Double.TryParse(Console.ReadLine(), out first_number_input)) // если цикл while принимает значение false от ввода символа, создает новый цикл с просьбой ввмести число
            {
                Console.WriteLine("You have inputted an invalid symbol, please input the digital value");
            }

            Console.WriteLine("Input the second number");//ввод второго числа с проверкой на подлинность числа
            while (!Double.TryParse(Console.ReadLine(), out second_number_input))
            {
                Console.WriteLine("You have inputted an invalid symbol, please input the digital value");
            }
       
            do // благодоря циклу do while проверяется подлинность введенного знака действия, если знак действия неверен - цикл повторяется с новым запросом на ввод
            {
                check_action_symbol = true; // булевой флаг, благодоря которому цикл while понимает повторять оператор do или нет
                Console.WriteLine("Choose, wich action do you want to commit: +, -, *, /");
                string input_action = Console.ReadLine();
                switch (input_action) // конструкция switch в которой прописаны все случаи введения того или иного математического знака и присвоение переменной result соответвенной операции
                {
                    case "+":
                        result = first_number_input + second_number_input;
                        break;
                    case "-":
                        result = first_number_input - second_number_input;
                        break;
                    case "*":
                        result = first_number_input * second_number_input;
                        break;
                    case "/":
                        result = first_number_input / second_number_input;
                        break;
                    default:
                        check_action_symbol = false; // если булевой флаг указывает false следовательно цикл while примет это и цикл do повторит итерацию
                        Console.WriteLine("You have inputted an invalid symbol, please input wich action you want to commit +, -, *, /");
                        break;
                }
            }    while (!check_action_symbol);

            Console.WriteLine($"Your answer is {result}");
            Console.ReadKey();
        }
    }
}
