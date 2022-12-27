using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral
{
    public partial class AddMesa : System.Web.UI.Page
    {
        public bool confirm;
        public bool banderaOcup;

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (!IsPostBack)
            {
                List<Usuario> lista = negocio.listarMeseros();
                ddlMeseros.DataSource = lista;
                ddlMeseros.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    MesaNegocio mesaNegocio = new MesaNegocio();
                    Mesa mesa = mesaNegocio.ObtenerMesaPorNumero(Request.QueryString["id"].ToString());

                    txtNumeroMesa.Text = mesa.Numero.ToString();
                    txtCapacidad.Text = mesa.Capacidad.ToString();

                    ddlMeseros.SelectedIndex = mesa.MeseroAsignado.Legajo - 1;

                    if (mesa.Ocupado == true)
                    {
                        banderaOcup = true;
                        chkOcupada.Checked = true;
                    }
                    else
                    {
                        banderaOcup = false;
                        chkOcupada.Checked = false;
                    }

                    txtNumeroMesa.Enabled = false;

                }
            }

        }

        protected void btnEditarMesa_Click(object sender, EventArgs e)
        {
            MesaNegocio negocio = new MesaNegocio();
            Mesa nuevaMesa = new Mesa();

            nuevaMesa.Numero = int.Parse(txtNumeroMesa.Text);
            nuevaMesa.Capacidad = int.Parse(txtCapacidad.Text);

            nuevaMesa.Ocupado = banderaOcup;

            nuevaMesa.MeseroAsignado.Legajo = ddlMeseros.SelectedIndex + 1;
            if (Request.QueryString["id"] != null)
            {
                negocio.editarMesa(nuevaMesa);
            }
            else
            {
                negocio.agregarMesa(nuevaMesa);
            }

            Response.Redirect("Mesas.aspx", false);

        }

        protected void chkOcupada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcupada.Checked)
            {
                banderaOcup = true;

            }
            else
            {
                banderaOcup = false;
            }
        }
    }
}