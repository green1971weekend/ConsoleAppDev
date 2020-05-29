using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShopLibrary
{
    /// <summary>
    /// Тип продукта
    /// </summary>
    public enum ProductType
    {
        Phone,
        Notebook,
        Headphones
    }

    public class Storage<T> where T: Product
    {
        /// <summary>
        /// База данных в виде словаря в котором храняться: ключ - вид продукта, значение - в виде типизированного списка
        /// </summary>
        Dictionary<ProductType,List<T>> product_library = new Dictionary<ProductType, List<T>>();

        /// <summary>
        /// Список конкретного типа товаров
        /// </summary>
        List<T> list;

        /// <summary>
        /// Добавить товар. 
        /// </summary>
        /// <param name="type">Тип товара.</param>
        /// <param name="comp">Название компании.</param>
        /// <param name="model">Наименование модели.</param>
        /// <param name="amount">Количество товаров.</param>
        public void AddItem(ProductType type, string comp, string model, int amount)
        {
            T product = null;
            int list_index = 0;
            try
            {
                switch (type)
                {
                    case ProductType.Phone:
                        product = new Phone(comp, model, amount) as T;
                        if (!product_library.TryGetValue(type, out list))
                        {
                            list = new List<T>();
                            list.Add(product);
                            product_library.Add(type, list);
                        }
                        else  // найти решение по сокращению данного куска кода
                        {
                            foreach (var item in list)
                            {
                                ++list_index;
                                if (item.Model == product.Model)
                                {
                                    item.Amount += product.Amount;
                                    if (list.Count == list_index) { --list_index; }
                                        break;
                                }
                            }
                            if (list.Count == list_index)
                                list.Add(product);
                        }
                        break;

                    case ProductType.Notebook:
                        product = new Notebook(comp, model, amount) as T;
                        if (!product_library.TryGetValue(type, out list))
                        {
                            list = new List<T>();
                            list.Add(product);
                            product_library.Add(type, list);
                        }
                        else  // найти решение по сокращению данного куска кода
                        {
                            foreach (var item in list)
                            {
                                ++list_index;
                                if (item.Model == product.Model)
                                {
                                    item.Amount += product.Amount;
                                    if (list.Count == list_index) { --list_index; }
                                    break;
                                }
                            }
                            if (list.Count == list_index)
                                list.Add(product);
                        }
                        break;

                    case ProductType.Headphones:
                        product = new Headphone(comp, model, amount) as T;
                        if (!product_library.TryGetValue(type, out list))
                        {
                            list = new List<T>();
                            list.Add(product);
                            product_library.Add(type, list);
                        }
                        else  // найти решение по сокращению данного куска кода
                        {
                            foreach (var item in list)
                            {
                                ++list_index;
                                if (item.Model == product.Model)
                                {
                                    item.Amount += product.Amount;
                                    if (list.Count == list_index) { --list_index; }
                                    break;
                                }
                            }
                            if (list.Count == list_index)
                                list.Add(product);
                        }
                        break;
                }
                Console.WriteLine("Данные успешно добавлены\n");
            }
            //TODO: Какие виды исключений лучше использовать 
            catch(InvalidCastException ex)
            {
                Console.WriteLine($"Неудачное преобразование типов: {ex.Message} \t Путь: {ex.StackTrace}");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"Неудачное преобразование типов: {ex.Message} \t Путь: {ex.StackTrace}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Неудача: {ex.Message} \t Путь: {ex.StackTrace}");
            }
        }   

        /// <summary>
        /// Отобразить список товаров 
        /// </summary>
        /// <param name="type">Тип продукта.</param>
        public void DisplayProduct(ProductType type)
        {
            try
            {
                var data = product_library[type];
                switch (type)
                {
                    case ProductType.Phone:
                        Console.WriteLine("Данные по телефонам\n");
                        Console.WriteLine("Компания \t Модель \t Количество товаров\n");
                        foreach (var item in data)
                        {
                            Console.WriteLine($"{item.Company}\t{item.Model}\t{item.Amount}\n");
                        }
                        break;
                    case ProductType.Notebook:
                        Console.WriteLine("Данные по ноутбукам\n");
                        Console.WriteLine("Компания \t Модель \t Количество товаров\n");
                        foreach (var item in data)
                        {
                            Console.WriteLine($"{item.Company}\t{item.Model}\t{item.Amount}\n");
                        }
                        break;
                    case ProductType.Headphones:
                        Console.WriteLine("Данные по наушникам\n");
                        Console.WriteLine("Компания \t Модель \t Количество товаров\n");
                        foreach (var item in data)
                        {
                            Console.WriteLine($"{item.Company}\t{item.Model}\t{item.Amount}\n");
                        }
                        break;
                }
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("Данного вида продукта нет в базе\n");
            }
        }

        /// <summary>
        /// Сортировка списка продуктов по компании производителя
        /// </summary>
        /// <param name="type">Тип продукта</param>
        public void SortList(ProductType type)
        {
            var data = product_library[type];
            var sorted_data = data.GroupBy(p => p.Company);
            foreach(IGrouping<string,T> group in sorted_data)
            {
                Console.WriteLine(group.Key);
                foreach (var phone in group)
                    Console.WriteLine($"Модель: {phone.Model} Количество: {phone.Amount}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Удалить товар.
        /// </summary>
        /// <param name="type">Тип товара</param>
        /// <param name="comp">Компания</param>
        /// <param name="model">Модель</param>
        /// <param name="amount">Количество</param>
        public void DeleteProduct(ProductType type, string comp, string model, int amount)
        {
            try
            {
                if (!product_library.TryGetValue(type, out list))
                {
                    throw new NullReferenceException("Список товаров отсутствует");
                }    
                switch (type)
                {
                    case ProductType.Phone:
                        foreach (var item in list)
                        {
                            if(item.Company == comp && item.Model == model)
                            {
                                item.Amount -= amount;
                                break;
                            }
                        }
                        break;
                    case ProductType.Notebook:
                        foreach (var item in list)
                        {
                            if (item.Company == comp && item.Model == model)
                            {
                                item.Amount -= amount;
                                break;
                            }
                        }
                        break;
                    case ProductType.Headphones:
                        foreach (var item in list)
                        {
                            if (item.Company == comp && item.Model == model)
                            {
                                item.Amount -= amount;
                                break;
                            }
                        }
                        break;
                }
                Console.WriteLine("Данные успешно удалены");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
