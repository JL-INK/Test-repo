using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=учет;password=85963258;";
             
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {

                conn.Open();

               
                Console.WriteLine("Осталось на складе:");

                string sql3 = @"SELECT t.Название, (o.Количество - p.Количество) cnt  FROM товары t
                                join поставки o on t.id = o.productId
                                join продажа p on t.id = p.productId";

                MySqlCommand command3 = new MySqlCommand(sql3, conn);
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    Console.WriteLine(reader3[0].ToString() + " = " + reader3[1].ToString());
                }
                reader3.Close();

                Console.ReadLine();
                conn.Close();
            }
         
        }

        void MyMethod() {
            Console.WriteLine("Система учета товара");
        }
    }
}
