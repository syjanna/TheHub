<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TheHub2.Products" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Our Products</title>
    <link href="main.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="main.js" type="text/javascript"></script>
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
        <div id="webcontent" style="width: 100%; height: 100%;">
            <center>
            <h1 class="title" style="text-align:center;">Our Products</h1>
            <hr />
            <h2 class="subtitle" style="text-align:center;">Computers</h2>
              
            <div id="computercontent">
                
                <asp:GridView ID="ComputersGridView" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
                    <Columns>
                        <asp:ImageField DataImageUrlField="imgurl" ControlStyle-Width="200" ControlStyle-Height = "200">
<ControlStyle Height="200px" Width="200px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="name" ItemStyle-Width="300" HeaderStyle-Width="300" FooterStyle-Width="300">
<FooterStyle Width="300px"></FooterStyle>

<HeaderStyle Width="300px"></HeaderStyle>

<ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="viewproduct" runat="server" CommandArgument='<%# Eval("productid")  %>' Text="View" OnClick="viewproduct_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                
            </div>
                <br /><br />

            <h2 class="subtitle" style="text-align:center;">Computer components</h2>
                SHOP BY CATEGORY
                <ul id="componentsmenu" style="background-color: #b7bcc4; width: 80%">
                    <li class="components" id="ram">Memory (RAM)</li>
                    <li class="components" id="os">OS</li>
                    <li class="components" id="cpu">CPU</li>
                    <li class="components" id="drive">Drives</li>
                    <li class="components" id="sound">Sound Cards</li>
                    <li class="components" id="display">Displays</li>
                    <li class="components" id="graphicscard">Graphics Cards</li>
                </ul>
                <hr />
                <div id ="componentcontent" >Click a category above to browse our products!</div>
                
                <br />
                <br />

            </center>
        </div>
    </form>
</body>
</html>
