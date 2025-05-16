<%@ Page Title="Add friend" EnableEventValidation="false" Language="C#" MasterPageFile="~/Container.Master" AutoEventWireup="true" CodeBehind="addFriend.aspx.cs" Inherits="FinalYearProject.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #ccc;
            margin: 0;
            padding: 0;
        }

        .container {
            text-align: center;
            width: 20%;
            margin: 50px 0 0 0px;
            overflow-y: scroll;
            height: 600px;
            background-color: #fff;
            padding: 10px;
            border-radius: 10px;
            box-shadow: 4px 6px 7px rgba(0, 0, 0, 0.7);
        }

        .friend-panel {
            display: flex;
            align-items: center;
            padding: 10px;
            background-color: grey;
            border-radius: 25px;
            margin-bottom: 10px;
            border-bottom: 1px solid #ddd;
        }
        /* Style for friend image */
        .friend-image {
            display: inline;
            width: 100px;
            height: 100px;
            margin-left: 20px;
            background-size: cover;
            background-repeat: no-repeat;
            background-position: center center;
            -webkit-border-radius: 99em;
            -moz-border-radius: 99em;
            border-radius: 99em;
            border: 5px solid #eee;
            box-shadow: 4px 4px 2px rgba(0, 0, 0, 0.3);
        }
        /* Style for friend name */
        .friend-name {
            font-size: 20px;
            font-weight: bold;
            margin-right: 10px;
            margin: 0.3% 0 0 50px;
        }
        /* Style for add friend button */
        .add-friend-button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin: 7px 0 0 50px;
            transition: background-color 0.3s;
        }

        .aa {
            height: 150px;
            border-radius: 50%;
            border: 10px solid #FC92C4;
        }

        .header {
            background-color: #2196F3;
            color: #fff;
            text-align: center;
            padding: 20px 0;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }

        .footer {
            position: fixed;
            width: 100%;
            bottom: 0;
            background-color: #2196F3;
            color: #fff;
            text-align: center;
            padding: 10px 0;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 50px;
        }

        .content {
            padding: 30px 0;
        }

        .profileImgDiv {
            display: flex;
            flex-direction: column;
            justify-content: left;
        }

        .container2 {
            width: 75%;
            height: 625px;
            margin: 50px 0 0 0;
            /*background-color: #808080;*/
            background-color: #ccc;
            padding-left:30px;
            /*border-radius: 10px;*/
            /*box-shadow: 4px 6px 7px rgba(0, 0, 0, 0.7);*/
        }


        .headSection {
            /*box-shadow: 7px 7px 8px #7d7138;*/
            display: flex;
            justify-content: center;
            /*background-color: #d7cd1d;*/
            border-radius: 25px;
            /*margin: 20px;*/
            margin-bottom: 10px;
            padding: 40px 80px;
        }

        .bodysection {
            background-image: linear-gradient(to right,#A1C4FD,#C2E9FB);
            padding: 40px;
            margin-bottom:30px;
        }
    </style>
    <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
    <div style="width: 100%">
        <div class="header">
            <h1>Add Friends</h1>
        </div>
        <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:database %>" ID="ds1"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:database %>" ID="ds2"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:database %>" ID="ds3"></asp:SqlDataSource>
        <div style="display: flex; justify-content: space-between; margin: 0 30px;">

            <asp:Panel runat="server" CssClass="container2" ScrollBars="Vertical">
                <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <asp:Timer runat="server" ID="tm1" OnTick="tm1_Tick" Interval="1000"></asp:Timer>
                        <asp:DataList runat="server" ID="dl1" DataSourceID="ds1" Style="width: 100%;">
                            <ItemTemplate>
                                <div class="headSection" style="width: 300px; background-color: #A1C4FD;">

                                    <div style="display: flex; justify-content: center; flex-direction: column">
                                        <asp:Image runat="server" ID="profileImg" Style="height: 140px; width: 140px;" ImageUrl='<%# ((Eval("Image") is System.DBNull) ? "[Path to blank image]" : "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image"))) %>' CssClass="aa" />
                                        <div style="font-size: 25px; margin-top: 30px;">
                                            <div style="background-color: #d5b01c;width:contain; display: flex; justify-content: center; padding: 15px; border-top-right-radius: 25px; border-bottom-left-radius: 25px;">
                                                <asp:Label runat="server" ID="nameTagF" Text='<%#Eval("Fname")%>'></asp:Label>
                                                <asp:Label runat="server" ID="nameTagL" Text='<%#Eval("Lname")%>' style="margin-left:10px"></asp:Label>

                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <div class="bodysection" style="height: contain;border-radius:25px">
                                    <span style="font-size: 25px;">About</span>
                                    <div style="margin-top: 50px">
                                        <div style="display: flex; flex-direction: column">
                                            <div style="font-size: 30px;text-decoration:underline">
                                                From
                                                <asp:Image runat="server" ImageUrl="~/IMAGES/location.png" Height="30" Width="30" />
                                            </div>
                                            <div style="background-color: #00CDAC; display: inline; padding: 20px; font-size: 20px; border-radius: 25px; box-shadow: #02AABD 7px 7px 6px; margin-left: 20px; margin-top: 20px; width: 220px">

                                                <asp:Label runat="server" Text='<%#Eval("cDistName") %>'></asp:Label>
                                                ,
                                                <asp:Label runat="server" Text='<%#Eval("cStateName") %>'></asp:Label>
                                            </div>
                                        </div>


                                    </div>
                                    <div style="margin-top: 60px">
                                        <div style="display: flex; flex-direction: column;">
                                            <div style="font-size: 30px;text-decoration:underline">
                                                Marital status
    <asp:Image runat="server" ImageUrl="~/IMAGES/marital.png" Height="30" Width="30" />
                                            </div>
                                            <div style="background-color: #00CDAC; display: inline; padding: 20px; font-size: 20px; border-radius: 25px; box-shadow: #02AABD 7px 7px 6px; margin-left: 20px; width: 220px; margin-top: 20px">

                                                <asp:Label runat="server" Text='<%#Eval("maritalStatus") %>'></asp:Label>
                                            </div>

                                        </div>

                                    </div>
                            </ItemTemplate>
                        </asp:DataList>

                        <div runat="server" id="h1" class="bodysection" style=" display:none;border-radius:25px">
                            <div style="font-size: 30px;text-decoration:underline;padding:5px">
                                Education status
                                <asp:Image runat="server" ImageUrl="~/IMAGES/education.png" Height="30" Width="30" />
                            </div>

                            <asp:DataList runat="server" DataSourceID="ds2" ID="dl2">
                                <ItemTemplate>
                                    <div style="background-color: #00CDAC; padding: 20px; font-size: 20px; border-radius: 25px; box-shadow: #02AABD 7px 7px 6px; margin-left: 20px; width: 220px;margin-top:30px">
                                        <asp:Label runat="server" Text='<%#Eval("EducationStatus") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        
                        <div runat="server" id="h2" class="bodysection" style="display: none;border-radius:25px">
                            <div style="font-size: 30px; text-decoration: underline; padding: 5px;">
                                Working status
                                <asp:Image runat="server" ImageUrl="~/IMAGES/working.png" Height="30" Width="30" />
                            </div>

                            <asp:DataList runat="server" DataSourceID="ds3" ID="dl3">
                                <ItemTemplate>
                                    <div style="background-color: #00CDAC; padding: 20px; font-size: 20px; border-radius: 25px; box-shadow: #02AABD 7px 7px 6px; margin-left: 20px; width: 220px; margin-top: 30px">
                                        <asp:Label runat="server" Text='<%#Eval("workingStatus") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </asp:Panel>


            <%----%>
            <iframe runat="server" src="~/addFrndViewer.aspx" class="container"></iframe>

        </div>

        <div class="footer">
            <p>© 2024 Friend Book. All rights reserved.</p>
        </div>
    </div>


</asp:Content>
