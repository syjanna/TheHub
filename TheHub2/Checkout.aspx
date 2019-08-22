<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TheHub2.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
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
        <h1 class="title" style="text-align:center;">Checkout</h1>
        <center>
            <h2><asp:Label ID="msg" runat="server"></asp:Label></h2>
        </center>
        <div>
            <h3 class="subtitle">Shipping details</h3>
            <label>Full name (*): </label> <asp:TextBox ID="name" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />

            <label>Address (*): </label> <asp:TextBox ID="addr" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />

            <label>City (*): </label> <asp:TextBox ID="city" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />

            <label>State/Province (*): </label> <asp:TextBox ID="province" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />

            <label>Postal code (*): </label> <asp:TextBox ID="postal" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />

            <label>Phone number (*): </label> <asp:TextBox ID="phone" runat="server" style="z-index: 1" required="required"></asp:TextBox>
            <br />
            
            
        </div>

        <div>
            <h3 class="subtitle">Order summary</h3>
            <asp:GridView ID="summary_grid" runat="server" AutoGenerateColumns="false" BorderStyle="none" GridLines="Horizontal" CellPadding="2" Width="100%">
            <Columns>
                <asp:ImageField DataImageUrlField="imgurl" ControlStyle-Width="200" ControlStyle-Height = "200"><ControlStyle Height="200px" Width="200px"></ControlStyle>
                </asp:ImageField>
                
                <asp:BoundField DataField="product.name" HeaderText="Name"/>
                <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:c}"/>
                <asp:BoundField DataField="quantity" HeaderText="Qty" />
                <asp:TemplateField HeaderText="Configurations (if applicable)">
                    <ItemTemplate>
                        <%# Eval("ram.name") + "<br/>" + Eval("os.name") + "<br/>" + Eval("cpu.name") + "<br/>" + Eval("drive.name") + "<br/>" + Eval("sound.name") 
    + "<br/>" + Eval("display.name") + "<br/>" + Eval("graphicscard.name") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
        <br />
        <center><asp:Button ID="order_btn" runat="server" Text="Submit order" OnClick="order_btn_Click" CssClass="auto-style1" Height="113px" Width="490px" /></center>
        <br />
    </form>
</body>
</html>
