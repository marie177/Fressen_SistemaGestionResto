<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditTipoPlato.aspx.cs" Inherits="TP_Cuatrimestral.EditTipoPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row m-5 justify-content-center">
        <div class="col-6 card p-5">
            <div class="card-boy">
                <div class="row">
                    <div class="col">
                        <h5 class="card-title">Nombre</h5>
                        <asp:Label runat="server" ID="lblId" Text="" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="card-text w-100"></asp:TextBox>
                    </div>
                </div>

                <div class="row justify-content-end mt-2">
                    <div class="col-2">
                        <asp:Button runat="server" CssClass="btn btn-danger m-1" CommandArgument='<%#Eval("Id")%>' CommandName="idTipo" OnClick="btnEliminar_Click" ID="btnEliminar" Text="Inactivar" />
                    </div>
                    <div class="col-3">
                        <asp:Button runat="server" CssClass="btn btn-success m-1" CommandArgument='<%#Eval("Id")%>' Visible="false" CommandName="idTipo" OnClick="btnReActivar_Click" ID="btnReActivar" Text="Reactivar" />
                    </div>
                    <div class="col-2">
                        <asp:Button runat="server" CssClass="btn btn-primary m-1" CommandArgument='<%#Eval("Id")%>' CommandName="idTipo" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Guardar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
