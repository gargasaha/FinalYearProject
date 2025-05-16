<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example.aspx.cs" Inherits="FinalYearProject.Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="GET" runat="server" OnClick="Unnamed_Click" />
            <asp:Label runat="server" ID="txt"></asp:Label>
        </div>
    </form>
</body>
</html>
