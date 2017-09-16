<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="Admin_admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .style1
        {
            width: 329px;
        }
    </style>
    
</head>
<body >
    <form id="form1" runat="server">
    <table align="center" width="1000px" >
    <tr>
    <td>
    <img src="../ICON.jpg" style="height: 114px; width: 454px; margin-top: 0px" />       
    </td>
    <td>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
    <td>
        <img src="../admin.gif" />
    </td>
    </tr>
    </table>
    <div style="margin:200 200 200;">
    <table align="center" width="400px" border="1px ridge" style="background-color:#bcd890;">
    <tr>
    <td align="center" colspan="2">
    <h2>Login-Admin Panel</h2>
    </td>
    </tr>
    <tr>
    <td align="right" style="font-weight:bold;" class="style1">Username:</td>
    <td>
        <asp:TextBox ID="txtlogin" runat="server" Width="186px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td align="right" style="font-weight:bold;" class="style1">Password:</td>
    <td>
        <asp:TextBox ID="txtpass" runat="server" Width="186px" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan=2 align="center">
        <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
    </td>
    </tr>
    <tr>
    <td class="style1" colspan=2>
        <asp:Label ID="Label1" runat="server" Text="Label" style="color:red"></asp:Label>    
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
