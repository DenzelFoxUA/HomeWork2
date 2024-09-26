using HomeWork2.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2.Task1
{
    public static class Task1
    {
        //список валют
        public static List<Currency> currencies = new List<Currency>()
        {
                new (0, "UA Hryvnia", "UAH"),
                new (1, "US Dollar", "USD"),
                new (2, "EURO", "EUR"),
                new (3, "PL Zloty", "ZLT"),
                new (4, "GB Pound", "GBP"),
                new (5, "JAPAN YENA", "YEN")

        };

        public static void Run()
        {
            //створити лист для товарів
            List<TradableModel<AssetModel>> tradables = new List<TradableModel<AssetModel>>() ;
            //

            //створення та додавання товарів
            Product product1 = new Product(0,
                                             "Samsung S22 Ultra",
                                             "Smartphone",
                                             new Money(currencies[0], 45999.99M));
            Product product2 = new Product(1,
                                                "Roventa",
                                                "VacuumCleaner",
                                                new Money(currencies[1], 99.78M));

            TradableModel<AssetModel> service1 = new Service(2,
                                                             "IT Course",
                                                             "Teaching programming language",
                                                             new Money(currencies[0], 16000M));

            TradableModel<AssetModel> product3 = new Product(2,
                                                             "Asus ROG",
                                                             "Laptop",
                                                             new Money(currencies[0], 51000.0M));


            tradables.Add(service1);
            tradables.Add(product1);
            tradables.Add(product2);
            tradables.Add(product3);
            //

            //друк на екран
            Print(tradables);
            Console.WriteLine("--------------BEFORE EDITING PRICES--------------------");

            //додавання ціни для товару 1
            decimal valueToAdd = 10.99M;
            product1.IncreasePrice(valueToAdd);
            //

            //віднімання ціни від товару 2 і послуги 1
            decimal valueToSubtract = 100.29M;
            try
            {
                product2.DecreasePrice(valueToSubtract);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            try
            {
                service1.DecreasePrice(valueToSubtract);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            //

            //дисконт для товару 3
            int percent = 12;
            try
            {
                product3.SetPriceWithDiscount(percent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            percent = 120;
            try
            {
                product3.SetPriceWithDiscount(percent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            //

            //Друк результатів на екран
            Print(tradables);
            //
            
            
        }

        private static void Print<T>(List<T> list) where T : class
        {
            foreach (T item in list)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(item);
            }
        }
    }
}
