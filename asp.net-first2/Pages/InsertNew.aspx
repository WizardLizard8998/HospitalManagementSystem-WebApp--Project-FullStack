<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertNew.aspx.cs" Inherits="asp.net_first2.InsertNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Style.css" rel="stylesheet" type="text/css" />

    <title>HMS - Add Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            
            
            <div class ="header">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />

                 <asp:Button ID="BtnReturn" runat="server" Text="Return " OnClick="BtnReturn_Click" />

            </div>

            
            <div class="Insertcontent">

                <asp:Label ID="LblName" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

                
                <asp:Label ID="LblSurname" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtSurname" runat="server"></asp:TextBox>

                
                <asp:Label ID="LblTelNum" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtTelNum" runat="server"></asp:TextBox>

                
                <asp:Label ID="LblAdress" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtAdress" runat="server"></asp:TextBox>
                
                <asp:Label ID="LblBlood" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DDLBlood" runat="server"></asp:DropDownList>
                
                <asp:Label ID="LblTC" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtTc" runat="server"></asp:TextBox>
                
                <asp:Label ID="LblSex" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtSex" runat="server"></asp:TextBox>

                <asp:Label ID="LblBirthDate" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtBirthDate" runat="server" TextMode="Date"></asp:TextBox>

                
                <asp:Label ID="LblCity" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DDLCity" runat="server" OnSelectedIndexChanged="DDLCity_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                <asp:Label ID="LblDistrict" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DDLDistrict" runat="server"></asp:DropDownList>
                
                <asp:Label ID="LblTitle" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DDLTitle" runat="server"></asp:DropDownList>

                <asp:Label ID="LblPoliclinic" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DDLPoliclinic" runat="server"></asp:DropDownList>
                
                <asp:Label ID="LblUserId" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TxtUserId" runat="server"></asp:TextBox>

                <asp:Label ID="LblCheck" runat="server" Text="Label"></asp:Label>
            </div>
            

            <div class="footer">
                <asp:Label ID="LblSend" runat="server" Text="Insert new s"></asp:Label>
                <asp:Button ID="BtnSend" runat="server" Text="Insert " OnClick="BtnSend_Click" />

            </div>



        </div>
    </form>
</body>
</html>
