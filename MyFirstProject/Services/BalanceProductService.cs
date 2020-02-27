using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyFirstProject.Service
{
    public class BalanseProdustService
    {
        string _connectionString;
        public BalanseProdustService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetProductByName(string connectionString, string nameOrDate)
        {
            _connectionString = connectionString;
            var result = "";
            var nOrD = nameOrDate;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlParameter name = new SqlParameter("@name", nOrD);
                SqlCommand product = new SqlCommand(
                @"select p.Id,p.Name, (u.Quantity-a.Quantity) as Quantity  from Products p
                              left join Sales a on a.ProductId = p.Id
                              left join Supply u on u.ProductId = p.Id
               where p.Name = @name", connection);
                product.Parameters.Add(name);

                SqlDataReader readerName = product.ExecuteReader();
                while (readerName.Read())
                {
                    result += string.Format("{0,18} | {1,11} | {2,5} " + Environment.NewLine, readerName["Id"].ToString(), readerName["Name"].ToString(), readerName["Quantity"].ToString());
                }
                readerName.Close();
                connection.Close();
            }
            return result;
        }


        public string GetProductByDate(string connectionString, string nameOrDate)
        {
            _connectionString = connectionString;
            var result = "";
            var nOrD = nameOrDate;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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

                SqlDataReader readerDate = balance.ExecuteReader();
                while (readerDate.Read())
                {
                    result += string.Format("{0,18} | {1,11} | {2,5} " + Environment.NewLine, readerDate["Id"].ToString(), readerDate["Name"].ToString(), readerDate["Quantity"].ToString());
                }
                readerDate.Close();
                connection.Close();
            }
            return result;
        }

        public void DeleteFromTable(string filterV, string nameOrDate)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"delete from " + filterV + " where Id = '" + nameOrDate + "'";
            SqlCommand delete = new SqlCommand(sql, connection);
            delete.ExecuteNonQuery();
            connection.Close();
        }

        public void AddFromTable(string filterV, string nameOrDate)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
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
