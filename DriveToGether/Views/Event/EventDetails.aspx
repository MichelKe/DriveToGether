<%@ Page Title="Eventdetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="DriveToGether.EventDetails" %>
<!-- Zeigt erstellte Events an und bietet die Funktion eines auszuwählen-->
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div runat="server" id="event_details_container"><span runat="server" id="carlist" style="display: none;"></span></div>
</asp:Content>
