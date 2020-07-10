<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployeeList.aspx.cs" Inherits="WebApplicationAssignment.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 719px; width: 1220px; background-color:beige; margin-right: 0px;">
            <asp:Button ID="btnBack" runat="server" BackColor="#FF9999" BorderStyle="Groove" BorderWidth="5px" Height="38px" OnClick="btnBack_Click" style="margin-left: 1041px" Text="Back" Width="98px" />
            <br /><br />      
            <asp:GridView ID="dataGrid" runat="server" AutoGenerateColumns="False" Height="590px" HeaderStyle-Height="40" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1148px" BackColor="#99CCFF" BorderColor="Black" BorderStyle="Double" BorderWidth="10px" ForeColor="Black" style="margin-left: 32px">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="EmployeeID" />
                    <asp:BoundField HeaderText="Name" DataField="EmployeeName" />
                    <asp:BoundField HeaderText="Email" DataField="EmployeeEmail"/>
                    <asp:BoundField HeaderText="Place One" DataField="EmployeePlace[0].Places" />
                    <asp:BoundField HeaderText="Pincode One" DataField="EmployeePlace[0].EmployeeAddress[0].Pincodes" />
                    <asp:BoundField HeaderText="Pincode Two" DataField="EmployeePlace[0].EmployeeAddress[1].Pincodes" />
                    <asp:BoundField HeaderText="Place Two" DataField="EmployeePlace[1].Places" />
                    <asp:BoundField HeaderText="Pincode Three" DataField="EmployeePlace[1].EmployeeAddress[0].Pincodes" />
                     <asp:BoundField HeaderText="Pincode Four" DataField="EmployeePlace[1].EmployeeAddress[1].Pincodes" />    
                </Columns>
                <HeaderStyle Height="40px" />
            </asp:GridView>          
        </div>
    </form>
</body>
</html>
