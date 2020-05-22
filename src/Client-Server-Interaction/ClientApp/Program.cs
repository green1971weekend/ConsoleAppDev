using System;
using ClientServer.BL;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ClientController();

            Console.WriteLine("Вас приветствует приложение Client\n");
            Console.Write("Введите ваш логин: ");
            string login = Console.ReadLine();

            controller.EstablishClientConnection(login);


            
            
        }

    }
}
