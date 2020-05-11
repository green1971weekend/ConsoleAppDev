using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer.BL
{
    /// <summary>
    ///  Класс клиент-контроллер, содержащий в себе настройки соединения с сервером.
    /// </summary>
    public class ClientController
    {
        readonly IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(Constants.HOST), Constants.PORT);
        readonly ServerController server_controller = new ServerController();

        /// <summary>
        /// Установка и работа клиентской части.
        /// </summary>
        public void EstablishClientConnection(string login)
        {
            try
            {
                server_controller.AddConnection(login);

                while (true)
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(end_point);

                    // Отправка сообщения серверу

                    Console.Write("Введите сообщение для отправки: ");
                    var message = Console.ReadLine();

                    var data = Encoding.UTF8.GetBytes($"{login} : {message}");
                    socket.Send(data);

                    // Получение сообщений от сервера

                    server_controller.ReceiveMessage(socket);

                    Console.WriteLine("Для выхода нажмите Y, для продолжения любую клавишу.");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Y)
                    {
                        server_controller.RemoveConnection(login);

                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
