using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;

public partial class catalogos_Clientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE CLIENTE";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Cliente de Servicio de Desarrollo Empresarial";
        }
        catch (Exception ex)
        {
        }
        if (!IsPostBack)
        {
            LlenarListadoDeDepartamentos();
        }
        MostrarListaDeCliente();
    }
    protected void MostrarListaDeCliente()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ast_tm_Cliente";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvCliente.DataSource = te;
            }
            this.gvCliente.DataBind();
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
        }
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        MostrarListaDeCliente();
    }
    protected void gvCliente_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvCliente.PageIndex = e.NewPageIndex;
        MostrarListaDeCliente();
    }
}

