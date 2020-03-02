using Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warehouse.Service
{
    public class BalanceProductService
    {
        string _connectionString;

        public BalanceProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BalanceProduct> GetProductByName(string name)
        {
            List<BalanceProduct> list = new List<BalanceProduct>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlParameter paramName = new SqlParameter("@name", name);
                SqlCommand product = new SqlCommand(
                @"select p.Id,p.Name, Description,(u.Quantity-a.Quantity) as Quantity  from Products p
                              left join Sales a on a.ProductId = p.Id
                              left join Supply u on u.ProductId = p.Id
                where p.Name like '%' + @name + '%'", connection);
                product.Parameters.Add(paramName);

                SqlDataReader readerName = product.ExecuteReader();
                while (readerName.Read())
                {
                    BalanceProduct item = new BalanceProduct()
                    {
                        Id = (int)readerName["Id"],
                        Name = readerName["Name"].ToString(),
                        Description = readerName["Description"].ToString(),
                        Quantity = (int)readerName["Quantity"]
                    };
                    list.Add(item);
                }
                readerName.Close();
                connection.Close();
            }
            return list;
        }

        public List<BalanceProduct> GetProductByDate(string date)
        {
            List<BalanceProduct> list = new List<BalanceProduct>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DateTime saleDate = DateTime.Now;
                try
                {
                    saleDate = DateTime.Parse((string)date);
                }
                catch (Exception)
                {
                    Console.WriteLine("Некорретная дата");

                }
                Console.WriteLine("Остатки на " + saleDate);
                SqlParameter paramDate = new SqlParameter("@date", saleDate);
                SqlCommand balance = new SqlCommand(
                 @"select p.Id,p.Name,Description, (u.Quantity-a.Quantity) as Quantity  from Products p
                              left join Sales a on a.ProductId = p.Id
                              left join Supply u on u.ProductId = p.Id
                              where u.Date <= @date and a.Date <= @date", connection);
                balance.Parameters.Add(paramDate);

                SqlDataReader readerDate = balance.ExecuteReader();
                while (readerDate.Read())
                {
                    BalanceProduct dateList = new BalanceProduct()
                    {
                        Id = (int)readerDate["Id"],
                        Name = readerDate["Name"].ToString(),
                        Description = readerDate["Description"].ToString(),
                        Quantity = (int)readerDate["Quantity"]
                    };
                    list.Add(dateList);
                }

                readerDate.Close();
                connection.Close();
            }
            return list;
        }

        public void DeleteFromTable(string filterV, string deleteName)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"delete from " + filterV + " where Id = '" + deleteName + "'";
            using (SqlCommand delete = new SqlCommand(sql, connection))
            {
                delete.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void AddFromTable(BalanceProduct balance)
        {
            AddFromTable(balance.Name, balance.Description);
        }

        public void AddFromTable(string filterV, string nameOrDate)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"insert into Products (Name,Description)
                               values (@Name,@Descrition)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@Name", filterV));
            command.Parameters.Add(new SqlParameter("@Descrition", nameOrDate));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}