<%@ Page Title="Ride Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RideDetail.aspx.cs" Inherits="Carpool.RideDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <h3>Ride Details</h3>

    <asp:DetailsView ID="RideDetailsView" runat="server" Height="50px" Width="562px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <%--<asp:BoundField DataField="startingpoint" HeaderText="StartingPoint" ReadOnly="True" />
            <asp:BoundField DataField="destination" HeaderText="Destination" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="time" HeaderText="Time" />
            <asp:BoundField DataField="driver" HeaderText="Driver" /> --%>           
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>

    <h3>Vehicle Information</h3>

    <asp:DetailsView ID="CarDetailsView" runat="server" Height="50px" Width="562px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <%--<asp:BoundField DataField="startingpoint" HeaderText="StartingPoint" ReadOnly="True" />
            <asp:BoundField DataField="destination" HeaderText="Destination" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="time" HeaderText="Time" />
            <asp:BoundField DataField="driver" HeaderText="Driver" /> --%>           
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" OnClick="GoBack" Text="Back" CssClass="btn btn-default" />
            
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" OnClick="BookRide" Text="Book This Ride" CssClass="btn btn-default" />
        </div>
        <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    </div>



       
    

       
</asp:Content>