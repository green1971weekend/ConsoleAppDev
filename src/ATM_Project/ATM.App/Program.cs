using System;
using ATM.BL;

namespace ATM.App
{
    class Program
    {
        static Bank bank = new Bank("Сбербанк");
        static ATMMachine atm = new ATMMachine(bank);
        static Account current_account = new Account();
        static void Main(string[] args)
        {
            bool alive = true;
            Console.WriteLine("Вас приветствует банковская система v.1.0");
            while (alive)
            {
                Console.WriteLine("Выберите действие которое хотите совершить\n");
                Console.WriteLine("1.Банковские операции 2.Операции с банкоматом 3.Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        StartBankOperation();
                        break;

                    case "2":
                        Console.Clear();
                        Start_ATM_Operation();
                        break;

                    case "3":
                        alive = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Работа с банком
        /// </summary>
        public static void StartBankOperation()
        {
            string input;
            string name;
            string surname;
            decimal sum;
            int id;
            try
            {
                Console.WriteLine("Выберите цифрой  действие которое хотите совершить в банке\n");
                Console.WriteLine("1.Открыть счет 2.Закрыть счет 3.Создать кредитную карту для счета");
                Console.WriteLine("4.Добавить средства на счет 5.Снять средства со счета 6.Получить информацию о счете");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Введите имя\n");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите фамилию\n");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите начальную сумму счета\n");
                        sum = Convert.ToDecimal(Console.ReadLine());

                        bank.OpenAccount(name, surname, sum, AddSumHandler, WithdrawSumHandler, OpenAccHandler, CloseAccHandler, DisplayHandler);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Введите ID счета\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        bank.CloseAccount(id);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Введите ID счета\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        bank.CreateCreditCard(id);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Введите ID счета\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите cумму\n");
                        sum = Convert.ToDecimal(Console.ReadLine());
                        bank.Put(sum, id);
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Введите ID счета\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите cумму\n");
                        sum = Convert.ToDecimal(Console.ReadLine());
                        bank.Withdraw(sum, id);
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Введите ID счета\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        bank.GetAccountInfo(id);
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        /// <summary>
        /// Работа с банкоматом
        /// </summary>
        public static void Start_ATM_Operation()
        {
            string input;
            int id;
            decimal sum;
            bool alive;
            try
            {
                Console.WriteLine("Введите ID счета для работы с банкоматом\n");
                id = Convert.ToInt32(Console.ReadLine());
                current_account = bank.GetAccount(id);
                Console.WriteLine("Вставляем карту...");
                alive = atm.InsertCard(current_account.Card);
                if(!alive)
                    Console.WriteLine("У вас все еще нет карты? Создайте ее в банке в пару кликов");

                while (alive)
                {
                    Console.WriteLine("Выберите цифрой действие\n");
                    Console.WriteLine("1.Положить средства на счет 2.Снять средства со счета");
                    Console.WriteLine("3.Проверить баланс 4.Закончить работу");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Введите cумму для пополнения\n");
                            sum = Convert.ToDecimal(Console.ReadLine());
                            bank.Put(sum, id);
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Введите cумму для снятия\n");
                            sum = Convert.ToDecimal(Console.ReadLine());
                            bank.Withdraw(sum, id);
                            break;

                        case "3":
                            Console.Clear();
                            bank.GetAccountInfo(id);
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Незабудьте вашу карту!");
                            alive = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Task Handlers
        /// <summary>
        /// Обработчик события добавления на счет
        /// </summary>
        /// <param name="args">Содержание события</param>
        private static void AddSumHandler(AccountEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        /// <summary>
        ///  Обработчик события снятия со счета
        /// </summary>
        /// <param name="args">Содержание события</param>
        private static void WithdrawSumHandler(AccountEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        /// <summary>
        ///  Обработчик события открытия счета
        /// </summary>
        /// <param name="args">Содержание события</param>
        private static void OpenAccHandler(AccountEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        /// <summary>
        /// Обработчик события закрытия счета
        /// </summary>
        /// <param name="args">Содержание события</param>
        private static void CloseAccHandler(AccountEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        /// <summary>
        /// Обработчик события отображения информации по счету
        /// </summary>
        /// <param name="args">Содержание события</param>
        private static void DisplayHandler(AccountEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
        #endregion
    }
}
