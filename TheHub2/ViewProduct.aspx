<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="TheHub2.ViewProduct" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 122px;
            left: 13px;
            z-index: 1;
            height: 61px;
            width: 500px;
            margin-bottom: 15px;
        }
        .auto-style2 {
            position: absolute;
            top: 227px;
            left: 8px;
            z-index: 1;
            width: 528px;
            height: 422px;
        }
        .auto-style3 {
            position: absolute;
            top: 121px;
            left: 564px;
            z-index: 1;
            width: 469px;
            height: 67px;
        }
        .auto-style4 {
            position: absolute;
            top: 248px;
            left: 562px;
            z-index: 1;
            width: 459px;
            height: 302px;
        }
        .auto-style5 {
            position: absolute;
            top: 580px;
            left: 573px;
            z-index: 1;
            width: 426px;
            height: 70px;
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
            <br />
            <br />
            <asp:Image ID="displayImage" runat="server" CssClass="auto-style2" />
            <asp:Label ID="displayName" runat="server" CssClass="auto-style1" Font-Size="XX-Large"></asp:Label>
            <br />

        </div>
        <p>
            <asp:Label ID="displayPrice" runat="server" CssClass="auto-style3" Font-Size="XX-Large"></asp:Label>
            </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="displayConfigs" runat="server" CssClass="auto-style4"></asp:Label>
        </p>
        <asp:Button ID="orderBtn" runat="server" CssClass="auto-style5" Text="Go to Order Page" OnClick="orderBtn_Click" />
    </form>
</body>
</html>
