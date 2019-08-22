<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TheHub2.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Cart</title>
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
        <h1 class="title" style="text-align:center;">Your Cart</h1>
        <br />
        <div style=""width:100%">
        <asp:GridView ID="cartitems_grid" runat="server" AutoGenerateColumns="false" BorderStyle="none" GridLines="Horizontal" CellPadding="2" Width="100%">
            <Columns>
                <asp:ImageField DataImageUrlField="imgurl" ControlStyle-Width="200" ControlStyle-Height = "200"><ControlStyle Height="200px" Width="200px"></ControlStyle>
                </asp:ImageField>
                
                <asp:BoundField DataField="product.name" HeaderText="Name"/>
                <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:c}"/>
                <asp:TemplateField HeaderText="qty">
                    <ItemTemplate>
                        <asp:TextBox ID="purchasequantity" Width="40" runat="server" Text='<%#: Eval("quantity") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="purchasequantity_validator" runat="server" ControlToValidate = "purchasequantity" ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
            
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Configurations (if applicable)">
                    <ItemTemplate>
                        <%# Eval("ram.name") + "<br/>" + Eval("os.name") + "<br/>" + Eval("cpu.name") + "<br/>" + Eval("drive.name") + "<br/>" + Eval("sound.name") 
    + "<br/>" + Eval("display.name") + "<br/>" + Eval("graphicscard.name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:CheckBox ID="remove" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <strong>
            <br />
            <asp:Label ID="ordertotal_label" runat="server" Text="Order total: "></asp:Label>
            <asp:Label ID="ordertotal" runat="server" Text="$0"></asp:Label>
            <asp:Button ID="update_btn" runat="server" Text="Update" OnClick="update_btn_Click" style="float: right"/>      
        </strong>
              
        <br />
        <br />
        <br />
        <center><asp:Button ID="checkout_btn" runat="server" Text="Checkout" Height="94px" Width="367px" OnClick="checkout_btn_Click" />
            <br /><asp:Label ID="msg" runat="server"></asp:Label></center>
        
        
 
        
        
    </form>
</body>
</html>
