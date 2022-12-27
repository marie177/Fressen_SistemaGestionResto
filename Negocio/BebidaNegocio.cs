using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class BebidaNegocio
    {
        private AccesoDatos baseDatos = new AccesoDatos();

        public List<Bebida> ListarBebidas(string id = "")
        {
            string consulta = @"SELECT i.Id, i.Nombre as Nombre, i.Precio,
                               i.Capacidad,  m.Id as IdMarca, m.Nombre as Marca, i.Alcoholica
                               FROM Insumos I
                               inner join TipoInsumo ti
                               on i.IdTipoInsumo = ti.Id
                               left join Marcas m
                               on i.Marca = m.Id
                               where i.Activo = 1
                               and ti.Id = 1";

            if (!string.IsNullOrEmpty(id))
                consulta += $"AND I.ID = {id}";

            baseDatos.SetearConsulta(consulta);
            baseDatos.EjecutarLectura();

            List<Bebida> listaBebidas = new List<Bebida>();

            try
            {
                while (baseDatos.Lector.Read())
                {
                    Bebida bebida = new Bebida();

                    bebida.Id = baseDatos.Lector.GetInt32(0);
                    bebida.Nombre = baseDatos.Lector.GetString(1);
                    bebida.Precio = baseDatos.Lector.GetDecimal(2);
                    bebida.Capacidad = (float)baseDatos.Lector.GetDouble(3);

                    bebida.Marca = new Marca();
                    bebida.Marca.Id = baseDatos.Lector.IsDBNull(baseDatos.Lector.GetOrdinal("IdMarca")) ? 0 : baseDatos.Lector.GetInt32(4);
                    bebida.Marca.Nombre = baseDatos.Lector.IsDBNull(baseDatos.Lector.GetOrdinal("Marca")) ? "" : baseDatos.Lector.GetString(5);

                    bebida.Alcoholica = baseDatos.Lector.GetBoolean(6);

                    bebida.Detalle = String.Format("{0} {1}lts - {2}", bebida.Nombre, bebida.Capacidad, bebida.Marca.Nombre);
                    listaBebidas.Add(bebida);
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

            return listaBebidas;
        }

        public void ModificarBebida(Bebida bebida)
        {

            try
            {
                string idMarca = bebida.Marca.Id == 0 ? "" : bebida.Marca.Id.ToString();

                string consulta = $"Update Insumos set Nombre = '{bebida.Nombre}', Precio = '{bebida.Precio.ToString().Replace(',', '.')}', Capacidad = '{bebida.Capacidad}', Marca = '{idMarca}', Alcoholica ={(bebida.Alcoholica ? 1 : 0)} where Id = {bebida.Id}";

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

        public void AgregarBebida(Bebida bebida)
        {
 
            try
            {
                string idMarca = bebida.Marca.Id == 0 ? "" : bebida.Marca.Id.ToString();

                string consulta = $"Insert into Insumos(Nombre, Precio, Capacidad, IdTipoInsumo, Marca, Alcoholica)  values ('{bebida.Nombre}',  '{bebida.Precio.ToString().Replace(',', '.')}',  '{bebida.Capacidad}', @idTipoInsumo ,'{idMarca}',  {(bebida.Alcoholica ? 1 : 0)})";

                baseDatos.SetearConsulta(consulta);
                baseDatos.SetearParametro("@idTipoInsumo", 1);

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

        public void EliminarBebida(int id)
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
