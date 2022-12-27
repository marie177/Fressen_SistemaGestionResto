<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TP_Cuatrimestral.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <div class="container mt-5 mb-5">
                <div class="row m-2">
                    <div class="col" style="background-color: #92aedb !important; border-radius: 50px">
                        <div class="title-page">
                            <h1 class="mt-2 mb-2" style="color: #e2e1e5fc;">Reportes</h1>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-6 text-center headerTitleReporteMeserosFirst">
                        <asp:Label runat="server" ID="lblTotalRecaudadoTitle" Text=' Total recaudado en el Dia' CssClass="text-light" Enabled="false"></asp:Label>
                    </div>
                    <div class="col-6 text-center headerTitleReporteMeserosFirst">
                        <asp:Label runat="server" ID="lblFechaTitle" Text=' Fecha' CssClass="text-light" Enabled="false"></asp:Label>
                    </div>
                </div>
                <div class="row mb-2  item-listaPedidos bg-light">
                    <div class="col-6 text-center">
                        <asp:Label runat="server" ID="lblTotalRecaudado" Text='$ ' CssClass="text-dark" Enabled="false"></asp:Label>

                    </div>
                    <div class="col-6 text-center">
                        <asp:TextBox runat="server" AutoPostBack="true" CssClass="form-label br-6 w-100 btn-outline-dark bg-light mt-1" OnTextChanged="txtFechaReportes_TextChanged" ID="txtFechaReportes" Text="" TextMode="Date"></asp:TextBox>

                    </div>
                </div>

                <div class="row">
                    <div class="col-12 p-0">
                        <div class="row headerTitleReporteMeserosFirst mx-1">
                            <div class="col text-center">
                                <asp:Label runat="server" ID="lblPedidosMeseroTitle" Text='Pedidos Por Mesero' CssClass="text-light fs-4" Enabled="false"></asp:Label>
                            </div>
                        </div>

                        <div class="row headerTitleReporteMeseros mx-1">
                            <div class="col-1">
                                Legajo
                            </div>
                            <div class="col-3">
                                Mesero
                            </div>

                            <div class="col-3">
                                Total Pedidos
                            </div>

                            <div class="col-3">
                                Total Recaudado
                            </div>
                            <div class="col-2">
                                Dia
                            </div>
                        </div>

                        <%--  aca repeater--%>

                        <div class="divScroll item-listaPedidos bg-light mx-1">
                            <asp:Repeater runat="server" ID="repeaterReporteMeseros">
                                <ItemTemplate>
                                    <div class="row item-listaPedidos bg-light">
                                        <div class="col-1 ">
                                            <asp:Label runat="server" ID="lblLegajo" Text='<%#Eval("Legajo")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                        </div>

                                        <div class="col-3 ">
                                            <asp:Label runat="server" ID="lblMesero" Text='<%#Eval("Mesero")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                        </div>

                                        <div class="col-3 ">
                                            <asp:Label runat="server" ID="lblTotalPedidos" Text='<%# Eval("TotalPedidos") %>'></asp:Label>
                                        </div>

                                        <div class="col-3">
                                            <asp:Label runat="server" ID="lblTotalRecaudado" Text='<%#Eval("TotalRecaudado")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                        </div>

                                        <div class="col-2">
                                            <asp:Label Text='<%# ((DateTime)Eval("FechaPedidos")).ToString("dd/MM/yyyy") %>' runat="server" ID="lblFechaPedidos" />
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>


                    <div class="col-12 mt-5">
                        <div class="row headerTitleReporteMesasFirst mx-1">
                            <div class="col text-center">
                                <asp:Label runat="server" ID="lblReporteMesasTitle" Text='Pedidos Por Mesa' CssClass="text-light fs-4" Enabled="false"></asp:Label>
                            </div>
                        </div>

                        <div class="row headerTitleReporteMesas mx-1">
                            <div class="col-3">
                                Mesa Numero
                            </div>

                            <div class="col-3">
                                Total Pedidos
                            </div>

                            <div class="col-3">
                                Total Recaudado
                            </div>
                            <div class="col-2">
                                Dia
                            </div>
                        </div>


                        <div class="divScroll item-listaPedidos bg-light mx-1">
                             <asp:Repeater runat="server" ID="repeaterReporteMesas">
                            <ItemTemplate>
                                <div class="row item-listaPedidos bg-light">
                                    <div class="col-3 ">
                                        <asp:Label runat="server" ID="lblMesero" Text='<%#Eval("Numero")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                    </div>

                                    <div class="col-3 ">
                                        <asp:Label runat="server" ID="lblTotalPedidos" Text='<%# Eval("TotalPedidos") %>'></asp:Label>
                                    </div>

                                    <div class="col-3">
                                        <asp:Label runat="server" ID="lblTotalRecaudado" Text='<%#Eval("TotalRecaudado")%>' CssClass="text-dark" Enabled="false"></asp:Label>
                                    </div>

                                    <div class="col-2">
                                        <asp:Label Text='<%# ((DateTime)Eval("FechaPedidos")).ToString("dd/MM/yyyy") %>' runat="server" ID="lblFechaPedidos" />
                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
