using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Счет клиента
    /// </summary>
    class Account
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
        public string Name { get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; }
        /// <summary>
        /// Текущая сумма счета
        /// </summary>
        public decimal CurrentSum { get; set; }
        /// <summary>
        /// ID клиента
        /// </summary>
        public int ID { get; }
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
        public Account(int id, decimal sum)
        {
            if (id < 1000)
                throw new ArgumentException("Неккоректно указано ID", nameof(id));
            if (sum <= 0)
                throw new ArgumentException("Должна быть указана корректная сумма, больше нуля", nameof(sum));

            ID = id;
            CurrentSum = sum;
        }
        #region Invoke events
        /// <summary>
        /// Базовый метод вызова событий 
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        /// <param name="handler">Обработчик событий</param>
        public void CallEvent(AccountEventArgs args,AccountStateHandler handler)
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
        public void OnAdded(AccountEventArgs args)
        {
            CallEvent(args, Added);
        }
        /// <summary>
        /// Событие при списании средств со счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        public void OnWithdrawed(AccountEventArgs args)
        {
            CallEvent(args, Withdrawed);
        }
        /// <summary>
        /// Событие при открытии счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        public void OnOpened(AccountEventArgs args)
        {
            CallEvent(args, Opened);
        }
        /// <summary>
        /// Событие при закрытии счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        public void OnClosed(AccountEventArgs args)
        {
            CallEvent(args, Closed);
        }
        /// <summary>
        /// Событие при отображении текущего счета
        /// </summary>
        /// <param name="args">Вспомогательный класс обработки событий</param>
        public void OnDisplayed(AccountEventArgs args)
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
                throw new ArgumentException("Должна быть указана корректная сумма", nameof(sum));
            else
                CurrentSum -= sum;
                OnWithdrawed(new AccountEventArgs($"Со счета списана сумма в размере {sum}", sum));
        }
        /// <summary>
        /// Метод отображения текущего счета
        /// </summary>
        public void DisplayCurrentSum()
        {
            OnDisplayed(new AccountEventArgs($"Ваш текущий баланс состовляет {CurrentSum}", CurrentSum));
        }
        #endregion
    }
}
