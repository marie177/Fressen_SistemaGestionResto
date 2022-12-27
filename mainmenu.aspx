<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="mainmenu.aspx.cs" Inherits="TP_Cuatrimestral.mainmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-4">
        <div class="col-2"></div>
        <div class="col-8 " style="background-color:#92aedb !important;border-radius:50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color:#e2e1e5fc;">Menú Principal</h1>
                <%--<hr style="background-color:red">--%>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row">
        <div class="col-2 px-5 pt-5">
            <div class="row">
                <div class="col-1">
                    <div style="height: 15px; width: 15px; border-radius: 50%; background: green; margin: auto"></div>
                </div>
                <div class="col">
                    <p>Mesas libres: <%: contMesasLibres %></p>
                </div>
            </div>

            <div class="row">
                <div class="col-1">
                    <div style="height: 15px; width: 15px; border-radius: 50%; background: red; margin: auto"></div>
                </div>
                <div class="col">
                    <p>Mesas ocupadas: <%: contMesasOcupadas %></p>
                </div>
            </div>

            <div class="row">
            </div>
        </div>
        <div class="col-8">

            <div class="container pt-3">
                <div class="row">

                    <asp:Repeater ID="RepeaterMesas" runat="server">
                        <ItemTemplate>
                            <div class="col-4">
                                <div class="card text-white <%#: (bool)Eval("Ocupado") ? "bg-danger" : "bg-success"%> mb-3 text-center cardMesas">
                                    <div class="card-title" style="margin-top: 20px">Mesa #<%#: Eval("Numero") %></div>
                                    <div class="card-body" style="padding: 0">
                                        <%--<h5 class="card-title">Primary card title</h5>--%>
                                        <p class="card-text">Mesero: <%#: Eval("MeseroAsignado") %></p>
                                        <p class="card-text">Asientos: <%#: Eval("Capacidad") %></p>
                                        <asp:Button ID="btnVerDetallePedido" CommandName="IdMesa" CommandArgument='<%#: Eval("Numero") %>' CssClass="btn btn-secondary btn-rounded" runat="server" Text="Ver Pedidos" OnClick="btnVerDetallePedido_Click" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
