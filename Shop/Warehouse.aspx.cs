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
    public partial class Warehouse : System.Web.UI.Page
    {
        string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Products_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Date_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            var service = new BalanceProductService(connectionString);
            var product = new BalanceProduct();
            string i = Name.Text.ToString();
            int id = Convert.ToInt32(i);
            product.Id = id;
            string d = Date.Text.ToString();
            DateTime date = Convert.ToDateTime(d);
            product.Date = date;
            string q = Quantity.Text.ToString();
            int quantity = Convert.ToInt32(q);
            product.Quantity = quantity;
            service.AddSupply(id, quantity, date);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}