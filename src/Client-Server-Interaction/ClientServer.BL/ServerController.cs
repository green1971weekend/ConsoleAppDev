using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer.BL
{
    /// <summary>
    /// Класс сервер-контроллер, содержащий в себе настройки соединения с клиентом.
    /// </summary>
    public class ServerController
    {
        readonly IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(Constants.HOST), Constants.PORT);

        public List<User> UserList { get; } = new List<User>();

        /// <summary>
        /// Установка и работа серверной части.
        /// </summary>
        public void EstablishServerConnection()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(end_point);
                socket.Listen(10);

                while (true)
                {
                    var listener = socket.Accept();

                    ReceiveMessage(listener);

                    listener.Send(Encoding.UTF8.GetBytes("Сообщение доставлено на сервер.\n"));

                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Добавить в список соединений нового пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        public void AddConnection(string login)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(end_point);

                var check_user_login = UserList.FirstOrDefault(u => u.Login == login);
                if (check_user_login == null)
                {
                    User new_user = new User(login);
                    UserList.Add(new_user);

                    var data = Encoding.UTF8.GetBytes($"Пользователь {login} успешно добавлен в чат!\n");
                    Console.WriteLine("Вы вошли в чат.\n");
                    socket.Send(data);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                else
                {
                    Console.WriteLine("Данный логин уже существует, попробуйте заново.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Удаление по логину из списка соединений.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        public void RemoveConnection(string login)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(end_point);

                var user_login = UserList.FirstOrDefault(u => u.Login == login);
                UserList.Remove(user_login);

                var data = Encoding.UTF8.GetBytes($"Пользователь {login} вышел из чата!\n");
                socket.Send(data);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Получение сообщения серевером или клиентом в виде строки.
        /// </summary>
        /// <param name="socket">Входная точка для получения данных, сокет.</param>
        public string ReceiveMessage(Socket socket)
        {
            try
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

                return answer.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

