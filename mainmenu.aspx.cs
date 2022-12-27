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
    public partial class mainmenu : System.Web.UI.Page
    {
        public string contMesasOcupadas;
        public string contMesasReservadas;
        public string contMesasLibres;

        protected void Page_Load(object sender, EventArgs e)
        {
            MesaNegocio negocio = new MesaNegocio();

            if (!IsPostBack)
            {
                List<Mesa> lista = new List<Mesa>();
                if (((Dominio.Usuario)Session["usuario"]).Perfil.Id != 1)
                {
                    lista = negocio.ListarMesasPorMesero((Usuario)Session["usuario"]);
                }
                else
                {
                    lista = negocio.ListarMesas();
                }

                RepeaterMesas.DataSource = lista;
                contMesasOcupadas = (lista.Where(x => x.Ocupado).Count()).ToString();
                contMesasLibres = (lista.Where(x => !x.Ocupado).Count()).ToString();

                RepeaterMesas.DataBind();
            }
        }

        protected void btnVerDetallePedido_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect($"Pedidos.aspx?NumeroMesa={id}", false);
        }
    }
}