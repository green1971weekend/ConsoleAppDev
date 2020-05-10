using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ClientServer.BL;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ClientServerController();

            Console.WriteLine("Вас приветствует приложение Client\n");

            controller.EstablishClientConnection();
        }

    }
}
