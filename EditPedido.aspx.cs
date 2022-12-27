using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral
{
    public partial class EditPedido : System.Web.UI.Page
    {
        private PedidoNegocio negocio;
        private Pedido pedido;
        private DetallePedidoNegocio negocioDetalle;
        public TipoAlert tipoAlert;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new PedidoNegocio();
            negocioDetalle = new DetallePedidoNegocio();

            try
            {
                string idPedido = Request.QueryString["Id"] != null ? Request.QueryString["Id"] : "";

                if (!IsPostBack)
                {

                    if (Session["usuario"] == null)
                    {
                        Session.Add("error", "Debes logearte para acceder a esta area.");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        tipoAlert = TipoAlert.Default;
                        cargarDdlMesas();
                        cargarDdlEmpleados();
                        crearSessionDetallePedido();
                    }

                }

                if (!IsPostBack && !String.IsNullOrEmpty(idPedido))
                    PrecargarCampos(idPedido);
                else
                {
                    txtFechaPedido.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    divEntregarPedido.Visible = false;
                    divEliminarPedido.Visible = false;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void cargarDdlMesas()
        {
            MesaNegocio negocioMesa = new MesaNegocio();
            string idMesa = Request.QueryString["IdMesa"] != null ? Request.QueryString["IdMesa"] : "";

            ddlMesas.DataSource = negocioMesa.ListarMesas();
            ddlMesas.DataTextField = "Numero";
            ddlMesas.DataValueField = "ID";
            ddlMesas.DataBind();

            if (!String.IsNullOrEmpty(idMesa))
            {
                ddlMesas.SelectedIndex = ddlMesas.Items.IndexOf((ddlMesas.Items.FindByValue(idMesa)));
                ddlMesas.Enabled = false;
            }
            else
            {
                ddlMesas.SelectedIndex = 0;
            }

        }

        private void cargarDdlEmpleados()
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            string legajoMesero = Request.QueryString["LegajoMesero"] != null ? Request.QueryString["LegajoMesero"] : "";

            ddlMeseros.DataSource = negocioUsuario.listarUsuarios().Where(x => x.Perfil.Id == (int)Perfiles.Mesero);
            ddlMeseros.DataTextField = "Legajo";
            ddlMeseros.DataValueField = "Legajo";
            ddlMeseros.DataBind();

            if (!String.IsNullOrEmpty(legajoMesero))
            {
                ddlMeseros.SelectedIndex = ddlMeseros.Items.IndexOf((ddlMeseros.Items.FindByValue(legajoMesero)));
                ddlMeseros.Enabled = false;
            }
            else
            {
                MesaNegocio negocioMesa = new MesaNegocio();
                Usuario mesero = negocioMesa.ObtenerMesaPorNumero(ddlMesas.Items[0].Value).MeseroAsignado;

                ddlMeseros.SelectedIndex = ddlMeseros.Items.IndexOf((ddlMeseros.Items.FindByValue(mesero.Legajo.ToString())));
            }
            ddlMeseros.Enabled = false;

        }
        private void PrecargarCampos(string idPedido)
        {
            Pedido pedido = negocio.ListarPedidos(IdPedido: idPedido)[0];

            lblId.Text = pedido.ID.ToString();

            ddlMesas.SelectedIndex = ddlMesas.Items.IndexOf((ddlMesas.Items.FindByValue(pedido.Mesa.ID.ToString())));
            ddlMesas.Enabled = false;

            ddlMeseros.SelectedIndex = ddlMeseros.Items.IndexOf((ddlMeseros.Items.FindByValue(pedido.MeseroAsignado.Legajo.ToString())));
            ddlMeseros.Enabled = false;

            cargarDgvDetallePedido(idPedido);

            txtFechaPedido.Text = pedido.FechaPedido.ToString("yyyy-MM-dd");
            txtPrecio.Text = pedido.Total.ToString();

            if (pedido.Entregado)
            {
                btnAgregarBebida.Visible = false;
                btnAgregarPlato.Visible = false;
                divEntregarPedido.Visible = false;
                divEliminarPedido.Visible = false;
            }
            divAgregarPedido.Visible = false;


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();

            pedido.Mesa = new Mesa();
            pedido.Mesa.ID = Convert.ToInt32(ddlMesas.SelectedItem.Value);
            pedido.MeseroAsignado = new Usuario();
            pedido.MeseroAsignado.Legajo = Convert.ToInt32(ddlMeseros.SelectedItem.Value);

            List<DetallePedido> detallePedidoList = ((Pedido)Session["Pedido"]).ListDetallePedido;

            try
            {
                if (!(detallePedidoList.Count() > 0))
                {
                    mostrarAlert("El Pedido no ha podido realizarse, no contiene Insumos cargados!");
                    return;
                }

                int IdPedido = negocio.AgregarPedido(pedido);
                lblId.Text = IdPedido.ToString();

                decimal total = negocioDetalle.AgregarDetallesPedido(IdPedido, detallePedidoList);

                negocio.ActualizarTotalPedido(IdPedido, total);
                txtPrecioTotalInsumos.Text = total.ToString();

                divAgregarPedido.Visible = false;
                mostrarElementosPedidoPendiente();
            }
            catch (Exception ex)
            {
                mostrarAlert(ex.ToString());
            }
        }

        private void cargarDgvDetallePedido(string IdPedido = "")
        {
            if (!string.IsNullOrEmpty(IdPedido))
            {
                repeaterDetallePedido.DataSource = null;
                repeaterDetallePedido.DataSource = negocioDetalle.ListarDetallePedido(IdPedido);
                repeaterDetallePedido.DataBind();
            }
            else
            {
                List<DetallePedido> detallePedidoList = ((Pedido)Session["Pedido"]).ListDetallePedido;
                repeaterDetallePedido.DataSource = null;
                repeaterDetallePedido.DataSource = detallePedidoList;
                repeaterDetallePedido.DataBind();
            }

        }

        private void crearSessionDetallePedido()
        {
            pedido = new Pedido();
            if (Session["Pedido"] == null)
            {
                Session.Add("Pedido", pedido);
            }
            else
            {
                Session["Pedido"] = pedido;
            }

        }
        protected void btnAgregarBebida_Click(object sender, EventArgs e)
        {
            rowAgregarInsumo.Visible = true;
            BebidaNegocio neogocioBebida = new BebidaNegocio();
            List<Bebida> listaBebidas = neogocioBebida.ListarBebidas();

            ddlDetalleInsumo.DataSource = listaBebidas;
            ddlDetalleInsumo.DataTextField = "Detalle";
            ddlDetalleInsumo.DataValueField = "Id";
            ddlDetalleInsumo.DataBind();

            txtPrecioUnitario.Text = listaBebidas[0].Precio.ToString();
            txtPrecioTotalInsumos.Text = listaBebidas[0].Precio.ToString();
            txtCantidad.Text = "1";

            if (lblId.Text != "")
            {
                mostrarElementosPedidoPendiente();
            }
        }

        protected void btnAgregarPlato_Click(object sender, EventArgs e)
        {
            rowAgregarInsumo.Visible = true;
            PlatoNegocio neogocioPlato = new PlatoNegocio();
            List<Plato> listaPlatos = neogocioPlato.ListarPlatos();

            ddlDetalleInsumo.DataSource = listaPlatos;
            ddlDetalleInsumo.DataTextField = "Detalle";
            ddlDetalleInsumo.DataValueField = "Id";
            ddlDetalleInsumo.DataBind();

            txtPrecioUnitario.Text = listaPlatos[0].Precio.ToString();
            txtPrecioTotalInsumos.Text = listaPlatos[0].Precio.ToString();
            txtCantidad.Text = "1";


            if (lblId.Text != "")
            {
                mostrarElementosPedidoPendiente();
            }
        }

        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            rowAgregarInsumo.Visible = false;
            LimpiarCampos();

            if (lblId.Text != "")
                mostrarElementosPedidoPendiente();
        }

        private void LimpiarCampos()
        {
            txtPrecioUnitario.Text = "";
            txtPrecioTotalInsumos.Text = "";
            txtCantidad.Text = "";
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precio = Convert.ToDecimal(txtPrecioUnitario.Text);
            txtPrecioTotalInsumos.Text = (cantidad * precio).ToString();

            if (lblId.Text != "")
                mostrarElementosPedidoPendiente();
        }

        protected void ddlDetalleInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsumoNegocio negocioInsumo = new InsumoNegocio();
            int idSelected = (Convert.ToInt32(ddlDetalleInsumo.SelectedItem.Value));

            Insumo selected = negocioInsumo.ObtenerInsumoPorId(idSelected);
            txtPrecioUnitario.Text = selected.Precio.ToString();
            txtPrecioTotalInsumos.Text = selected.Precio.ToString();
            txtCantidad.Text = "1";

            if (lblId.Text != "")
                mostrarElementosPedidoPendiente();

        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            int idSelected = (Convert.ToInt32(ddlDetalleInsumo.SelectedItem.Value));
            string nombreSelected = (ddlDetalleInsumo.SelectedItem.Text);

            //si el pedido no existe, agrega los detalles en la Session
            if (lblId.Text == "")
            {
                agregarDetalleEnSession(idSelected, nombreSelected);
            }
            //si no, hace el insert directo en DB
            else
            {
                agregarDetalleEnDB(idSelected);
                mostrarElementosPedidoPendiente();
            }

            rowAgregarInsumo.Visible = false;
            LimpiarCampos();


        }

        private void agregarDetalleEnSession(int idSelected, string nombreSelected = "")
        {
            List<DetallePedido> detallePedidoList = ((Pedido)Session["Pedido"]).ListDetallePedido;

            if (!detallePedidoList.Any(x => x.Insumo.Id == idSelected))
            {
                DetallePedido detalle = new DetallePedido();
                detalle.Insumo = new Insumo();
                detalle.Insumo.Id = idSelected;
                detalle.Insumo.Nombre = nombreSelected;
                detalle.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                detalle.Cantidad = (Convert.ToInt32(txtCantidad.Text));

                detallePedidoList.Add(detalle);
                actualizarTextTotalPedido(detalle.Cantidad, detalle.PrecioUnitario, true);
            }
            else
            {
                //si existe, busca el detalle en la lista e incrementa la cantidad
                detallePedidoList.Where(x => x.Insumo.Id == idSelected).First().Cantidad += Convert.ToInt32(txtCantidad.Text);
                actualizarTextTotalPedido(Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtPrecioUnitario.Text), true);
            }

            cargarDgvDetallePedido();
        }

        private void agregarDetalleEnDB(int idSelected)
        {
            List<DetallePedido> detallePedidoList = negocioDetalle.ListarDetallePedido(lblId.Text);

            DetallePedido detalle = new DetallePedido();
            detalle.Insumo = new Insumo();

            if (!detallePedidoList.Any(x => x.Insumo.Id == idSelected))
            {
                detalle.Insumo.Id = idSelected;
                detalle.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                detalle.Cantidad = (Convert.ToInt32(txtCantidad.Text));

                negocioDetalle.AgregarDetallePedido(Convert.ToInt32(lblId.Text), detalle);

                actualizarTextTotalPedido(detalle.Cantidad, detalle.PrecioUnitario, true);
                negocio.ActualizarTotalPedido(Convert.ToInt32(lblId.Text), Convert.ToDecimal(txtPrecio.Text));
            }
            else
            {
                detalle = detallePedidoList.Find(x => x.Insumo.Id == idSelected);
                detalle.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                detalle.Cantidad += (Convert.ToInt32(txtCantidad.Text));

                negocioDetalle.ActualizarDetallePedido(Convert.ToInt32(lblId.Text), detalle);

                actualizarTextTotalPedido((Convert.ToInt32(txtCantidad.Text)), detalle.PrecioUnitario, true);
                negocio.ActualizarTotalPedido(Convert.ToInt32(lblId.Text), Convert.ToDecimal(txtPrecio.Text));

            }

            cargarDgvDetallePedido(lblId.Text);

        }


        protected void btnEntregarPedido_Click(object sender, EventArgs e)
        {
            var idPedido = Convert.ToInt32(lblId.Text);

            mostrarElementosPedidoPendiente();

            mostrarAlert($"Confirma entregar el Pedido #{idPedido}?", "Confirmar", tipoAlert: (int)TipoAlert.ConfirmaEntregarPedido);
        }

        protected void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            int idDetalleSelected = Convert.ToInt32(((Button)sender).CommandArgument);
            DetallePedido detalleDeleted;
            //aaca logica

            if (lblId.Text != "")
            {
                detalleDeleted = negocioDetalle.ListarDetallePedido(lblId.Text).Find(x => x.Insumo.Id == idDetalleSelected);
                negocioDetalle.EliminarDetallePedido(detalleDeleted.Id);
                cargarDgvDetallePedido(lblId.Text);

                actualizarTextTotalPedido(detalleDeleted.Cantidad, detalleDeleted.PrecioUnitario, false);
                negocio.ActualizarTotalPedido(Convert.ToInt32(lblId.Text), Convert.ToDecimal(txtPrecio.Text));
                mostrarElementosPedidoPendiente();
            }
            else
            {
                List<DetallePedido> detallePedidoList = ((Pedido)Session["Pedido"]).ListDetallePedido;
                detalleDeleted = detallePedidoList.Where(x => x.Insumo.Id == idDetalleSelected).FirstOrDefault();
                detallePedidoList.Remove(detalleDeleted);
                actualizarTextTotalPedido(detalleDeleted.Cantidad, detalleDeleted.PrecioUnitario, false);
                cargarDgvDetallePedido();
            }
        }

        private void actualizarTextTotalPedido(int cantidad, decimal precioUnitario, bool suma)
        {
            decimal total = Convert.ToDecimal(txtPrecio.Text);
            decimal totalDetalle = cantidad * precioUnitario;

            if (suma)
                total += totalDetalle;
            else
                total -= totalDetalle;

            txtPrecio.Text = total.ToString();
        }

        protected void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            var idPedido = Convert.ToInt32(lblId.Text);

            mostrarElementosPedidoPendiente();

            mostrarAlert($"Confirma eliminar el Pedido #{idPedido}?", "Confirmar", tipoAlert: (int)TipoAlert.ConfirmaEliminarPedido);
        }

        protected void ddlMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeroMesa = ddlMesas.SelectedValue;

            MesaNegocio negocioMesa = new MesaNegocio();
            Mesa mesa = negocioMesa.ObtenerMesaPorNumero(numeroMesa);

            ddlMeseros.SelectedIndex = ddlMesas.Items.IndexOf((ddlMesas.Items.FindByValue(mesa.MeseroAsignado.Legajo.ToString())));
        }

        protected void btnAceptarAlert_Click(object sender, EventArgs e)
        {
            int alert = Convert.ToInt32(((Button)sender).CommandArgument);
            int idPedido = Convert.ToInt32(lblId.Text != "" ? lblId.Text : "0");

            switch (alert)
            {
                case (int)TipoAlert.ConfirmaEliminarPedido:
                    negocio.EliminarPedido(idPedido);
                    Response.Redirect("Pedidos.aspx", false);
                    break;
                case (int)TipoAlert.ConfirmaEliminarDetallePedido:

                    break;

                case (int)TipoAlert.ConfirmaEntregarPedido:
                    negocio.CambiarEstadoPedido(idPedido, true);
                    ocultarElementosPedidoEntregado();
                    break;
                default:
                    break;
            }
            divAlert.Visible = false;
        }

        private void mostrarAlert(string message = "", string btnAceptarText = "Aceptar", string btnCancelarText = "Cancelar", int tipoAlert = 0)
        {
            btnAceptarAlert.CommandArgument = tipoAlert.ToString();
            btnAceptarAlert.Text = btnAceptarText;

            btnCancelarAlert.CommandArgument = tipoAlert.ToString();
            btnCancelarAlert.Text = btnCancelarText;

            lblMessageError.Text = message;
            divAlert.Visible = true;
        }

        protected void btnCancelarAlert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
            int alert = Convert.ToInt32(((Button)sender).CommandArgument);

            switch (alert)
            {
                case (int)TipoAlert.ConfirmaEliminarPedido:
                    mostrarElementosPedidoPendiente();
                    break;
                case (int)TipoAlert.ConfirmaEliminarDetallePedido:
                    break;
                case (int)TipoAlert.ConfirmaEntregarPedido:
                    mostrarElementosPedidoPendiente();
                    break;
                default:
                    break;
            }

            divAlert.Visible = false;

        }

        private void mostrarElementosPedidoPendiente()
        {
            btnAgregarBebida.Visible = true;
            btnAgregarPlato.Visible = true;
            divEntregarPedido.Visible = true;
            divEliminarPedido.Visible = true;
        }

        private void ocultarElementosPedidoEntregado()
        {
            btnAgregarBebida.Visible = false;
            btnAgregarPlato.Visible = false;
            divEntregarPedido.Visible = false;
            divEliminarPedido.Visible = false;
        }
    }
}