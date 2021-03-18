using LINQ_HomeWork.Data;
using LINQ_HomeWork.DataClasses;
using LINQ_HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Смартфоны"
                },
                new Category()
                {
                    Name = "Кнопочные телефоны"
                },
            };

            List<Smartphone> smartphones = new List<Smartphone>()
            {
                new Smartphone()
                {
                    Model = "Samsung Galaxy A02",
                    MemoryCapacity = 32,
                    Processor = "MT6739",
                    CoreNumber = 2,
                    Color = "Blue",
                    Price = 48700,
                    RAMamount = 2,
                    Producer = "Samsung",
                    dateProduction = new DateTime(2019,10,10),
                    CategoryId=categories[0].Id
                },

                new Smartphone()
                {
                    Model = "Samsung Galaxy A05",
                    MemoryCapacity = 64,
                    Processor = "MT6739",
                    CoreNumber = 2,
                    Color = "Black",
                    Price = 59000,
                    RAMamount = 4,
                    Producer = "Samsung",
                    dateProduction = new DateTime(2018,10,10),
                     CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Xiaomi Mi 10T",
                    MemoryCapacity = 32,
                    Processor = "MT6739",
                    CoreNumber = 4,
                    Color = "Black",
                    Price = 65000,
                    RAMamount = 8,
                    Producer = "Xiaomi",
                    dateProduction = new DateTime(2017,10,10),
                     CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Xiaomi Mi 17T",
                    MemoryCapacity = 16,
                    Processor = "MT6739",
                    CoreNumber = 8,
                    Color = "Blue",
                    Price = 89000,
                    RAMamount = 4,
                    Producer = "Xiaomi",
                    dateProduction = new DateTime(2016,10,10),
                     CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Samsung Galaxy A02",
                    MemoryCapacity = 32,
                    Processor = "MT6739",
                    CoreNumber = 2,
                    Color = "Blue",
                    Price = 48700,
                    RAMamount = 2,
                    Producer = "Samsung",
                    dateProduction = new DateTime(2019,10,10),
                     CategoryId=categories[0].Id
                },

                new Smartphone()
                {
                    Model = "Samsung Galaxy A05",
                    MemoryCapacity = 64,
                    Processor = "MT6739",
                    CoreNumber = 2,
                    Color = "Black",
                    Price = 59000,
                    RAMamount = 4,
                    Producer = "Samsung",
                    dateProduction = new DateTime(2018,10,10),
                    CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Xiaomi Mi 10T",
                    MemoryCapacity = 32,
                    Processor = "MT6739",
                    CoreNumber = 4,
                    Color = "Black",
                    Price = 65000,
                    RAMamount = 8,
                    Producer = "Xiaomi",
                    dateProduction = new DateTime(2017,10,10),
                    CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Xiaomi Mi 17T",
                    MemoryCapacity = 16,
                    Processor = "MT6739",
                    CoreNumber = 8,
                    Color = "Blue",
                    Price = 89000,
                    RAMamount = 4,
                    Producer = "Xiaomi",
                    dateProduction = new DateTime(2016,10,10),
                    CategoryId=categories[0].Id
                },
                new Smartphone()
                {
                    Model = "Xiaomi Mi 17T",
                    MemoryCapacity = 16,
                    Processor = "MediaTek",
                    CoreNumber = 2,
                    Color = "Blue",
                    Price = 8990,
                    RAMamount = 8,
                    Producer = "Tecno Mobile",
                    dateProduction = new DateTime(2016,10,10),
                    CategoryId=categories[1].Id
                },
            };

            using (ShopContext context = new ShopContext())
            {
                context.AddRange(categories);
                context.AddRange(smartphones);
                context.SaveChanges();

                int pageSize = 3;
                int pageNumber = 0;
                var products = context.Products.ToList();
                var counter = 1;
                var partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\tShop.kz\n");
                    Console.WriteLine($"Страница №{pageNumber+1}\n");

                    counter = 1 + 3 * pageNumber;
                    foreach (var product in partProducts)
                    {
                        Console.WriteLine($"\nТовар №{counter++}");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(product.ToString());
                    }


                    Console.WriteLine("\n------------Меню------------");
                    Console.WriteLine("1.Следующая страница");
                    Console.WriteLine("2.Предыдущая страница");
                    Console.WriteLine("3.Сортировка по алфавиту");
                    Console.WriteLine("4.Сортировка по цене");
                    Console.WriteLine("5.Сортировка по дате");

                    int.TryParse(Console.ReadLine(), out int choose);

                    switch (choose)
                    {
                        case 1:
                            if ((pageNumber + 1) * pageSize < products.Count) pageNumber++;
                            partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                            break;
                        case 2:
                            if (pageNumber - 1 >= 0) { pageNumber--; }
                            partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                            break;
                        case 3:
                            partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).OrderBy(phone => phone.Model).ToList();
                            break;
                        case 4:
                            partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).OrderBy(phone => phone.Price).ToList();
                            break;
                        case 5:
                            partProducts = products.Skip(pageNumber * pageSize).Take(pageSize).OrderBy(phone => phone.dateProduction).ToList();
                            break;
                        default:
                            Console.WriteLine("Вы ввели неправильный индекс!");
                            break;
                    }

                    } while (true);

            }
        }
    }
}
