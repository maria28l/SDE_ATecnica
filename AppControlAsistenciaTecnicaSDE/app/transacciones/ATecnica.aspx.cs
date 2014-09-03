using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;
using NitlapanTic.Sdeat.transacciones;

public partial class transacciones_ATecnica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "ASISTENCIA TÉCNICA";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Registro de Asistencia Técnica";
        }
        catch (Exception ex )
        {
            throw ex;
        }

        if (!IsPostBack)
        {
            var elUsuario = Session["login"].ToString();
            hfCodUsuario.Value = elUsuario; 
            LlenarListadoDeFinanciador();
            //LlenarListadoDeCliente();
            //LlenarListadoDeFacilitador();
            //LlenarListadoDeProductoFinanciero();
            LlenarListadoDeDepartamentos();
            //LlenarListadoDeSucursal();
        }
        MostrarListaDeATecnica();
    }
    protected void MostrarListaDeATecnica()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var elUsuario = Session["login"].ToString();
                //hfCodUsuario.Value = elUsuario;
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT * FROM ast_tt_ATecnica ";
                cmd.CommandText = "SELECT ast_tt_ATecnica.*, adm_tc_Financiador.Des_Financiador, " +
                    "ast_tm_Cliente.Cad_Nombre_Completo AS Des_Cliente, ast_tm_Personal.Cad_Nombre_Completo AS Des_Facilitador, " +
                    "adm_tc_ProductoFinanciero.Des_ProdFinanciero, adm_tc_Departamento.Des_Departamento, adm_tc_Municipio.Des_Municipio, " +
                    "adm_tc_Sucursal.Des_Sucursal, (select top 1 cod_personal from ast_tm_personal where cod_usuario = '" +
                    elUsuario + "') as Cod_Usuario FROM ast_tt_ATecnica LEFT JOIN adm_tc_Financiador ON " +
                    "ast_tt_ATecnica.Cod_Empresa = adm_tc_Financiador.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Financiador = adm_tc_Financiador.Cod_Financiador LEFT JOIN ast_tm_Cliente ON " +
                    "ast_tt_ATecnica.Cod_Empresa = ast_tm_Cliente.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Cliente = ast_tm_Cliente.Cod_Cliente LEFT JOIN ast_tm_Personal ON " +
                    "ast_tt_ATecnica.Cod_Empresa = ast_tm_Personal.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Facilitador = ast_tm_Personal.Cod_Personal LEFT JOIN adm_tc_ProductoFinanciero ON " +
                    "ast_tt_ATecnica.Cod_Empresa = adm_tc_ProductoFinanciero.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_ProductoFinanciero = adm_tc_ProductoFinanciero.Cod_ProdFinanciero LEFT JOIN " +
                    "adm_tc_Departamento ON ast_tt_ATecnica.Cod_Empresa = adm_tc_Departamento.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Departamento = adm_tc_Departamento.Cod_Departamento LEFT JOIN adm_tc_Sucursal ON " +
                    "ast_tt_ATecnica.Cod_Empresa = adm_tc_Sucursal.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Sucursal = adm_tc_Sucursal.Cod_Sucursal LEFT JOIN adm_tc_Municipio ON " +
                    "ast_tt_ATecnica.Cod_Empresa = adm_tc_Municipio.Cod_Empresa AND " +
                    "ast_tt_ATecnica.Cod_Municipio = adm_tc_Municipio.Cod_Municipio ORDER BY ast_tt_ATecnica.Fec_Inicio_Asistencia DESC;";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvATecnica.DataSource = te;
            }
            this.gvATecnica.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LlenarListadoDeFacilitador()
    {
        var df = new DataTable();
        df = Personal.Obtener_TablaPersonalParaDdl();
        ddlFacilitador.Items.Clear();
        if (df.Rows.Count > 0)
        {
            ddlFacilitador.DataSource = df;
            ddlFacilitador.DataValueField = "Cod_Personal";
            ddlFacilitador.DataTextField = "Cad_Nombre_Completo";
            ddlFacilitador.DataBind();
        }
    }

    protected void LlenarListadoDeProductoFinanciero()
    {
        var dpf = new DataTable();
        dpf = ATecnica.Obtener_TablaProductoFinancieroParaDdl();
        ddlProductoFinanciero.Items.Clear();
        if (dpf.Rows.Count > 0)
        {
            ddlProductoFinanciero.DataSource = dpf;
            ddlProductoFinanciero.DataValueField = "Cod_ProductoFinanciero";
            ddlProductoFinanciero.DataTextField = "Des_ProdFinanciero";
            ddlProductoFinanciero.DataBind();
        }
    }

    protected void LlenarListadoDeCliente()
    {
        var dc = new DataTable();
        dc = Clientes.Obtener_TablaClienteParaDdl();
        ddlCliente.Items.Clear();
        if (dc.Rows.Count > 0)
        {
            ddlCliente.DataSource = dc;
            ddlCliente.DataValueField = "Cod_Cliente";
            ddlCliente.DataTextField = "Cad_Nombre_Completo";
            ddlCliente.DataBind();
        }
    }

    protected void LlenarListadoDeFinanciador()
    {
        var df = new DataTable();
        df = Financiador.Obtener_TablaFinanciadoresParaDdl();
        ddlFinanciador.Items.Clear();
        if (df.Rows.Count > 0)
        {
            ddlFinanciador.DataSource = df;
            ddlFinanciador.DataValueField = "Cod_Financiador";
            ddlFinanciador.DataTextField = "Des_Financiador";
            ddlFinanciador.DataBind();
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

     protected void LlenarListadoDeMunicipio(string codDepartamento)
    {
        var dm = new DataTable();
        dm = Municipio.Obtener_TablaMunicipioParaDdl(codDepartamento);
        ddlMunicipio.Items.Clear();        
        if (dm.Rows.Count > 0)
        {
            ddlMunicipio.DataSource = dm;           
            ddlMunicipio.DataValueField = "Cod_Municipio";
            ddlMunicipio.DataTextField = "Des_Municipio";            
            ddlMunicipio.DataBind();
        }
    }

     //protected void LlenarListadoDeSucursal(string codMunicipio)
     //{
     //    var ds = new DataTable();
     //    ds = Sucursal.Obtener_TablaSucursalxMunicParaDdl(codMunicipio);
     //    ddlSucursal.Items.Clear();
     //    if (ds.Rows.Count > 0)
     //    {
     //        ddlSucursal.DataSource = ds;
     //        ddlSucursal.DataValueField = "Cod_Sucursal";
     //        ddlSucursal.DataTextField = "Des_Sucursal";
     //        ddlSucursal.DataBind();
     //    }
     //}
     protected void LlenarListadoDeSucursal()
     {
         var ds = new DataTable();
         ds = Sucursal.Obtener_TablaSucursalParaDdl();
         ddlSucursal.Items.Clear();
         if (ds.Rows.Count > 0)
         {
             ddlSucursal.DataSource = ds;
             ddlSucursal.DataValueField = "Cod_Sucursal";
             ddlSucursal.DataTextField = "Des_Sucursal";
             ddlSucursal.DataBind();
         }
     }
     protected void LlenarListadoDeTerritorio(string codMunicipio)
     {

         var dt = new DataTable();
         dt = Territorio.Obtener_TablaTerritorioParaDdl(codMunicipio);
         ddlTerritorio.Items.Clear();
         if (dt.Rows.Count > 0)
         {
             ddlTerritorio.DataSource = dt;
             ddlTerritorio.DataValueField = "Cod_Territorio";
             ddlTerritorio.DataTextField = "Des_Territorio";
             ddlTerritorio.DataBind();
         }
     }

     protected void btnActualizar_Click(object sender, EventArgs e)
     {
         MostrarListaDeATecnica();
     }

     protected void gvATecnica_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
     {
         gvATecnica.PageIndex = e.NewPageIndex;
         MostrarListaDeATecnica();
     }
}