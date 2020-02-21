using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string connStr = @"Data Source=ORV-1;Initial Catalog=Shop;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                conn.Open();
                while (true)
                {
                    Console.Write ("                              Введите дату поставки");
                    Console.Write("\n");
                    Console.Write("                   (Доступные даты: 2020-01-15; 2020-01-20)");
                    Console.Write("\n");
                    string D = Console.ReadLine();

                    switch (D)
                    {
                        case "2020-01-15":
                            Console.WriteLine("Продано на 2020-01-15");
                            String sql = @"SELECT ID,IDName, Date, Quantity FROM Shop.dbo.Sales
                               where Date = '2020-01-15'";
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                            }
                            reader.Close();
                            break;
                        case "2020-01-20":
                            Console.WriteLine("Продано на 2020-01-15");
                            String sql1 = @"SELECT ID,IDName, Date, Quantity FROM Shop.dbo.Sales
                               where Date = '2020-01-20'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            SqlDataReader reader1 = command1.ExecuteReader();
                            while (reader1.Read())
                            {
                                Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5}", reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), reader1[3].ToString());
                            }
                            reader1.Close();
                            break;
                        default:
                            Console.WriteLine("                           На эту дату ничего не продано");
                            break;
                    }
                    Console.WriteLine("         Чтобы закрыть нажмите 0 или любую кнопку чтобы начать заного");
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar == '0') break;
                }
                    conn.Close();
            }

        }
    }
}
