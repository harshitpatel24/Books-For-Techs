<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="add_book.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
    textarea {
        resize:none;
    }
</style>
    <table align=center width="100%" align="center">
<tr>
<td colspan="3">
<h1 align="center" style="font-family:Agency FB;text-decoration:underline;">Add New Book</h1>
</td>
</tr>
        
    <table align="center"  cellpadding="5px" cellspacing="5px" style="font-weight:bold;">
    
    <tr>
    <td>
    Book Name:
    </td>
    <td>
        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    Book Publication:
    </td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" 
            DataSourceID="SqlDataSource2" DataTextField="pub_name" 
            DataValueField="pub_name">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [pub_name] FROM [add_publication]">
        </asp:SqlDataSource>
    </td>
    </tr>
    <tr>
    <td>
    Book Author:
    </td>
    <td>
        <asp:TextBox ID="txtauthor" runat="server"></asp:TextBox>
    </td>
    </tr>
     <!--   <tr>
    <td>
    Book Description:
    </td>
    <td>
    
        <asp:TextBox ID="txtdesc" runat="server"></asp:TextBox>
    
    </tr> -->
    <tr>
    <td>
    Book Semester:
    </td>
    <td>
        <asp:TextBox ID="txtsem" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    Book Image:
    </td>
    <td>
        <asp:FileUpload ID="imgUpload" runat="server" Width="222px" />
        
    </td>
    </tr>
    <!--<tr>
    <td>
    Book Quantity:
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    </td>
    </tr> -->
    <tr>
    <td>
    Book Price:
    </td>
    <td>
        <asp:TextBox ID="txtprice" runat="server" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan=3>
        <asp:Button ID="Button1" runat="server" onClick="Button1_Click" Text="Submit" style="height: 26px" />
    </td>
    </tr>
        
    <tr>
    <td colspan=3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource1" GridLines="None" 
            Width="330px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="book_id" HeaderText="book_id" 
                    SortExpression="book_id" />
                <asp:BoundField DataField="book_name" HeaderText="book_name" 
                    SortExpression="book_name" />
                <asp:BoundField DataField="pub_name" HeaderText="pub_name" 
                    SortExpression="pub_name" />
                <asp:BoundField DataField="book_author" HeaderText="book_author" 
                    SortExpression="book_author" />
                <asp:BoundField DataField="book_sem" HeaderText="book_sem" 
                    SortExpression="book_sem" />
                <asp:BoundField DataField="book_price" HeaderText="book_price" 
                    SortExpression="book_price" />
                <asp:ButtonField CommandName="Cancel" HeaderText="Remove" ShowHeader="True" Text="Remove" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [add_book]"></asp:SqlDataSource>
    </td>
    </tr>
    </table>
            
</tr>
</table>
</asp:Content>

