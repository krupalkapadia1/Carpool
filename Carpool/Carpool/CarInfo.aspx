<%@ Page Title="Manage your car information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarInfo.aspx.cs" Inherits="Carpool.CarInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="carInformation">
        Display car information
        <a href="ConfirmDriver.aspx" class="btn btn-primary btn-lg">Confirm &raquo;</a>
    </div>
</asp:Content>
