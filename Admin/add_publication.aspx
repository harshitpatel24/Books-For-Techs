<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="add_publication.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" width="100%" cellpadding="5px" style="font-weight :bold ;">
<tr>
<td colspan="3">
<h1 align="center" style="font-family:Agency FB;text-decoration:underline;">Add New Publication</h1>
</td>
</tr>
<tr>
<td colspan="2" align=right>
Add New Publication
</td>
<td align=left>
    <asp:TextBox ID="txtpubname" runat="server" ></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="3">
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    *<asp:Label ID="lblresult" runat="server" style="color:Red;"></asp:Label>
</td>
</tr>
<tr>
<td colspan="3" align="center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="334px">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="pub_id" HeaderText="pub_id" 
                SortExpression="pub_id" />
            <asp:BoundField DataField="pub_name" HeaderText="pub_name" 
                SortExpression="pub_name" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [add_publication]"></asp:SqlDataSource>
</td>
</tr>
</table>
</asp:Content>

