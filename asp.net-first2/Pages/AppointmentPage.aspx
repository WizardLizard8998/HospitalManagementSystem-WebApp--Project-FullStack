<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentPage.aspx.cs" Inherits="asp.net_first2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Style.css" type="text/css" rel="stylesheet" />
    
    <title>HMS- Appointment Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            
            <div class="header">
                <asp:Label ID="Label1" runat="server" Text="Welcome Kerem"></asp:Label>

                <br />

                 <asp:Button ID="BtnReturn" runat="server" Text="Return " OnClick="BtnReturn_Click" />

            </div>


            <div class="content">


                <asp:Label ID="LblPatient" runat="server" Text="Please select a Patient"></asp:Label>
                <div>
                    <asp:DropDownList ID="DDLPatient" runat="server" ></asp:DropDownList>
                    <asp:Button ID="BtnPatient" runat="server" Text="CreatePatient" OnClick="BtnPatient_Click" /> 
                </div>

                 <asp:Label ID="LblPoliclinic" runat="server" Text="Please select a Policlinic"></asp:Label>
                <asp:DropDownList ID="DDLPoliclinic" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLPoliclinic_SelectedIndexChanged"></asp:DropDownList>
                
                <asp:Label ID="LblDoctor" runat="server" Text="Please select a Doctor"></asp:Label>
                <asp:DropDownList ID="DDLDoctor" runat="server" ></asp:DropDownList>
                

               
                <asp:Label ID="LblDate" runat="server" Text="Select a date" ></asp:Label>
            <asp:TextBox ID="TxtDate" runat="server" TextMode="Date" Height="25px"></asp:TextBox>


            <asp:Label ID="LblTime" runat ="server" Text="Select an hour"></asp:Label>
            <asp:TextBox ID="TxtTime" runat="server" TextMode="Time" Height="25px"></asp:TextBox>
               
                


            </div>
            
            
            <div class="footer">

                 <asp:Label ID="LblTest" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="BtnSubmit" runat="server" Text="Button" OnClick="BtnSubmit_Click" />

            </div>
        
        </div>
    </form>
</body>
</html>
