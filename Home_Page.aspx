<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home_Page.aspx.cs" Inherits="Home_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div style="max-height:400px;margin-left:-180px;">
        <img src="Technical%20publications/Sem-1/EG.jpg"  height="500px" width="480px" style="padding:10px;"/>
        <img src="Technical%20publications/Sem-1/CPU.jpg"  height="500px" width="480px"style="padding:10px;"/>
        <img src="Technical%20publications/8.jpg"  height="500px" width="480px"style="padding:10px;"/>
    </div>
    
<marquee behavior="alternate" scrollamount="5" style="margin-top:150px;" >
<a href="#"><img src="Logo/McGrawHill_logo.png"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
<a href="#"><img src="Logo/tech-max1.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
<a href="#"><img src="Logo/Mahajan_Logo.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
<a href="#"><img src="Logo/Technical_logo.png" /></a>
</marquee> 
</asp:Content>




<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <asp:Label ID="Label1" runat="server" Text="LOGIN" STYLE="color:Black;font-weight:bold;"></asp:Label>
            </asp:Content>






