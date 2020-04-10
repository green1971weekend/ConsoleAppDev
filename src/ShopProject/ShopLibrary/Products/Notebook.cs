using System;
using System.Collections.Generic;
using System.Text;

namespace ShopLibrary
{
    /// <summary>
    /// Класс ноутбук наследуемый от класса продукт
    /// </summary>
    class Notebook : Product
    {
        /// <summary>
        /// Конструктор ноутбуков 
        /// </summary>
        /// <param name="comp">Компания</param>
        /// <param name="mdl">Модель</param>
        /// <param name="amount">Количество</param>
        public Notebook(string comp, string mdl, int amount)
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
            Console.WriteLine($"Type:{ProductType.Notebook}, Company:{Company}, Model:{Model}, Amount:{Amount}");
        }
    }
}
