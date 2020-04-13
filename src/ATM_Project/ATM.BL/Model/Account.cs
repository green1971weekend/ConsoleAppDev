using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Счет клиента
    /// </summary>
     public class Account : IPayable
    {
        #region Assigning events
        /// <summary>
        /// Событие добавления на счет
        /// </summary>
        protected internal event AccountStateHandler Added;
        /// <summary>
        /// Событие снятия со счета
        /// </summary>
        protected internal event AccountStateHandler Withdrawed;
        /// <summary>
        /// Событие открытия счета
        /// </summary>
        protected internal event AccountStateHandler Opened;
        /// <summary>
        /// Событие закрытия счета
        /// </summary>
        protected internal event AccountStateHandler Closed;
        /// <summary>
        /// Событие отображения счета
        /// </summary>
        protected internal event AccountStateHandler Displayed;
        #endregion

        #region Assigning properties
        /// <summary>
        /// Имя
        /// </summary>
        private string Name { get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        private string Surname { get; }
        /// <summary>
        /// Текущая сумма счета
        /// </summary>
        private decimal CurrentSum { get; set; } = 0;
        /// <summary>
        /// ID клиента
        /// </summary>
        private int ID { get; }

        public CreditCard Card { get; set; } = null;
        #endregion

        /// <summary>
        /// Конструктор счета по умолчанию
        /// </summary>
        public Account() { }
        /// <summary>
        /// Конструктор счета с параметрами
        /// </summary>
        /// <param name="id">ID счета</param>
        /// <param name="sum">Сумма счета</param>
        public Account(string name, string surname, int id, decimal sum)
        {
            #region Сheck input values
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не должно быть пустым");
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentNullException("Фамилия не должна быть пустой");
            if (id < 1000)
                throw new ArgumentException("Неккоректно указано ID", nameof(id));
            if (sum <= 0)
                throw new ArgumentException("Должна быть указана корректная сумма, больше нуля", nameof(sum));
            #endregion

            Name = name;
            Surname = surname;
            ID = id;
            CurrentSum = sum;
        }
        #region Invoke events
        /// <summary>
        /// Базовый метод вызова событий 
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        /// <param name="handler">Обработчик событий</param>
        private void CallEvent(AccountEventArgs args,AccountStateHandler handler)
        {
            if (args == null)
                throw new Exception("При вызове определенного события, оно должно иметь содержание");
            else
                handler?.Invoke(args);
        }
        /// <summary>
        /// Событие при добавлении средств на счет
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        private void OnAdded(AccountEventArgs args)
        {
            CallEvent(args, Added);
        }
        /// <summary>
        /// Событие при списании средств со счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        private void OnWithdrawed(AccountEventArgs args)
        {
            CallEvent(args, Withdrawed);
        }
        /// <summary>
        /// Событие при открытии счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        private void OnOpened(AccountEventArgs args)
        {
            CallEvent(args, Opened);
        }
        /// <summary>
        /// Событие при закрытии счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        private void OnClosed(AccountEventArgs args)
        {
            CallEvent(args, Closed);
        }
        /// <summary>
        /// Событие при отображении текущего счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        private void OnDisplayed(AccountEventArgs args)
        {
            CallEvent(args, Displayed);
        }
        #endregion

        #region Account methods
        /// <summary>
        /// Метод добавления на счет
        /// </summary>
        /// <param name="sum">Сумма добавления</param>
        public void Put(decimal sum)
        {
            if (sum <= 0)
                throw new ArgumentException("Должна быть указана корректная сумма, больше нуля", nameof(sum));
            else
                CurrentSum += sum;
                OnAdded(new AccountEventArgs($"На счет поступила сумма в размере {sum}", sum));
        }
        /// <summary>
        /// Метод снятия со счета
        /// </summary>
        /// <param name="sum">Сумма снятия</param>
        public void Withdraw(decimal sum)
        {
            if (sum <= 0 || sum > CurrentSum)
                throw new ArgumentException("Должна быть указана корректная сумма, не превышающая текущую", nameof(sum));
            else
                CurrentSum -= sum;
                OnWithdrawed(new AccountEventArgs($"Со счета списана сумма в размере {sum}", CurrentSum));
        }
        /// <summary>
        /// Метод открытия счета
        /// </summary>
        public void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый клиентский счет. ID cчета - {ID}", CurrentSum));
        }
        /// <summary>
        /// Метод закрытия счета
        /// </summary>
        public void Close()
        {
            OnClosed(new AccountEventArgs($"Kлиентский счет успешно закрыт. ID cчета - {ID}", CurrentSum));
        }
        /// <summary>
        /// Метод получения полной информации о клиенте
        /// </summary>
        public void DisplayAccountInfo()
        {
            OnDisplayed(new AccountEventArgs($"Имя: {Name}, Фамилия: {Surname}, Текущая сумма на счете: {CurrentSum}, ID: {ID}", CurrentSum));
        }
        /// <summary>
        /// Создать новую карту для аккаунта
        /// </summary>
        public void CreateCreditCard()
        {
            OnOpened(new AccountEventArgs($"Кредитная карта успешно привязана к аккаунту ID: {ID} Запомните ваш пароль: {Card.Password}", CurrentSum));
        }
        #endregion
    }
}
