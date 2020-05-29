using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.BL
{
    /// <summary>
    /// Класс кредитная карта
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// Банк привязанный к карте
        /// </summary>
        public string Bank { get; } = "Cбербанк";

        /// <summary>
        /// Пароль карты
        /// </summary>
        public int Password { get; }

        /// <summary>
        /// ID карты, совпадает с ID аккаунта
        /// </summary>
        private int ID { get; }

        /// <summary>
        /// Конструктор создания карты
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        public CreditCard(int id)
        { 
            ID = id;
            Password = GeneratePassword();
        }

        /// <summary>
        /// Генератор 4-х значного пароля для карты
        /// </summary>
        /// <returns>Int32</returns>
        public int GeneratePassword()
        {
            Random generated = new Random();
            int new_id = generated.Next(1001,9998);
            return new_id;
        }
    }
}
