<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="FinalYearProject.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource runat="server" ID="ds" ConnectionString="<%$ ConnectionStrings:database %>"></asp:SqlDataSource>
            <asp:DataList runat="server" DataSourceID="ds" ID="dl" style="height:100px">
                <ItemTemplate>
                    <asp:Image  runat="server" style="height:300px;width:300px" ImageUrl='<%# ((Eval("Image") is System.DBNull) ? "[Path to blank image]" : "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image"))) %>'/>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
