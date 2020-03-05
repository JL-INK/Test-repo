<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="Shop.Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="187px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="214px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="balance" HeaderText="balance" ReadOnly="True" SortExpression="balance" />
            </Columns>
        </asp:GridView>
        <br />
        Товар<br />
        <asp:DropDownList ID="Id" runat="server" DataSourceID="SqlDataSource3" DataTextField="ProductId" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [ProductId] FROM [Sales]"></asp:SqlDataSource>
        <br />
        Количество&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="Quantity" runat="server" Width="87px" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
&nbsp;
        <br />
        Дата<br />
        <asp:TextBox ID="Date" runat="server" Width="87px" OnTextChanged="Date_TextChanged"></asp:TextBox>
        <br />
&nbsp;<asp:Button ID="Add" runat="server" Text="Продать" BorderStyle="None" OnClick="Add_Click" />
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select p.Id, Name, (sumSupply.Quantity - sumSales.Quantity) as balance from Products p
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
" OnSelecting="SqlDataSource1_Selecting">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Sales]"></asp:SqlDataSource>
        <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Удалить" />
        <br />
    </form>
</body>
</html>
