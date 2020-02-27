using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MyFirstProject.Service;

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
                                var nameText = service.GetProductByName(connectionString, nameOrDate);
                                Console.WriteLine(nameText);
                                break;
                            case "date":
                                var dateText = service.GetProductByDate(connectionString, nameOrDate);
                                Console.Write(dateText);
                                break;
                        }
                        break;

                    case "delete":
                        service.DeleteFromTable(filterV, nameOrDate);
                        break;

                    case "add":
                        service.AddFromTable(filterV, nameOrDate);
                        break;
                }
                Console.WriteLine("Для выхода введите:exit");
                isContinue = Console.ReadLine() != "exit";
            }
        }

    }
}
