<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewParts.aspx.cs" Inherits="TheHub2.ViewParts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Parts</title>
    <link href="main.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="main.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="PartsGridView" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
                    <Columns>
                        <asp:ImageField DataImageUrlField="imgurl" ControlStyle-Width="100" ControlStyle-Height = "100">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="name" ItemStyle-Width="300" HeaderStyle-Width="300" FooterStyle-Width="300">
<FooterStyle Width="300px"></FooterStyle>

<HeaderStyle Width="300px"></HeaderStyle>

<ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="defaultprice" DataFormatString="{0:C2}" HeaderText="$ per unit" />
                        <asp:TemplateField HeaderText="qty">
                        <ItemTemplate>
                            <asp:TextBox ID="qty" Width="40" runat="server" Text="1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="qty_validator" runat="server" ControlToValidate = "qty" ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" Display="Dynamic" ></asp:RegularExpressionValidator>
            
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="addpart" runat="server" CommandArgument='<%# Container.DataItemIndex  %>' Text="Add to cart" OnCommand="addpart_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
         </asp:GridView>
        
    </form>
</body>
</html>
