using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
 


public partial class catalogos_rptDepartamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {         
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "REPORTE DE DEPARTAMENTOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Lista Departamentos del país";
        }
        catch (Exception ex )
        {
        }

        MostrarReporteDeDepartamentos();


    }


    protected void MostrarReporteDeDepartamentos()
    {
        try
        {
            crViewer.ReportSource = null;
            var dsDepartamento = new DataSet("Departamento");

            var daDepartamento = new SqlDataAdapter("SELECT atd.Cod_Empresa,atd.Cod_Departamento AS CodDepartamento,atd.Cod_Registro,atd.Des_Departamento AS Descripcion,"
                 + "atd.Tip_EstadoReg, atd.Cod_Usuario_Creo, atd.Fec_Creado as Fecha, atd.Cod_Usuario_Modifico, atd.Fec_Modificado, atd.Cad_Equipo FROM adm_tc_Departamento atd", ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            daDepartamento.Fill(dsDepartamento, "Departamento");

            var rd = new ReportDocument();
            rd.Load(Server.MapPath("~/app/reportes/crDepartamentos.rpt"));
            rd.SetDataSource(dsDepartamento);

            this.crViewer.ReportSource = rd;
            this.crViewer.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
}