<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="Shop.Warehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:SqlDataSource ID="Товары" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
        <asp:DropDownList class="Product" Width="100%" ID="Name" runat="server" DataSourceID="Товары" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="Name_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:TextBox class="Product" Width="100%" placeholder="Введите количество..." ID="Quantity" runat="server" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox class="Product" Width="100%" placeholder="Введите дату..." ID="Date" runat="server" OnTextChanged="Date_TextChanged"></asp:TextBox>
    </p>
    <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="Добавить" />
    <p>
        <asp:GridView ID="GridView1" class="table table-bordered" Width="100%" PageSize="8" AllowPaging="True" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Supply" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" Visible="false" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField ItemStyle-Width="500px" DataField="Name" HeaderText="Наименование" SortExpression="Name" />
                <asp:BoundField ItemStyle-Width="200px" DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" />
                <asp:BoundField ItemStyle-Width="200px" DataField="Date" HeaderText="Дата" SortExpression="Date" />
                <asp:ButtonField ItemStyle-Width="50px" ControlStyle-CssClass="btn btn-secondary" ButtonType="Button" CommandName="Delete" Text="Удалить" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Supply" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="delete from Supply where Id=@Id"
            SelectCommand="select u.Id,p.Name,Quantity,Date from Supply u 
            left join Products p on u.ProductId=p.Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" />
            </DeleteParameters>
        </asp:SqlDataSource>
</asp:Content>

