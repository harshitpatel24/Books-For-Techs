<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 152px;
        }
        .style7
        {
            width: 152px;
            height: 34px;
        }
        .style8
        {
            height: 34px;
            width: 128px;
        }
        .style9
        {
            width: 128px;
        }
        .style10
        {
            text-align: center;
        }
        .style11
        {
            width: 679px;
        }
        .style13
      {
          height: 44px;
      }
    .style14
    {
        width: 681px;
    }
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:#bcd890;height:480px; width: 1334px;margin-left:-100px;margin-bottom:50px;" >
<h1 align="center" style="font-family:Agency FB;text-decoration:underline;">Sign-up/Login</h1>

<table>
<tr>
<td class="style11">

<h2 align="center" style="font-family:Agency FB;">Sign-up</h2>
    <table style="line-height:40px;font-size:20px;" align="center">
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
    </td>
    <td class="style9">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
    </td>
    <td class="style9">
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label3" runat="server" Text="Email-ID"></asp:Label>
    </td>
    <td class="style9">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
    </td>
    <td class="style9">
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    <tr class="style10">
    <td class="style7">
        <asp:Label ID="Label5" runat="server" Text="Re-Type Password"></asp:Label>
    </td>
    <td class="style8">
        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    
    </tr>  
    <tr >
    <td colspan="2" class="style13">
         <asp:Button ID="Button1" runat="server" Text="Signup" onclick="Button1_Click" />
    </td>    
    </tr>  
    <tr>
    <td colspan=2>
        <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>    
    </td>
    </tr>
    </table>

</td>
<td class="style14">
    <table style="line-height:40px;font-size:20px;" align="center">
    <h2 align="center" style="font-family:Agency FB;">Login</h2>
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Email-ID"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Button ID="Button2" runat="server" Text="Login" onclick="Button2_Click" />
    </td>
    </tr>
    <tr>
    <td colspan=2>
        <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>    
    </td>
    </tr>
      
    </table>

</td>
</tr>
</table>
</div>
</asp:Content>

