<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="Shop.Warehouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Закупки</title>
</head>
<body style="height: 487px; width: 986px">
    <form id="form1" runat="server">
        <div style="height: 405px; width: 704px">
            Товар<br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [Products]"></asp:SqlDataSource>
            <br />
            Дата<br />
            <asp:TextBox ID="Date" runat="server" OnTextChanged="Date_TextChanged"></asp:TextBox>
            <br />
            Количество<br />
            <asp:TextBox ID="Quantity" runat="server" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
            <br />
            <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="Добавить" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                     <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select u.Id, u.ProductId, p.Name, Quantity, Date from Shop.dbo.Products p
left join Shop.dbo.Supply u on u.ProductId =p.Id "></asp:SqlDataSource>
            <br />
            <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Удалить" />
        </div>
    </form>
</body>
</html>
