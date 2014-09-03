using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using NitlapanTic.Sdeat.Util;

public struct ddlCodProdFinanciero
{
    static ddlCodProdFinanciero()
    {
        
    }
}
public partial class catalogos_FinanciadorMetas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE METAS DEL FINANCIADOR";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Metas del financiador";
        }
        catch (Exception ex )
        {
        }
        MostrarListaDeDeFinanciadorMetas();
        LlenarListadoDeProductosFinancieros();
    }
    protected void MostrarListaDeDeFinanciadorMetas()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM adm_tc_Financiador_Metas";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvFinanciadorMetas.DataSource = te;
            }
            this.gvFinanciadorMetas.DataBind();

        }
        catch (Exception ex)
        {

        }
    }

    protected void LlenarListadoDeProductosFinancieros()
    {
        var dt = new DataTable();
        try
        {
            var cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerProductosFinancierosParaDdl", CommandType = CommandType.StoredProcedure };

            using (var con = new clsConexion())
            {
                dt = con.ObtenerDataSet(cmd).Tables[0];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        ddlCodProdFinanciero.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlCodProdFinanciero.DataSource = dt;
            ddlCodProdFinanciero.DataValueField = "Cod_TipoProducto";
            ddlCodProdFinanciero.DataTextField = "Des_TipoProducto";
            ddlCodProdFinanciero.DataBind();

            ddlCodProdFinanciero.SelectedIndex = ddlCodProdFinanciero.Items.IndexOf(ddlCodProdFinanciero.Items.FindByValue("00"));
        }
    }

}