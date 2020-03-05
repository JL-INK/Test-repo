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
            string connStr = @"Data Source=DESKTOP-IM096BK\SQLEXPRESS;Initial Catalog=Shop_Test;Integrated Security=True;";

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);

            conn.Open();
            string date = Console.ReadLine();
            Console.WriteLine("Left in stock:");
            String sql = @"SELECT t.id,Name, (o.Quantity - p.Quantity) Quantity FROM Products t
                           join Sales p on t.ID = p.idProducts
                           join Supply o on t.ID = o.idProducts
                           where o.Date <='" + date + "' and  p.Date <='" + date + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,18} | {1,11} | {2,5}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            Console.Read();
            reader.Close();
            conn.Close();

        }
    }
}