using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Queue_simulator
{
    /// <summary>
    /// Касса быстрого обслуживания
    /// </summary>
    class FastCheckoutCounter: CheckoutCounter
    {
        /// <summary>
        /// Конструктор быстрой кассы
        /// </summary>
        /// <param name="number">Номер быстрой кассы</param>
        public FastCheckoutCounter(int number,CheckoutCounterHandler handler): base(number,handler) { }

        /// <summary>
        /// Рандомайзер числа клиентов
        /// </summary>
        Random client_amount = new Random();
        /// <summary>
        /// Рандомайзер времени обслуживания клиента
        /// </summary>
        Random random_service_time = new Random();

        /// <summary>
        /// Переопределенный метод работы быстрой кассы
        /// </summary>
        public override void CounterWork()
        {
            int service_time;
            for (int i = 0; i < client_amount.Next(10, 40); i++)
            {
                service_time = random_service_time.Next(500, 1000);
                Thread.Sleep(service_time);
                OnServed($"Клиент {i + 1} обслужен в быстрой кассе номер {Number} за {service_time / 100} секунд");
            }
        }
    }
}
