<%@ Page Title="Booking Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmPassenger.aspx.cs" Inherits="Carpool.ConfirmPassenger" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
<div>
    <h5>Done! Pack your bag!</h5>    
    <asp:Button runat="server" OnClick="ToMyPage" Text="View my bookings" CssClass="btn btn-default" />
</div>


</asp:Content>