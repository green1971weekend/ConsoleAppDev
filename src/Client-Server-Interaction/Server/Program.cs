using System;
using ClientServer.BL;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ServerController();

            Console.WriteLine("Запуск сервера\n");
            Console.WriteLine("Ожидание входящих подключений...\n");

            controller.EstablishServerConnection();
        }
    }
}
