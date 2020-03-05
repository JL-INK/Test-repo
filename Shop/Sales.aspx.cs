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
    public partial class Sales : System.Web.UI.Page
    {
        string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void Add_Click(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            var product = new BalanceProduct();
            string i = Id.Text.ToString();
            int id = Convert.ToInt32(i);
            product.ProductId = id;
            string d = Date.Text.ToString();
            DateTime date = Convert.ToDateTime(d);
            product.Date = date;
            string q = Quantity.Text.ToString();
            int quantity = Convert.ToInt32(q);
            product.Quantity = quantity;
            service.AddSales(id, quantity, date);
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void Id_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Date_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Id_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            if (GridView2.SelectedDataKey == null)
            {
                return;
            }
            string id = GridView2.SelectedDataKey["Id"].ToString();
            string tableName = "Sales";
            service.DeleteFromTable(tableName, id);
            GridView1.DataBind();
            GridView2.DataBind();
        }
    }
}