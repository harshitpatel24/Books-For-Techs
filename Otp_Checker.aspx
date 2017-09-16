<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Otp_Checker.aspx.cs" Inherits="Otp_Checker" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div style="background-color:#bcd890;height:480px; width: 1334px;margin-bottom:50px;" >
<h1 align="center" style="font-family:Agency FB;text-decoration:underline;">OTP Verification</h1>

    <table style="line-height:40px;font-size:20px;" align="center">
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label1" runat="server" Text="Your Email : "></asp:Label>
    </td>
    <td class="style9">
        <asp:Label ID="Label10" runat="server" ></asp:Label>
    </td>
    </tr>
    <tr class="style10">
    <td class="style6">
        <asp:Label ID="Label2" runat="server" Text="OTP : "></asp:Label>
    </td>
    <td class="style9">
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
    <tr >
    <td class="style13">
    <center><asp:Button ID="Button2" runat="server" Text="Resend" OnClick="Button2_Click1" /></center>    
    </td>

        <td class="style13">
        <center> <asp:Button ID="Button1" runat="server" Text="Verify" onclick="Button1_Click" /></center>
    </td>    
    </tr>  
    <tr>
    <td colspan=2>
        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="Enter OTP which is sent to your registered email"></asp:Label>    
    </td>
    </tr>
    </table>

</div>

</asp:Content>

