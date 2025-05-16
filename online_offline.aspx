<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="online_offline.aspx.cs" Inherits="FinalYearProject.online_offline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .searchlbl {
            
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
        <asp:Timer runat="server" ID="tm1"></asp:Timer>
        <div style="width:100%;text-align:center">
            <div>
                <asp:Label runat="server" CssClass="searchlbl"></asp:Label>
            </div>
            <asp:Panel runat="server" ID="onlineofflinepnl"></asp:Panel>
        </div>
    </form>
</body>
</html>
