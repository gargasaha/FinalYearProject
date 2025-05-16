<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="FinalYearProject.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #00DBDE; background-image: linear-gradient(90deg, #00DBDE 0%, #FC00FF 100%);
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        label {
            display: block;
            margin-bottom: 8px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin-bottom: 16px;
            box-sizing: border-box;
        }

        .btn {
            background-color: #4caf50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
    </style>
    <script>
        function fun11(e) {
            var n = document.getElementById('<%=nm2.ClientID%>');
            n.focus();
        }
        function fun12(e) {
            var keyCode = e.keyCode || e.which;
            if (e == "Backspace" || e == "Delete") {
                var n = document.getElementById('<%=nm2.ClientID%>');
                n.innerText = "";
                var n = document.getElementById('<%=nm1.ClientID%>');
                n.focus();
                return;
            }
            var n = document.getElementById('<%=nm3.ClientID%>');
            n.focus();
        }
        function fun13(e) {
            var n = document.getElementById('<%=nm4.ClientID%>');
            n.focus();
        }
        function fun14(e) {

        }
    </script>
    <form id="form1" runat="server">
        <div class="container">
            
            <label runat="server" id="usr">User ID:</label>
            <asp:TextBox runat="server" ID="usrId"></asp:TextBox>
            <label runat="server" id="sendotpl" >Send OTP:</label>
            <asp:Button ID="btnsendcode" CssClass="btn" runat="server" Text="SEND OTP" OnClick="sendCode" />
            <br/>
            <asp:TextBox Width="50" runat="server" ID="nm1" Visible="false" onkeyup="fun11(event)"></asp:TextBox>
            <asp:TextBox Width="50" runat="server" ID="nm2" Visible="false" onkeyup="fun12(event)"></asp:TextBox>
            <asp:TextBox Width="50" runat="server" ID="nm3" Visible="false" onkeyup="fun13(event)"></asp:TextBox>
            <asp:TextBox Width="50" runat="server" ID="nm4" Visible="false" onkeyup="fun14(event)"></asp:TextBox>
            <asp:Label runat="server" Text="WRONG OTP" ID="wrong" Visible="false"></asp:Label>
            <asp:Button runat="server" CssClass="btn" Text="SUBMIT OTP" ID="sbotp" OnClick="submitotp" Visible="false"/>
            <label  runat="server" id="cnfpl" visible="false">Password:</label>
            
            
            <asp:TextBox runat="server" TextMode="Password" ID="password" Visible="false"></asp:TextBox>
            <label runat="server" id="cnfpcl" visible="false">Confirm password:</label>
            <asp:Label runat="server" ID="weakness" Text="Your password is not matching with password policies" Visible="false"></asp:Label>
            <p runat="server" visible="false" id="warning" style="color: black;font-size: 10px">Password should contain <b>alphabet(Uppsercase and Lowercase),special character,digits and have 8 characters long</b></p>
            
            <asp:TextBox runat="server" ID="passwordc" Visible="false"></asp:TextBox>
            <asp:Label runat="server" ID="chkval" Text="Confirm Password is not matching with Password" Visible="false"></asp:Label>

            <asp:Button runat="server" ID="upb" Visible="false" Text="Update password" OnClick="updatePassword" />

        </div>
    </form>

</body>
</html>
