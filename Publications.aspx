<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="Publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pub">
<center>
<asp:Image ID="Image1" runat="server" Height="64px" 
        ImageUrl="~/Logo/Technical_logo.png" Width="296px" />
</center>
</div>
<div class="img">
    <img src="Technical%20publications/CN.jpg" height="300px" width="200px" />
        <div class="desc">
       <b>Computer Networks</b>
            <br />
        Price:
        </div>
</div>
<div class="img">
    <img src="Technical%20publications/CO.jpg" height="300px" width="200px"/>    
<div class="desc">
<b>Computer Organization and architecture</b>
    <br />
    Price:
</div>
</div>
<div class="img">
    <img src="Technical%20publications/DBMS.jpg" height="300px" width="200px" />
<div class="desc">
<b>Database Management System</b>
    <br />
    Price:
</div>
</div>
<div class="img">
    <img src="Technical%20publications/DE.jpg" height="300px" width="270px"/>
<div class="desc">
<b>Digital Electronics</b>
    <br />
    Price:
</div>
</div>
<div class="img">
    <img src="Technical%20publications/AEM.jpg" height="300px" width="270px"/>
<div class="desc">
<b>Advance Engineering Mathematics</b>
    <br />
    Price:
</div>
</div>
</asp:Content>

