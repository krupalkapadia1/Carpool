<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carpool._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

  
    <div class="jumbotron">
        <h3>Available Rides
            <asp:ListView ID="RideList" runat="server" ItemPlaceholderID="rideItemPlaceHolder" GroupPlaceholderID="groupPlaceHolder" OnPagePropertiesChanging="OnPagePropertiesChanging">
                <LayoutTemplate>
                    <table>
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
                        <tr>
                            <td colspan="3">
                                <asp:DataPager ID="DataPager" runat="server" PagedControlID="RideList" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="rideItemPlaceHolder"></asp:PlaceHolder>
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
        </h3>
        

        
    </div>

      <div class="filterSearch">
        <h3> Search for your desired destination in Canada</h3>
        From: <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        To: <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
        Date: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        <a href="FilterSearch.aspx" class="btn btn-primary btn-lg">Go &raquo;</a>
        
    </div>


    

</asp:Content>
