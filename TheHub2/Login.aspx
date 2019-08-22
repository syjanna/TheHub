<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheHub2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style3 {
            position: absolute;
            top: 251px;
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
            <center>
            <h3 class="subtitle">Sign in</h3>
            <label>Username: </label> <asp:TextBox ID="uname_login" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />
            <label>Password: </label> <asp:TextBox ID="pswd_login" runat="server" style="z-index: 1" TextMode="Password" required="required"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="login_btn" runat="server" style="z-index: 1" Text="Sign in" OnClick="login_btn_Click" />

            <br />
            <asp:Label ID="msg" runat="server" ></asp:Label>
            <br />
            <br />
            
            <a href="Register.aspx">Register for an account</a>
            </center>

        </div>
    </form>
</body>
</html>
