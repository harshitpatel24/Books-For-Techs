<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayBook.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="5"
            onselectedindexchanged="DataList1_SelectedIndexChanged"
            style="margin-left:200px;"
        >

    
    <ItemTemplate>
<table border="0" width="100%" >
<tr>
<td rowspan="2">
            <asp:Image ID="Image1" AlternateText="img1" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/OldImage1.ashx?id=" + System.Convert.ToString(Eval("old_book_id")) %>' />
             
             <asp:Image ID="Image2" AlternateText="img2" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/OldImage2.ashx?id=" + System.Convert.ToString(Eval("old_book_id")) %>' />
             </td>
             
<td style="text-align:left;padding:2%" >
<b style="color:green;font-size:20px">Book Name : </b><asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label></td>
</tr>
<tr>
<td style="text-align:left;padding:2%">
<b style="color:green;font-size:20px">Book Description : </b><asp:Label ID="Label2" runat="server" Text='<%# Bind("book_description") %>'></asp:Label>
</td>
</tr>
<tr>
<td rowspan="3" style="width:40%;">
             <asp:Image ID="Image3" AlternateText="img1" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/OldImage3.ashx?id=" + System.Convert.ToString(Eval("old_book_id")) %>' />
             <asp:Image ID="Image4" AlternateText="img1" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/OldImage4.ashx?id=" + System.Convert.ToString(Eval("old_book_id")) %>' />
</td>
<td style="text-align:left;padding:2%">
<b style="color:green;font-size:20px">Book Price : </b><asp:Label ID="Label3" runat="server" Text='<%# Bind("price") %>'></asp:Label>
</td>
</tr>
<tr>
<td style="text-align:left;padding:2%">
    <b style="color:green;font-size:20px">Quantity : </b>
     <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
</td>
</tr>
<tr>
<td style="text-align:left;padding:2%">
   <asp:Button ID="Button1" runat="server" Text="Buy" width="20%" />
        <asp:Button ID="Button2" runat="server" Text="Add to Cart" width="20%" />
  
</td>
</tr>
</table>
     </ItemTemplate>
        
        
    </asp:DataList>     
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [oldBook]"></asp:SqlDataSource>

   
</asp:Content>

