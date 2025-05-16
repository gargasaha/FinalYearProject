<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="FinalYearProject.chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link rel="preconnect" href="https://fonts.googleapis.com" />
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="" />
<link href="https://fonts.googleapis.com/css2?family=Caveat:wght@400..700&family=Pacifico&display=swap" rel="stylesheet" />
<link rel="preconnect" href="https://fonts.googleapis.com" />
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
<link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet" />
<style>
    .chat-header {
        background-color: #2196F3;
        color: #fff;
        padding: 10px;
        display: flex;
        justify-content: left;
        height: 50px;
        display: flex;
        align-items: center;
        width: 98%;
    }

    .chtlbl1 {
        display: inline-block;
        text-align: right;
        background-color: #0094ff;
        border-top-left-radius: 30%;
        border-top-right-radius: 30%;
        border-bottom-left-radius: 30%;
        padding: 20px;
    }

    .lbl1 {
        text-align: right;
    }

    .lbl2 {
        text-align: left;
    }

    .chtlbl2 {
        display: inline-block;
        text-align: right;
        background-color: darkgray;
        border-top-left-radius: 30%;
        border-top-right-radius: 30%;
        border-bottom-right-radius: 30%;
        padding: 20px;
    }

    .pnl {
        width: 100%;
    }

    .tbl {
        width: 100%;
    }

    .chtlbl11 {
        display: inline-block;
        text-align: right;
        padding: 20px;
    }

    .chtlbl22 {
        display: inline-block;
        text-align: right;
        padding: 20px;
    }

    .frndimg {
        height: 50px;
        width: 50px;
        border-radius: 50%;
        align-content: flex-start;
    }

    .frndname {
        font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        font-size: 25px;
        margin-left: 30px;
        font-weight: 400;
        font-style: normal;
        color: black;
        padding: .5rem 0 0 1rem;
        position: absolute;
    }

    .dot {
        height: 50px;
        width: 50px;
    }

    .im {
        height: 150px;
        width: 150px;
        border-width: 4px;
        border: solid;
        border-color: black;
        border-radius: 25px;
    }
</style>
<body style="background-image: url('IMAGES/ChatBG.jpg')">
    <script>
        function fun1(x) {
            var a = document.getElementById('<%= main.ClientID %>');
            a.style.display = "none";
            var b = document.getElementById('<%= imgpnl.ClientID %>');
            b.style.display = "inherit";
            var i = document.getElementById("selectedimage");
            i.src = x;
        }
        function fun2() {
            var a = document.getElementById('<%= main.ClientID %>');
            a.style.display = "inherit";
            var b = document.getElementById('<%= imgpnl.ClientID %>');
            b.style.display = "none";

        }
    </script>

    <form id="form1" runat="server" style="height: 90vh">
        <asp:Panel runat="server" ID="bd" style="height:95vh">
            <asp:Label runat="server" ID="temp" Visible="false" Text="0"></asp:Label>
            <asp:Panel runat="server" ID="main" Style="width: 100%; text-align: center">
                <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
                <div style="display: flex; justify-content: right; width: 100%; position: absolute;">
                    <asp:Button runat="server" Text="Unfriend" ID="uf" OnClick="unfriend" Style="margin-right: 40px; margin-top: 10px; width: 100px; height: 50px; border-radius: 25px; border: none; background-color: black; color: white" />

                </div>
                <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <div class="chat-header">
                            <div style="width: 50%; text-align: left;">
                                <asp:Image runat="server" ID="frndimage" CssClass="frndimg" />
                                <asp:Label runat="server" ID="frndname" CssClass="frndname" />
                            </div>


                            <%--<div style="width: 50%; text-align: right">
    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="dot" ImageUrl="~/IMAGES/3dot.jpg" />
</div>--%>
                        </div>
                        <asp:Panel runat="server" ID="chatpnl" CssClass="pnl">
                            <asp:Timer runat="server" Interval="1000"></asp:Timer>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </asp:Panel>
            <asp:Panel runat="server" ID="imgpnl" Style="display: none; height: 500px">
                <div style="display: flex; justify-content: right">
                    <asp:ImageButton runat="server" ImageUrl="~/IMAGES/cross.png" Style="height: 40px; width: 40px" OnClientClick="fun2()" />
                </div>
                <img id="selectedimage" style="height: 500px; width: 500px; width: 752px; border-radius: 25px; border-color: black; border-width: 10px" />

            </asp:Panel>

        </asp:Panel>

    </form>
</body>

</html>
