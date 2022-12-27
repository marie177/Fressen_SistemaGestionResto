<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="TP_Cuatrimestral.Platos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row pt-4">
                <div class="col-2"></div>
                <div class="col-8 " style="background-color: #92aedb !important; border-radius: 50px">
                    <div class="title-page">
                        <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">Platos</h1>
                        <%--<hr style="background-color:red">--%>
                    </div>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row m-5">
                <div class="col mt-3">
                    <div class="row">
                        <div class="col">
                            <asp:Label runat="server" CssClass="fs-5 fw-bold text-dark" Text="Tipo"></asp:Label>
                        </div>
                    </div>

                    <div class="row me-5">
                        <div class="col">
                            <asp:DropDownList AutoPostBack="true" CssClass="btn btn-outline-dark bg-light dropwdown-toggle w-100" runat="server" ID="ddlTipoPLato" OnSelectedIndexChanged="ddlTipoPLato_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div class="col-8">
                    <div class="row  row-cols-1 row-cols-md-3 g-4">
                        <asp:Repeater runat="server" ID="repeaterPlatos">
                            <ItemTemplate>
                                <div class="col-4 mt-3">
                                    <div class="card h-100">
                                        <div class="card-body">
                                            <p class="card-text text-end">#<%# Eval("Id") %></p>
                                            <div class="row">
                                                <div class="col text-start">
                                                    <h5 class="card-title text-dark"><%#Eval("Tipo.Nombre") %></h5>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <h5 class="card-title fs-5 fw-normal"><%#Eval("Nombre") %></h5>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col text-start">
                                                    <h5 class="card-title fs-6 fw-normal">$ <%#Eval("Precio") %></h5>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer bg-danger p-2 text-dark bg-opacity-25 text-end">
                                            <asp:LinkButton ID="linkBtnDetalle" OnClick="linkBtnDetalle_Click" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="IdPLato" CssClass="color-black fs-6 fw-semibold  m-3" Text="Ver Detalle"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col">
                    <div class="row">
                        <div class="col text-center ">
                            <a href="EditPlato.aspx" class="w-100 btn btn-danger">Agregar Plato</a>
                        </div>

                    </div>
                    <div class="row mt-3">
                        <div class="col text-center ">
                            <a href="TiposPlato.aspx" class="w-100 btn btn-dark">Administrar Tipos</a>

                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
