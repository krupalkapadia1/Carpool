<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Carpool.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
 
    <div class="col-md-12">
        <div class="form-horizontal">
            <h4><asp:Literal runat="server" ID="StatusText" /></h4>                
        </div>
    </div>

    <asp:ListView ID="BookingListPassenger" runat="server" ItemPlaceholderID="bookingItemPlaceHolder" 
                GroupPlaceholderID="groupPlaceHolder" Visible="false" >        
        <LayoutTemplate>
            <table class="table table-striped">
                <tr>
                    <th>
                        Starting Point
                    </th>
                    <th>
                        Destination
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                        Time
                    </th>
                    <th>
                        Driver
                    </th>
                </tr>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>                        
            </table>            
        </LayoutTemplate>
        <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="bookingItemPlaceHolder"></asp:PlaceHolder>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <%# Eval("startingpoint") %>
                    </td>
                    <td>
                        <%# Eval("destination") %>
                    </td>
                    <td>
                        <%# Eval("date") %>
                    </td>
                    <td>
                        <%# Eval("time") %>
                    </td>
                    <td>
                        <%# Eval("driver") %>
                    </td>                    
                </ItemTemplate>

    </asp:ListView>
    
    <asp:ListView ID="BookingListDriver" runat="server" ItemPlaceholderID="bookingItemPlaceHolder" 
                GroupPlaceholderID="groupPlaceHolder" Visible="false" >        
        <LayoutTemplate>
            <table class="table table-striped">
                <tr>
                    <th>
                        Starting Point
                    </th>
                    <th>
                        Destination
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                        Time
                    </th>
                    <th>
                        Curretnly Booked
                    </th>
                </tr>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>                        
            </table>
            
        </LayoutTemplate>
        <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="bookingItemPlaceHolder"></asp:PlaceHolder>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <%# Eval("startingpoint") %>
                    </td>
                    <td>
                        <%# Eval("destination") %>
                    </td>
                    <td>
                        <%# Eval("date") %>
                    </td>
                    <td>
                        <%# Eval("time") %>
                    </td>
                    <td>
                        <%# Eval("currentBook") %>
                    </td>                    
                </ItemTemplate>


    </asp:ListView>


</asp:Content>
