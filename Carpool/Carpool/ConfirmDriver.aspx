<%@ Page Title="Confirmation for Drivers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmDriver.aspx.cs" Inherits="Carpool.ConfirmDriver" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="confirmMessage">
        Confirmation message for registering a ride
    </div>


</asp:Content>
