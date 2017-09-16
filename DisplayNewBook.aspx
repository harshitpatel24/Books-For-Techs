<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayNewBook.aspx.cs" Inherits="DisplayNewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="5" Width="1200px" 
            onselectedindexchanged="DataList1_SelectedIndexChanged"
            
        >
        <ItemTemplate>
    <table>
<tr>
<td rowspan=9><asp:Image ID="Image1" AlternateText="img1" runat="server" Width="500px" Height="500px" ImageUrl='<%# "~/ShowImage.ashx?id=" + System.Convert.ToString(Eval("book_id")) %>' /></td>
<td><b style="color:green;font-size:20px">Book Name : </b><asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label></td> 
</tr>
<tr>
<td><b style="color:green;font-size:20px">Publication : </b><asp:Label ID="Label2" runat="server" Text='<%# Bind("pub_name") %>'></asp:Label></td> 
</tr>
<tr>
<td><b style="color:green;font-size:20px">Book Price : </b><asp:Label ID="Label3" runat="server" Text='<%# Bind("book_price") %>'></asp:Label></td> 
</tr>
<tr>
<td><b style="color:green;font-size:20px">Quantity : </b>
<asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
</td> 
</tr>
<tr>
<td>   <asp:Button ID="Button1" runat="server" Text="Buy" width="100%" />
       
</td> 
</tr>
<tr>
<td> <asp:Button ID="Button2" runat="server" Text="Add to Cart" width="100%" /> </td>
</tr>

<tr>
<td></td>
</tr>


</table>



        </ItemTemplate>
    </asp:DataList>     
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [add_book]"></asp:SqlDataSource>

   
</asp:Content>


