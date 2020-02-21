using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
               string connectionString = ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
               System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
                conn.Open();

                while (true)
                {
                    Console.Write ("                              Введите дату поставки");
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
                    String sql = @"SELECT s.Id, p.Name, s.Quantity, s.Date From Sales s
                                   join Products p on P.ID = s.ProductId
                                   where s.Date = '" + saleDate +"'";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5}", reader["Id"].ToString(), reader["Name"].ToString(), reader["Quantity"].ToString(), reader["Date"].ToString());
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
