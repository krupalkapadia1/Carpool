<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterSearch.aspx.cs" Inherits="Carpool.FilterSearch" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="filterSearch">
        <h4>Your filtered search</h4>
        <p class="lead">Destination: </p>
        <p class="lead">Date: </p>
        <p class="lead">Time </p>
        <p class="lead">Amount each head: </p>
        <p class="lead">Driver's Information </p>
        <p class="lead">Vehicle: </p>
        <p class="lead">Vehicle Number: </p>
         <p><a href="Confirm.aspx" class="btn btn-primary btn-lg">Confirm &raquo;</a>
             <a href="Default.aspx" class="btn btn-primary btn-lg">Cancel&raquo;</a>
         </p>
        


    </div>


</asp:Content>
