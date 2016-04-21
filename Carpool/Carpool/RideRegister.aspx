<%@ Page Title="Register a ride" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RideRegister.aspx.cs" Inherits="Carpool.RideRegister" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <asp:PlaceHolder runat="server" ID="AddRideForm" Visible="false">            
        <div class="form-horizontal">
            <h4>Offer a ride?</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <h5>Locations:</h5>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="StartingPoint" CssClass="col-md-2 control-label">Starting Point</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="StartingPoint" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="startingPoint"
                            CssClass="text-danger" ErrorMessage="Starting point is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Destination" CssClass="col-md-2 control-label">Destination</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Destination" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Destination"
                            CssClass="text-danger" ErrorMessage="Destination is required." />
                    </div>
                </div>
                <br />
                <br />
                <h5> Travel Time </h5> <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DepartingDate" CssClass="col-md-2 control-label">Departing Date</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="DepartingDate" CssClass="form-control" TextMode="Date" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartingDate"
                            CssClass="text-danger" ErrorMessage="Departing date is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DepartingTime" CssClass="col-md-2 control-label">Departing Time</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="DepartingTime" CssClass="form-control" TextMode="Time" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartingTime"
                            CssClass="text-danger" ErrorMessage="Departing time is required." />
                    </div>
                </div>                              
                <asp:Button runat="server" OnClick="AddRide" Text="Confirm" />
                        
        </div>
    </asp:PlaceHolder>

</asp:Content>

