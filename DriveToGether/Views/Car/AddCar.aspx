<%@ Page Title="Auto Hinzufügen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="DriveToGether.Account.addCar" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Hier Daten eingeben:</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Fahrzeugname" CssClass="col-md-2 control-label">Fahrzeugname</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Fahrzeugname" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Fahrzeugname"
                    CssClass="text-danger" ErrorMessage="Das Fahrzeugname-Feld ist erforderlich." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FahrerVorname" CssClass="col-md-2 control-label">Vorname des Fahrers</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FahrerVorname" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FahrerVorname"
                    CssClass="text-danger" ErrorMessage="Das Faherename-Feld ist erforderlich." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FahrerNachname" CssClass="col-md-2 control-label">Nachname des Fahrers</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FahrerNachname" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FahrerNachname"
                    CssClass="text-danger" ErrorMessage="Das Faherename-Feld ist erforderlich." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CarDetails" CssClass="col-md-2 control-label">Details (wie z.b abfahrts Ort & Zeit etc)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CarDetails" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CarDetails"
                    CssClass="text-danger" ErrorMessage="Das Details-Feld ist erforderlich." />
            </div>
        </div><div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Autonummer" CssClass="col-md-2 control-label">Autonummer (z.b SG123)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Autonummer" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Autonummer"
                    CssClass="text-danger" ErrorMessage="Das Details-Feld ist erforderlich." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Plaetze" CssClass="col-md-2 control-label">Anzahl Plätze</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Plaetze" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Plaetze"
                    CssClass="text-danger" ErrorMessage="Das Anzahl-Plätze-Feld ist erforderlich." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="Plaetze" runat="server"
                    CssClass="text-danger" ErrorMessage="Nur Zahlen als eingabe zulässig" ValidationExpression="\d+">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="AddCar_Click" Text="Hinzufügen" CssClass="btn btn-default"/>
            </div>
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="RedirectBack_Click" Text="Abbrechen" CssClass="btn btn-default" CausesValidation="False"/>
            </div>
        </div>
    </div>
</asp:Content>
