using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Класс банк
    /// </summary>
    public class Bank
    {
        bool check;
        /// <summary>
        /// Название банка
        /// </summary>
        public string BankName { get; } = "Cбербанк";
        /// <summary>
        /// Конструктор создания банка
        /// </summary>
        /// <param name="name">Название банка</param>
        public Bank(string name)
        {
            BankName = name;
        }
        /// <summary>
        /// Словарь где ключ - ID клиента, а значение - его аккаунт
        /// </summary>
        Dictionary<int, Account> account_data = new Dictionary<int, Account>();
        /// <summary>
        /// Метод открытия счета в банке
        /// </summary>
        /// <param name="name">Имя клиента</param>
        /// <param name="surname">Фамилия клиента</param>
        /// <param name="sum">Начальная сумма</param>
        /// <param name="add">Событие добавления на счнт</param>
        /// <param name="withdraw">Событие снятия со счета</param>
        /// <param name="open">Событие открытия счета</param>
        /// <param name="close">Событие закрытия счета</param>
        public void OpenAccount(string name, string surname, decimal sum, AccountStateHandler add, AccountStateHandler withdraw, AccountStateHandler open, AccountStateHandler close, AccountStateHandler display)
        {
            #region Check input values
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не может быть пустым");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Фамилия не может быть пустой");
            if (sum < 0)
                throw new ArgumentException("Cумма не может быть с отрицательным значением");
            #endregion
            int id = GenerateID();
            while(!check)
            {
                check = true;
                foreach (KeyValuePair<int, Account> data in account_data)
                {
                    if (data.Key == id)
                    {
                        check = false;
                        id = GenerateID();       
                    }
                }
            }
            Account new_account = new Account(name, surname, id, sum);
            new_account.Added += add;
            new_account.Withdrawed += withdraw;
            new_account.Opened += open;
            new_account.Closed += close;
            new_account.Displayed += display;
            if (!account_data.ContainsKey(id)) //при конструкции TryGetValue out new_account в 64 строке new_account является пустым, почему?
            {
                account_data.Add(id, new_account);
                new_account.Open();
            }
            else
            {
                throw new Exception("Ошибка создания счета. Аккаунт с данным ID уже существует"); //TODO: Какое исключение применять
            }
           
        }
        /// <summary>
        /// Перегруженный метод открытия счета
        /// </summary>
        /// <param name="acc">Открываемый аккаунт</param>
        public void OpenAccount(Account acc)
        {
            int id = GenerateID();
            while (!check)
            {
                check = true;
                foreach (KeyValuePair<int, Account> data in account_data)
                {
                    if (data.Key == id)
                    {
                        check = false;
                        id = GenerateID();
                    }
                }
            }
            if (!account_data.ContainsKey(id)) //при конструкции TryGetValue out new_account в 64 строке new_account является пустым, почему?
            {
                account_data.Add(id, acc);
                acc.Open();
            }
            else
            {
                throw new Exception("Ошибка создания счета. Аккаунт с данным ID уже существует"); //TODO: Какое исключение применять
            }

        }
        /// <summary>
        /// Закрытие счета
        /// </summary>
        /// <param name="id">ID Клиента</param>
        public void CloseAccount(int id)
        {
            if(id < 1000 || id > 100000)
                throw new ArgumentException("Неккоректно указано ID");
            
            if (account_data.TryGetValue(id, out Account existing_account))
            {
                account_data.Remove(id);
                existing_account.Close();
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }
        /// <summary>
        /// Добавление на счет
        /// </summary>
        /// <param name="sum">Сумма добавления</param>
        /// <param name="id">ID Клиента</param>
        public void Put(decimal sum, int id)
        {
            if (id < 1000 || id > 100000)
                throw new ArgumentException("Неккоректно указано ID");

            if (account_data.TryGetValue(id, out Account existing_account))
            {
                existing_account.Put(sum);
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }
        /// <summary>
        /// Снятие со счета
        /// </summary>
        /// <param name="sum">Сумма снятия со счета</param>
        /// <param name="id">ID Клиента</param>
        public void Withdraw(decimal sum, int id)
        {
            if (id < 1000 || id > 100000)
                throw new ArgumentException("Неккоректно указано ID");

            if (account_data.TryGetValue(id, out Account existing_account))
            {
                existing_account.Withdraw(sum);
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }
        /// <summary>
        /// Получить полную информацию о клиенте
        /// </summary>
        /// <param name="id">ID клиента</param>
        public void GetAccountInfo(int id)
        {
            if (id < 1000 || id > 100000)
                throw new ArgumentException("Неккоректно указано ID");

            if (account_data.TryGetValue(id, out Account existing_account))
            {
                existing_account.DisplayAccountInfo();
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }
        /// <summary>
        /// Cоздание кредитной карты
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        public void CreateCreditCard(int id)
        {
            if (account_data.TryGetValue(id, out Account existing_account))
            {
                if (existing_account.Card == null)
                {
                    CreditCard card = new CreditCard(id);
                    existing_account.Card = card;
                    existing_account.CreateCreditCard();
                }
                else
                    throw new Exception("У данного клиента, кредитная карта уже существует");
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }
        /// <summary>
        /// Получить текущий аккаунт
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns>Account</returns>
        public Account GetAccount(int id)
        {
            if (id < 1000 || id > 100000)
                throw new ArgumentException("Неккоректно указано ID");

            if (account_data.TryGetValue(id, out Account existing_account))
            {
                return existing_account;
            }
            else
                throw new Exception("Данного аккаунта не существует");
        }

        /// <summary>
        /// Генерация случайного ID значением от 1000 до 100000
        /// </summary>
        /// <returns>Int32</returns>
        public int GenerateID()
        {
            Random generated = new Random();
            int new_id = generated.Next(1000,100000);
            return new_id;
        }
        /// <summary>
        /// Получение количества аккаунтов
        /// </summary>
        /// <returns>Int32</returns>
        public int GetAccountsNumber() => account_data.Count;
    }
}
