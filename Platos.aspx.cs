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
    public partial class Platos : System.Web.UI.Page
    {
        private TipoPlatoNegocio tipoPlatoNegocio;
        private PlatoNegocio platoNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoPlatoNegocio = new TipoPlatoNegocio();
            platoNegocio = new PlatoNegocio();

            try
            {
                if (!IsPostBack)
                {
                    cargarRepeaterPlatos();
                    cargarDdlTiposPlato();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void cargarRepeaterPlatos()
        {
            if (!IsPostBack)
            {
                List<Plato> listaInsumos = platoNegocio.ListarPlatos();
                repeaterPlatos.DataSource = listaInsumos;
                repeaterPlatos.DataBind();
            }
        }

        private void cargarDdlTiposPlato()
        {
            if (!IsPostBack)
            {
                List<TipoPlato> listaTipoPlatos = tipoPlatoNegocio.ListarTiposPlatos();

                ddlTipoPLato.DataSource = listaTipoPlatos;
                ddlTipoPLato.DataTextField = "Nombre";
                ddlTipoPLato.DataValueField = "Id";

                ddlTipoPLato.DataBind();
            }
        }

        protected void linkBtnDetalle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("EditPlato.aspx?id=" + id, false);
        }


        protected void ddlTipoPLato_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoPLato.SelectedItem.Text.ToUpper();
            List<Plato> listaPlatos = platoNegocio.ListarPlatos();

            repeaterPlatos.DataSource = null;
            repeaterPlatos.DataSource = listaPlatos.Where(x => x.Tipo.Nombre.ToUpper().Contains(tipo));
            repeaterPlatos.DataBind();
        }

    }
}