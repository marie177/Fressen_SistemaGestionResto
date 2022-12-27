using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoPlatoNegocio
    {
        private AccesoDatos baseDatos = new AccesoDatos();
        public List<TipoPlato> ListarTiposPlatos()
        {

            baseDatos.SetearProcedimiento("SpListarTiposPlato");
            baseDatos.EjecutarLectura();

            List<TipoPlato> listaTipoPlato = new List<TipoPlato>();

            try
            {
                while (baseDatos.Lector.Read())
                {
                    TipoPlato tipo = new TipoPlato();

                    tipo.Id = baseDatos.Lector.GetInt32(0);
                    tipo.Nombre = baseDatos.Lector.GetString(1);
                    tipo.Activo = baseDatos.Lector.GetBoolean(2);

                    listaTipoPlato.Add(tipo);
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

            return listaTipoPlato;
        }

        public TipoPlato ObtenerTipoPlatoPorId(int id)
        {
            TipoPlato tipo = new TipoPlato();

            try
            {
                string consulta = $"SELECT ID, NOMBRE, ACTIVO FROM TIPOPLATOS WHERE ID = @Id";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@Id", id);
                baseDatos.EjecutarLectura();

                while (baseDatos.Lector.Read())
                {
                    tipo.Id = baseDatos.Lector.GetInt32(0);
                    tipo.Nombre = baseDatos.Lector.GetString(1);
                    tipo.Activo = baseDatos.Lector.GetBoolean(2);
                }

                return tipo;

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
        public void AgregarTipoPlato(TipoPlato tipo)
        {
            try
            {
                string consulta = $"INSERT INTO TIPOPLATOS(NOMBRE) VALUES ('{tipo.Nombre}')";

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

        public void EditarTipoPlato(TipoPlato tipo)
        {
            try
            {
                string consulta = $"UPDATE TIPOPLATOS SET NOMBRE = '{tipo.Nombre}' WHERE ID = @Id";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@Id", tipo.Id);
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

        public void DesactivarTipoPlato(int id)
        {
            try
            {
                string consulta = "Update TipoPlatos set Activo = 0 where Id = @Id";

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

        public void ReactivarTipoPlato(int id)
        {
            try
            {
                string consulta = "Update TipoPlatos set Activo = 1 where Id = @Id";

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
