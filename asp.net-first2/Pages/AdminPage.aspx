<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="asp.net_first2.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Style.css" type="text/css" rel="stylesheet" />

    <title>HMS AdminPage</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page">
            <div class="header">
                <asp:Label ID="LblUser" runat="server" Text=""></asp:Label>
                
                <br />
                <br />

                <div class="button-group">
                      <asp:Button ID="BtnPatient" runat="server" Text="Show Patient" OnClick="BtnPatient_Click1" />
                <asp:Button ID="BtnPersonal" runat="server" Text="Show Personal" OnClick="BtnPersonal_Click" />
                <asp:Button ID="BtnPoliclinic" runat="server" Text="Show Policlinic" OnClick="BtnPoliclinic_Click" />
                <asp:Button ID="BtnUser" runat="server" Text="Show User" OnClick="BtnUser_Click" />

                </div>

              


            </div>

            <div class="content">

                         <asp:Label ID="lblDisplay" runat="server" Text="" CssClass="mainPageTextBox" ></asp:Label>

                        <asp:Label ID="lblInfo" runat="server" Text="Information" CssClass="mainPageTextBox" ></asp:Label>
               

                <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >


                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />

                    
                </asp:GridView>


                        
                  
                <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                   
            </div>
            <br />
            
            <div class="footer">

              <div class="button-group">

                  <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                  <asp:Button ID="BtnInsert" runat="server" Text="Insert new" OnClick="BtnInsert_Click" />
                  <asp:Button ID="BtnDelete" runat="server" Text="Delete " OnClick="BtnDelete_Click" />



              </div>

            </div>
        </div>
    </form>
</body>
</html>
