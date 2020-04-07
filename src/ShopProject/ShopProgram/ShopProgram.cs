using System;
using ShopLibrary;


namespace ShopProgram
{
    class ShopProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shop simulator v.1.0\n");

            bool alive = true;
            Storage<Product> store = new Storage<Product>();
            string action_input;

            while (alive)
            {
                Console.WriteLine("Выберите цифрой действие, которое хотите совершить :");
                Console.WriteLine("1.Добавить товар на склад  2.Отобразить список товаров  3.Удалить товар  4.Выход");
                action_input = Console.ReadLine();
                switch(action_input)
                {
                    case "1":
                        Console.Clear();
                        AddProduct(store);
                        break;
                    case "2":
                        Console.Clear();
                        Display(store);
                        break;
                    case "3":
                        Console.Clear();
                        Delete(store);
                        break;
                    case "4":
                        Console.WriteLine("Удачного времени суток!");
                        alive = false;
                        break;
                    default:
                        Console.WriteLine("Введены некорректные значения");
                        break;

                }
            }
        }

        #region AddProduct Method
        public static void AddProduct(Storage<Product> store)
        {
            bool alive = true;
            string input_comp;
            string input_model;
            int input_amount;

            while (alive)
            {
                try
                {
                    alive = false;
                    Console.WriteLine("Укажите какой тип желаете добавить: 1.Телефон 2.Ноутбук 3.Наушники");
                    Console.WriteLine("Для отмены введите cancel\n");
                    string input_type = Console.ReadLine();

                    switch (input_type)
                    {
                        case "1":
                            Console.WriteLine("Укажите компанию производителя\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество добавляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.AddItem(ProductType.Phone, input_comp, input_model, input_amount);
                            break;
                        case "2":
                            Console.WriteLine("Укажите компанию производителя\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество добавляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.AddItem(ProductType.Notebook, input_comp, input_model, input_amount);
                            break;
                        case "3":
                            Console.WriteLine("Укажите компанию производителя\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество добавляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.AddItem(ProductType.Headphones, input_comp, input_model, input_amount);
                            break;
                        case "cancel":
                            Console.WriteLine("Действие отменено\n");  
                            break;
                        default:
                            Console.WriteLine("Указаны неккоректные значения типа товаров, попробуйте указать заново\n");
                            alive = true;
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Добавление данных закончилось неудачно,возможно некорректно указано количество товара, попробуйте снова.\n");
                }
            }

        }
        #endregion

        #region Display Products
        public static void Display(Storage<Product> store)
        {
            bool alive = true;

            while (alive)
            {
                alive = false;
                try
                {
                    Console.Clear();
                    Console.WriteLine("Укажите цифрой, какой тип продукта желаете отобразить: 1.Телефон 2.Ноутбук 3.Наушники");
                    Console.WriteLine("Для отмены введите cancel\n");
                    string input_type = Console.ReadLine();
                    switch (input_type)
                    {
                        case "1":
                            store.DisplayProduct(ProductType.Phone);
                            Console.WriteLine("Хотите отобразить отсортированный список? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            input_type = Console.ReadLine().Trim().ToLower();
                            if (input_type == "-y" || input_type == "yes") { store.SortList(ProductType.Phone); }
                            break;
                        case "2":
                            store.DisplayProduct(ProductType.Notebook);
                            Console.WriteLine("Хотите отобразить отсортированный список? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            input_type = Console.ReadLine().Trim().ToLower();
                            if (input_type == "-y" || input_type == "yes") { store.SortList(ProductType.Notebook); }
                            break;
                        case "3":
                            store.DisplayProduct(ProductType.Headphones);
                            Console.WriteLine("Хотите отобразить отсортированный список? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            input_type = Console.ReadLine().Trim().ToLower();
                            if (input_type == "-y" || input_type == "yes") { store.SortList(ProductType.Headphones); }
                            break;
                        case "cancel":
                            Console.WriteLine("Действие отменено\n");
                            break;
                        default:
                            Console.WriteLine("Указаны неккоректные значения типа продукта, попробуйте указать заново\n");
                            alive = true;
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Неудача: {ex.Message} ");
                }
            }

        }
        #endregion

        #region DeleteProduct
        public static void Delete(Storage<Product> store)
        {
            bool alive = true;
            string action_input;
            string input_comp;
            string input_model;
            int input_amount;

            while (alive)
            {
                try
                {
                    Console.Clear();
                    alive = false;
                    Console.WriteLine("Укажите цифрой, какой тип продукта желаете удалить 1.Телефон \t 2.Ноутбук \t 3.Наушники");
                    Console.WriteLine("Для отмены введите cancel\n");
                    string input_type = Console.ReadLine();

                    switch (input_type)
                    {
                        case "1":
                            Console.WriteLine("Хотите отобразить данные о товаре? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            action_input = Console.ReadLine().Trim().ToLower();
                            if (action_input == "-y" || action_input == "yes") { store.DisplayProduct(ProductType.Phone); }
                            Console.WriteLine("Укажите компанию производителя товары которой хотите удалить\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество удаляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.DeleteProduct(ProductType.Phone, input_comp, input_model, input_amount);
                            break;

                        case "2":
                            Console.WriteLine("Хотите отобразить данные о товаре? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            action_input = Console.ReadLine().Trim().ToLower();
                            if (action_input == "-y" || action_input == "yes") { store.DisplayProduct(ProductType.Notebook); }
                            Console.WriteLine("Укажите компанию производителя товары которой хотите удалить\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество удаляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.DeleteProduct(ProductType.Phone, input_comp, input_model, input_amount);
                            break;

                        case "3":
                            Console.WriteLine("Хотите отобразить данные о товаре? Введите -y или yes для подтверждения. Любой ввод для отказа.\n");
                            action_input = Console.ReadLine().Trim().ToLower();
                            if (action_input == "-y" || action_input == "yes") { store.DisplayProduct(ProductType.Headphones); }
                            Console.WriteLine("Укажите компанию производителя товары которой хотите удалить\n");
                            input_comp = Console.ReadLine().Trim().ToUpper();
                            Console.WriteLine("Укажите модель\n");
                            input_model = Console.ReadLine().Trim().ToLower();
                            Console.WriteLine("Укажите количество удаляемых товаров\n");
                            input_amount = Convert.ToInt32(Console.ReadLine());
                            store.DeleteProduct(ProductType.Phone, input_comp, input_model, input_amount);
                            break;

                        case "cancel":
                            break;

                        default:
                            alive = true;
                            Console.WriteLine("Введены некорректные значения, попробуйте снова");
                            break;
                    }   
                }
                catch(Exception)
                {
                    Console.WriteLine("Введены некорректные значения, попробуйте снова");
                }
            }
        }
        #endregion 
    }
}
