<%@ Page Title="Vorname verwalten" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageNachname.aspx.cs" Inherits="DriveToGether.Account.ManageNachname" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <span id="nachnameForm">
            <asp:PlaceHolder runat="server" ID="changeNachnameHolder">
                <div class="form-horizontal">
                    <h4>Formular zum Ändern des Nachnamens</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewNachnameLabel" AssociatedControlID="NewNachname" CssClass="col-md-2 control-label">Neuer Nachname</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewNachname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewNachname"
                                CssClass="text-danger" ErrorMessage="Ein neuer Nachname muss eingegeben werden." />
                        </div>
                    </div>
           
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Nachnamen ändern" OnClick="ChangeNachname_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </span>
    </div>
</asp:Content>
