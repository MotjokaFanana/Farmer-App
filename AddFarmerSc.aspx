<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFarmerSc.aspx.cs" Inherits="Agri_Energy_Connect_Web_Application.AddFarmerSc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Farmer</title>
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

        .header {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
            width: 400px;
            max-width: 100%;
        }

        .form-container label {
            font-weight: bold;
            margin-bottom: 8px;
            display: block;
        }

        .form-container input[type="text"],
        .form-container input[type="password"],
        .form-container input[type="email"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 4px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .form-container input[type="submit"] {
            background-color: #0071e3;
            background-image: linear-gradient(to right, #0071e3, #005bb5);
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
            transition: background 0.3s ease, transform 0.3s ease;
        }

        .form-container input[type="submit"]:hover {
            background-color: #005bb5;
            transform: translateY(-2px);
        }

        .form-container input[type="submit"]:active {
            background-color: #004494;
            transform: translateY(0);
        }

        .form-container input[type="submit"]:focus {
            outline: none;
            box-shadow: 0 0 0 4px rgba(0, 113, 227, 0.3);
        }
    </style>
</head>
<body>
    <div class="header">Add Farmer</div>
    <form id="form1" runat="server" class="form-container">
        <div>
            <label for="txtFirstName">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" required></asp:TextBox>
        </div>
        <div>
            <label for="txtLastName">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" required></asp:TextBox>
        </div>
        <div>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" required></asp:TextBox>
        </div>
        <div>
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required></asp:TextBox>
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" type="email" required></asp:TextBox>
        </div>
        <div>
            <label for="txtPhoneNumber">Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" required></asp:TextBox>
        </div>
        <div>
            <label for="txtAddress">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" OnClick="btnAddFarmer_Click" />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
