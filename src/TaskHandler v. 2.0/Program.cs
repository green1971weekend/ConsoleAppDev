using System;
using System.Collections.Generic;

namespace TaskHandler_v._2._0
{
    class Program
    {
        
        static string task_input;
        static string str_date_time;

        /// <summary>
        /// Store of DateTime value
        /// </summary>
        static DateTime value_keeper;
        /// <summary>
        /// The dictionary where key-value data exists.
        /// </summary>
        static Dictionary<string,List<string>> data = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Scheduler of tasks v.2.0\n");
            bool alive = true;
          
            while (alive)
            {            
                Console.WriteLine("Введите цифрой действие, которое хотите совершить\n");
                Console.WriteLine("1.Добавить задачу на день \t  2.Отобразить назначенные задачи \t 3.Удалить задачи на день");
                Console.WriteLine("4.Отобразить текущую дату и время \t  5.Выход из программы");      
                try 
                {
                    string action_input = Console.ReadLine();

                    switch(action_input)
                    {
                        case "1":
                            Console.Clear();
                            AddTask();
                            break;
                        case "2":
                            Console.Clear();
                            Display();
                            break;
                        case "3":
                            Console.Clear();
                            Delete();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine(DateTime.Now.ToString("F"));
                            break;
                        case "5":
                            alive = false;
                            Console.WriteLine("Удачного вам дня!");
                            break;
                        default:
                            Console.Clear();
                            throw new ArgumentException("Введите корректные значения\n");

                    }               
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            }
        }
        #region Add a new task
        /// <summary>
        /// Add new task to the list.
        /// </summary>
        public static void AddTask()
        {
            value_keeper = new DateTime();
            bool method_alive = false;         
            List<string> list;

            Console.WriteLine("Опишите задачу, которую желаете добавить\n");
            task_input = Console.ReadLine();

            Console.WriteLine("Заполните дату, на которую хотите добавить задачу. Формат заполнения: 01.01.2000\n");
            while (!method_alive)
            {
                try
                {
                    method_alive = DateTime.TryParse(Console.ReadLine(), out value_keeper);
                    if (!method_alive)
                        throw new ArgumentException("Введите коректные значения\n");
                    if(value_keeper < DateTime.Now)
                        throw new ArgumentException("Невозможно назначить задачу на прошедшее время\n");
                    else
                    {
                        str_date_time = value_keeper.ToString("D");
                        if (!data.TryGetValue(str_date_time, out list))
                        {
                            list = new List<string>();
                            list.Add(task_input);
                            data.Add(str_date_time, list);
                        }
                        else { list.Add(task_input); }
                        method_alive = true;
                    }
                    Console.WriteLine($"Задача: {task_input} успешно добавлена на {value_keeper.ToString("D")}\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }   
        }
        #endregion

        #region Display tasks
        /// <summary>
        /// Display all assigned tasks for a certain calendar day.
        /// </summary>
        public static void Display()
        {
            bool method_alive = true;
            value_keeper = new DateTime();

            while (method_alive)
            {
                Console.WriteLine("Выберите дату, планы которой хотите отобразить. Формат заполнения: 01.01.2000\n");            
                try
                {
                    method_alive = DateTime.TryParse(Console.ReadLine(), out value_keeper);
                    Console.Clear();
                    if (!method_alive) { throw new ArgumentException("Введите корректные значения\n"); }       
                    else
                    {
                        str_date_time = value_keeper.ToString("D");
                        if (!data.ContainsKey(str_date_time)) { throw new ArgumentNullException($"На {str_date_time} не назначено каких-либо планов\n"); }
                        else
                        {
                            Console.WriteLine($"Список дел на {str_date_time}\n");
                            foreach (var task in data[str_date_time])
                            {
                                Console.WriteLine($"{task}\n");
                            }
                            method_alive = false;
                        }
                    }
                }
                catch (ArgumentNullException ex_null)
                {
                    Console.WriteLine($"{ex_null.Message}");
                    method_alive = false;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }
        #endregion

        #region Delete tasks method
        /// <summary>
        /// Delete all the tasks for a certain day
        /// </summary>
        public static void Delete()
        {
            bool method_alive = true;
            value_keeper = new DateTime();

            while (method_alive)
            {
                Console.Clear();
                Console.WriteLine("Выберите дату, на которую хотите стереть все задачи. Формат заполнения: 01.01.2000\n");              
                try 
                {
                    method_alive = DateTime.TryParse(Console.ReadLine(), out value_keeper);
                    if(method_alive)
                    {
                        str_date_time = value_keeper.ToString("D");
                        data.Remove(str_date_time);
                        Console.Clear();
                        Console.WriteLine($"Данные на {str_date_time} успешно удалены.\n") ;
                        method_alive = false;

                    }
                    else { throw new ArgumentException("Введите корректные значения\n"); }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        #endregion







    }
}
