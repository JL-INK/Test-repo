<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="Shop.Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> – мое приложение ASP.NET</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="~/">Имя приложения</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a runat="server" href="~/">Домашняя</a></li>
                    <li><a runat="server" href="~/About">Информация</a></li>
                    <li><a runat="server" href="~/Contact">Связаться</a></li>
                    <li><a runat="server" href="~/WebShop">Магазин</a></li>
                    <li><a runat="server" href="~/Warehouse">Закупки</a></li>
                    <li><a runat="server" href="~/Sales">Продажи</a></li>
                </ul>
            </div>
        </div>
    </div>


    <form id="form1" runat="server">
        <br />

        <br />
        <asp:GridView CssClass="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="187px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name" />
                <asp:BoundField DataField="balance" HeaderText="Остаток" ReadOnly="True" SortExpression="balance" />
            </Columns>
        </asp:GridView>
        <br />




        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select p.Id, Name, (sumSupply.Quantity - sumSales.Quantity) as balance from Products p
left join (
select ProductId,
sum(Quantity) Quantity
 from dbo.Sales a
 group by ProductId) as sumSales 
 on sumSales.ProductId = p.Id
 left join (
 select ProductId,
sum(Quantity) Quantity
 from dbo.Supply u
 group by ProductId) as sumSupply
 on sumSupply.ProductId = p.Id
"
            OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT a.Id, p.Name,Quantity,Date FROM Sales a
left join Products p on a.ProductId=p.Id"
            DeleteCommand="delete from Sales where Id=@Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" />
            </DeleteParameters>
        </asp:SqlDataSource>
        &nbsp;&nbsp;
                Дата&nbsp;
        <asp:TextBox ID="Date" runat="server" Width="87px" OnTextChanged="Date_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp; Количество
                <asp:TextBox ID="Quantity" runat="server" Width="87px" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Add0" runat="server" Text="Продать" BorderStyle="None" OnClick="Add_Click" />
        <br />
        <br />
        <asp:GridView CssClass="table table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Height="187px" Width="100%" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Наименование" SortExpression="Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" />
                <asp:BoundField DataField="Date" HeaderText="Дата" SortExpression="Date" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Удалить" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
