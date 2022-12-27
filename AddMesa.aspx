<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddMesa.aspx.cs" Inherits="TP_Cuatrimestral.AddMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row pt-4 mb-4">
        <div class="col-3"></div>
        <div class="col-6 " style="background-color: #92aedb !important; border-radius: 50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">
                    <asp:Label ID="titulo" runat="server" Text="Editar mesa / Asignar mesero"></asp:Label>
                </h1>
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="boxForm">

                <div class="row mb-4">
                    <!-- txtNumeroMesa -->
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:TextBox ID="txtNumeroMesa" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtNumeroMesa">Numero de Mesa</label>
                        </div>
                    </div>
                    <!-- Dropdown Meseros -->
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:Label runat="server" Style="color: white" CssClass="h6" Text="Mesero a asignar: "></asp:Label>
                            <asp:DropDownList ID="ddlMeseros" CssClass="btn btn-info dropdown-toggle" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <!-- Chk Reserva -->
                <div class="row mb-4">
                    <!-- Chk Ocupado -->
                    <div class="col">
                        <div class="form-check">
                            <asp:CheckBox ID="chkOcupada" CssClass="form-check-input" OnCheckedChanged="chkOcupada_CheckedChanged" AutoPostBack="true" runat="server" />
                            <label class="form-check-label" for="chkOcupada">Esta ocupada?</label>
                        </div>
                    </div>
                    <%-- Capacidad --%>
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:TextBox ID="txtCapacidad" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtCapacidad">Numero de Asientos</label>
                        </div>
                    </div>
                </div>
                <hr style="margin-top: -15px;" />
                <div class="row">
                    <div class="col">
                        <%-- Telefono --%>
                    </div>
                    <div class="col">
                        <%-- Email --%>
                        
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <%-- Calle --%>
                        
                    </div>
                    <div class="col">
                        <%-- Numero --%>
                        
                    </div>
                    <div class="col">
                        <%-- Numero --%>
                        
                    </div>
                    <div class="col">
                        <%-- Calle --%>
                        
                    </div>
                    <div class="col">
                        
                    </div>


                </div>
                <!-- Ruta Imagen con update panel -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!-- Boton Agregar -->
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnEditarMesa" CssClass="btn btn-primary mb-4" OnClick="btnEditarMesa_Click" runat="server" Text="Guardar" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnEliminarMesa" CssClass="btn btn-danger mb-4" runat="server" Text="Eliminar" />
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <%if (confirm)
                                { %>

                            <div class="col">
                                <asp:Label ID="lblConfirm" runat="server" CssClass="lead" Text="Desea eliminar?"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:Button ID="btnConfirmar" CssClass="btn btn-danger mb-4" runat="server" Text="Sí" />
                            </div>

                            <%} %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="col-3"></div>
</asp:Content>
