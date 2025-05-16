<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrndReq.aspx.cs" Inherits="FinalYearProject.FrndReq" %>

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
            text-align: center;
            border-radius: 25px;
            -webkit-box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
            -moz-box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
            box-shadow: 13px 13px 22px -3px rgba(0,0,0,0.63);
        }

        .header {
            width: 100vw;
            height: 75px;
            background-color: #2196F3;
            margin-bottom: 30px;
        }

        .friend {
            width: 400px;
            display: flex;
            align-items: center;
            border-bottom: 1px solid #ccc;
            padding: 20px 0;
        }

        .aa {
            display: block;
            width: 60px;
            height: 60px;
            margin: 1em auto;
            background-size: cover;
            background-repeat: no-repeat;
            background-position: center center;
            -webkit-border-radius: 99em;
            -moz-border-radius: 99em;
            border-radius: 99em;
            border: 5px solid #eee;
            box-shadow: 4px 4px 2px rgba(0, 0, 0, 0.3);
        }

        .friend .info {
            width: 200px;
        }

        .nm {
            color: #333;
            font-size: 16px;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .nametxt {
            margin-left: 10px
        }

        .btncol {
            display: flex;
            flex-direction: row;
            justify-content: center;
        }


        .friend .add-button:hover {
            background-color: #45a049;
        }

        .content {
            padding: 30px 0;
        }

        .pnl1 {
            display: flex;
            justify-content: center;
        }
    </style>
    <form id="form1" runat="server" style="height:95vh">
        <asp:Panel runat="server" ID="bd" style="height:95vh">
            <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
            <div class="header">
                <div style="display: flex; justify-content: center; font-size: 30px; padding-top: 20px">
                    Friend requests
                </div>
            </div>
            <asp:SqlDataSource runat="server" ID="ds" ConnectionString="<%$ ConnectionStrings:database %>"></asp:SqlDataSource>
            <asp:UpdatePanel runat="server" ID="up1">
                <ContentTemplate>
                    <asp:Panel runat="server" CssClass="pnl1" ScrollBars="Vertical">
                        <asp:Timer runat="server" Interval="1000" ID="tm1" OnTick="tm1_Tick"></asp:Timer>

                        <asp:DataList DataSourceID="ds" ID="dl" runat="server">
                            <ItemTemplate>
                                <div class="container">
                                    <div>
                                        <asp:Image runat="server" CssClass="aa" ImageUrl='<%# ((Eval("Image") is System.DBNull) ? "[Path to blank image]" : "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image"))) %>' />
                                        <div class="nm">
                                            <div style="display: flex; justify-content: center">
                                                <asp:Label runat="server" Text='<%#Eval("Fname") %>' CssClass="nametxt"></asp:Label>
                                                <asp:Label runat="server" Text='<%#Eval("Lname") %>' CssClass="nametxt"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div style="display: flex; flex-direction: column; justify-content: center; margin-top: 20px">
                                            <div class="btncol">
                                                <asp:Button runat="server" Text="Accept" OnClick="acceptrequest" Style="background-color: #2196F3; color: white; height: 50px; width: 90px; border: none; border-radius: 10px; cursor: pointer; font-size: 16px; transition: background-color 0.3s;"
                                                    CssClass='<%#Eval("Fid") %>' />
                                                <asp:Button runat="server" Text="Reject" OnClick="rejectrequest" Style="background-color: #2196F3; color: white; height: 50px; margin-left: 20px; width: 90px; border: none; border-radius: 10px; cursor: pointer; font-size: 16px; transition: background-color 0.3s;"
                                                    CssClass='<%#Eval("Fid") %>' />

                                            </div>

                                            <asp:Button runat="server" Text="View Profile" OnClick="viewProfile" Style="background-color: #2196F3; color: white; height: 50px; width: 100px; margin-left: 60px; margin-top: 10px; width: 90px; border: none; border-radius: 10px; cursor: pointer; font-size: 16px; transition: background-color 0.3s;"
                                                CssClass='<%#Eval("Fid") %>' />

                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:DataList>

                    </asp:Panel>





                </ContentTemplate>
            </asp:UpdatePanel>




            <!-- More friend entries can be added here -->

        </asp:Panel>

    </form>
</body>
</html>
