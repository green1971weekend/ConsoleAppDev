using System;
using System.Collections.Generic;
using System.Text;

namespace ShopLibrary
{
    public abstract class Product
    {    
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


        public int GetAmount()
        {
            return Amount;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Company:{Company}, Model:{Model}, Amount:{Amount}");
        }




        

    }
}
