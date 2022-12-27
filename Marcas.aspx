<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TP_Cuatrimestral.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-4">
        <div class="col-2"></div>
        <div class="col-8 " style="background-color:#92aedb !important;border-radius:50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color:#e2e1e5fc;">Marcas</h1>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row m-5">
        <div class="col p-5">
            <div class="row m-3 justify-content-center">
                <div class="col-4">
                    <asp:TextBox runat="server" CssClass="w100 form-control" ID="txtFiltroNombre" AutoPostBack="true" OnTextChanged="txtFiltroNombre_TextChanged"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Button runat="server" ID="btnLimpiarFiltro" OnClick="btnLimpiarFiltro_Click" Text="Limpiar Filtro" CssClass="btn btn-info"/>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-6">
                    <div class="row headerTitleMarcas">
                        <div class="col-4">
                            <asp:Label runat="server" Text="Nombre"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:Label runat="server" Text="Activo"></asp:Label>
                        </div>
                        <div class="col-6">
                        </div>
                    </div>
                    <asp:Repeater runat="server" ID="repeaterMarcas">
                        <ItemTemplate>
                            <div class="row itemMarcas">
                                <div class="col m-auto w-100">
                                    <asp:label runat="server" ID="txtMarca" Text='<%#Eval("Nombre")%>' CssClass="text-dark" Enabled="false"></asp:label>
                                </div>
                                <div class="col m-auto">
                                    <asp:CheckBox runat="server" ID="cbxMarca" Enabled="false" Checked='<%#Eval("Activo") %>' />
                                </div>
                                <div class="col m-auto">
                                      <asp:Button runat="server" CssClass="btn btn-success m-1" CommandArgument='<%#Eval("Id")%>' CommandName="idMarca" ID="btnModificar" OnClick="btnModificar_Click" Text="Modificar"/>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="row justify-content-center m-3">

                <div class="col-6 text-end">
                    <div class="row justify-content-end pe-5">
                        <div class="col-2">
                            <asp:Label runat="server" ID="lblNuevaMarca" CssClass="fs-5 fw-normal text-dark" Text="Nombre"></asp:Label>
                        </div>
                        <div class="col-4">
                            <asp:TextBox runat="server" ID="txtNuevaMarcaNombre" CssClass="w100 form-control"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-success " OnClick="btnAceptar_Click" Text="Aceptar" />
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary " OnClick="btnAgregar_Click" Text="Agregar Marca" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
