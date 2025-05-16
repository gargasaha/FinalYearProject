<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineOffline.aspx.cs" Inherits="FinalYearProject.OnlineOffline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .container {
            margin-top: 10px;
            width: 100%;
            background-color: #bfbfbf;
            padding: 10px;
            margin-bottom: 30px;
            display: flex;
            justify-content: center;
            border-radius: 25px;
            -webkit-box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
            -moz-box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
            box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
        }

        .searchtxt {
            border-block-width: 2px;
            border-radius: 10px;
            border-color: black;
            color: transparent;
            color: black;
            height: 50px;
            width: 300px;
        }

        .aa {
            display: block;
            width: 50px;
            height: 50px;
            background-color: #2196F3;
            background-size: cover;
            background-repeat: no-repeat;
            background-position: center center;
            -webkit-border-radius: 99em;
            -moz-border-radius: 99em;
            border-radius: 99em;
            border: 5px solid #eee;
            box-shadow: 4px 4px 2px rgba(0, 0, 0, 0.3);
        }

        .searchbutt {
            cursor: pointer;
            margin-left: 10px;
            border-radius: 50px;
            height: 50px;
            width: 40px;
        }

        .crossbutt {
            cursor: pointer;
            margin-left: 10px;
            margin-top: 15px;
            border-radius: 50px;
            height: 20px;
            width: 20px;
        }

        .profileimage {
            border-radius: 25px;
        }

        .row {
            padding: 20px;
        }

        .lowerimg2 {
            padding-top: 60px;
        }

        .stylenone {
            border: none;
            cursor: pointer;
            border-radius: 50px;
            padding: 10px
        }

        .pnl {
            width: 100%;
        }

        .info {
            position: relative;
            padding-top: 20px;
            margin: 0 20px
        }

        .tbl {
            width: 100%;
            text-align: center;
            border-radius: 50px;
        }

        .nm {
            color: #333;
            font-size: 16px;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .column {
            border-radius: 50px;
        }
    </style>
    <script>
        function fun1(x) {

            window.open("addFriend.aspx?i=" + x);
            //alert(x);
        }

    </script>
    <form id="form1" runat="server" style="height: 100vh">
        <asp:Panel runat="server" Style="height: 100vh" ID="bd">
            <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
            <asp:Label runat="server" ID="temp" Visible="false" Text="0"></asp:Label>
            <div style="width: 100%;">
                <div style="display: flex; justify-content: center; background-color: #2196F3; padding: 10px; margin: 10px;">
                    <asp:TextBox CssClass="searchtxt" runat="server" ID="searchpnl" placeholder="SEARCH FRIEND"></asp:TextBox>
                    <asp:ImageButton runat="server" ImageUrl="~/IMAGES/searchIcon.png" BackColor="#cccccc" CssClass="searchbutt" OnClick="showSearchResult" />
                    <asp:ImageButton runat="server" ImageUrl="~/IMAGES/cross.png" ID="cr" Visible="false" BackColor="#cccccc" CssClass="crossbutt" OnClick="disableSearch" />

                </div>
                <div style="margin-top: 30px; margin: 0 30px 0 10px; width: 100%;">
                    <div style="margin-right: 40px;">
                        <asp:UpdatePanel runat="server" ID="up1">
                            <ContentTemplate>
                                <asp:Panel runat="server" CssClass="pnl1">
                                    <asp:Timer runat="server" Interval="1000" ID="Timer1"></asp:Timer>
                                    <div style="width: 100%;" class="container">
                                        <asp:Panel ID="pnl1" runat="server"></asp:Panel>
                                    </div>

                                </asp:Panel>





                            </ContentTemplate>
                        </asp:UpdatePanel>




                        <!-- More friend entries can be added here -->
                    </div>
                </div>
            </div>
        </asp:Panel>

    </form>
</body>
</html>
