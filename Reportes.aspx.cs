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
    public partial class Reportes : System.Web.UI.Page
    {
        private ReporteNegocio negocioReporte;
        protected void Page_Load(object sender, EventArgs e)
        {
            negocioReporte = new ReporteNegocio();

            if (!IsPostBack)
            {
                CargarRepeaterReporteMeseros();
                CargarRepeaterReporteMesas();
                CargarDatosDiarios();
            }
        }

        private void CargarRepeaterReporteMeseros(string fechaFiltro = "")
        {
            List<ReporteMeseros> listaReporteMeseros;
            if (string.IsNullOrEmpty(fechaFiltro))
                listaReporteMeseros = negocioReporte.ObtenerReporteMeseros(DateTime.Now.ToString("yyyy/MM/dd"));
            else
                listaReporteMeseros = negocioReporte.ObtenerReporteMeseros(fechaFiltro);

            repeaterReporteMeseros.DataSource = listaReporteMeseros;
            repeaterReporteMeseros.DataBind();
        }

        public void CargarDatosDiarios(string fechaFiltro = "")
        {
            List<ReporteMeseros> listaReporteMeseros;
            if (string.IsNullOrEmpty(fechaFiltro))
                listaReporteMeseros = negocioReporte.ObtenerReporteMeseros(DateTime.Now.ToString("yyyy/MM/dd"));
            else
                listaReporteMeseros = negocioReporte.ObtenerReporteMeseros(fechaFiltro);


            var totalDiario = listaReporteMeseros.Sum(x => x.TotalRecaudado);
            lblTotalRecaudado.Text = $"$ {totalDiario}";

            if (string.IsNullOrEmpty(fechaFiltro))
                txtFechaReportes.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void CargarRepeaterReporteMesas(string fechaFiltro = "")
        {
            List<ReporteMesas> listaReporteMesas;
            if (string.IsNullOrEmpty(fechaFiltro))
                listaReporteMesas = negocioReporte.ObtenerReporteMesas(DateTime.Now.ToString("yyyy/MM/dd"));
            else
                listaReporteMesas = negocioReporte.ObtenerReporteMesas(fechaFiltro);

            repeaterReporteMesas.DataSource = listaReporteMesas;
            repeaterReporteMesas.DataBind();
        }

        protected void txtFechaReportes_TextChanged(object sender, EventArgs e)
        {
            string fechaFiltro = (Convert.ToDateTime(txtFechaReportes.Text)).ToString("yyyy/MM/dd");
            CargarRepeaterReporteMesas(fechaFiltro);
            CargarRepeaterReporteMeseros(fechaFiltro);
            CargarDatosDiarios(fechaFiltro);
        }
    }
}