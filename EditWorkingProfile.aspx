<%@ Page Title="" Language="C#" MasterPageFile="~/Container.Master" AutoEventWireup="true" CodeBehind="EditWorkingProfile.aspx.cs" Inherits="FinalYearProject.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            background-color: grey;
        }

        .h11 {
            font-family: "Open Sans", sans-serif;
            font-optical-sizing: auto;
            font-weight: <weight>;
            font-style: normal;
            font-variation-settings: "wdth" 100;
            font-size: 25px;
        }
        .btn {
            background-color: #2196F3;
            border: none;
            padding: 10px;
            height:30px;
            margin-left:10px;
            font-size:30px;
            font-size: 10px; 
            color: white;
            cursor: pointer;
        }
    </style>
    <div style="display: flex; justify-content: center; margin: 0px 20px 0 20px; column-gap: 20px">
        <div style="height: 500px; width: 40vw; background-color: white;">
            <header class="h11" style="background-color: lightgrey; height: 70px; display: flex; flex-direction: column; justify-content: center">
                <span style="margin-left: 40px">Profile Picture
                </span>

            </header>

            <main style="display: flex; flex-direction: column; justify-content: center; height: 430px">
                <div>
                    <div style="display: flex; justify-content: center; margin-bottom: 60px">
                        <asp:Image runat="server" ID="profileImg" Style="height: 180px; width: 180px; border-radius: 50%" />
                    </div>
                    <div style="display: flex; justify-content: center">
                        <asp:Button runat="server" ID="uplBtn" Text="Upload new image" Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer" OnClick="uploadimage" />
<asp:FileUpload runat="server" ID="fi" Visible="false" />
                    </div>
                </div>
            </main>
        </div>

        <div style="width: 50vw; background-color: white">
            <header class="h11" style="background-color: lightgrey; height: 70px; display: flex; flex-direction: column; justify-content: center">
                <span style="margin-left: 40px">Account Details
                </span>

            </header>
            <main>
                <div style="display:flex;justify-content:left">
                    <asp:ImageButton runat="server" ImageUrl="~/IMAGES/back.png" PostBackUrl="~/EditProfile.aspx" Height="30" Width="30" style="margin:10px 0 0 10px" />
                    <div style="margin:10px 10px 0 10px;font-size:25px;text-decoration:underline">
                        Working details
                    </div>
                </div>
                <div style="display:flex; margin:20px 30px 0 30px">
                    <h2 style="display:inline">Working</h2>
                    <div style="padding-top:25px;padding-left:15px">
                        <asp:ImageButton runat="server" ImageUrl="~/IMAGES/add.png" Height="20" Width="20" ID="wi" OnClick="addWorkingField" />
                    </div>

                </div>
                <div style="display: flex; margin: 20px 30px 0 30px">
                    <asp:Panel runat="server" ID="pnl2"></asp:Panel>
                </div>
                <div style="display:flex; margin:10px 30px 0 30px">
                     <asp:Panel runat="server" ID="pnl1" Visible="false">
                         <asp:TextBox runat="server" ID="tb1" whdth="150" Height="30"></asp:TextBox>
                         <asp:Button runat="server" Text="ADD" OnClick="addWork" CssClass="btn" />
                         
                     </asp:Panel>
                </div>
               
            </main>
        </div>

    </div>
</asp:Content>
