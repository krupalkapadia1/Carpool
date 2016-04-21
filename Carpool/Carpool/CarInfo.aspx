<%@ Page Title="Manage your car information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarInfo.aspx.cs" Inherits="Carpool.CarInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <asp:PlaceHolder runat="server" ID="ShowCarInfo" Visible="false">
        <p class="text">
            License Number: <asp:Literal runat="server" ID="ShowLicense" /><br />
        </p>
        <p class="text">
            Car Type: <asp:Literal runat="server" ID="ShowCarType" /><br />
        </p>
        <p class="text">
            Capacity: <asp:Literal runat="server" ID="ShowCapacity" /><br />
        </p>
        <asp:Button runat="server" OnClick="ConfirmRide" Text="Confirm" />
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="EditCarInfo" Visible="false">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LicenseNumber" CssClass="col-md-2 control-label">Car Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LicenseNumber" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LicenseNumber"
                    CssClass="text-danger" ErrorMessage="License number is required for security reason." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CarType" CssClass="col-md-2 control-label">Car Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CarType" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CarType"
                    CssClass="text-danger" ErrorMessage="Car type is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Capacity" CssClass="col-md-2 control-label">Capacity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Capacity" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Capacity"
                    CssClass="text-danger" ErrorMessage="Capacity is required." />
            </div>
        </div>

        <asp:Button runat="server" OnClick="ConfirmRide" Text="Confirm" />
    </asp:PlaceHolder>




    
</asp:Content>
