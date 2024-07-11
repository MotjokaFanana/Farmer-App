<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSc.aspx.cs" Inherits="Agri_Energy_Connect_Web_Application.LoginSc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Login</title>
    <style>
        body {
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            height: 100vh;
            color: #333;
        }

        .welcome-message {
            font-size: 36px;
            font-weight: bold;
            margin-bottom: 40px;
            color: #333;
        }

        .login-form {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 4px 16px rgba(0, 0, 0, 0.1);
            width: 400px;
            max-width: 90%;
            text-align: center;
        }

        .login-form label {
            font-weight: bold;
            margin-bottom: 8px;
            display: block;
            text-align: left;
        }

        .login-form input[type="text"],
        .login-form input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 4px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .login-form .button {
            background-color: #0071e3;
            background-image: linear-gradient(to right, #0071e3, #005bb5);
            color: white;
            padding: 14px 20px;
            margin: 12px 0;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            width: 100%;
            font-size: 18px;
            transition: background 0.3s ease, transform 0.3s ease;
            display: inline-block;
        }

        .login-form .button:hover {
            background-color: #005bb5;
            transform: translateY(-2px);
        }

        .login-form .button:active {
            background-color: #004494;
            transform: translateY(0);
        }

        .login-form .button:focus {
            outline: none;
            box-shadow: 0 0 0 4px rgba(0, 113, 227, 0.3);
        }

        .login-form .back-button {
            background-color: #666;
            background-image: linear-gradient(to right, #666, #444);
            color: white;
        }

        .login-form .back-button:hover {
            background-color: #444;
            transform: translateY(-2px);
        }

        .login-form .back-button:active {
            background-color: #222;
            transform: translateY(0);
        }

        .login-form .back-button:focus {
            outline: none;
            box-shadow: 0 0 0 4px rgba(100, 100, 100, 0.3);
        }

        .login-form .register-btn {
            background-color: #007bff;
            background-image: linear-gradient(to right, #007bff, #0056b3);
        }

        .login-form .register-btn:hover {
            background-color: #0056b3;
        }

        .login-form .register-btn:active {
            background-color: #004494;
        }

        .login-form .register-btn:focus {
            outline: none;
            box-shadow: 0 0 0 4px rgba(0, 123, 255, 0.3);
        }

    </style>
</head>
<body>
    <div class="welcome-message">EMPLOYEE LOGIN</div>
    <form id="form1" runat="server" class="login-form">
        <div>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="button register-btn" />
        </div>
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button back-button" />
        </div>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
    </form>
</body>
</html>
