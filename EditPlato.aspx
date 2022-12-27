<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditPlato.aspx.cs" Inherits="TP_Cuatrimestral.EditPlato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row m-5">
                <div class="col-3"></div>
                <div class="col-6 p-5 container-platos_edit">
                    <div class="row bg-light br-6">
                        <div class="col text-center">
                            <asp:Label runat="server" CssClass="form-label text-dark fw-semibold" Text="Id #"></asp:Label>
                            <asp:Label runat="server" ID="lblId" CssClass="form-label br-6 w-100"></asp:Label>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col">
                            <asp:Label runat="server" CssClass="form-label text-dark fw-semibold" Text="Nombre"></asp:Label>
                        </div>

                        <div class="col">
                            <asp:Label runat="server" CssClass="form-label text-dark w-100 fw-semibold" Text="Precio"></asp:Label>
                        </div>

                    </div>
                    <div class="row mb-3">
                        <div class="col">
                            <div class="form-outline">
                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-label br-6 w-100 btn-outline-dark bg-light"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-label br-6 w-100 btn-outline-dark bg-light"></asp:TextBox>

                        </div>


                    </div>

                    <div class="row mt-1">

                        <div class="col">
                            <asp:Label runat="server" CssClass="form-label text-dark w-100 fw-semibold" Text="Tipo"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col ">
                            <asp:DropDownList CssClass="form-select btn btn-outline-dark dropwdown-toggle bg-light" runat="server" ID="ddlTipoPlato">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <div class="row mt-5 justify-content-end">
                                <div class="col-2 text-end">
                                    <asp:Button runat="server" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mb-4" />
                                </div>

                                <%if (ConfirmaEliminacion)
                                    {  %>

                                <div class="row ">
                                    <div class="col-6">
                                        <asp:Label runat="server" ID="lblConfirmaDesactivar" Text="¿Confirmar desactivar el Plato?"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Button runat="server" CssClass="btn btn-danger" CommandArgument='<%#Eval("Id")%>' CommandName="IdPlato" Text="Confirmar" ID="btnConfirmaDesactivar" OnClick="btnConfirmaDesactivar_Click" />
                                    </div>
                                    <div class="col">
                                        <asp:Button runat="server" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id")%>' CommandName="IdPlato" Text="Cancelar" ID="btnCancelaDesactivar" OnClick="btnCancelaDesactivar_Click" />
                                    </div>

                                </div>
                                <%} %>


                                <div class="col-2 text-end">
                                    <asp:Button runat="server" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-warning mb-4" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
