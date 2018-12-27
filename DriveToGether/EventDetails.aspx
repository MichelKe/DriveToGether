<%@ Page Title="Eventdetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="DriveToGether.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>EVENT _ NAME</h3>
    <div class="row">
        <div class="col-md-6">
            <h2>Details</h2>
             <p>EVENT DETAILS -- Use this area to provide additional information.Use this area to provide additional information.Use this area to provide additional information.</p>
        </div>
        <div class="col-md-6">
            <div class="row">
                <h2>- DATUM -</h2>
            </div>
            <div class="row">
                <h2>Autos</h2>
                <ul>
                    <li>AUTo1</li>
                    <li>AUTo2</li>
                    <li>AUTo3</li>
                    <li>AUTo4</li>
                </ul>
             <div>
                 <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">in auto Einschreiben &raquo;</a>
                 <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">auto hinzufügen &raquo;</a>
             </div>
            </div>
            
        </div>
    </div>
   
</asp:Content>
