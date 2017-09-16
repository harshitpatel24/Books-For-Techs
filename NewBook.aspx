<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewBook.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 103px;
        }
        .style4
        {
            width: 235px;
            height: 142px;
        }
        .style6
        {
            width: 246px;
        }
        .style7
        {
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
   <asp:Label ID="user_lbl" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
    <div style="width:1200px; height:auto;">
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="5" Width="1200px" 
            onselectedindexchanged="DataList1_SelectedIndexChanged"
            onItemCommand="DataList1_ItemCommand"
        >
        <ItemTemplate>
        <table border=0>
          <tr>
          <td class="style7">
              <b style="color:green;font-size:20px">Book Name : </b><asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label>             
          </td>
          </tr>
          <tr>
          <td class="style4">
            <asp:Image ID="Image1" AlternateText="img1" runat="server" Width="150px" Height="180px"
             ImageUrl='<%# "~/ShowImage.ashx?id=" + System.Convert.ToString(Eval("book_id"))%>' 
                
                />
          </td             
          </tr>
          <tr>
          <td class="style7">
             <b style="color:green;font-size:20px">Price : </b> <asp:Label ID="Label2" runat="server" Text='<%# Bind("book_price") %>'></asp:Label>
              
          </td>
          </tr>
           <tr>
           <td class="style7">
              <br />
               <asp:Button runat="server" Text="View Deatils"  id="LnkAnswer" CommandName="getid" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"book_id") %>'/>
               
               <asp:Button runat="server" Text="Add to Cart"  id="Button1" CommandName="getidforaddcart" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"book_id") %>'/>
             
               <br />
               <br />
               <br />
               <br />
           </td>
           </tr>
          </table>
          
        </ItemTemplate>
    </asp:DataList>     
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [add_book]"></asp:SqlDataSource>
     </div>   
   
</asp:Content>

