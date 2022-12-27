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
    public partial class TiposPlato : System.Web.UI.Page
    {
        TipoPlatoNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new TipoPlatoNegocio();

            try
            {
                lblNuevoTipo.Visible = false;
                txtNuevoTipoNombre.Visible = false;
                btnAceptar.Visible = false;
                btnAgregar.Visible = true;

                if (!IsPostBack)
                {
                    cargarGridTipos();
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void cargarGridTipos()
        {
            if (!IsPostBack)
            {
                repeaterTipoPlatos.DataSource = negocio.ListarTiposPlatos();
                repeaterTipoPlatos.DataBind();
            }
            else
            {
                repeaterTipoPlatos.DataSource = null;
                repeaterTipoPlatos.DataSource = negocio.ListarTiposPlatos();
                repeaterTipoPlatos.DataBind();
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect("EditTipoPlato.aspx?id=" + id, false);
        }

        protected void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            string parametro = txtFiltroNombre.Text.ToUpper();

            repeaterTipoPlatos.DataSource = null;
            repeaterTipoPlatos.DataSource = negocio.ListarTiposPlatos().Where(x => x.Nombre.ToUpper().Contains(parametro));
            repeaterTipoPlatos.DataBind();
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Text = "";
            cargarGridTipos();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoTipoNombre.Text;
            txtNuevoTipoNombre.Text = "";

            TipoPlato newTipo = new TipoPlato();
            newTipo.Nombre = nombre;
            negocio.AgregarTipoPlato(newTipo);

            cargarGridTipos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblNuevoTipo.Visible = true;
            txtNuevoTipoNombre.Visible = true;
            btnAceptar.Visible = true;

            btnAgregar.Visible = false;
        }
    }
}