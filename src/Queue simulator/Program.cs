using System;
using System.Threading;

namespace Queue_simulator
{ 
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++) // Создаем 3 быстрых кассы
            {
                var counter = new FastCheckoutCounter(i + 1, DisplayGreenHandler);

                var thread = new Thread(new ThreadStart(counter.CounterWork)); // Создаем поток работы быстрой кассы
                thread.Priority = ThreadPriority.AboveNormal;
                thread.Start();
            }

            for (int i = 0; i < 10; i++) // Создаем 10 обычных касс
            {
                var counter = new CheckoutCounter(i + 1, DisplayHandler);

                var thread = new Thread(new ThreadStart(counter.CounterWork)); // Создаем поток работы кассы
                thread.Start();

            }  
        }

        /// <summary>
        /// Обработчик уведомления обычной кассы
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void DisplayHandler(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Обработчик уведомления быстрой кассы
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void DisplayGreenHandler(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
