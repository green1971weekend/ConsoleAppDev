using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Банкомат класс
    /// </summary>
    public class ATMMachine
    {
        /// <summary>
        /// Текущий банк
        /// </summary>
        private Bank _bank = null;
        /// <summary>
        /// Текущий аккаунт
        /// </summary>
        private Account CurrentAccount { get; set; }
        /// <summary>
        /// Конструктор создания банкомата
        /// </summary>
        /// <param name="bank"></param>
        public ATMMachine(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("Данного банка нет в базе");
            _bank = bank;

        }
        /// <summary>
        /// Вставляем карту
        /// </summary>
        /// <param name="card">Credit Card</param>
        /// <returns>Boolean</returns>
        public bool InsertCard(CreditCard card)
        {
            if (card != null)
                return true;
            else 
                return false;
        }

    }
}
