using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ClientServer.BL;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ClientServerController();

            Console.WriteLine("Запуск сервера\n");
            Console.WriteLine("Ожидание входящих подключений...\n");

            controller.EstablishServerConnection();

        }
    }
}
