using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Обработчик событий
    /// </summary>
    /// <param name="args">Вспомогательный класс обработчика событий</param>
    public delegate void AccountStateHandler(AccountEventArgs args);
    /// <summary>
    /// Вспомогательный класс обработчика событий
    /// </summary>
    public class AccountEventArgs
    {
        /// <summary>
        /// Сообщение события
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Сумма на которую изменился счет
        /// </summary>
        public decimal Sum { get; }
        /// <summary>
        /// Конструктор обработки события
        /// </summary>
        /// <param name="message">Сообщение события</param>
        /// <param name="sum">Сумма на которую изменился счет</param>
        public AccountEventArgs(string message, decimal sum)
        {
            if(string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("Событие должно содержать сообщение");
            
            if(sum <= 0)
                throw new ArgumentException("Должна быть указана корректная сумма, больше нуля", nameof(sum));

            Message = message;
            Sum = sum;
        }
    }
}
