<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="Shop.Warehouse" %>

<%@ Register assembly="FastReport.Web, Version=2020.2.2.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c" namespace="FastReport.Web" tagprefix="cc1" %>

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
    <p>
        <cc1:WebReport ID="WebReport1" Width="100%" runat="server" ReportResourceString="77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxSZXBvcnQgU2NyaXB0TGFuZ3VhZ2U9IkNTaGFycCIgUmVwb3J0SW5mby5DcmVhdGVkPSIwMy8yMy8yMDIwIDIyOjQyOjU1IiBSZXBvcnRJbmZvLk1vZGlmaWVkPSIwMy8yNC8yMDIwIDAwOjE1OjM0IiBSZXBvcnRJbmZvLkNyZWF0b3JWZXJzaW9uPSIyMDIwLjIuMi4wIj4NCiAgPERpY3Rpb25hcnk+DQogICAgPE1zU3FsRGF0YUNvbm5lY3Rpb24gTmFtZT0iQ29ubmVjdGlvbjEiIENvbm5lY3Rpb25TdHJpbmc9InJpamNtbHFCem5oMElUbmlQRkM2YkVHVElqNDdkYm8zQVd3UjhTV3hGbkJZcjZkdEszMlVZcDBiT0FJWk1OSEx4blVLcUpyWFJ5d3ZoT3pjQ1JRQ3RReEFua2NRT1dXTjNMVU5SV1luOVYxZXRNREVLWXBjYU45MktVOWZVOVI3NVJXUk5JOUJ5OWVkZDk2aXdqRG1WNm85RmRydS9sbXFOM3NYWGNsMkNBN0JxY0NYQWo1djRBZDBqR0NNTzRpSzl5VFMvNHoiPg0KICAgICAgPFRhYmxlRGF0YVNvdXJjZSBOYW1lPSJQcm9kdWN0cyIgRGF0YVR5cGU9IlN5c3RlbS5JbnQzMiIgRW5hYmxlZD0idHJ1ZSIgVGFibGVOYW1lPSJQcm9kdWN0cyI+DQogICAgICAgIDxDb2x1bW4gTmFtZT0iSWQiIERhdGFUeXBlPSJTeXN0ZW0uSW50MzIiLz4NCiAgICAgICAgPENvbHVtbiBOYW1lPSJOYW1lIiBEYXRhVHlwZT0iU3lzdGVtLlN0cmluZyIvPg0KICAgICAgICA8Q29sdW1uIE5hbWU9IkRlc2NyaXB0aW9uIiBEYXRhVHlwZT0iU3lzdGVtLlN0cmluZyIvPg0KICAgICAgPC9UYWJsZURhdGFTb3VyY2U+DQogICAgICA8VGFibGVEYXRhU291cmNlIE5hbWU9IlN1cHBseSIgRGF0YVR5cGU9IlN5c3RlbS5JbnQzMiIgRW5hYmxlZD0idHJ1ZSIgVGFibGVOYW1lPSJTdXBwbHkiPg0KICAgICAgICA8Q29sdW1uIE5hbWU9IklkIiBEYXRhVHlwZT0iU3lzdGVtLkludDMyIi8+DQogICAgICAgIDxDb2x1bW4gTmFtZT0iUHJvZHVjdElkIiBEYXRhVHlwZT0iU3lzdGVtLkludDMyIi8+DQogICAgICAgIDxDb2x1bW4gTmFtZT0iUXVhbnRpdHkiIERhdGFUeXBlPSJTeXN0ZW0uSW50MzIiLz4NCiAgICAgICAgPENvbHVtbiBOYW1lPSJEYXRlIiBEYXRhVHlwZT0iU3lzdGVtLkRhdGVUaW1lIi8+DQogICAgICA8L1RhYmxlRGF0YVNvdXJjZT4NCiAgICA8L01zU3FsRGF0YUNvbm5lY3Rpb24+DQogICAgPFJlbGF0aW9uIE5hbWU9IlByb2R1Y3RzX1N1cHBseSIgUGFyZW50RGF0YVNvdXJjZT0iUHJvZHVjdHMiIENoaWxkRGF0YVNvdXJjZT0iU3VwcGx5IiBQYXJlbnRDb2x1bW5zPSJJZCIgQ2hpbGRDb2x1bW5zPSJQcm9kdWN0SWQiIEVuYWJsZWQ9InRydWUiLz4NCiAgICA8UmVsYXRpb24gTmFtZT0iUHJvZHVjdHNfU3VwcGx5MSIgUGFyZW50RGF0YVNvdXJjZT0iUHJvZHVjdHMiIENoaWxkRGF0YVNvdXJjZT0iU3VwcGx5IiBQYXJlbnRDb2x1bW5zPSJJZCIgQ2hpbGRDb2x1bW5zPSJQcm9kdWN0SWQiIEVuYWJsZWQ9InRydWUiLz4NCiAgICA8UmVsYXRpb24gTmFtZT0iU3VwcGx5X1Byb2R1Y3RzIiBQYXJlbnREYXRhU291cmNlPSJTdXBwbHkiIENoaWxkRGF0YVNvdXJjZT0iUHJvZHVjdHMiIFBhcmVudENvbHVtbnM9IlByb2R1Y3RJZCIgQ2hpbGRDb2x1bW5zPSJJZCIgRW5hYmxlZD0idHJ1ZSIvPg0KICA8L0RpY3Rpb25hcnk+DQogIDxSZXBvcnRQYWdlIE5hbWU9IlBhZ2UxIiBGaXJzdFBhZ2VTb3VyY2U9IjEiIE90aGVyUGFnZXNTb3VyY2U9IjEiIFdhdGVybWFyay5Gb250PSJBcmlhbCwgNjBwdCI+DQogICAgPFJlcG9ydFRpdGxlQmFuZCBOYW1lPSJSZXBvcnRUaXRsZTEiIFdpZHRoPSI3MTguMiIgSGVpZ2h0PSIzNy44Ii8+DQogICAgPFBhZ2VIZWFkZXJCYW5kIE5hbWU9IlBhZ2VIZWFkZXIxIiBUb3A9IjQxLjgiIFdpZHRoPSI3MTguMiIgSGVpZ2h0PSIyOC4zNSIvPg0KICAgIDxEYXRhQmFuZCBOYW1lPSJEYXRhMSIgVG9wPSI3NC4xNSIgV2lkdGg9IjcxOC4yIiBIZWlnaHQ9IjM3LjgiIENhbkdyb3c9InRydWUiPg0KICAgICAgPFRleHRPYmplY3QgTmFtZT0iVGV4dDEiIExlZnQ9IjMwIiBUb3A9IjkuNCIgV2lkdGg9Ijk0LjUiIEhlaWdodD0iMTguOSIgVGV4dD0i0J3QsNC40LzQtdC90L7QstCw0L3QuNC1IiBGb250PSJBcmlhbCwgMTBwdCIvPg0KICAgICAgPFRleHRPYmplY3QgTmFtZT0iVGV4dDIiIExlZnQ9IjU5Ni41NSIgVG9wPSI3LjQiIFdpZHRoPSI5NC41IiBIZWlnaHQ9IjE4LjkiIFRleHQ9ItCU0LDRgtCwIiBGb250PSJBcmlhbCwgMTBwdCIvPg0KICAgICAgPFRleHRPYmplY3QgTmFtZT0iVGV4dDMiIExlZnQ9IjQ4MyIgVG9wPSI2LjQiIFdpZHRoPSI5NC41IiBIZWlnaHQ9IjE4LjkiIFRleHQ9ItCa0L7Qu9C40YfQtdGB0YLQstC+IiBGb250PSJBcmlhbCwgMTBwdCIvPg0KICAgICAgPERhdGFCYW5kIE5hbWU9IkRhdGEyIiBUb3A9IjExNS45NSIgV2lkdGg9IjcxOC4yIiBIZWlnaHQ9IjM3LjgiIERhdGFTb3VyY2U9IlByb2R1Y3RzIj4NCiAgICAgICAgPFRleHRPYmplY3QgTmFtZT0iVGV4dDQiIExlZnQ9IjI4IiBUb3A9IjkuNiIgV2lkdGg9Ijk0LjUiIEhlaWdodD0iMTguOSIgVGV4dD0iW1Byb2R1Y3RzLk5hbWVdIiBGb250PSJBcmlhbCwgMTBwdCIvPg0KICAgICAgICA8VGV4dE9iamVjdCBOYW1lPSJUZXh0NSIgTGVmdD0iNDgzIiBUb3A9IjkuNiIgV2lkdGg9Ijk0LjUiIEhlaWdodD0iMTguOSIgVGV4dD0iW1Byb2R1Y3RzLlN1cHBseS5RdWFudGl0eV0iIEZvbnQ9IkFyaWFsLCAxMHB0Ii8+DQogICAgICAgIDxUZXh0T2JqZWN0IE5hbWU9IlRleHQ2IiBMZWZ0PSI1OTgiIFRvcD0iNy42IiBXaWR0aD0iOTQuNSIgSGVpZ2h0PSIxOC45IiBUZXh0PSJbUHJvZHVjdHMuU3VwcGx5LkRhdGVdIiBGb3JtYXQ9IkRhdGUiIEZvcm1hdC5Gb3JtYXQ9ImQiIEZvbnQ9IkFyaWFsLCAxMHB0Ii8+DQogICAgICA8L0RhdGFCYW5kPg0KICAgIDwvRGF0YUJhbmQ+DQogICAgPFBhZ2VGb290ZXJCYW5kIE5hbWU9IlBhZ2VGb290ZXIxIiBUb3A9IjE1Ny43NSIgV2lkdGg9IjcxOC4yIiBIZWlnaHQ9IjE4LjkiLz4NCiAgPC9SZXBvcnRQYWdlPg0KPC9SZXBvcnQ+DQo=" />
</asp:Content>

