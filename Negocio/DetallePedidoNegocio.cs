using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetallePedidoNegocio
    {
        private AccesoDatos _db;

        public DetallePedidoNegocio()
        {
            _db = new AccesoDatos();
        }

        public List<DetallePedido> ListarDetallePedido(string IdPedido)
        {
            string consulta = string.Format(@"
                               SELECT DP.Id, I.Id,
                               I.Nombre, I.Precio, I.Activo,
                               DP.Cantidad, DP.PrecioUnitario
                               FROM DetallePedidos DP
                               INNER JOIN Insumos I 
                               ON DP.IdInsumo = I.Id
                               WHERE DP.IdPedido = {0}
                               ", IdPedido);

            _db.SetearConsulta(consulta);
            _db.EjecutarLectura();

            List<DetallePedido> listaDetallePedido = new List<DetallePedido>();

            try
            {
                while (_db.Lector.Read())
                {
                    DetallePedido detalle = new DetallePedido();

                    detalle.Id = _db.Lector.GetInt32(0);

                    detalle.Insumo = new Insumo();
                    detalle.Insumo.Id = _db.Lector.GetInt32(1);
                    detalle.Insumo.Nombre = _db.Lector.GetString(2);
                    detalle.Insumo.Precio = _db.Lector.GetDecimal(3);
                    detalle.Insumo.Activo = _db.Lector.GetBoolean(4);
                    
                    detalle.Cantidad = _db.Lector.GetInt32(5);
                    detalle.PrecioUnitario = _db.Lector.GetDecimal(6);

                    listaDetallePedido.Add(detalle);
                }

                return listaDetallePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
        }

        public decimal AgregarDetallesPedido(int idPedido, List<DetallePedido> detallePedidoList)
        {
            try
            {
                decimal total = 0;
                string consulta = $"Insert into DetallePedidos (IdPedido, IdInsumo, Cantidad, PrecioUnitario) values ";

                foreach (var item in detallePedidoList)
                {
                    consulta += $"({idPedido}, {item.Insumo.Id}, {item.Cantidad}, '{item.PrecioUnitario.ToString().Replace(",",".")}'),";

                    total += (item.Cantidad * item.PrecioUnitario);
                }

                consulta = consulta.TrimEnd(',');

                _db.SetearConsulta(consulta);
                _db.EjecutarAccion();

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
        }

        public void AgregarDetallePedido(int idPedido, DetallePedido detalle)
        {
            try
            {
                string consulta = $"Insert into DetallePedidos (IdPedido, IdInsumo, Cantidad, PrecioUnitario) values ({idPedido}, {detalle.Insumo.Id}, {detalle.Cantidad}, '{detalle.PrecioUnitario.ToString().Replace(",",".")}') ";
                _db.SetearConsulta(consulta);

                _db.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
        }

        public void ActualizarDetallePedido(int idPedido, DetallePedido detalle)
        {
            try
            {
                string consulta = $"Update DetallePedidos Set Cantidad = '{detalle.Cantidad}', PrecioUnitario = '{detalle.PrecioUnitario.ToString().Replace(",", ".")}' where IdPedido = {idPedido} AND IdInsumo = {detalle.Insumo.Id} ";

                _db.SetearConsulta(consulta);
                _db.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
        }
        public void EliminarDetallePedido(int idDetalle)
        {
            try
            {
                string consulta = "Delete From DetallePedidos where Id = @Id";

                _db.SetearConsulta(consulta);
                _db.SetearParametro("@Id", idDetalle);

                _db.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
        }
    }
}
