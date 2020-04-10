using System;
using System.Collections.Generic;
using System.Text;

namespace ShopLibrary
{
    /// <summary>
    /// Абстрактный продукт
    /// </summary>
    public abstract class Product
    {    
        /// <summary>
        /// Количество товара
        /// </summary>
        private int _amount;

        /// <summary>
        /// Компания.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Модель товара.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Amount
        {
            get { return _amount; }

            set 
            {
              if(value < 0) { Console.WriteLine("Количество товара не может быть отрицательным"); _amount = 0; }
              else { _amount = value; }
            }
        }

        /// <summary>
        /// Получить количество товара
        /// </summary>
        /// <returns>Int32</returns>
        public int GetAmount()
        {
            return Amount;
        }

        /// <summary>
        /// Получить информацию о продукте
        /// </summary>
        public virtual void GetInfo()
        {
            Console.WriteLine($"Company:{Company}, Model:{Model}, Amount:{Amount}");
        }




        

    }
}
