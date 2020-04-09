using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using Warehouse.Service;
using WebStoreMVC.Controllers;

namespace WebStoreMVC.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            List<Products> list = new List<Products>();
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand product = new SqlCommand(@"select * from Products", connection);
                SqlDataReader readerName = product.ExecuteReader();
                while (readerName.Read())
                {
                    Products item = new Products()
                    {
                        Id = (int)readerName["Id"],
                        Name = readerName["Name"].ToString(),
                        Description = readerName["Description"].ToString(),
                    };
                    list.Add(item);
                }
                readerName.Close();
                connection.Close();
                ViewBag.Products = list;
                return View();
            }
        }

        public void Add(string name, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"insert into Products (Name,Description)
                               values (@Name,@Descrition)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@Name", name));
                command.Parameters.Add(new SqlParameter("@Descrition", description));
                command.ExecuteNonQuery();
                connection.Close();
                Products();
            }
        }
        public void Delete(int id)
        {
            ViewBag.Id = id;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"delete from Products where Id = " + id;
                using (SqlCommand delete = new SqlCommand(sql, connection))
                {
                    delete.ExecuteNonQuery();
                }
                connection.Close();
                Products();
            }
        }

    }
}