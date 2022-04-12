<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultationPage.aspx.cs" Inherits="asp.net_first2.Pages.ConsultationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link href="../Style.css" type="text/css" rel="stylesheet" />
     <title></title>
</head>
<body>
    <form id="form1" runat="server">

      <div class="page">
            
            <div class="header">
                <asp:Label ID="Label1" runat="server" Text="Create a consultation "></asp:Label>

                <br />
                
                <br />

                <asp:Button ID="BtnReturn" runat="server" Text="Return " OnClick="BtnReturn_Click" />

            </div>


            <div class="content">


               

                 <asp:Label ID="LblPoliclinic" runat="server" Text="Please select a Policlinic"></asp:Label>
                <asp:DropDownList ID="DDLPoliclinic" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLPoliclinic_SelectedIndexChanged"></asp:DropDownList>
                
                <asp:Label ID="LblDoctor" runat="server" Text="Please select a Doctor"></asp:Label>
                <asp:DropDownList ID="DDLDoctor" runat="server" ></asp:DropDownList>
                
                 <asp:Label ID="LblCURid" runat="server" Text="CUR id " ></asp:Label>
            <asp:TextBox ID="TxtCURid" runat="server"  Height="15px" ></asp:TextBox>
               
                <asp:Label ID="LblDate" runat="server" Text="Select a Date" ></asp:Label>
            <asp:TextBox ID="TxtDate" runat="server" TextMode="Date" Height="15px" ></asp:TextBox>


            <asp:Label ID="LblTime" runat ="server" Text="Enter Consultation Report"></asp:Label>
            <textarea id="TxtReport" name="TxtReport" accesskey="TxtReport" itemid="Txtreport"   ></textarea>
               


            </div>
            
            
            <div class="footer">

                
                 <asp:Label ID="LblTest" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="BtnSubmit" runat="server" Text="Button" OnClick="BtnSubmit_Click" />

            </div>
    </form>
</body>
</html>
