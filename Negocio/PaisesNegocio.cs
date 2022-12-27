using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PaisesNegocio
    {
        AccesoDatos basedatos = new AccesoDatos();

        public List<Pais> listarPaises()
        {
            List<Pais> listaPaises = new List<Pais>();

            try
            {

                basedatos.SetearProcedimiento("SpListarPaises");
                basedatos.EjecutarLectura();

                while (basedatos.Lector.Read())
                {
                    Pais pais = new Pais();

                    pais.ID = basedatos.Lector.GetInt32(0);
                    pais.Nombre = basedatos.Lector.GetString(1);

                    listaPaises.Add(pais);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                basedatos.CerrarConexion();
            }

            return listaPaises;
        }

    }
}
