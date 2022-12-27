using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class InsumoNegocio
    {
        private AccesoDatos baseDatos = new AccesoDatos();

        public List<Insumo> ListarInsumosConSP()
        {
            baseDatos.SetearProcedimiento("SpListarInsumos");
            baseDatos.EjecutarLectura();

            List<Insumo> listaInsumos = new List<Insumo>();

            try
            {
                while (baseDatos.Lector.Read())
                {
                    Insumo insumo = new Insumo();

                    insumo.Id = baseDatos.Lector.GetInt32(0);
                    insumo.Nombre = baseDatos.Lector.GetString(1);
                    insumo.Precio = baseDatos.Lector.GetDecimal(2);

                    listaInsumos.Add(insumo);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseDatos.CerrarConexion();
            }

            return listaInsumos;
        }


        public Insumo ObtenerInsumoPorId(int id)
        {
            string consulta = $"SELECT Id, Nombre, Precio From Insumos Where Id = {id}";
            baseDatos.SetearConsulta(consulta);
            baseDatos.EjecutarLectura();

            Insumo insumo = new Insumo();
            try
            {
                while (baseDatos.Lector.Read())
                {
                    insumo.Id = baseDatos.Lector.GetInt32(0);
                    insumo.Nombre = baseDatos.Lector.GetString(1);
                    insumo.Precio = baseDatos.Lector.GetDecimal(2);
                }

                return insumo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseDatos.CerrarConexion();
            }

        }

    }
}
