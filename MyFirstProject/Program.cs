﻿using System;
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
                {
                    
                    {
                        string ent = Console.ReadLine();
                        String[] request = ent.Split();
                        var cmd = request[0];
                        var filter = request[1];
                        var nOrD = request[2];
                        switch (cmd)
                        {
                            case "get":

                                switch (filter)
                                {
                                    case "name":

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
                                        
                                        break;

                                    case "date":

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
                                        
                                        break;
                                }

                                break;
                            case "delete":

                                string sql = @"delete from " + filter + " where Id = '" + nOrD +"'";
                                SqlCommand delete = new SqlCommand(sql,connection);
                                delete.ExecuteNonQuery();
                                break;
                        }

                    }
                }
                connection.Close();
                Console.ReadKey();

            }

        }
    }
}
