using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TP_Cuatrimestral
{
    public partial class EditBebida : System.Web.UI.Page
    {
        private MarcaNegocio marcaNegocio;
        private BebidaNegocio bebidaNegocio;
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            marcaNegocio = new MarcaNegocio();
            bebidaNegocio = new BebidaNegocio();

            try
            {
                btnEliminar.Visible = false;
                if (!IsPostBack)
                {
                    List<Marca> marcas = marcaNegocio.ListarMarcas();
                    ddlMarcas.DataSource = marcas;
                    ddlMarcas.DataTextField = "Nombre";
                    ddlMarcas.DataValueField = "Id";
                    ddlMarcas.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                if (!string.IsNullOrEmpty(id) && !IsPostBack)
                {
                    Bebida bebida = new Bebida();
                    bebida = bebidaNegocio.ListarBebidas(id)[0];
                    precargarCamposBebida(bebida);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }

        private void precargarCamposBebida(Bebida bebida)
        {
            lblId.Text = bebida.Id.ToString();

            txtNombre.Text = bebida.Nombre;
            txtPrecio.Text = bebida.Precio.ToString();
            txtCapacidad.Text = bebida.Capacidad.ToString();

            ddlMarcas.SelectedIndex = ddlMarcas.Items.IndexOf((ddlMarcas.Items.FindByValue(bebida.Marca.Id.ToString())));

            ckxAlcoholica.Checked = bebida.Alcoholica;

            btnAgregar.Text = "GUARDAR";
            btnEliminar.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Bebida bebida = new Bebida();

                cargarBebida(bebida);

                if (bebida.Id > 0)
                {
                    bebidaNegocio.ModificarBebida(bebida);
                }
                else
                {
                    bebidaNegocio.AgregarBebida(bebida);
                }

                Response.Redirect("Bebidas.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cargarBebida(Bebida bebida)
        {
            bebida.Id = lblId.Text != "" ? int.Parse(lblId.Text) : 0;
            bebida.Nombre = txtNombre.Text ?? "";
            bebida.Precio = txtPrecio.Text != "" ? decimal.Parse(txtPrecio.Text) : 0;
            bebida.Capacidad = txtCapacidad.Text != "" ? float.Parse(txtCapacidad.Text) : 0;

            bebida.Marca = new Marca();
            bebida.Marca.Id = ddlMarcas.SelectedValue != null ? int.Parse(ddlMarcas.SelectedValue) : 0;

            bebida.Alcoholica = ckxAlcoholica.Checked;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
            btnEliminar.Visible = false;
            btnAgregar.Visible = false;

        }

        protected void btnConfirmaDesactivar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(lblId.Text);
            try
            {
                bebidaNegocio.EliminarBebida(id);
                Response.Redirect("Bebidas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnCancelaDesactivar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            btnEliminar.Visible = true;
            btnAgregar.Visible = true;
        }
    }
}