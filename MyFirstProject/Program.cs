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
                switch (cmd)
                {
                    case "get":
                        switch (filterV)
                        {
                            case "name":
                                GetProductByName(nameOrDate);
                                break;
                            case "date":
                                GetProductByDate(nameOrDate);
                                break;
                        }
                        break;

                    case "delete":
                        DeleteFromTable(filterV, nameOrDate);
                        break;

                    case "add":
                        AddFromTable(filterV, nameOrDate);
                        break;
                }
                Console.WriteLine("Для выхода введите:exit");
                isContinue = Console.ReadLine() != "exit";
            }
        }

        static void GetProductByName(string nameOrDate)
        {
            var nOrD = nameOrDate;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlParameter name = new SqlParameter("@name", nOrD);
                SqlCommand product = new SqlCommand(
                @"SELECT * From Products p
               where p.Name = @name", connection);
                product.Parameters.Add(name);

                SqlDataReader readerN = product.ExecuteReader();
                while (readerN.Read())
                {
                    Console.WriteLine("{0,18} | {1,11} | {2,5}", readerN["Id"].ToString(), readerN["Name"].ToString(), readerN["Description"].ToString());
                }
                readerN.Close();
                connection.Close();
            }
        }

        static void GetProductByDate(string nameOrDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var nOrD = nameOrDate;
                DateTime saleDate = DateTime.Now;
                try
                {
                    saleDate = DateTime.Parse(nOrD);
                }
                catch (Exception)
                {
                    Console.WriteLine("Некорретная дата");

                }
                Console.WriteLine("Остатки на " + saleDate);
                SqlParameter date = new SqlParameter("@date", saleDate);
                SqlCommand balance = new SqlCommand(
                 @"select p.Id,p.Name, (u.Quantity-a.Quantity) as Quantity  from Products p
                              left join Sales a on a.ProductId = p.Id
                              left join Supply u on u.ProductId = p.Id
                              where u.Date <= @date and a.Date <= @date", connection);
                balance.Parameters.Add(date);

                SqlDataReader readerD = balance.ExecuteReader();
                while (readerD.Read())
                {
                    Console.WriteLine("{0,18} | {1,11} | {2,5}", readerD["Id"].ToString(), readerD["Name"].ToString(), readerD["Quantity"].ToString());
                }
                readerD.Close();
                connection.Close();
            }
        }

        static void DeleteFromTable(string filterV, string nameOrDate)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            string sql = @"delete from " + filterV + " where Id = '" + nameOrDate + "'";
            SqlCommand delete = new SqlCommand(sql, connection);
            delete.ExecuteNonQuery();
            connection.Close();
        }

        static void AddFromTable(string filterV, string nameOrDate)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            string sql = @"insert into Products (Name,Description)
                               values (@Name,@addD)";
            SqlCommand comand = new SqlCommand(sql, connection);
            comand.Parameters.Add(new SqlParameter("Name", filterV));
            comand.Parameters.Add(new SqlParameter("Descrition", nameOrDate));
            comand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
