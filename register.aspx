<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FinalYearProject.Register" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGPAGE</title>
    <link rel="stylesheet" href="./reg.css" />
    <style>
        body {
        }

        .chat-header {
            background-color: #db3474;
            color: #fff;
            /*padding: 10px;*/
            text-align: center;
            height: 65px;
            border-radius: 50px;
            font-family: "Pacifico", cursive;
            font-weight: 400;
            font-style: normal;
            width: 150px;
        }

        .btn {
            border: 0;
            outline: 0;
            background-color: #00DBDE;
            background-image: linear-gradient(90deg, #00DBDE 0%, #FC00FF 100%);
            color: white;
            padding: 7px 20px;
            font-size: 12px;
            border-radius: 4px;
            margin: 10px;
            cursor: pointer;
        }

        .image {
            box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
            border-radius: 50%;
        }

        .h {
            display: none;
        }

        .h1 {
            border: 0;
            outline: 0;
            background-color: #00DBDE;
            background-image: linear-gradient(90deg, #00DBDE 0%, #FC00FF 100%);
            color: white;
            padding: 7px 20px;
            font-size: 12px;
            border-radius: 4px;
            margin: 10px;
            cursor: pointer;
            display: none;
        }

        .s1 {
            border: 0;
            outline: 0;
            background-color: #00DBDE;
            background-image: linear-gradient(90deg, #00DBDE 0%, #FC00FF 100%);
            color: white;
            padding: 7px 20px;
            font-size: 12px;
            border-radius: 4px;
            margin: 10px;
            cursor: pointer;
            display: inherit;
        }

        .s {
            display: inherit;
        }

        .newDis {
            /*text-transform: uppercase;*/
            width: 70%;
            padding-top: 10px;
            padding-bottom: 10px;
            height: 40px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(131, 0, 219, 0.5);
            border: none;
        }

        #redirect, #idshower {
            font-family: "Pacifico", cursive;
            font-weight: 600;
            font-style: normal;
        }

        #llbb11 {
            font-family: "Permanent Marker", cursive;
            font-weight: 400;
            font-style: normal;
        }
    </style>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Licorice&family=Permanent+Marker&display=swap" rel="stylesheet">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Caveat:wght@400..700&family=Pacifico&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
</head>
<body style="background-image: url('https://images.rawpixel.com/image_800/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvdjQ4MS1iYi1uaW5nLTEyYl8xLmpwZw.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; height: 100%;">
    <script>

        function NameFun(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) ||
                ((keyEntry >= '97') && (keyEntry <= '122')) || keyEntry == '8' ||
                keyEntry == '0')
                return true;
            else {
                //alert('Please Enter Only Character values.');
                return false;
            }
        }
        function scrverify() {
            var i = document.getElementById("Upassword").value;
            console.log(i)
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
    <script>
        function limitTextbox(event) {
            var keyCode = event.keyCode || event.which;

            // Allow numeric digits (0-9), backspace, and arrow keys
            if ((keyCode >= 48 && keyCode <= 57) || keyCode === 8 || (keyCode >= 37 && keyCode <= 40)) {
                var textbox = document.getElementById('<%= myTextbox.ClientID %>');

                if (textbox.value.length >= 10 && keyCode !== 8) {
                    event.preventDefault();
                }
            } else {
                event.preventDefault();
            }


        }
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

        function lessthan() {
            let i = document.getElementById('<%=myTextbox.ClientID%>');
            if (i.value.length < 10) {
                j = document.getElementById('<%=incorrectphonenum.ClientID%>');
                j.style.display = "inherit";
                i.focus();
            }
            else {
                j.style.display = "none";
            }

        }
        function checkemail() {
            email = document.getElementById('<%=Email.ClientID%>');
            const emailPattern =
                /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            const isValid = emailPattern.test(email.value);
            w = document.getElementById('<%=incorrectemail.ClientID%>');
            b1 = document.getElementById('<%=send.ClientID%>');
            if (isValid) {
                w.style.display = "none";
                b1.style.display = "inherit";

                return true;
            }
            else {
                w.style.display = "inherit";
                b1.style.display = "none";

                return false;
            }
        }


    </script>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
        <div style="display: flex; justify-content: center; padding-top: 20px;">
            <h1 class="chat-header">Sign Up</h1>
        </div>
        <div style="display: flex; justify-content: center; background-color: white; margin-left: 20%; margin-right: 20%; margin-top: 2%; border-radius: 20px; padding: 50px; -webkit-box-shadow: 10px 10px 5px 0px rgba(46,74,117,0.48); -moz-box-shadow: 10px 10px 5px 0px rgba(46,74,117,0.48); box-shadow: 10px 10px 5px 0px rgba(46,74,117,0.48);">

            <div runat="server" id="all" style="width: 50%; text-align: center;">

                <%--<asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
                --%>

                <div>
                    <asp:Label runat="server" Text="ENTER VALID EMAIL" ID="llbb11"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Email" ID="Email" CssClass="newDis" placeholder="Email" onchange="return checkemail();"></asp:TextBox>
                    <asp:Label runat="server" ID="incorrectemail" Text="NOT A VALID EMAIL" ForeColor="Red" CssClass="h"></asp:Label>
                    <br />
                    <asp:Button runat="server" Text="SEND OTP" ID="send" OnClick="sendOtp" CssClass="h1" />
                    <br />
                </div>
                <div runat="server" id="otpenter" style="margin-top: 30px" visible="false">
                    <br />
                    <asp:Button runat="server" Text="RESEND OTP" CssClass="btn" OnClick="sendOtp" />
                    <br />
                    <asp:Label runat="server" ID="sendto" Visible="false"></asp:Label>
                    <br />
                    <asp:TextBox Width="50" runat="server" ID="nm1" MaxLength="1" onkeyup="fun11(event)"></asp:TextBox>
                    <asp:TextBox Width="50" runat="server" ID="nm2" MaxLength="1" onkeyup="fun12(event)"></asp:TextBox>
                    <asp:TextBox Width="50" runat="server" ID="nm3" MaxLength="1" onkeyup="fun13(event)"></asp:TextBox>
                    <asp:TextBox Width="50" runat="server" ID="nm4" MaxLength="1" onkeyup="fun14(event)"></asp:TextBox>
                    <br />
                    <asp:Label runat="server" ID="warninglbl" Visible="false"></asp:Label>
                    <asp:Button runat="server" Text="VERIFY OTP" CssClass="btn" OnClick="verifyOtp" />

                </div>
                <div runat="server" visible="false" id="left">

                    <div>
                        <asp:TextBox runat="server" ID="UnameF" placeholder="ENTER FIRST NAME" CssClass="newDis" Style="text-transform: uppercase" onkeypress="return NameFun(event)"></asp:TextBox>
                        <asp:Label runat="server" Text="*" ID="r1" ForeColor="Black"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:TextBox runat="server" ID="UnameL" placeholder="ENTER LAST NAME" CssClass="newDis" onkeydown="return (event.keyCode!=32);" Style="text-transform: uppercase" onkeypress="return NameFun(event)"></asp:TextBox>
                        <asp:Label runat="server" Text="*" ID="rr1" ForeColor="Black"></asp:Label>
                    </div>

                    <br />
                    <div>
                        <asp:TextBox CssClass="newDis" placeholder="PHONE NUMBER" runat="server" ID="myTextbox" onkeydown="limitTextbox(event);" onchange="lessthan()"></asp:TextBox>
                        <asp:Label runat="server" ID="incorrectphonenum" Text="NOT A VALID PHONE NUMBER" ForeColor="Red" CssClass="h"></asp:Label>
                        <asp:Label runat="server" Text="*" ID="r2" ForeColor="Black"></asp:Label>

                    </div>
                    <br />

                    <div>

                        <asp:DropDownList runat="server" ID="state" CssClass="newDis" OnSelectedIndexChanged="fun1" AutoPostBack="true"></asp:DropDownList>
                        <asp:Label runat="server" Text="*" ID="a1" ForeColor="Black"></asp:Label>



                    </div>
                    <br />
                    <div>
                        <asp:DropDownList runat="server" CssClass="newDis" ID="dist" AutoPostBack="true">
                            <asp:ListItem Text="DISTRICT"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label runat="server" Text="*" ID="a2" ForeColor="Black"></asp:Label>

                    </div>

                    <br />

                    <%--<div>
                            <asp:DropDownList runat="server" CssClass="newDis" ID="town"></asp:DropDownList>
                            <asp:Label runat="server" Text="*" ID="a3" ForeColor="Black"></asp:Label>
                        </div>
                        <br />
                        <br />--%>
                    <div>
                        <asp:DropDownList runat="server" CssClass="newDis" ID="drp1">
                            <asp:ListItem Value="select">Gender</asp:ListItem>
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                            <asp:ListItem Value="other">Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label runat="server" Text="*" ID="r3" ForeColor="Black"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:TextBox runat="server" CssClass="newDis" TextMode="Date" ID="dob"></asp:TextBox>
                        <asp:Label runat="server" Text="*" ID="r4" ForeColor="Black"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <%--<input type="checkbox">
<label>Remember Me</label>--%>
                    <br />
                    <br />



                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>

                <br />
                <label style="color: black">Already have an account?</label>
                <a href="Signin.aspx">Sign In</a>
            </div>
            <div runat="server" visible="false" id="right" style="width: 50%; display: flex; flex-direction: column;">
                <div style="text-align: center">
                    <asp:Image runat="server" CssClass="image" Height="190" Width="200" ImageUrl="https://thumbs.dreamstime.com/b/cute-man-face-cartoon-cute-man-face-cartoon-vector-illustration-graphic-design-135024353.jpg" ID="im" />
                    <asp:FileUpload runat="server" ForeColor="Black" ID="FileUpload1" CssClass="newDis" />
                    <asp:Label runat="server" Text="*" ID="r5"></asp:Label>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:Button runat="server" Text="UPLOAD IMAGE" CssClass="btn" OnClick="Unnamed_Click" ID="sh" />

                    <asp:Button runat="server" Text="REMOVE IMAGE" CssClass="btn" Visible="false" OnClick="Unnamed_Click1" ID="rm" />

                </div>

                <div>
                    <asp:TextBox runat="server" TextMode="password" ID="Upassword" placeholder="Password" CssClass="newDis"></asp:TextBox>
                    <asp:Label runat="server" Text="*" ID="p1" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ID="weakness" Text="Your password is not matching with password policies" Visible="false"></asp:Label>
                </div>

                <br />
                <div>
                    <p style="color: black; font-size: 10px">Password should contain <b>alphabet(Uppsercase and Lowercase),special character('&','$','%','@','!','#'),digits and have 8 characters long</b></p>
                </div>
                <br />
                <div>
                    <asp:TextBox runat="server" ID="UpasswordC" placeholder="Confirm Password" CssClass="newDis"></asp:TextBox>
                    <asp:Label runat="server" Text="*" ID="pp1" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ID="chkval" Text="Confirm Password is not matching with Password" Visible="false"></asp:Label>
                </div>
                <br />
                <br />

                <asp:Button runat="server" Text="Create Account" CssClass="btn" OnClick="submit" ID="reg" Visible="false" />

            </div>
            <asp:Label runat="server" ID="idshower" Visible="false"></asp:Label>
            <br />
            <a href="~/EditProfile.aspx" runat="server" id="redirect" visible="false">Click here to Edit profile page</a>
        </div>

    </form>

</body>
</html>
