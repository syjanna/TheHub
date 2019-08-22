<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="TheHub2.ViewOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View order details</title>
    <link href="main.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            float: right;
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

        <center><h1 class="title">Order Details</h1></center>
        <br />

        <h2 class="subtitle"> Shipping details </h2>
        <asp:Repeater ID="r1" runat="server" >
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Date placed</td>
                        <td>Full name</td>
                        <td>Address</td>
                        <td>City</td>
                        <td>State/province</td>
                        <td>Postal code</td>
                        <td>Phone number</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("date") %></td>
                    <td><%# Eval("fullname") %></td>
                    <td><%# Eval("address") %></td>
                    <td><%# Eval("city") %></td>
                    <td><%# Eval("province") %></td>
                    <td><%# Eval("postalcode") %></td>
                    <td><%# Eval("phone") %></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <br />
        <h2 class="subtitle">Items ordered</h2>
        <center>
        <asp:GridView ID="order_gridview"  EnableViewState="false"  runat="server" AutoGenerateColumns="false" BorderStyle="none" GridLines="Horizontal" CellPadding="2" Width="100%">
            <Columns>
                <asp:ImageField DataImageUrlField="imgurl" ControlStyle-Width="200" ControlStyle-Height = "200"><ControlStyle Height="200px" Width="200px"></ControlStyle></asp:ImageField>
                <asp:BoundField DataField="name" HeaderText="Name"/>
                <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:c}"/>
                <asp:TemplateField HeaderText="qty">
                    <ItemTemplate>
                        <asp:TextBox ID="purchasequantity" Width="40" runat="server" Text='<%#: Eval("quantity") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="purchasequantity_validator" runat="server" ControlToValidate = "purchasequantity" ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                        <asp:Button ID="update_btn" runat="server" Text="update" CommandArgument='<%# Container.DataItemIndex + ";" + Eval("orderdetailid") %>' OnCommand="update_click" ></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="configs" HeaderText="Configurations (if applicable)" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="remove" runat="server" Text="delete" ButtonType="LinkButton" CommandArgument='<%# Eval("orderdetailid") %>' OnCommand="delete_click" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>



        <br />
        </center>
        <strong>
            <asp:Label ID="ordertotal_label" runat="server" Text="Order total: "></asp:Label>
            <asp:Label ID="ordertotal" runat="server" Text="$0"></asp:Label>
            <asp:Button ID="deleteorder_btn" runat="server" Text="Delete Order" CssClass="auto-style1" Height="62px" OnClick="deleteorder_btn_Click" Width="227px"/>      
        </strong>
        <br /><br />
        <a href="AccountPage.aspx"> Click here to return. </a>
        <br /><br />
    </form>
</body>
</html>
