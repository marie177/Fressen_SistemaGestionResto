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
    public partial class EditPlato : System.Web.UI.Page
    {

        private TipoPlatoNegocio tipoPlatoNegocio;
        private PlatoNegocio platoNegocio;

        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoPlatoNegocio = new TipoPlatoNegocio();
            platoNegocio = new PlatoNegocio();

            try
            {
                btnEliminar.Visible = false;
                if (!IsPostBack)
                {

                    List<TipoPlato> tipoPlatos = tipoPlatoNegocio.ListarTiposPlatos();
                    ddlTipoPlato.DataSource = tipoPlatos;
                    ddlTipoPlato.DataTextField = "Nombre";
                    ddlTipoPlato.DataValueField = "Id";
                    ddlTipoPlato.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                if (!string.IsNullOrEmpty(id) && !IsPostBack)
                {
                    Plato plato = new Plato();
                    plato = platoNegocio.ObtenerPlatoPorId(int.Parse(id));
                    precargarCamposPlato(plato);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }

        private void precargarCamposPlato(Plato plato)
        {
            lblId.Text = plato.Id.ToString();

            txtNombre.Text = plato.Nombre;
            txtPrecio.Text = plato.Precio.ToString();

            ddlTipoPlato.SelectedIndex = ddlTipoPlato.Items.IndexOf((ddlTipoPlato.Items.FindByValue(plato.Tipo.Id.ToString())));

            btnAgregar.Text = "GUARDAR";
            btnEliminar.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Plato plato = new Plato();

                cargarPlato(plato);

                if (plato.Id > 0)
                {
                    platoNegocio.ModificarPlato(plato);
                }
                else
                {
                    platoNegocio.AgregarPlato(plato);
                }

                Response.Redirect("Platos.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cargarPlato(Plato plato)
        {
            plato.Id = lblId.Text != "" ? int.Parse(lblId.Text) : 0;
            plato.Nombre = txtNombre.Text ?? "";
            plato.Precio = txtPrecio.Text != "" ? decimal.Parse(txtPrecio.Text) : 0;

            plato.Tipo = new TipoPlato();
            plato.Tipo.Id = ddlTipoPlato.SelectedValue != null ? int.Parse(ddlTipoPlato.SelectedValue) : 0;
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
                platoNegocio.EliminarPlato(id);
                Response.Redirect("Platos.aspx");
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