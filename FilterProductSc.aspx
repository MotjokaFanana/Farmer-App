<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterProductSc.aspx.cs" Inherits="Agri_Energy_Connect_Web_Application.FilterProductSc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Filter Products</title>
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

        .form-container select {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 4px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .form-container input[type="submit"] {
            background-color: #0071e3;
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
    <div class="header">Filter Products</div>
    <form id="form1" runat="server" class="form-container">
        <div>
            <label for="txtFilterCategory">Filter by Category:</label>
            <asp:TextBox ID="txtFilterCategory" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnFilterProducts" runat="server" Text="Filter Products" OnClick="btnFilterProducts_Click" />
        </div>
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
        <div class="text-section" runat="server">
            <asp:Literal ID="textSection" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
