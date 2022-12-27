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
    public partial class Bebidas : System.Web.UI.Page
    {
        private BebidaNegocio negocio;
        private MarcaNegocio marcaNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new BebidaNegocio();
            marcaNegocio = new MarcaNegocio();

            try
            {
                if (!IsPostBack)
                {
                    cargarRepeaterBebidas();
                    cargarDdlMarcas();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void cargarRepeaterBebidas()
        {
            if (!IsPostBack)
            {
                List<Bebida> listaInsumos = negocio.ListarBebidas();
                repeaterBebidas.DataSource = listaInsumos;
                repeaterBebidas.DataBind();
            }
        }

        private void cargarDdlMarcas()
        {
            if (!IsPostBack)
            {
                List<Marca> listaMarcas = marcaNegocio.ListarMarcas();

                ddlMarcas.DataSource = listaMarcas;
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "Id";

                ddlMarcas.DataBind();
            }
        }
        protected void linkBtnDetalle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("EditBebida.aspx?id=" + id, false);
        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(ddlMarcas.SelectedItem.Value); 
            List<Bebida> listaBebidas = negocio.ListarBebidas();

            repeaterBebidas.DataSource = null;
            repeaterBebidas.DataSource = listaBebidas.Where(x => x.Marca.Id == id);
            repeaterBebidas.DataBind();
        }


    }
}