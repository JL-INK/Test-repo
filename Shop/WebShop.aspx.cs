using System;
using System.Configuration;
using System.Data.SqlClient;
using Warehouse.Models;
using Warehouse.Service;

namespace Shop
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            var product = new Product();
            string name = TextBox1.Text.ToString();
            product.Name = name;
            string description = TextBox2.Text.ToString();
            product.Description = description;
            service.AddProduct(product);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            var product = new Product();
            string name = TextBox1.Text.ToString();
            product.Name = name;
            string description = TextBox2.Text.ToString();
            product.Description = description;
            service.DeleteFromTable(name, description);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
