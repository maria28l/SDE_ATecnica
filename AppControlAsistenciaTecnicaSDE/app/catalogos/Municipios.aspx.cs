using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;

public partial class catalogos_Municipios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE MUNICIPIOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Municipios del país";
        }
        catch (Exception ex)
        {
        }
        MostrarListaDeMunicipios();
        if (!IsPostBack)
        {
            LlenarListadoDeDepartamentos();
        }
    }
    protected void MostrarListaDeMunicipios()
    {
        try
        {
            var cmd = new SqlCommand();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM adm_tc_Municipio";
            cmd.CommandType = CommandType.Text;

            var da = new SqlDataAdapter(cmd);
            var te = new DataTable();
            da.Fill(te);

            this.gvMunicipios.DataSource = te;
            this.gvMunicipios.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
    protected void LlenarListadoDeDepartamentos()
    {
        var dt = new DataTable();
        dt = Departamento.Obtener_TablaDepartamentosParaDdl();
        ddlDepartamento.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlDepartamento.DataSource = dt;
            ddlDepartamento.DataValueField = "Cod_Departamento";
            ddlDepartamento.DataTextField = "Des_Departamento";
            ddlDepartamento.DataBind();

            ddlDepartamento.SelectedIndex = 0;
        }
    }
}