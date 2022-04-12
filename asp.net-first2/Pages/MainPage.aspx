<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="asp.net_first2.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../Style.css" type="text/css" rel="stylesheet" />
    <title>Main Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="page">

            <div class="header">
                <h2>Welcome To Hospital Management System </h2>

            </div>
            <div class="content">
                   <div class="mainPageLogin">
                       <h3> To continue please login </h3>

                       <asp:Label ID="LblUName" runat="server" Text="Username"></asp:Label>
                       <asp:TextBox  ID="TxtUsername" runat="server" Class="mainPageTextBox"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldUName" runat="server" ErrorMessage="Required Field!" ControlToValidate="TxtUsername"></asp:RequiredFieldValidator>
                       
                       <br />

                       <asp:Label ID="LblPw" runat="server" Text="Password" ></asp:Label>
                       <asp:TextBox  ID="TxtPassword" runat="server" TextMode="Password" Class="mainPageTextBox"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldPw" runat="server" ErrorMessage="Required Field!" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator>
                       
                       <br />

                       <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />

                       <br />

                       <asp:HyperLink ID="HyperLink1" runat="server" href="Home.html">Forgot Password?</asp:HyperLink>
                       <asp:Label ID="LblError" runat="server" Text=""></asp:Label>


                   </div>
            </div>


        </div>
    </form>
</body>
</html>
