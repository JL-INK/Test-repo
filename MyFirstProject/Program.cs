using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //Подключение к БД через App.config
               string connectionString = ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
               System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
                connection.Open();

                //Начало цикла возвращения
                while (true)
                {
                    Console.Write("                              Введите дату поставки");
                    Console.Write("\n");
                    string text = Console.ReadLine();
                    DateTime saleDate = DateTime.Now;

                    //Проверка вводимых данных
                    try
                    {
                        saleDate = DateTime.Parse(text);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некорретная дата");
                        continue;
                    }
                    Console.WriteLine("Продано на " + saleDate);

                    //Создание Sqlparameter
                    SqlParameter filter = new SqlParameter("@filter", SqlDbType.VarChar);
                                 filter.Value = saleDate;

                    //Запрос с применением параметра
                    SqlCommand request = new SqlCommand(
                     @"SELECT s.Id, p.Name, s.Quantity, s.Date From Sales s
                                    join Products p on P.ID = s.ProductId
                                    where s.Date = @filter", connection);
                    request.Parameters.Add(filter);

                    //Считывание данных с таблицы
                     SqlDataReader reader = request.ExecuteReader();
                     while (reader.Read())
                      {
                        Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,5}", reader["Id"].ToString(), reader["Name"].ToString(), reader["Quantity"].ToString(), reader["Date"].ToString());
                      }
                     reader.Close();

                   //Цикл возврата
                    Console.WriteLine("         Чтобы закрыть нажмите 0 или любую кнопку чтобы начать заного");
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar == '0') break;
                }
                connection.Close();
            }

        }
    }
}
