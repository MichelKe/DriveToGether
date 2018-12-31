<%@ Page Title="Dein Profil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="DriveToGether.Account.Manage" %>

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
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
