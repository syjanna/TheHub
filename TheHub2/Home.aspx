<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TheHub2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Hub</title>
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


        <div>
            <center>
                <br />
                <img src="Resources/Images/logo.png" width="400" height="auto"/>

                <p>
                    Welcome to The Hub! <br />
                    We are dedicated to bring you the most convenient and pleasurable experience of purchasing computers, whether you are looking to buy it pre-made or 
                    looking for parts to build one of your own. <br />
                    Get started by creating a new account with us or using our user-friendly interface to easily browse through our products.
                </p>
            </center>
        </div>
    </form>
</body>
</html>
