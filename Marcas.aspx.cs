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
    public partial class Marcas : System.Web.UI.Page
    {
        private MarcaNegocio marcaNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            marcaNegocio = new MarcaNegocio();

            try
            {
                lblNuevaMarca.Visible = false;
                txtNuevaMarcaNombre.Visible = false;
                btnAceptar.Visible = false;
                btnAgregar.Visible = true;

                if (!IsPostBack)
                {
                    cargarGridMarcas();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void cargarGridMarcas()
        {
            if (!IsPostBack)
            {
                repeaterMarcas.DataSource = marcaNegocio.ListarMarcas();
                repeaterMarcas.DataBind();
            }
            else
            {
                repeaterMarcas.DataSource = null;
                repeaterMarcas.DataSource = marcaNegocio.ListarMarcas();
                repeaterMarcas.DataBind();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblNuevaMarca.Visible = true;
            txtNuevaMarcaNombre.Visible = true;
            btnAceptar.Visible = true;

            btnAgregar.Visible = false;

        }

        protected void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            string parametro = txtFiltroNombre.Text.ToUpper();

            repeaterMarcas.DataSource = null;
            repeaterMarcas.DataSource = marcaNegocio.ListarMarcas().Where(x => x.Nombre.ToUpper().Contains(parametro));
            repeaterMarcas.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevaMarcaNombre.Text;
            txtNuevaMarcaNombre.Text = "";

            Marca newMarca = new Marca();
            newMarca.Nombre = nombre;
            marcaNegocio.AgregarMarca(newMarca);

            cargarGridMarcas();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect("EditMarca.aspx?id=" + id, false);
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Text = "";
            cargarGridMarcas();
        }
    }
}