<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Webshop.aspx.cs" Inherits="Shop.Webshop" %>

<asp:Content ID="Wareshop" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:TextBox class="Product" ID="Product" runat="server" MaxLength="50" Width="100%" placeholder="Введите название товара..."></asp:TextBox>
    </p>
    <asp:TextBox class="Product" ID="Description" runat="server" TextMode="MultiLine" Height="50px" Width="100%" placeholder="Введите описание товара..."></asp:TextBox>

    <p>
        <asp:Button ID="Add" runat="server" Text="Добавить" OnClick="Add_Click1" />
    </p>
    <p>
        <asp:GridView class="table table-bordered" ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Products" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="8" AllowPaging="True">
            <Columns>
                <asp:BoundField ItemStyle-Width="50px" DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="200px" DataField="Name" HeaderText="Наименование" SortExpression="Name"></asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Описание" SortExpression="Description" />
                <asp:ButtonField ItemStyle-Width="50px" ControlStyle-CssClass="btn btn-secondary" ButtonType="Button" CommandName="Delete" Text="Удалить" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Products" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Products]" DeleteCommand="delete from Products where id = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
