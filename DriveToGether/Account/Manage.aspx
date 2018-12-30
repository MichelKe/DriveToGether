﻿<%@ Page Title="Dein Profil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="DriveToGether.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
    <div class="row">
        <div class="col-md-6">
             <div class="form-horizontal">
                <h4>Deine Daten</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Vorname:</dt>
                    <dd>
                        
                        <span><%: Vorname  %></span>
                    </dd>
                    <dt>Nachname:</dt>
                    <dd>
                       
                        <span><%: Nachname  %></span>
                    </dd>
                    <dt>Email:</dt>
                    <dd>
                        <span><%: Context.User.Identity.GetUserName()  %></span>
                    </dd>
                 </dl>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-horizontal">
                <h4>Kontoeinstellungen ändern</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Vorname:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManageVorname" Text="[Ändern]" Visible="false" ID="ChangeVorname" runat="server" />
                    </dd>
                    <dt>Nachname:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManageNachname" Text="[Ändern]" Visible="false" ID="ChangeNachname" runat="server" />
                    </dd>
                    <dt>Kennwort:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Ändern]" Visible="false" ID="ChangePassword" runat="server" />
                    </dd>
                    <dt>Externe Anmeldungen:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>Zweistufige Authentifizierung:</dt>
                    <dd>
                        <p>
                            Es sind keine Anbieter für zweistufige Authentifizierung konfiguriert. In <a href="https://go.microsoft.com/fwlink/?LinkId=403804">diesem Artikel</a>
                            finden Sie Details zum Einrichten dieser ASP.NET-Anwendung für die Unterstützung zweistufiger Authentifizierung.
                        </p>
                        <% if (TwoFactorEnabled)
                          { %> 
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                          else
                          { %> 
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
