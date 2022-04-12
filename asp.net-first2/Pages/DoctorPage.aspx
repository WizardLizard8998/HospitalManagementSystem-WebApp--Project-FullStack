<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorPage.aspx.cs" Inherits="asp.net_first2.DoctorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

   <link href="../Style.css" type="text/css" rel="stylesheet" />


    <title> HMS - Doctor </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <div class="page"> 
              

                <div class="header">

                      <asp:Label ID="Label1" runat="server" Text="Welcome Kerem"></asp:Label>
                        
                    <br />
                    <br />

                    <div class="button-group">
                        <asp:Button ID="BtnCU" runat="server" Text="Display upcoming checkups" OnClick="BtnCU_Click" />
                        <asp:Button ID="BtnAppointment" runat="server" Text="Display upcoming appointments" OnClick="BtnAppointment_Click" />
                        <asp:Button ID="BtnCUR" runat="server" Text="Create Checkup report" OnClick="BtnCUR_Click" />
                        <asp:Button ID="BtnSearchCU" runat="server" Text="Search Checkups"  OnClick="BtnSearchCU_Click"/>
                        <asp:Button ID="BtnConsultation" runat="server" Text="Create Consultation" OnClick="BtnConsultation_Click" />
                        <asp:Button ID="BtnDisplayCon" runat="server" Text="Display Consultation" OnClick="BtnDisplayCon_Click" />
                    
                        <asp:Button ID="BtnLab" runat="server" Text="Create Lab Report" OnClick="BtnLab_Click" />
                        <asp:Button ID="BtnLbDisplay" runat="server" Text="Display Lab Report" OnClick="BtnLbDisplay_Click" />
                        <asp:Button ID="BtnDrugDisplay" runat="server" Text="Display Drug reports" OnClick="BtnDrugDisplay_Click" />
                        

                    </div>

                </div>


                <div class="content">

                    <asp:Label ID="LblWhatUdoin" runat="server" ></asp:Label>

                    <asp:Label ID="LblDate" runat="server" Text="Select date"></asp:Label>
                    <asp:TextBox ID="TxtDate" runat="server" TextMode ="Date" Height="15px"></asp:TextBox>

                    <asp:Label ID="LblReport" runat="server" Text="Enter your Report"></asp:Label>
                    <textarea id="TxtReport" name="TxtReport" runat="server" cols="20" rows="2"></textarea>

                    <asp:Label ID="LblCU" runat="server" Text="Enter CheckUpId"></asp:Label>
                    <asp:TextBox ID="TxtCu" runat="server" ></asp:TextBox>

                    <asp:Label ID="LblLab" runat="server" Text="Select Lab"></asp:Label>
                    <asp:DropDownList ID="DDLLab" runat="server" ></asp:DropDownList>

                    <asp:Label ID="LblDrug" runat="server" Text="Enter given drugs/medicine"></asp:Label>
                    <textarea id="TxtDrug" name="TxtDrug"  runat="server" cols="20" rows="2"></textarea>

                    <asp:Label ID="LblDisease" runat="server" Text="Enter Patients Disease"></asp:Label>
                    <textarea id="TxtDisease" name="TxtDisease" runat="server" cols="20" rows="2"></textarea>

                    <asp:Label ID="LblAid" runat="server" Text="Enter AppointmentID"></asp:Label>
                    <asp:TextBox ID="TxtAppointment" Font-Names="TxtAppointment" runat="server" ></asp:TextBox>



                    <asp:Label ID="LblCheck" runat="server" ></asp:Label>
                    <asp:Button ID="BtnSend" runat="server" Text="Send Checkup" OnClick="BtnSend_Click" />


                    <asp:GridView ID="GV" runat="server" AutoGenerateSelectButton="true" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" > 

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


                   

                </div>


                <div class=" footer"></div>


            </div>


        </div>
    </form>
</body>
</html>
