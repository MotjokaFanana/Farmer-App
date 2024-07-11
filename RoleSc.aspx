<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleSc.aspx.cs" Inherits="Agri_Energy_Connect_Web_Application.RoleSc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Role</title>
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

        .form-container {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 4px 16px rgba(0, 0, 0, 0.1);
            width: 400px;
            max-width: 90%;
            text-align: center;
        }

        .form-container h1 {
            font-size: 24px;
            margin-bottom: 20px;
            color: #333;
        }

        .form-container .button {
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

        .form-container .button:hover {
            background-color: #005bb5;
            transform: translateY(-2px);
        }

        .form-container .button:active {
            background-color: #004494;
            transform: translateY(0);
        }

        .form-container .button:focus {
            outline: none;
            box-shadow: 0 0 0 4px rgba(0, 113, 227, 0.3);
        }

        .form-container div {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <div class="welcome-message">WELCOME TO AGRI!</div>
    <form id="form1" runat="server" class="form-container">
        <h1>Select Your Role</h1>
        <div>
            <asp:Button ID="btnFarmer" runat="server" Text="Farmer" OnClick="btnFarmer_Click" CssClass="button" />
        </div>
        <div>
            <asp:Button ID="btnEmployee" runat="server" Text="Employee" OnClick="btnEmployee_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
