using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Queue_simulator
{
    /// <summary>
    /// Касса
    /// </summary>
    class CheckoutCounter
    {
        /// <summary>
        /// Делегат обработки события
        /// </summary>
        /// <param name="notify"></param>
        public delegate void CheckoutCounterHandler(string notify);
        /// <summary>
        /// Событие обслуживания клиента
        /// </summary>
        public event CheckoutCounterHandler Served;

        /// <summary>
        /// Номер кассы
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Рандомайзер числа клиентов
        /// </summary>
        Random client_amount = new Random();
        /// <summary>
        /// Рандомайзер времени обслуживания клиента
        /// </summary>
        Random random_service_time = new Random();
        /// <summary>
        /// Конструктор кассы
        /// </summary>
        /// <param name="number">Номер кассы</param>
        public CheckoutCounter(int number,CheckoutCounterHandler handler)
        {
            if(number == 0 || number > 10)
            {
                throw new ArgumentException("Задано некорректное количество касс");
            }
            Served += handler;
            Number = number;
        }
        /// <summary>
        /// Метод вызова события
        /// </summary>
        /// <param name="message">Сообщение события</param>
        /// <param name="handler">Обработчик события</param>
        public void Notify(string message, CheckoutCounterHandler handler)
        {
            if (message != null)
                handler.Invoke(message);
            else
                throw new ArgumentNullException("Уведомление не может быть пустым");
        }
        /// <summary>
        /// Событие при обслуживании клиента
        /// </summary>
        /// <param name="message"></param>
        public void OnServed(string message)
        {
            Notify(message,Served);
        }
        /// <summary>
        /// Симулятор определенной работы в кассе
        /// </summary>
        public virtual void CounterWork()
        {
            int service_time;
            for (int i = 0; i < client_amount.Next(10, 70); i++)
            {
                service_time = random_service_time.Next(1000, 2000);
                Thread.Sleep(service_time);
                OnServed($"Клиент {i+1} обслужен в кассе номер {Number} за {service_time/100} секунд");
            }
        }

    }
}
