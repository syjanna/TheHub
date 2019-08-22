<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="TheHub2.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contacts</title>
    <link href="main.css" rel="stylesheet" />
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

        <br />
        <h1 class="title">Contact Us</h1>
        <br />
        We are happy to answer your questions. Feel free to contact us using any of the following methods: <br />
        Email: contact@thehub.com <br />
        Phone (Toll-free): 1-800-123-4567

    </form>
</body>
</html>
