using System;
using System.Collections.Generic;
using System.Text;

namespace ShopLibrary
{
    /// <summary>
    /// Класс наушники наследуемый от класса продукт
    /// </summary>
    class Headphone : Product
    {
        /// <summary>
        /// Конструктор наушников 
        /// </summary>
        /// <param name="comp">Компания</param>
        /// <param name="mdl">Модель</param>
        /// <param name="amount">Количество</param>
        public Headphone(string comp, string mdl, int amount)
        {
            Company = comp;
            Model = mdl;
            Amount = amount;
        }
        
        /// <summary>
        /// Получить информацию о продукте
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine($"Type:{ProductType.Headphones}, Company:{Company}, Model:{Model}, Amount:{Amount}");
        }
    }
}
