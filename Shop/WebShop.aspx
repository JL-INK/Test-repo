<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebShop.aspx.cs" Inherits="Shop.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
  
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
</head>
<body>
    <form id="WebShop" runat="server">
        <nav class="navbar navbar-dark bg-dark">
            <ul class="nav">
                <li class="nav-item" style="border-right: 2px solid gray"><a class="nav-link text-light" runat="server" href="~/">Главная</a></li>
            </ul>
            <div class="page-header text-light">
                <h3>Магазин
                </h3>
            </div>
            <ul class="nav">
                <li class="nav-item" style="border-left: 2px solid gray"><a class="nav-link text-light" runat="server" href="~/Warehouse">Склад</a></li>
                <li class="nav-item"><a class="nav-link text-light" runat="server" href="~/Sales">Продажи</a></li>
            </ul>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
                <p>
                    <asp:GridView CssClass="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" Width="300px" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="187px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        </Columns>

                    </asp:GridView>
                </p>
            </div>
            <div class="col-md-4">
                <p>
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox1" class="form-control" placeholder="Товар" runat="server" OnTextChanged="TextBox1_TextChanged" Width="145px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Описание" runat="server" OnTextChanged="TextBox2_TextChanged" Style="margin-top: 0px" Width="144px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    &nbsp;<asp:Button class="btn btn-dark" ID="Add" runat="server" Height="40px" OnClick="Add_Click" Text="Добавить" Width="100px" />
                    <br />
                    <br />
                    &nbsp;<asp:Button class="btn btn-dark" ID="Delete" runat="server" Height="40px" OnClick="Delete_Click" Text="Удалить" Width="100px" />
                    <br />
                    <br />
                </p>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id, Name, Description FROM Shop.dbo.Products"></asp:SqlDataSource>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
