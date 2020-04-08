using System;
using System.Collections.Generic;
using System.Text;

namespace ShopLibrary
{
    public class Phone : Product
    {
        /// <summary>
        /// Конструктор телефона 
        /// </summary>
        /// <param name="comp">Компания</param>
        /// <param name="mdl">Модель</param>
        /// <param name="amount">Количество</param>
        public Phone(string comp, string mdl, int amount)
        {
            Company = comp;
            Model = mdl;
            Amount = amount;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Type:{ProductType.Phone}, Company:{Company}, Model:{Model}, Amount:{Amount}");
        }
    }
}
