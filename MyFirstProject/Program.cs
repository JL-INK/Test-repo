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
                string connStr = @"Data Source=ORV-1;Initial Catalog=Shop;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User ID=sa;Password=123456;";
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                conn.Open();
                while (true)
                {
                    Console.Write ("Введите дату поставки");
                    Console.Write("\n");                    
                    string text = Console.ReadLine();
                    DateTime saleDate = DateTime.Now;
                    try
                    {
                        saleDate = DateTime.Parse(text);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некорретная дата");
                        continue;
                    }

                    Console.WriteLine("Продано на 2020-01-15");
                    String sql = @"SELECT ID,IDName, Date, Quantity FROM Shop.dbo.Sales
                               where Date = '"  + saleDate +"'";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    }
                    reader.Close();

                    Console.WriteLine("         Чтобы закрыть нажмите 0 или любую кнопку чтобы начать заного");
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar == '0') break;
                }
                    conn.Close();
            }

        }
    }
}
