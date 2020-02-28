using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MyFirstProject.Service;
using MyFirstProject.Models;

namespace ConsoleApp1
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;

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
                var service = new BalanseProdustService(connectionString);
                switch (cmd)
                {
                    case "get":
                        switch (filterV)
                        {
                            case "name":
                                List<BalanceProduct> products = service.GetProductByName(connectionString, nameOrDate);
                                foreach (BalanceProduct product in products)
                                {
                                    Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5} " + Environment.NewLine, product.Id, product.Name, product.Description, product.Quantity);
                                }
                                break;
                            case "date":
                                List<BalanceProduct> dates = service.GetProductByDate(connectionString, nameOrDate);
                                foreach (BalanceProduct date in dates)
                                {
                                    Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5} " + Environment.NewLine, date.Id, date.Name, date.Description, date.Quantity);
                                }
                                break;
                        }
                        break;

                    case "delete":
                        service.DeleteFromTable(filterV, nameOrDate);
                        break;

                    case "add":
                        var balance = new BalanceProduct();
                        balance.Name = filterV;
                        balance.Description = nameOrDate;
                        service.AddFromTable(balance);
                        break;
                }
                Console.WriteLine("Для выхода введите:exit");
                isContinue = Console.ReadLine() != "exit";
            }
        }

    }
}
