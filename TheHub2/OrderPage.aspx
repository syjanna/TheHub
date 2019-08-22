<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="TheHub2.OrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Page</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 102px;
            left: 10px;
            z-index: 1;
            width: 302px;
            height: 63px;
        }
        .auto-style2 {
            position: absolute;
            top: 101px;
            left: 519px;
            z-index: 1;
            width: 384px;
            height: 80px;
        }
        .auto-style4 {
            width: 1431px;
            height: 379px;
            position: absolute;
            top: 188px;
            left: 5px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 255px;
            left: 5px;
            z-index: 1;
            width: 362px;
            height: 81px;
        }
        .auto-style6 {
            position: absolute;
            top: 218px;
            left: 276px;
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

        <asp:Label ID="displayName" runat="server" CssClass="auto-style1" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="displayPrice" runat="server" CssClass="auto-style2" Font-Size="XX-Large"></asp:Label>

            
        <div class="auto-style4">
            RAM: <asp:DropDownList ID="selectRAM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectRAM_SelectedIndexChanged" ></asp:DropDownList>
            
            <br />
            OS: <asp:DropDownList ID="selectOS" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectOS_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            CPU: <asp:DropDownList ID="selectCPU" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectCPU_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            Drive (HDD/SSD): <asp:DropDownList ID="selectDRIVE" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectDRIVE_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            Sound: <asp:DropDownList ID="selectSOUND" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectSOUND_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            Display: <asp:DropDownList ID="selectDISPLAY" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectDISPLAY_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            Graphics card: <asp:DropDownList ID="selectGRAPHICSCARD" runat="server" AutoPostBack="true" AppendDataBoundItems="False" OnSelectedIndexChanged="selectGRAPHICSCARD_SelectedIndexChanged"></asp:DropDownList>
            
            <br />

            <br />
            <asp:Label ID="quantity" runat="server" Text="Quantity: "></asp:Label>
            <asp:TextBox ID="user_quantity" runat="server" Width="30px" Text="1" Required="required"></asp:TextBox>
            <asp:RegularExpressionValidator ID="user_quantity_validator" runat="server" ControlToValidate = "user_quantity" ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
            
            <asp:Button ID="addCart_btn" runat="server" CssClass="auto-style5" Text="Add to cart" OnClick="addCart_btn_Click" />
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

