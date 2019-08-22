<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="TheHub2.Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 514px;
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
        <br />
        <h1 class="title">Feedback</h1>
        <br />
        Have feedback? Send them to us! All feedback will be sent anonymously. 
        <br />
        <asp:TextBox ID="feedback_box" width="500" height="300" Required="required" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="submit_btn" runat="server" Text="Submit" OnClick="submit_btn_Click" />
        <br />
        <asp:Label ID="msg" runat="server"  style="z-index: 1" Text=""></asp:Label>
    </form>
</body>
</html>
