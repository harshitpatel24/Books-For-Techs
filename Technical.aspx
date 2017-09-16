<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Technical.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
<tr>
<td>
     <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="5" Width="1200px" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" >       
        
            <ItemTemplate>
             <table border=1>
          <tr>
          <td class="style7">
              <asp:Label ID="Label1" runat="server" Text='<%# Bind("book_name") %>'></asp:Label>             
          </td>
          </tr>
          <tr>
          <td class="style4">
            <asp:Image ID="Image1" runat="server" Width="150px" Height="180px" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "book_image") %>' GenerateEmptyAlternateText="True" />

              <%--<img src= '<%# DataBinder.Bind(Container.DataItem,"book_image")' %>>--%>
          </td             
          </tr>
          <tr>
          <td class="style7">
              <asp:Label ID="Label2" runat="server" Text='<%# Bind("book_price") %>'></asp:Label>
              
          </td>
          </tr>
           <tr>
           <td class="style7">
               <asp:Button ID="Button1" runat="server" Text="Add to Cart" />
           </td>
           </tr>
          </table>
          
            </ItemTemplate>
        
        </asp:DataList>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
         ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
         SelectCommand="SELECT * FROM [add_book] WHERE ([pub_name] LIKE '%' + @pub_name + '%')">
         <SelectParameters>
             <asp:Parameter DefaultValue="Technical" Name="pub_name" Type="String" />
         </SelectParameters>
     </asp:SqlDataSource>
    </td>
</tr>
</table>
</asp:Content>