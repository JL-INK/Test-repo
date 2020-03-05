using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Warehouse.Service;
using Warehouse.Models;

namespace ConsoleApp1
{
    class Program
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
        

        static void Main()
        {
            var isContinue = true;

            while (isContinue)
            {
                string ent = Console.ReadLine();
                String[] request = ent.Split();
                var cmd = request[0];
                var filterV = request[1];
                var nameOrDate = request[2];
                var service = new BalanceProductService(connectionString);

                switch (cmd)
                {
                    case "get":
                        {
                            switch (filterV)
                            {
                                case "name":
                                    {
                                        List<BalanceProduct> products = service.GetProductByName(nameOrDate);
                                        foreach (BalanceProduct product in products)
                                        {
                                            Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5} " + Environment.NewLine, product.Id, product.Name, product.Description, product.Quantity);
                                        }
                                        break;
                                    }
                                case "date":
                                    {
                                        DateTime saleDate;
                                        try
                                        {
                                            saleDate = DateTime.Parse((string)nameOrDate);
                                            Console.WriteLine("Остатки на " + saleDate);
                                            List<BalanceProduct> dates = service.GetProductByDate(nameOrDate);
                                            foreach (BalanceProduct date in dates)
                                            {
                                                Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5} " + Environment.NewLine, date.Id, date.Name, date.Description, date.Quantity);
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Некорретная дата");
                                        }
                                        break;
                                    }
                                case "products":
                                    {
                                        List<BalanceProduct> products = service.GetProducts();
                                        foreach (BalanceProduct product in products)
                                        {
                                            Console.WriteLine("{0,18} | {1,11} | {2,5} " + Environment.NewLine, product.Id, product.Name, product.Description);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    case "delete":
                        {
                            service.DeleteFromTable(filterV, nameOrDate);
                            break;
                        }

                    case "add":
                        {
                            var product = new Product();
                            product.Name = filterV;
                            product.Description = nameOrDate;
                            service.AddProduct(product);
                            break;
                        }
                }

                Console.WriteLine("Для выхода введите:exit");
                isContinue = Console.ReadLine() != "exit";
            }
        }
    }
}
