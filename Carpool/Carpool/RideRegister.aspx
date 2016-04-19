<%@ Page Title="Register a ride" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RideRegister.aspx.cs" Inherits="Carpool.RideRegister" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Offer a ride?</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <div class="registerRide">
            <h5> Locations </h5> <br />
            Departing From: <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox> <br />
            Travelling To: <asp:TextBox ID="txtTo" runat="server"></asp:TextBox> <br />

            <h5> Travel Time </h5> <br />
            Date: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox> <br />       
            Time: <asp:TextBox ID="txtTime" runat="server"></asp:TextBox> <br />

            <a href="CarInfo.aspx" class="btn btn-primary btn-lg">Register &raquo;</a>
        
    </div>

</asp:Content>

