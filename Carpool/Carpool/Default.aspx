<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carpool._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

  
    <div class="jumbotron">
        <h3>Available Rides</h3>
        <p class="lead">Destination: </p>
         <p class="lead">Date: </p>
        <p><a href="Search.aspx" class="btn btn-primary btn-lg">Search &raquo;</a></p>
    </div>

      <div class="filterSearch">
        <p class ="lead"> Search for your desired destination in Canada</p>
        From: <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        To: <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
        Date: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        <a href="FilterSearch.aspx" class="btn btn-primary btn-lg">Go &raquo;</a>
        
    </div>


    

</asp:Content>
