<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Cuatrimestral.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row justify-content-center caja">
        <div class="col ">
            <div class="row cajaLogin">
                <div class="col-6 imgLogin">
                    <div class="row">
                        <div class="col justify-content-center tituloLogin backgrLogin text-center">
                            <h2>Restaurant Fressen</h2>
                            <h4 style="font-size: 35px !important">Login</h4>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="container justify-content-center" style="width: 60%; padding-top: 50px; text-align: -webkit-center;">
                        <!-- Legajo -->
                        <div class="text-center" style="font-size: 150px; color: black">
                            <i class="fas fa-utensils"></i>
                            <div class="text-center">
                                <h4 class="h42">Ingrese su legajo y contraseña</h4>
                            </div>
                        </div>
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtLegajo" TextMode="Number" Font-Bold="true" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtLegajo">Legajo</label>
                        </div>

                        <!-- Password -->
                        <div class="form-outline mb-4">
                            <asp:TextBox TextMode="Password" ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                            <label class="form-label" for="txtPass">Contraseña</label>
                        </div>
                        
                        <%if ((bool)Session["errorLogin"])
                            { %>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="col">
                                        <div class="note note-danger mb-3">
                                            <strong>Error: </strong>
                                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                                <%} %>
                            
                        <asp:Button runat="server" ID="btnIngresar" CssClass="btn btn2" OnClick="btnIngresar_Click" Text="Ingresar" />

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
