<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Meseros.aspx.cs" Inherits="TP_Cuatrimestral.Meseros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-4">
        <div class="col-2"></div>
        <div class="col-8 " style="background-color: #92aedb !important; border-radius: 50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">Meseros</h1>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row m-5">
        <div class="pb-4">
        </div>
        <div class="col mt-3">
            <div class="row">
                <a class="btn btn-success" role="button" href="AddMesero.aspx">Agregar mesero</a>
            </div>
            <div class="row me-5">
            </div>

        </div>
        <div class="col-10">
            <div class="row  row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater runat="server" ID="repeaterMeseros">
                    <ItemTemplate>
                        <div class="card cardEdit" style="width: 18rem; margin-left: auto; margin-bottom: 3px">
                            <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="ImgEmpleado" />
                            <div class="card-body pb-0">
                                <h5 class="card-title">Legajo: #<%# Eval("Legajo") %></h5>
                                <p class="card-text"><%# Eval("Apellido") %>, <%# Eval("Nombre") %></p>
                            </div>
                            <ul class="list-group list-group-light list-group-small">
                                <li class="list-group-item px-4">Dni: <%# Eval("Dni") %></li>
                                <li class="list-group-item px-4">Ingreso: <%# Eval("FechaRegistro") %></li>
                            </ul>
                            <div class="card-body" style="text-align: center">
                                <asp:LinkButton ID="btnDetalle" OnClick="btnDetalle_Click" runat="server" CommandArgument='<%#Eval("Legajo") %>' CommandName="Legajo" CssClass="btn btn-outline-info" Text="+ Info"></asp:LinkButton>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
