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
    public partial class Meseros : System.Web.UI.Page
    {
        private UsuarioNegocio usuarioNegocio;
        public bool confirm = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioNegocio = new UsuarioNegocio();

            try
            {
                if (!IsPostBack)
                {
                    if (Session["usuario"] == null)
                    {
                        Session.Add("error", "Debes logearte para acceder a esta area.");
                        Response.Redirect("Error.aspx", false);
                    }
                    else if (((Dominio.Usuario)Session["usuario"]).Perfil.Id != 1)
                    {
                        Session.Add("error", "No posee los permisos suficientes para acceder.");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                    cargarRepeaterMeseros();

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        public void cargarRepeaterMeseros()
        {
            List<Usuario> listaUsuarios = usuarioNegocio.listarUsuarios();
            repeaterMeseros.DataSource = listaUsuarios;
            repeaterMeseros.DataBind();
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("AddMesero.aspx?Legajo=" + legajo, false);
        }
    }
}