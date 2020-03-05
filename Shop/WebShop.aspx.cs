using System;
using System.Configuration;
using System.Data.SqlClient;
using Warehouse.Models;
using Warehouse.Service;

namespace Shop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
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
            GridView1.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string productId = GridView1.SelectedDataKey["Id"].ToString();
            string tableName = "Products";
            var service = new BalanceProductService(connectionString);
            service.DeleteFromTable(tableName, productId);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}
