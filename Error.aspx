<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP_Cuatrimestral.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <div>
                <h1 class="display-4 mt-5">Oops! Hubo un problema</h1>
            </div>
            <div class="container pt-3 text-center">
                <p class="note note-danger mb-3"><strong>Error: </strong><asp:Label ID="lblError" runat="server" Text="Label"></asp:Label></p>
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
