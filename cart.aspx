<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
        <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Vertical" 
            onselectedindexchanged="DataList1_SelectedIndexChanged"
        >

    
    <ItemTemplate>
<table border="1">
    <col width="200px">
    <col width="300px">
    <col width="300px">
    <col width="300px">
    
    <tr>
        <td>
            <asp:Image ID="Image1" AlternateText="img1" runat="server" Width="150px" Height="180px"
                ImageUrl='<%# "~/OldImage1.ashx?id=" + System.Convert.ToString(Eval("old_book_id")) %>' />
        </td>
        
        <td style="padding:2%" >
            <b style="color:green;font-size:20px">Book Name : </b><asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label></td>
        
        <td style="padding:2%">
            <b style="color:green;font-size:20px">Book Price : </b><asp:Label ID="Label2" runat="server" Text='<%# Bind("price") %>'></asp:Label>
        </td>

        
        <td style="padding:2%">
            <asp:Button ID="Button1" runat="server" Text="Buy Now"/>
        </td>

        
    </tr>
</table>
        
     </ItemTemplate>
   </asp:DataList>     
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [oldBook]"></asp:SqlDataSource>
    

<asp:DataList ID="DataList2" runat="server" RepeatDirection="Vertical"
            onItemCommand="DataList2_ItemCommand" 
            onselectedindexchanged="DataList2_SelectedIndexChanged">

    
    <ItemTemplate>
<table border="1">
    <col width="200px">
    <col width="250px">
    <col width="250px">
    <col width="250px">
    <col width="250px">
    <tr>
        <td>
            <asp:Image ID="Image1" AlternateText="img1" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/ShowImage.ashx?id=" + System.Convert.ToString(Eval("book_id"))%>'/>
        </td>
    
        <td style="padding:2%" >
            <b style="color:green;font-size:20px">Book Name : </b><asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label></td>
        
        <td style="padding:2%">
            <b style="color:green;font-size:20px">Book Price : </b><asp:Label ID="Label3" runat="server" Text='<%# Bind("book_price") %>'></asp:Label>
        </td>
        <td style="padding:2%">
            <asp:Button runat="server" Text="-" CommandName="bookidforminus" CommandArgument='<%#Eval("bookid")+","+ Eval("userid")%>'/>
            <b style="color:green;font-size:20px">Quantity : </b><asp:Label ID="Label5" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
            <asp:Button ID="Button3" runat="server" Text="+" CommandName="bookidforplus" CommandArgument='<%#Eval("bookid")+","+ Eval("userid")%>'/>
        </td>
        <td style="padding:2%">
            <asp:Button runat="server" Text="Buy Now"/>
        </td>
    </tr>
</table>
        
     </ItemTemplate>
        
        
    </asp:DataList>     
      
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [add_book,addcart]"></asp:SqlDataSource>
    
<table border="1">
    <col width="200px">
    <col width="250px">
    <col width="250px">
    <col width="250px">
    <col width="250px">
    <tr>
        <td colspan="3"><b style="color:green;font-size:20px">Total Amount</td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </td>
        <td><asp:Button ID="Button2" runat="server" Text="Final CheckOut"/></td>
    </tr>
</table>
</asp:Content>

