<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="asp.net_first2.Pages.Update" %>

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
                <div>
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBName" runat="server" AutoPostBack="true" OnCheckedChanged="CBName_CheckedChanged" />
                </div>

                <asp:Label ID="LblSurname" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtSurname" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBSurname" runat="server" AutoPostBack="true" OnCheckedChanged="CBSurname_CheckedChanged" />
                </div>

                
                <asp:Label ID="LblTelNum" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtTelNum" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBTelNum" runat ="server" AutoPostBack="true" OnCheckedChanged="CBTelNum_CheckedChanged" />
                </div>
                
                <asp:Label ID="LblAdress" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtAdress" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBAdress" runat="server" AutoPostBack="true" OnCheckedChanged="CBAdress_CheckedChanged" />
                </div>


                <asp:Label ID="LblBlood" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:DropDownList ID="DDLBlood" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CBBlood" runat="server" AutoPostBack="true" OnCheckedChanged="CBBlood_CheckedChanged" /> 
                </div>
                
                <asp:Label ID="LblTC" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtTc" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBTc" runat="server" AutoPostBack="true" OnCheckedChanged="CBTc_CheckedChanged" />
                </div>

                <asp:Label ID="LblSex" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtSex" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBSex" runat="server" AutoPostBack="true" OnCheckedChanged="CBSex_CheckedChanged" />
                </div>

                <asp:Label ID="LblBirthDate" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtBirthDate" runat="server" TextMode="Date"></asp:TextBox>
                <asp:CheckBox ID="CBBirthdate" runat="server" AutoPostBack="true" OnCheckedChanged="CBBirthdate_CheckedChanged" />
                </div>

                
                <asp:Label ID="LblCity" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:DropDownList ID="DDLCity" runat="server" OnSelectedIndexChanged="DDLCity_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:CheckBox ID="CBCity" runat="server" AutoPostBack="true" OnCheckedChanged="CBCity_CheckedChanged" />
                </div>

                <asp:Label ID="LblDistrict" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:DropDownList ID="DDLDistrict" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CBDistrict" runat="server" OnCheckedChanged="CBDistrict_CheckedChanged" AutoPostBack="true" />
                </div>
                
                <asp:Label ID="LblTitle" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:DropDownList ID="DDLTitle" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CBTitle" runat="server" OnCheckedChanged="CBTitle_CheckedChanged" AutoPostBack="true" />
                </div>

                <asp:Label ID="LblPoliclinic" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:DropDownList ID="DDLPoliclinic" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CBPoliclinic" runat="server" OnCheckedChanged="CBPoliclinic_CheckedChanged" AutoPostBack="true" />
                </div>
                
                <asp:Label ID="LblUserId" runat="server" Text="Label"></asp:Label>
                <div>
                <asp:TextBox ID="TxtUserId" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CBUser" runat="server" OnCheckedChanged="CBUser_CheckedChanged"  AutoPostBack="true"/>
                </div>

                <asp:Label ID="LblCheck" runat="server" Text="Label"></asp:Label>

            </div>
            

            <div class="footer">
                <asp:Label ID="LblSend" runat="server" Text="Update"></asp:Label>
                <asp:Button ID="BtnSend" runat="server" Text="Update " OnClick="BtnSend_Click" />

            </div>



        </div>
    </form>
</body>
</html>
