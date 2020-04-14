using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    interface IPayable
    {
        /// <summary>
        /// Положить деньги на счет
        /// </summary>
        /// <param name="sum">Сумма добавления</param>
        void Put(decimal sum);
        /// <summary>
        /// Снять деньги со счета
        /// </summary>
        /// <param name="sum">Сумма снятия</param>
        void Withdraw(decimal sum);
        /// <summary>
        /// Метод получения полной информации о клиенте
        /// </summary>
        void DisplayAccountInfo();
    }
}
