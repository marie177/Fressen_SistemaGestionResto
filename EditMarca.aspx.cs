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
    public partial class EditMarca : System.Web.UI.Page
    {
        MarcaNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new MarcaNegocio();

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if (!string.IsNullOrEmpty(id) && !IsPostBack)
            {
                Marca marca = new Marca();
                marca = negocio.ListarMarcas(id)[0];
                precargarCamposMarca(marca);
            }
        }

        private void precargarCamposMarca(Marca marca)
        {
            lblId.Text = marca.Id.ToString();
            txtNombre.Text = marca.Nombre;

            if (!marca.Activo)
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
                negocio.DesactivarMarca(id);
                Response.Redirect("Marcas.aspx");
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
                Marca marca = new Marca();

                marca.Id = int.Parse(lblId.Text);
                marca.Nombre = txtNombre.Text;

                negocio.EditarMarca(marca);
                Response.Redirect("Marcas.aspx");
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
                negocio.ReactivarMarca(id);
                Response.Redirect("Marcas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}