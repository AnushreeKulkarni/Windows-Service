<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplicationAssignment.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/JavaScriptMain.js"></script>
</head>
<body>
    <form id="form1" runat="server" >
        <div style="height: 455px; width: 1566px; background-color:beige"><br />
            <asp:Label ID="lbl1" runat="server" Text="Enter ID:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="txtInput" runat="server" Height="22px"  style="margin-left: 15px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" OnClientClick="return validateForm();" style="margin-left: 26px" Text="Search" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" Width="98px" />
            <br />
            <br />
            <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="ID:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Height="22px" style="margin-left: 61px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Height="22px" style="margin-left: 35px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" style="margin-left: 33px" Height="22px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Places:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlPlaces" runat="server" Width="160px" Height="22px" style="margin-left: 27px" AutoPostBack="true" OnSelectedIndexChanged="ddlPlaces_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Addresses:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAddresses" runat="server" Width="162px" Height="22px" >
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnView" runat="server" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" OnClick="btnView_Click" style="margin-left: 17px; margin-top: 37px" Text="View Records" Width="120px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEdit" runat="server" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" OnClick="btnEdit_Click" Text="Edit Record" Width="110px" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
