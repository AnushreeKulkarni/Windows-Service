<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecord.aspx.cs" Inherits="WebApplicationAssignment.EditRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 436px; background-color:beige">
            <asp:Label ID="lblID" runat="server" Text="Enter ID:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
            &nbsp;<asp:TextBox ID="txtInput" runat="server" Height="22px"  style="margin-left: 15px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" style="margin-left: 26px" Text="Edit" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" Width="98px" />
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Height="22px" style="margin-left: 35px" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" style="margin-left: 33px" Height="22px" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPlaces1" runat="server" Text="Place One:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
            <asp:DropDownList ID="ddlPlaces1" runat="server" Width="160px" Height="22px" style="margin-left: 27px" AutoPostBack="true" OnSelectedIndexChanged="ddlPlaces1_SelectedIndexChanged" Visible="False" >
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPlaces2" runat="server" Text="Place Two:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlPlaces2" runat="server" Width="160px" Height="22px" style="margin-left: 27px" AutoPostBack="true" OnSelectedIndexChanged="ddlPlaces2_SelectedIndexChanged" Visible="False" >
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAddress1" runat="server" Text="Address One:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
&nbsp; <asp:DropDownList ID="ddlAddresses1" runat="server" Width="162px" Height="22px" Visible="False" >
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAddress3" runat="server" Text="Address Three:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAddresses3" runat="server" Width="162px" Height="22px" Visible="False" >
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAddress2" runat="server" Text="Address Two:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAddresses2" runat="server" Width="162px" Height="22px" Visible="False" >
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAddress4" runat="server" Text="Address Four:" Font-Bold="True" Font-Names="Calibri" Visible="False"></asp:Label>
&nbsp; <asp:DropDownList ID="ddlAddresses4" runat="server" Width="162px" Height="22px" Visible="False" >
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" OnClick="btnSave_Click" style="margin-left: 17px; margin-top: 37px" Text="Update" Width="120px" Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Size="Large" ForeColor="#006600" Text="Details Updated Successfully!!" Visible="False"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
