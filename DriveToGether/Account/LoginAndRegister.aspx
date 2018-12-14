﻿<%@ Page Title="Anmelden und Registrieren" Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginAndRegister.aspx.cs" Inherits="DriveToGether.Account.LoginAndRegister" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

 <div class="row">
        <div class="col-6>
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Lokales Konto für die Anmeldung verwenden.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-Mail</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Das E-Mail-Feld ist erforderlich." />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Kennwort</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                           <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Das Kennwortfeld ist erforderlich." />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Speichern?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Anmelden" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <%--<p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Als neuer Benutzer registrieren</asp:HyperLink>
                </p>--%>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

        <%--
        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
        --%>
    </div>


     <%--Register
    <p class="text-danger">
        <asp:Literal runat="server" ID="Literal1" />
    </p>
<div class="row">
  <div class="col-6">
    <div class="form-horizontal">
        <h4>Neues Konto erstellen</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-Mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="Email" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                     CssClass="text-danger" ErrorMessage="Das E-Mail-Feld ist erforderlich." />-
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Kennwort</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBox2" TextMode="Password" CssClass="form-control" />
                   <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Das Kennwortfeld ist erforderlich." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Kennwort bestätigen</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Das Feld zum Bestätigen des Kennworts ist erforderlich." />
                asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Das Kennwort stimmt nicht mit dem Bestätigungskennwort überein." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrieren" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
  </div>
</div>--%>
</asp:Content>