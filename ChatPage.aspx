<%@ Page Title="" Language="C#" MasterPageFile="~/Container.Master" AutoEventWireup="true" CodeBehind="ChatPage.aspx.cs" Inherits="FinalYearProject.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        Chat
    </title>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script>
        function verify() {
            let a = document.getElementById('<%= msglbl.ClientID%>').value;

            var flag = '<%=Session["Time"] == null%>';
            if (flag.toLowerCase() == 'false') {// some code
                return false;
            }

            //alert(%=Session["CFid"] == null%>);
            if (a.length == 0) {
                return false;
            }
            return true;
        }
        
    </script>
    <style>
        .newDis {
            border-radius: 10px;
            width: 80%;
            padding-top: 5px;
            padding-bottom: 10px;
            height: 40px;
            text-align: center;
            box-shadow: 0 6px 10px rgba(131, 0, 219, 0.5);
            border: solid;
            justify-content: space-between;
            box-shadow: 0 2px 4px rgba(27, 3, 31, 5.15);
        }

        .button {
            background-color: #7c34db;
            color: #fff;
            height: 40px;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            border-radius: 10px;
            box-shadow: 0 2px 4px rgba(131, 0, 219, 0.5);
            border: none;
            width: 20%;
            margin: 0 0 0 10px;
            justify-content: space-between;
            box-shadow: 0 2px 4px rgba(27, 3, 31, 5.15);
        }

            .button:hover {
                background-color: #b929a1;
            }

        .second {
            width: 40vw;
            background-color: #fff;
            height: 48px;
            display: flex;
            justify-content: center;
            bottom: 0;
        }

        .pop {
            height: 300px;
            width: 300px;
            display: flex;
            flex-direction: column;
            background-color: black;
            border-radius: 25px;
            position: absolute;
            margin-left: 8%;
            margin-top: 15%;
            box-shadow: 6px 6px 6px #808080;
        }
        .bt{
            background-color:#008CBA;
            width:150px;
            height:50px;
            border-radius:25px;
            font-size:25px;
            border:none;
        }
        .bt:hover{
            background-color:#f6d120;
        }   
        
    </style>
    <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
    
    
    <asp:panel runat="server" style="display: flex;">

        <div style="width: max-content">
            
            <div style="display: flex; justify-content: center">
                
                <div>
                    <iframe runat="server" id="onlineofflineiframe" style="width: 30vw; height: 100%"></iframe>
                </div>
                
                <div style="width: 40vw;">
                    
                    <div>
                        <iframe runat="server" style="width: 40vw; height: 93vh" id="chatiframe"></iframe>
                    </div>
                    
                    <div class="second" runat="server" id="ss">
                        <div style="display: flex; justify-content: center; flex-direction: column;">
                            <asp:Button runat="server" Text="Send image" ID="sl" Style="width: 90px;height:40px;font-size:14px; margin-top: 5px;margin-right:5px;margin-left:5px;background-color:#2196F3;" OnClick="sendImage" />
                        </div>
                        <asp:TextBox runat="server" placeholder="Type your message..." class="newDis" ID="msglbl"></asp:TextBox>
                        <asp:ImageButton runat="server" OnClick="sendmessage" ImageUrl="~/IMAGES/sendBtN.jpg" Style="margin-left: 30px;" OnClientClick="return verify();" />
                    </div>

                </div>
                <asp:Panel Visible="false" runat="server" ID="popup" CssClass="pop">
                    <div style="width: 100%; height: 30px; text-align: right">
                        <asp:ImageButton runat="server" ImageUrl="~/IMAGES/cross.png" Height="30" Width="30" Style="margin: 10px" OnClick="exitt" />
                    </div>
                    <div style="text-align: center; color: white; font-size: 25px">
                        Choose Image
                    </div>
                    <div style="text-align: center; color: white; font-size: 25px; margin-top: 20px">
                        <asp:FileUpload ID="fileUpload" CssClass="custom-file-upload" runat="server" Width="90" />
                    </div>
                    <div style="text-align: center; margin-top: 40px">
                        <asp:Button runat="server" Text="Send Image" CssClass="bt" OnClick="select" />
                    </div>
                </asp:Panel>
                <div>
                    <iframe style="width: 20vw; height: 100vh" runat="server" id="addfrnd_frndreq"></iframe>
                </div>
            </div>
        </div>
    </asp:panel>



</asp:Content>
