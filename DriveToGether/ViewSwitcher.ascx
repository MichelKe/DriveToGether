<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="DriveToGether.ViewSwitcher" %>
<!-- M�glichkeit mit Ajax ein alternatives Benutzerfenster zu �ffnen-->
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
</div>