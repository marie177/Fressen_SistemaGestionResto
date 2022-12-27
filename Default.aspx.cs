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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Add("errorLogin", false);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();   

            try
            {
                if(String.IsNullOrEmpty(txtLegajo.Text))
                {
                    lblError.Text = "Ingrese legajo, por favor";
                    Session.Add("errorLogin", true);
                    return;
                }
                usuario = new Usuario(int.Parse(txtLegajo.Text), txtPass.Text, false);

                if(negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("mainmenu.aspx");
                }
                else
                {
                    lblError.Text = "Legajo o contraseña incorrectos";
                    Session.Add("errorLogin", true );
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }
        }
    }
}