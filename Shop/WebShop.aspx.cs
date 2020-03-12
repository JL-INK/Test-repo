using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Models;
using Warehouse.Service;

namespace Shop
{
    public partial class Webshop : System.Web.UI.Page
    {
        string connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Add_Click1(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            var product = new Product();
            string name = Product.Text.ToString();
            product.Name = name;
            string description = Description.Text.ToString();
            product.Description = description;
            service.AddProduct(product);
            GridView1.DataBind();
        }
    }
}