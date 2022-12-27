using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        private AccesoDatos baseDatos = new AccesoDatos();
        public List<Marca> ListarMarcas(string id = "")
        {
            string consulta = "SELECT ID, NOMBRE, ACTIVO FROM MARCAS";
            if (!string.IsNullOrEmpty(id))
                consulta += $" WHERE ID = {id}";

            baseDatos.SetearConsulta(consulta);
            baseDatos.EjecutarLectura();

            List<Marca> listaMarcas = new List<Marca>();

            try
            {
                while (baseDatos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.Id = baseDatos.Lector.GetInt32(0);
                    marca.Nombre = baseDatos.Lector.GetString(1);
                    marca.Activo = baseDatos.Lector.GetBoolean(2);

                    listaMarcas.Add(marca);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseDatos.CerrarConexion();
            }

            return listaMarcas;
        }

        public void AgregarMarca(Marca marca)
        {
            try
            {
                string consulta = $"INSERT INTO MARCAS(NOMBRE) VALUES ('{marca.Nombre}')";

                baseDatos.SetearConsulta(consulta);
                baseDatos.EjecutarAccion();

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

        public void EditarMarca(Marca marca)
        {
            try
            {
                string consulta = $"UPDATE MARCAS SET NOMBRE = '{marca.Nombre}' WHERE ID = @Id";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@Id", marca.Id);
                baseDatos.EjecutarAccion();
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
        public void DesactivarMarca(int id)
        {
            try
            {
                string consulta = "Update MARCAS set Activo = 0 where Id = @Id";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@Id", id);
                baseDatos.EjecutarAccion();
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

        public void ReactivarMarca(int id)
        {
            try
            {
                string consulta = "Update MARCAS set Activo = 1 where Id = @Id";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@Id", id);
                baseDatos.EjecutarAccion();
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
