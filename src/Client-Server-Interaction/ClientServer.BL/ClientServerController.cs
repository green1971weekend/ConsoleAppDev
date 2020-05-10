using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer.BL
{
    public class ClientServerController
    {
        const string HOST = "127.0.0.1";
        const int PORT = 8080;
        readonly IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(HOST), PORT);

        /// <summary>
        /// Установка и работа серверной части.
        /// </summary>
        public void EstablishServerConnection()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(end_point);
            socket.Listen(10);

            while (true)
            {
                var listener = socket.Accept();

                ReceiveMessage(listener);

                listener.Send(Encoding.UTF8.GetBytes("Сообщение доставлено успешно\n"));
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }

        /// <summary>
        /// Установка и работа клиентской части.
        /// </summary>
        public void EstablishClientConnection()
        {
            while (true)
            {
                // Отправка сообщения серверу
                Console.Write("Введите сообщение для отправки: ");

                var message = Console.ReadLine();
                var data = Encoding.UTF8.GetBytes(message);

                Socket socket = CreateClientSocket(data);

                // Получение сообщений от сервера
                ReceiveMessage(socket);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        /// <summary>
        /// Получение входного соединения клиента и отправка данных на сервер.
        /// </summary>
        /// <param name="data">Массив байтов для передачи</param>
        /// <returns>Входное соединение, сокет.</returns>
        private Socket CreateClientSocket(byte[] data)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(end_point);
            socket.Send(data);

            return socket;
        }

        /// <summary>
        /// Получение сообщения серевером или клиентом в виде строки.
        /// </summary>
        /// <param name="socket">Входная точка для получения данных, сокет.</param>
        private void ReceiveMessage(Socket socket)
        {
            var buffer = new byte[256];
            var answer = new StringBuilder();
            do
            {
                var size = socket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (socket.Available > 0);

            Console.WriteLine(answer);
        }



    }
}
