<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OldBook.aspx.cs" Inherits="Old_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
            </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <center style="margin-left:-400px">
        <table style="line-height: 40px; font-size: 20px;" >
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label1" runat="server" Text="Book Name"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Text="Book Description"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_description" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label3" runat="server" Text="Upload Pic 1" ></asp:Label>
                </td>
                <td class="style9">
                    <asp:FileUpload ID="image1" runat="server" />
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label5" runat="server" Text="Upload Pic 2"></asp:Label>
                </td>
                <td class="style9">
                    <asp:FileUpload ID="image2" runat="server"  />
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label6" runat="server" Text="Upload Pic 3"></asp:Label>
                </td>
                <td class="style9">
                    <asp:FileUpload ID="image3" runat="server"  />
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label7" runat="server" Text="Upload Pic 4"></asp:Label>
                </td>
                <td class="style9">
                    <asp:FileUpload ID="image4" runat="server"  />
                </td>
            </tr>
            <tr class="style10">
                <td class="style6">
                    <asp:Label ID="Label4" runat="server" Text="Expected Price"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox_price" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style10">
                <td colspan="2" class="style7">
                    <asp:Button ID="Button1" runat="server" Text="Post My Book" OnClick="submit_data" />
                </td>
            </tr>
            <tr class="style10">
                <td colspan="2" class="style7">
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
       </center>
</asp:Content>

