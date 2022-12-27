<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TP_Cuatrimestral.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="row pt-4">
                <div class="col-2">
                </div>
                <div class="col-8 " style="background-color: #92aedb !important; border-radius: 50px">
                    <div class="title-page">
                        <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">Mesas</h1>
                    </div>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="container pt-3">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <a class="btn btn-success" role="button" href="AddMesa.aspx">Agregar mesa</a>
                        </div>
                    </div>
                    <div class="col">
                        <asp:GridView runat="server" CssClass="table table-primary align-middle mb-0"  OnSelectedIndexChanged="dgvMesas_SelectedIndexChanged" DataKeyNames="Numero" ID="dgvMesas" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Nro. Mesa" HeaderStyle-CssClass="headerTitle" DataField="Numero" />
                                <asp:BoundField HeaderText="Legajo" HeaderStyle-CssClass="headerTitle" DataField="MeseroAsignado.Legajo" />
                                <asp:BoundField HeaderText="Apellido y Nombre" HeaderStyle-CssClass="headerTitle" DataField="MeseroAsignado" />
                                <asp:BoundField HeaderText="Número de Asientos" HeaderStyle-CssClass="headerTitle" DataField="Capacidad" />
                                <asp:CheckBoxField HeaderText="Ocupada" HeaderStyle-CssClass="headerTitle" DataField="Ocupado" />
                                <asp:CheckBoxField HeaderText="Activa" HeaderStyle-CssClass="headerTitle" DataField="Activo" />
                                <asp:CommandField HeaderText="Editar" HeaderStyle-CssClass="headerTitle" ShowSelectButton="true" SelectText="✍" />
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div class="col"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
