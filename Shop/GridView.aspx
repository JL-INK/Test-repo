<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="Shop.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Магазин</title>
</head>
<body>
    <form id="form1" runat="server">
        Товар<br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="145px"></asp:TextBox>
        <br />
        Описание<br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" style="margin-top: 0px" Width="144px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Добавить" Width="74px" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Удалить" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
