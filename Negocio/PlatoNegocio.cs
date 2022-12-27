using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PlatoNegocio
    {
        private AccesoDatos baseDatos = new AccesoDatos();
        public List<Plato> ListarPlatos()
        {

            baseDatos.SetearProcedimiento("SpListarPlatos");
            baseDatos.EjecutarLectura();

            List<Plato> listaPlatos = new List<Plato>();

            try
            {
                while (baseDatos.Lector.Read())
                {
                    //terminar
                    Plato plato = new Plato();

                    plato.Id = baseDatos.Lector.GetInt32(0);
                    plato.Nombre = baseDatos.Lector.GetString(1);
                    plato.Precio = baseDatos.Lector.GetDecimal(2);
                    plato.Activo = baseDatos.Lector.GetBoolean(3);

                    plato.Tipo = new TipoPlato();
                    plato.Tipo.Nombre = baseDatos.Lector.IsDBNull(baseDatos.Lector.GetOrdinal("TipoPlato")) ? "-": baseDatos.Lector.GetString(5);

                    plato.Detalle = String.Format("{0} - {1}",  plato.Tipo.Nombre, plato.Nombre);
                    listaPlatos.Add(plato);
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

            return listaPlatos;
        }

        public Plato ObtenerPlatoPorId(int id)
        {

            baseDatos.SetearProcedimiento("SpBuscarPlatoPorId");

            baseDatos.SetearParametro("@id", id);
            baseDatos.EjecutarLectura();

            Plato plato = new Plato();
            try
            {
                while (baseDatos.Lector.Read())
                {
                    plato.Id = baseDatos.Lector.GetInt32(0);
                    plato.Nombre = baseDatos.Lector.GetString(1);
                    plato.Precio = baseDatos.Lector.GetDecimal(2);
                    plato.Activo = baseDatos.Lector.GetBoolean(3);

                    plato.Tipo = new TipoPlato();
                    plato.Tipo.Nombre = baseDatos.Lector.IsDBNull(baseDatos.Lector.GetOrdinal("TipoPlato")) ? "-" : baseDatos.Lector.GetString(5);

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

            return plato;
        }


        public void AgregarPlato(Plato plato)
        {

            try
            {
                string idTipoPlato = plato.Tipo.Id == 0 ? "" : plato.Tipo.Id.ToString();

                string consulta = $"Insert into Insumos(Nombre, Precio, IdTipoInsumo, IdTipoPlato)  values ('{plato.Nombre}', '{plato.Precio.ToString().Replace(',', '.')}', @idTipoInsumo ,'{idTipoPlato}')";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@idTipoInsumo", 2);

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


        public void ModificarPlato(Plato plato)
        {

            try
            {
                string idTipoPlato = plato.Tipo.Id == 0 ? "" : plato.Tipo.Id.ToString();

                string consulta = $"Update Insumos set Nombre = '{plato.Nombre}', Precio = '{plato.Precio.ToString().Replace(',', '.')}', IdTipoPlato = '{idTipoPlato}' where Id = {plato.Id}";

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

        public void EliminarPlato(int id)
        {
            try
            {
                string consulta = "Update Insumos set Activo = 0 where Id = @Id";

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

