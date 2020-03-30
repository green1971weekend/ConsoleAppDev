using System;
using System.Collections.Generic;


namespace Example1
{
    class Program
    {
        static bool alive;
        static bool inner_action_check;

        static string inner_action_input;
        static string inner_action_input2;
        static int inner_action_number;
        static int inner_action_number2;

        #region Assigned collections of each day
        static List<string> mn_task = new List<string>();
        static List<string> ts_task = new List<string>();
        static List<string> wd_task = new List<string>();
        static List<string> th_task = new List<string>();
        static List<string> fr_task = new List<string>();
        static List<string> st_task = new List<string>();
        static List<string> sn_task = new List<string>();
        #endregion Assigned collections of each day

        static void Main(string[] args)
        {
            Console.WriteLine("Scheduler of tasks v.1.1\n");

            Days week_day;
              
            do
            {
                alive = true;
                Console.WriteLine("Введите цифрой действие, которое хотите совершить\n");
                Console.WriteLine("1.Добавить задачу в определенный день\t 2.Сместить задачу на другой день\t 3.Удалить задачу");
                Console.WriteLine("4.Отобразить назначенные задачи\t 5.Отбразить текущее время и дату\t  6.Выход из программы");
                string action_input = Console.ReadLine();
                switch (action_input)
                {
                    case "1":                    
                        do
                        {
                            Console.WriteLine("Выберите цифрой, день недели, на который хотите добавить задачу: 1.Понедельник 2.Вторник 3.Среда 4.Четверг 5.Пятница 6.Суббота 7.Воскресенье");
                            inner_action_input = Console.ReadLine();
                            inner_action_check = Int32.TryParse(inner_action_input, out inner_action_number);
                        }
                        while (inner_action_number < 1 || inner_action_number > 7);
                        Console.Clear();

                        //???вопрос, как можно с помощью цикла for или foreach забить все значения перечеслений переменной week_day чтобы сократить конструкцию ниже
                        #region For certain day assign enum variable and add new task
                        if (inner_action_number == 1) { week_day = Days.Monday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 2) { week_day = Days.Tuesday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 3) { week_day = Days.Wednesday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 4) { week_day = Days.Thursday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 5) { week_day = Days.Friday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 6) { week_day = Days.Saturday; AddTask(week_day, inner_action_number); }
                        if (inner_action_number == 7) { week_day = Days.Sunday; AddTask(week_day, inner_action_number); }
                        #endregion     
                        break;

                    case "2":
                        do
                        {
                            Console.WriteLine("Выберите цифрой, день недели, задачи которого хотите перенести: 1.Понедельник 2.Вторник 3.Среда 4.Четверг 5.Пятница 6.Суббота 7.Воскресенье\n");
                            inner_action_input = Console.ReadLine();
                            inner_action_check = Int32.TryParse(inner_action_input, out inner_action_number);
                            Console.Clear();
                            Console.WriteLine("Выберите цифрой, день, в который хотите перенести задачи: 1.Понедельник 2.Вторник 3.Среда 4.Четверг 5.Пятница 6.Суббота 7.Воскресенье\n");
                            inner_action_input2 = Console.ReadLine();
                            inner_action_check = Int32.TryParse(inner_action_input2, out inner_action_number2);
                            if ((inner_action_number < 1 || inner_action_number > 7) || (inner_action_number2 < 1 || inner_action_number2 > 7))
                            {
                                Console.WriteLine("Некорректный ввод данных, попробуйте заново");
                            }           
                        }
                        while ((inner_action_number < 1 || inner_action_number > 7) || (inner_action_number2 < 1 || inner_action_number2 > 7));
                        Console.Clear();
                        //???как можно сократить данную конструкцию ниже
                        #region Implement the replacement 
                        if (inner_action_number2 == 1) { ReplaceTask(inner_action_number, mn_task); }
                        if (inner_action_number2 == 2) { ReplaceTask(inner_action_number, ts_task); }
                        if (inner_action_number2 == 3) { ReplaceTask(inner_action_number, wd_task); }
                        if (inner_action_number2 == 4) { ReplaceTask(inner_action_number, th_task); }
                        if (inner_action_number2 == 5) { ReplaceTask(inner_action_number, fr_task); }
                        if (inner_action_number2 == 6) { ReplaceTask(inner_action_number, st_task); }
                        if (inner_action_number2 == 7) { ReplaceTask(inner_action_number, sn_task); }
                        #endregion
                        break;
                    case "3":
                        Clear();        
                        break;
                    case "4":                  
                        Display();
                        break;
                    case "5":
                        DisplayDateTime();
                        break;
                    case "6":
                        alive = false;
                        Console.WriteLine("Удачного времени суток!");
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }                
            } while (alive);



        }


        public static void AddTask(Days day,int number)
        {
            Console.WriteLine($"Опишите задачу которую хотите добавить на {day}");
            string input_task = Console.ReadLine();

            switch(number)
            {
                case 1 :
                    mn_task.Add(input_task);
                    break;
                case 2:
                    ts_task.Add(input_task);
                    break;
                case 3:
                    wd_task.Add(input_task);
                    break;
                case 4:
                    th_task.Add(input_task);
                    break;
                case 5:
                    fr_task.Add(input_task);
                    break;
                case 6:
                    st_task.Add(input_task);
                    break;
                case 7:
                    sn_task.Add(input_task);
                    break;
            }
            Console.WriteLine($"Задача добавлена в {day}\n");

        }
        public static void Display()
        {
            Console.WriteLine("Выберите цифрой, день недели, задачи которого хотите отобразить: 1.Понедельник 2.Вторник 3.Среда 4.Четверг 5.Пятница 6.Суббота 7.Воскресенье\n");
            while(!Int32.TryParse(Console.ReadLine(),out inner_action_number))
            {
                Console.WriteLine("Введите число");
            }
            Console.Clear();
            switch (inner_action_number)
            {
                case 1:
                    Console.WriteLine($"Ваши задачи на {Days.Monday}");
                    foreach (var data in mn_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 2:
                    Console.WriteLine($"Ваши задачи на {Days.Tuesday}");
                    foreach (var data in ts_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 3:
                    Console.WriteLine($"Ваши задачи на {Days.Wednesday}");
                    foreach (var data in wd_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 4:
                    Console.WriteLine($"Ваши задачи на {Days.Thursday}");
                    foreach (var data in th_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 5:
                    Console.WriteLine($"Ваши задачи на {Days.Friday}");
                    foreach (var data in fr_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 6:
                    Console.WriteLine($"Ваши задачи на {Days.Saturday}");
                    foreach (var data in st_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                case 7:
                    Console.WriteLine($"Ваши задачи на {Days.Sunday}");
                    foreach (var data in sn_task)
                    {
                        Console.WriteLine(data);
                    }
                    break;
                default: Console.WriteLine("Указанного номера нет в списке");
                    break;
            }
        }

        public static void ReplaceTask(int from_day, List<string> week_day)
        {
            switch(from_day)
            {
                case 1:
                    week_day.AddRange(mn_task);
                    mn_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Monday}  ");
                    break;
                case 2:
                    week_day.AddRange(ts_task);
                    ts_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Tuesday} ");
                    break;
                case 3:
                    week_day.AddRange(wd_task);
                    wd_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Wednesday} ");
                    break;
                case 4:
                    week_day.AddRange(th_task);
                    th_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Thursday} ");
                    break;
                case 5:
                    week_day.AddRange(fr_task);
                    fr_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Friday} ");
                    break;
                case 6:
                    week_day.AddRange(st_task);
                    st_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Saturday} ");
                    break;
                case 7:
                    week_day.AddRange(sn_task);
                    sn_task.Clear();
                    Console.WriteLine($"Задачи удачно перемещены из {Days.Sunday} ");
                    break;

            }
        }
        public static void Clear()
        {
            Console.WriteLine("Выберите цифрой, день недели, содержимое которого хотите удалить: 1.Понедельник 2.Вторник 3.Среда 4.Четверг 5.Пятница 6.Суббота 7.Воскресенье\n");
            while (!Int32.TryParse(Console.ReadLine(), out inner_action_number))
            {
                Console.WriteLine("Введите число");
            }
            Console.Clear();
            switch (inner_action_number)
            {
                case 1:
                    mn_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Monday} успешно удалены");
                    break;
                case 2:
                    ts_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Tuesday} успешно удалены");
                    break;
                case 3:
                    wd_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Wednesday} успешно удалены");
                    break;
                case 4:
                    th_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Thursday} успешно удалены");
                    break;
                case 5:
                    fr_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Friday} успешно удалены");
                    break;
                case 6:
                    st_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Saturday} успешно удалены");
                    break;
                case 7:
                    sn_task.Clear();
                    Console.WriteLine($"Ваши задачи в {Days.Sunday} успешно удалены");
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;

            }         
        }

        static public void DisplayDateTime()
        {
            Console.Clear(); 
            Console.WriteLine(DateTime.Now);
        }

    }
    enum Days
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }





}
