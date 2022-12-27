<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddMesero.aspx.cs" Inherits="TP_Cuatrimestral.AddMesero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row pt-4 mb-4">
        <div class="col-2"></div>
        <div class="col-8 " style="background-color: #92aedb !important; border-radius: 50px">
            <div class="title-page">
                <h1 class="mt-4 mb-4" style="color: #e2e1e5fc;">
                    <asp:Label ID="titulo" runat="server" Text="Nuevo Mesero"></asp:Label></h1>
            </div>
        </div>
        <div class="col-2"></div>
    </div>


    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="boxForm">

                <div class="row mb-4">
                    <!-- Apellido -->
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtApellido">Apellido</label>
                        </div>
                    </div>
                    <!-- Nombre -->
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtNombre">Nombre</label>
                        </div>
                    </div>
                </div>

                <!-- Contraseña -->
                <div class="row mb-4">
                    <div class="col">
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtPassword">Contraseña</label>
                        </div>
                    </div>
                    <!-- DNI -->
                    <div class="col">
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox TextMode="Number" CssClass="form-control" ID="txtDni" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtDni">DNI</label>
                        </div>
                    </div>
                    <%-- Fecha Nac --%>
                    <div class="col">
                        <div class="form-outline form-white">
                            <asp:TextBox TextMode="Date" ID="txtFechaNac" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtNombre">Fecha Nacimiento</label>
                        </div>

                        <%-- Input con Formato viejo --%>

                        <%--<div class="row">
                            <div class="col">
                                <div class="form-outline form-white mb">
                                    <input type="text" id="txtDia" class="form-control" />
                                    <label class="form-label" for="txtDia">Dia</label>
                                </div>
                            </div>
                            <div class="col">
                                <div class="form-outline form-white mb">
                                    <input type="text" id="txtMes" class="form-control" />
                                    <label class="form-label" for="txtMes">Mes</label>
                                </div>
                            </div>
                            <div class="col">
                                <div class="form-outline form-white mb">
                                    <input type="text" id="txtAnio" class="form-control" />
                                    <label class="form-label" for="txtAnio">Año</label>

                                </div>
                            </div>
                            <div id="textExample1" class="form-text" style="color: #ffffff !important">
                                Fecha de Nacimiento
                            </div>
                        </div>--%>
                    </div>
                </div>
                <hr style="margin-top: -15px;" />
                <div class="row">
                    <div class="col">
                        <%-- Telefono --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox TextMode="Number" ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtTelefono">Telefono o Celular</label>
                        </div>
                    </div>
                    <div class="col">
                        <%-- Email --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox TextMode="Email" ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtEmail">Email</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <%-- Calle --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox ID="txtCalle" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtCalle">Calle</label>
                        </div>
                    </div>
                    <div class="col">
                        <%-- Numero --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox TextMode="Number" ID="txtNumero" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtNumero">Número</label>
                        </div>
                    </div>
                    <div class="col">
                        <%-- Numero --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox TextMode="Number" ID="txtPiso" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtPiso">Piso</label>
                        </div>
                    </div>
                    <div class="col">
                        <%-- Calle --%>
                        <div class="form-outline form-white mb-4">
                            <asp:TextBox ID="txtDpto" class="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtDpto">Dpto</label>
                        </div>
                    </div>
                    <div class="col">
                        <div class="row">
                            <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle dropdown-toggle2" Style="width: 95%" ID="ddlPaises" runat="server"></asp:DropDownList>
                        </div>
                    </div>


                </div>
                <!-- Ruta Imagen con update panel -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row mb-4">
                            <div class="col" style="align-self: center">
                                <div class="form-outline form-white">
                                    <asp:TextBox TextMode="Url" CssClass="form-control" ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                    <label class="form-label" for="txtUrlImagen">Ruta Imagen</label>
                                </div>
                            </div>
                            <div class="col" style="text-align: center;">
                                <asp:Image ID="imgPerfil" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!-- Boton Agregar -->
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnAgregarMesero" CssClass="btn btn-primary mb-4" OnClick="btnAgregarMesero_Click" runat="server" Text="Agregar" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger mb-4" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <%if (confirm)
                                { %>

                            <div class="col">
                                <asp:Label ID="lblConfirm" runat="server" CssClass="lead" Text="Desea eliminar?"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:Button ID="btnConfirmar" CssClass="btn btn-danger mb-4" OnClick="btnConfirmar_Click" runat="server" Text="Sí" />
                            </div>

                            <%} %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
