<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FinalYearProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:SqlDataSource runat="server" ID="ds" ConnectionString="<%$ ConnectionStrings:database %>" SelectCommand="select *from bh"></asp:SqlDataSource>
        <asp:DataList runat="server" ID="dl" DataSourceID="ds">
            <ItemTemplate>
                <asp:Label runat="server" Style="background-color: red" Text='<%#Eval("Num") %>'></asp:Label>
                <asp:Label runat="server" Style="background-color: green" Text='<%#Eval("Uname") %>'></asp:Label>
                <asp:Button runat="server" Text="Submit" OnClick="fun1" CssClass='<%#Eval("Num") %>' />
            </ItemTemplate>
        </asp:DataList>
        <asp:Label runat="server" ID="name"></asp:Label>
    </form>
</body>
</html>
