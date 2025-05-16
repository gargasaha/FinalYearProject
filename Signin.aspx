<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="FinalYearProject.Signin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Caveat:wght@400..700&family=Pacifico&display=swap" rel="stylesheet"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet"/>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <style>
        .all {
            display:flex;
            justify-content:center;
        }

        .auto-style1 {
            margin-top:180px;
            border-radius: 10px;
            width: 40%;
            height: 400px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(131, 0, 219, 0.5);
            border: none;
            box-shadow: 0 2px 4px rgba(27, 3, 31, 5.15);
        }

        .chat-header {
            background-color: #db3474;
            color: #fff;
            padding: 10px;
            text-align: center;
            height: 25px;
            border-radius: 50px;
            font-family: "Pacifico", cursive;
            font-weight: 400;
            font-style: normal;
        }

        #bt {
            background-color: #7c34db;
            color: #fff;
            border: none;
            padding: 8px 14px;
            cursor: pointer;
            border-radius: 10px;
            box-shadow: 0 2px 4px rgba(131, 0, 219, 0.5);
            border: none;
            justify-content: space-between;
            box-shadow: 0 2px 4px rgba(27, 3, 31, 5.15);
            font-family: "Pacifico", cursive;
            font-weight: 600;
            font-style: normal;
        }

            #bt:hover {
                background-color: #b929a1;
            }

        .table1 {
            text-align: center
        }

        #lbl2, #lbl3, #lbl4 {
            font-family: "Caveat", cursive;
            font-optical-sizing: auto;
            font-size: 30px;
            font-style: normal;
        }

        #txt1, #txt2 {
            border-radius: 10px;
            width: 100%;
            padding-top: 5px;
            padding-bottom: 10px;
            height: 25px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(131, 0, 219, 0.5);
            border: none;
            justify-content: space-between;
            box-shadow: 0 2px 4px rgba(27, 3, 31, 5.15);
        }
    </style>

</head>
<body style="background-image: url('https://images.rawpixel.com/image_800/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvdjQ4MS1iYi1uaW5nLTEyYl8xLmpwZw.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; height: 100%;">
    <form id="form1" runat="server">
        <div class="all">
            <div class="auto-style1">
                <div class="chat-header">
                    <asp:Label ID="Label1" runat="server" Text="Log In"></asp:Label>
                </div>

                <div style="width:100%;display:flex;justify-content:center;padding-top:10%">
                    <table class="table1">
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="User ID" ID="lbl2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txt1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Password" ID="lbl3"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txt2" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Label runat="server" ID="lbl4"></asp:Label>
                <br />
                <br />
                <asp:Button runat="server" ID="bt" Text="Submit" OnClick="conSubmit" />
                <br />
                <a href="ForgetPassword.aspx">Forget password</a>
                <br />
                <br />
                <br />
            </div>
        </div>
        
    </form>
</body>
</html>


