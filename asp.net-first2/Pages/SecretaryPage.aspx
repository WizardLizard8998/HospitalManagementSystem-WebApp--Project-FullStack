<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecretaryPage.aspx.cs" Inherits="asp.net_first2.Pages.SecretaryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../Style.css" rel="stylesheet" type="text/css" />

    
    <title>HMS - Secretary Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">

            <div class ="header">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                <br />
                <br />

                <div class="button-group">
                <asp:Button ID="BtnAppointment" runat="server" Text="Create Appointment" OnClick="BtnAppointment_Click" />
                <asp:Button ID="BtnReports" runat="server" Text="Search Reports" />
                </div>
            </div>
            
            
            <div class ="content">

               
                    
                    </div>
            
            
            <div class ="footer">


            </div>



        </div>
    </form>
</body>
</html>
