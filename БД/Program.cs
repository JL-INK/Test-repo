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
            string connStr = @"Data Source=JL_INK\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;";

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);

            conn.Open();

            Console.WriteLine ("                                Осталось на складе:");
            String sql = @"SELECT t.ID,t.Name, (u.Quantity - a.Quantity) Quantity , a.Date Date  FROM Name t
                           join Sales a on t.ID = a.IDName
                           join Supply u on t.ID = u.IDName";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,18} | {1,11} | {2,5} | {3,11}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            Console.Read();
            reader.Close();
            conn.Close();

        }
    }
}
