<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="TP_Cuatrimestral.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scrpManager"></asp:ScriptManager>
    <div class="row pt-4">
        <div class="col-2"></div>
        <div class="col-8 " style="background-color: #92aedb !important; border-radius: 50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">Pedidos</h1>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <div class="row m-1 mt-3">
                <div class="col">
                    <div class="row">
                        <div class="col-2">
                            <div class="row mb-2">
                                <div class="col">
                                    <asp:Label runat="server" CssClass="text-dark fw-bold" Text="Filtrar Pedidos por:"></asp:Label>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <label class="form-label text-dark" for="lblFiltroEstado">Estado</label>
                                <div class="btn-group-vertical w-200px" role="group" aria-label=" Basic radio toggle button group">

                                    <asp:Button CssClass="w-200px btn btn-outline-success bg-light p-2" OnClick="btnTodosLosEstados_Click" Text="Todos los Pedidos" runat="server" ID="btnTodosLosEstados"></asp:Button>

                                    <asp:Button CssClass="w-200px btn btn-outline-primary bg-light p-2" OnClick="btnEstadoEntregados_Click" Text="Pedidos Entregados" runat="server" ID="btnEstadoEntregados"></asp:Button>

                                    <asp:Button CssClass="w-200px btn btn-outline-danger bg-light p-2" OnClick="btnEstadoPendiente_Click" Text="Pedidos Pendientes" runat="server" ID="btnEstadoPendiente"></asp:Button>

                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class=" form-dark w-200px ms-2">
                                    <label class="form-label text-dark" for="lblFiltroFecha">Fecha Pedido Desde</label>
                                    <asp:TextBox TextMode="Date" ID="txtFechaPedidoDesde" OnTextChanged="txtFechaPedido_TextChanged" AutoPostBack="true" CssClass="form-control text-dark " runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class=" form-dark w-200px ms-2">
                                    <label class="form-label text-dark" for="lblFiltroFecha">Fecha Pedido Hasta</label>
                                    <asp:TextBox TextMode="Date" ID="txtFechaPedidoHasta" OnTextChanged="txtFechaPedidoHasta_TextChanged" AutoPostBack="true" CssClass="form-control text-dark " runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-8">
                            <div class="row headerTitleMarcas">
                                <div class="col-2">
                                    <asp:Label runat="server" Text="Pedido N°"></asp:Label>
                                </div>
                                <div class="col-2">
                                    <asp:Label runat="server" Text="Total"></asp:Label>
                                </div>
                                <div class="col-1">
                                    <asp:Label runat="server" Text="Mesa N°"></asp:Label>
                                </div>
                                <div class="col-1">
                                    <asp:Label runat="server" Text="Estado"></asp:Label>
                                </div>
                                <div class="col-2">
                                      <asp:Label runat="server" Text="Fecha"></asp:Label>
                                </div>
                                <div class="col-4">
                                </div>
                            </div>
                            <asp:Repeater runat="server" ID="repeaterPedidos">
                                <ItemTemplate>
                                    <div class="row item-listaPedidos <%# (bool)Eval("Entregado") ? "bg-alice-blue" : "bg-warning-light"%>">
                                        <div class="col-2 ">
                                            <asp:Label runat="server" ID="txtIdPedido" Text='<%#Eval("ID")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                        </div>

                                        <div class="col-2">
                                            <asp:Label runat="server" ID="lblTotal" Text='<%#Eval("Total")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                        </div>

                                        <div class="col-1 ">
                                            <asp:Label runat="server" ID="lblNumeroMesa" Text='<%# Eval("Mesa.Numero") %>'></asp:Label>
                                        </div>

                                        <div class="col-1">
                                            <asp:Label runat="server" ID="lblEntregado" Text='<%# (bool)Eval("Entregado") ? "Entregado" : "Pendiente"%>'></asp:Label>
                                        </div>

                                        <div class="col-2">
                                            <asp:Label Text='<%# ((DateTime)Eval("FechaPedido")).ToString("dd/MM/yyyy") %>' runat="server" ID="lblFecha" />
                                        </div>

                                        <div class="col-2 m-auto">
                                            <asp:Button runat="server" CssClass="btn btn-warning m-1" CommandArgument='<%#Eval("ID")%>' CommandName="idPedido" ID="btnVerPedido" OnClick="btnVerPedido_Click" Text="Ver Pedido" />
                                        </div>

                                        <div class="col-2 m-auto">
                                            <asp:Button runat="server" CssClass="btn btn-primary m-1" CommandArgument='<%#Eval("ID")%>' Visible='<%# !(bool)Eval("Entregado")%>' CommandName="idPedido" ID="btnEntregado" OnClick="btnEntregado_Click" Text="Entregar" />
                                        </div>


                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="col-2">
                            <asp:Button runat="server" Text="Agregar Pedido" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="w-200px btn btn-success mb-4" />
                        </div>
                    </div>


                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
