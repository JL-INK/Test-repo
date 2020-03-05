using Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Warehouse.Service
{
    public class BalanceProductService
    {
        string _connectionString;

        public BalanceProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Сортировать по названию
        /// </summary>
        /// <param name="name">название</param>
        /// <returns></returns>
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

        public void AddSupply(int id, int quantity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сортировать по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public List<BalanceProduct> GetProductByDate(string date)
        {
            List<BalanceProduct> list = new List<BalanceProduct>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DateTime saleDate = DateTime.Now;

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

        /// <summary>
        /// Удалить строку по ИД
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="rowId">ИД</param>
        public void DeleteFromTable(string tableName, string rowId)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"delete from " + tableName + " where Id = '" + rowId + "'";
            using (SqlCommand delete = new SqlCommand(sql, connection))
            {
                delete.ExecuteNonQuery();
            }
            connection.Close();
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="product">Продукт</param>
        public void AddProduct(Product product)
        {
            AddProduct(product.Name, product.Description);
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="productName">Наименование продукта</param>
        /// <param name="description">Описание продукта</param>
        public void AddProduct(string productName, string description)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"insert into Products (Name,Description)
                               values (@Name,@Descrition)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@Name", productName));
            command.Parameters.Add(new SqlParameter("@Descrition", description));
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Вывести все продукты
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns></returns>
        public List<BalanceProduct> GetProducts()
        {
            List<BalanceProduct> list = new List<BalanceProduct>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand product = new SqlCommand(@"select * from Products", connection);
                SqlDataReader readerName = product.ExecuteReader();
                while (readerName.Read())
                {
                    BalanceProduct item = new BalanceProduct()
                    {
                        Id = (int)readerName["Id"],
                        Name = readerName["Name"].ToString(),
                        Description = readerName["Description"].ToString(),
                    };
                    list.Add(item);
                }
                readerName.Close();
                connection.Close();
            }
            return list;
        }

        public void AddSales(int id, int quantity, DateTime date)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            string sql = @"insert into Sales (ProductId,Quantity,Date)
                               values (@ProductId,@Quantity,@Date)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@ProductId", id));
            command.Parameters.Add(new SqlParameter("@Quantity", quantity));
            command.Parameters.Add(new SqlParameter("@Date", date));
            command.ExecuteNonQuery();
            connection.Close();
        }


    }
}