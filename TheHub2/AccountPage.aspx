<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountPage.aspx.cs" Inherits="TheHub2.AccountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My account</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 119px;
            left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="loginlink" NavigateUrl="~/Login.aspx">Your account</asp:HyperLink>
        <div id="navbar" style="min-width: 700px; height: 60px; ">
            <a href="Home.aspx"><img src="Resources/Images/logo.png"/></a>
            <ul>
                <li><a href="./ViewCart.aspx">Cart</a></li>
                <li><a href="./Feedback.aspx">Feedback</a></li>
                <li><a href="./Contacts.aspx">Contacts</a></li>
                <li><a href="./Products.aspx">Browse</a></li>
            </ul>
        </div>

        <div>
            <br />
            <asp:Button ID="logout_btn" runat="server" Text="Logout" width="150" height="25" style="float:right;" OnClick="logout_btn_Click"/>
           <asp:Label ID="Label1" runat="server" CssClass="auto-style1" style="z-index: 1"></asp:Label>
            <br /><br />
           <h1 class="title">Order History</h1>
        </div>
        
        <asp:Repeater ID="userorders" runat="server">
            <HeaderTemplate>
                <table>
                <tr>
                    <td>Order ID</td>
                    <td>Date placed</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("orderid") %></td>
                    <td><%# Eval("date") %></td>
                    <td><a href='ViewOrder.aspx?orderid=<%# Eval("orderid") %>'>View full order</a></td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
