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
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ProductId" DataValueField="ProductId">
            </asp:DropDownList>
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
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select u.Id, u.ProductId, p.Name, Quantity, Date from Shop.dbo.Supply u
left join Products p on p.Id = u.ProductId"></asp:SqlDataSource>
            <br />
            <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Удалить" />
        </div>
    </form>
</body>
</html>
