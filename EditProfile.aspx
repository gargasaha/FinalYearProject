<%@ Page Title="" Language="C#" MasterPageFile="~/Container.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="FinalYearProject.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&display=swap" rel="stylesheet">
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
                        <asp:Button runat="server" ID="uplBtn" Text="Upload new image" Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer"  OnClick="uploadimage"/>
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
                <asp:Panel runat="server" ID="pnl1">
                    <div style="display: flex; justify-content: center; padding: 10px 10px 0px 10px;">
                        <label style="width: 50%; height: 40px">First name</label>
                        <label style="width: 50%; height: 40px">Last name</label>
                    </div>
                    <div style="display: flex; justify-content: center; padding: 0px 10px 10px 10px; column-gap: 10px">

                        <asp:TextBox runat="server" Style="width: 50%; height: 40px" ID="fname"></asp:TextBox>
                        <asp:TextBox runat="server" Style="width: 50%; height: 40px" ID="lname"></asp:TextBox>

                    </div>
                    <div style="display: flex; justify-content: center; padding: 10px 10px 0px 10px;">
                        <label style="width: 50%; height: 40px">Phone number</label>
                        <label style="width: 50%; height: 40px">Date of birth</label>
                    </div>
                    <div style="display: flex; justify-content: center; padding: 0px 10px 0px 10px; column-gap: 10px">
                        <asp:TextBox runat="server" placeholder="Phone" Style="width: 50%; height: 40px" ID="ph"></asp:TextBox>
                        <asp:TextBox runat="server" TextMode="Date" Style="width: 50%; height: 40px" ID="dob"></asp:TextBox>

                    </div>
                    <div style="display: flex; justify-content: center; padding: 10px 10px 0px 10px;">
                        <label style="width: 50%; height: 40px;text-align:center">State</label>
                        <label style="width: 50%; height: 40px;text-align:center">District</label>
                    </div>
                    <div style="display: flex; justify-content: center; padding: 10px 10px 10px 10px; column-gap: 10px">
                        <asp:Panel runat="server" ID="p1">
                            <div style="display:flex;justify-content:center;column-gap:200px">
                                <div>
                                    <asp:TextBox runat="server" Style="width: 100%; height: 40px;" ID="s" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" Style="width: 100%; height: 40px" ID="d" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="p2" Visible="false">
                            <div style="display:flex;justify-content:center">
                                <div>
                                    <asp:DropDownList runat="server" ID="state" Style="width: 100%; height: 40px" OnSelectedIndexChanged="fun1" AutoPostBack="true">
                                        <asp:ListItem Text="STATE" Value="-100"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div>
                                    <asp:DropDownList runat="server" ID="district" Style="width: 100%; height: 40px">
                                        <asp:ListItem Text="DISTRICT" Value="-100"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <div style="text-align: center">
                            <asp:Button runat="server" OnClick="EditStateDist" Text="Edit state & district" id="ed" Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer"/>
                    </div>
                    
                    <div style="display: flex; justify-content: center; padding: 10px 10px 0px 10px;">
                        <label style="width: 50%; height: 40px">Marital Status</label>

                    </div>
                    <div style="display: flex; justify-content: center; padding: 10px 10px 10px 10px; column-gap: 10px">
                        <asp:DropDownList runat="server" ID="marital" Style="width: 50%; height: 40px">
                        </asp:DropDownList>

                    </div>
                    <div style="display: flex; justify-content: center; flex-direction: column;row-gap:20px; padding: 10px 10px 10px 10px; column-gap: 10px">
                        <div style="text-align:center">
                            <asp:Button runat="server" Text="Save changes" Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer" OnClick="saveChanges" />
                        </div>
                        <div style="text-align:center">
                            <asp:Button runat="server" Text="Update working status" Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer"  OnClick="showWorking"/>

                        </div>
                        <div style="text-align:center">
                            <asp:Button runat="server" Text="Update Educational status"  Style="background-color: #2196F3; border: none; padding: 10px; font-size: 20px; color: white; cursor: pointer"  OnClick="showeducation"/>

                        </div>
                       
                    </div>

                </asp:Panel>
                



            </main>
        </div>

    </div>

</asp:Content>
