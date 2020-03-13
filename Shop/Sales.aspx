<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="Shop.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:Button ID="Add0" runat="server" Text="Продать" OnClick="Add_Click" />
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
</asp:Content>
