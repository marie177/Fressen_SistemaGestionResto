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
    public partial class EditTipoPlato : System.Web.UI.Page
    {
        private TipoPlatoNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new TipoPlatoNegocio();

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if (!string.IsNullOrEmpty(id) && !IsPostBack)
            {
                TipoPlato plato = new TipoPlato();
                plato = negocio.ObtenerTipoPlatoPorId(int.Parse(id));
                precargarCamposTipoPlato(plato);
            }
        }

        private void precargarCamposTipoPlato(TipoPlato tipo)
        {
            lblId.Text = tipo.Id.ToString();
            txtNombre.Text = tipo.Nombre;

            if (!tipo.Activo)
            {
                btnEliminar.Visible = false;
                btnReActivar.Visible = true;
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            try
            {
                negocio.DesactivarTipoPlato(id);
                Response.Redirect("TiposPlato.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnReActivar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            try
            {
                negocio.ReactivarTipoPlato(id);
                Response.Redirect("TiposPlato.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoPlato tipo = new TipoPlato();

                tipo.Id = int.Parse(lblId.Text);
                tipo.Nombre = txtNombre.Text;

                negocio.EditarTipoPlato(tipo);
                Response.Redirect("TiposPlato.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}