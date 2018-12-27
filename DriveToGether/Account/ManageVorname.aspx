<%@ Page Title="Nachname verwalten" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageVorname.aspx.cs" Inherits="DriveToGether.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <section id="passwordForm">
            <asp:PlaceHolder runat="server" ID="changeVornameHolder" Visible="false">
                <div class="form-horizontal">
                    <h4>Formular zum Ändern des Vornamens</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewVornameLabel" AssociatedControlID="NewVorname" CssClass="col-md-2 control-label">Neuer Vorname</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewVorname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewVorname"
                                CssClass="text-danger" ErrorMessage="Ein neuer Vorname muss eingegeben werden." />
                        </div>
                    </div>
           
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Vornamen ändern" OnClick="NewVorname_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
