<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="DriveToGether.ViewSwitcher" %>
<!-- Möglichkeit mit Ajax ein alternatives Benutzerfenster zu öffnen-->
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
</div>