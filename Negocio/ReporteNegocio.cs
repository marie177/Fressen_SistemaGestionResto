using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReporteNegocio
    {
        private AccesoDatos _db;

        public ReporteNegocio()
        {
            _db = new AccesoDatos();
        }
        public List<ReporteMeseros> ObtenerReporteMeseros(string fecha)
        {
            List<ReporteMeseros> listaReporteMeseros = new List<ReporteMeseros>();
            try
            {
                string consulta = $"SELECT * FROM V_REPORTE_MESEROS WHERE FECHAPEDIDOS =  '{fecha}'";
                _db.SetearConsulta(consulta);
                _db.EjecutarLectura();

                while (_db.Lector.Read())
                {
                    ReporteMeseros reporteMesero = new ReporteMeseros();

                    reporteMesero.Legajo = _db.Lector.GetInt32(0);
                    reporteMesero.Mesero = _db.Lector.GetString(1);
                    reporteMesero.FechaPedidos = _db.Lector.GetDateTime(2);
                    reporteMesero.TotalPedidos = _db.Lector.GetInt32(3);
                    reporteMesero.TotalRecaudado = _db.Lector.GetDecimal(4);

                    listaReporteMeseros.Add(reporteMesero);
                }

                return listaReporteMeseros;

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

        public List<ReporteMesas> ObtenerReporteMesas(string fecha)
        {
            List<ReporteMesas> listaReporteMesas = new List<ReporteMesas>();
            try
            {
                string consulta = $"SELECT * FROM V_REPORTE_MESAS WHERE FECHAPEDIDOS =  '{fecha}'";
                _db.SetearConsulta(consulta);
                _db.EjecutarLectura();

                while (_db.Lector.Read())
                {
                    ReporteMesas reporteMesa = new ReporteMesas();

                    reporteMesa.Numero = _db.Lector.GetInt32(0);
                    reporteMesa.FechaPedidos = _db.Lector.GetDateTime(1);
                    reporteMesa.TotalPedidos = _db.Lector.GetInt32(2);
                    reporteMesa.TotalRecaudado = _db.Lector.GetDecimal(3);

                    listaReporteMesas.Add(reporteMesa);
                }

                return listaReporteMesas;

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



    public class ReporteMeseros
    {
        public int Legajo { get; set; }
        public string Mesero { get; set; }
        public DateTime FechaPedidos { get; set; }
        public int TotalPedidos { get; set; }
        public decimal TotalRecaudado { get; set; }
    }

    public class ReporteMesas
    {
        public int Numero { get; set; }
        public DateTime FechaPedidos { get; set; }
        public int TotalPedidos { get; set; }
        public decimal TotalRecaudado { get; set; }
    }
}
