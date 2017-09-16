<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DonateBooks.aspx.cs" Inherits="DonateBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center style="margin-left:-400px">
    <table style="line-height: 40px; font-size: 20px;" >
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label1" runat="server" Text="Book Name"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_Bookname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Text="Book Description"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_Bookdescription" runat="server"></asp:TextBox>
                </td>
            </tr>
           
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label4" runat="server" Text="Contact No"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_contact_no" runat="server"></asp:TextBox>
                </td>
            </tr>
          <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label5" runat="server" Text="Email id"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_emailID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style10">
                <td class="style7" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="submit_data" />
                </td>
            </tr>
        <tr><td colspan="2"><asp:Label ID="result" runat="server" Text=""></asp:Label></td></tr>

        </table>
        </center>
</asp:Content>

