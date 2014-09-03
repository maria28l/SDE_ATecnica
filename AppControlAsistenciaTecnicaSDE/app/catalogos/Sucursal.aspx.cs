using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using NitlapanTic.Sdeat.Util;

public partial class catalogos_Sucursal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE SUCURSAL";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Sucursales del País";
        }
        catch (Exception ex)
        {
        }
        MostrarListaDeSucursal();
    }
    protected void MostrarListaDeSucursal()
    {
        try
        {
            var cmd = new SqlCommand();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM adm_tc_Sucursal";
            cmd.CommandType = CommandType.Text;

            var da = new SqlDataAdapter(cmd);
            var te = new DataTable();
            da.Fill(te);

            this.gvSucursal.DataSource = te;
            this.gvSucursal.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static DataTable Obtener_TablaSucursalParaDdl()
    {
        DataTable dc;
        try
        {
            SqlCommand cmd = new SqlCommand { CommandText = "dbo.sp_ObtenerSucursalParaDdl", CommandType = CommandType.StoredProcedure };

            using (clsConexion con = new clsConexion())
            {
                dc = con.ObtenerDataSet(cmd).Tables[0];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dc;
    }

}