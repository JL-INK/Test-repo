<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebShop.aspx.cs" Inherits="Shop.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Магазин</title>
</head>
<body>
    <form id="form1" runat="server">
        Товар<br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="145px"></asp:TextBox>
        <br />
        Описание<br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Style="margin-top: 0px" Width="144px"></asp:TextBox>
        <br />
        <asp:Button ID="Add" runat="server" Height="24px" OnClick="Add_Click" Text="Добавить" Width="74px" />
        &nbsp;<asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Удалить" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="187px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="214px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id, Name, Description FROM Shop.dbo.Products" DeleteCommand="DELETE FROM Products
WHERE id = @id" OnSelecting="SqlDataSource1_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
