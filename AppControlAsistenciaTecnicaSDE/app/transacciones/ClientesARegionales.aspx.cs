using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NitlapanTic.Sdeat.Catalogos;
using NitlapanTic.Sdeat.transacciones;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class transacciones_ClientesARegionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "ASIGNAR CLIENTES A REGIONALES";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Asignación de Asistencia Técnica";
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (!IsPostBack)
        {
            MostrarListaDeClientesNuevos();
            //LlenarListadoDeFacilitador();
            LlenarListadoDeCliente();
            LlenarListadoDeSucursal();
        }
        
    }

    protected void MostrarListaDeClientesNuevos()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var elUsuario = Session["login"].ToString();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                /*cmd.CommandText = "SELECT dbo.ast_tm_Cliente.Cod_Empresa, (select cod_personal from ast_tm_personal where cod_usuario = '" + 
                    elUsuario + "') as Cod_Personal_Asigna, dbo.ast_tm_Cliente.Cod_Cliente, " +
                    "dbo.ast_tm_Cliente.Cad_Nombre_Completo, dbo.adm_tm_Financiador_Cliente.Cod_Sucursal, " +
                    "dbo.adm_tc_Sucursal.Des_Sucursal, dbo.adm_tm_Financiador_Cliente.Cod_Financiador, " +
                    "dbo.adm_tc_Financiador.Des_Financiador, '00000000' as cod_facilitador, " +
	                "(select val_param_str from adm_tc_Parametro where Cod_Param='COD_CARGO_REGIONAL') as Cargo_Regional " + 
                    "FROM dbo.ast_tm_Cliente INNER JOIN " +
                    "dbo.adm_tm_Financiador_Cliente ON dbo.ast_tm_Cliente.Cod_Empresa = dbo.adm_tm_Financiador_Cliente.Cod_Empresa " + 
                    "AND dbo.ast_tm_Cliente.Cod_Cliente = dbo.adm_tm_Financiador_Cliente.Cod_Cliente INNER JOIN " +
                    "dbo.adm_tc_Financiador ON dbo.adm_tm_Financiador_Cliente.Cod_Empresa = dbo.adm_tc_Financiador.Cod_Empresa " + 
                    "AND dbo.adm_tm_Financiador_Cliente.Cod_Financiador = dbo.adm_tc_Financiador.Cod_Financiador INNER JOIN " +
                    "dbo.adm_tc_Sucursal ON dbo.adm_tm_Financiador_Cliente.Cod_Empresa = dbo.adm_tc_Sucursal.Cod_Empresa AND " +
                    "dbo.adm_tm_Financiador_Cliente.Cod_Sucursal = dbo.adm_tc_Sucursal.Cod_Sucursal WHERE NOT EXISTS " + 
                    "(select * from ast_tt_Clientes_Asignados WHERE " + 
                    "adm_tm_Financiador_Cliente.Cod_Empresa = ast_tt_Clientes_Asignados.Cod_Empresa AND " +
                    "adm_tm_Financiador_Cliente.Cod_Cliente = ast_tt_Clientes_Asignados.Cod_Cliente AND " +
                    "adm_tm_Financiador_Cliente.Cod_Sucursal = ast_tt_Clientes_Asignados.Cod_Sucursal);";*/
                cmd.CommandText = "SELECT dbo.ast_tm_Cliente.Cod_Empresa, (select cod_personal from ast_tm_personal where cod_usuario = '" +
                    elUsuario + "') as Cod_Personal_Asigna, dbo.ast_tm_Cliente.Cod_Cliente, " +
                    "dbo.ast_tm_Cliente.Cad_Nombre_Completo, dbo.adm_tm_Financiador_Cliente.Cod_Sucursal, " +
                    "dbo.adm_tc_Sucursal.Des_Sucursal, dbo.adm_tm_Financiador_Cliente.Cod_Financiador, " +
                    "dbo.adm_tc_Financiador.Des_Financiador, '00000000' as cod_facilitador, " +
                    "(select val_param_str from adm_tc_Parametro where Cod_Param='COD_CARGO_REGIONAL') as Cargo_Regional " +
                    "FROM dbo.ast_tm_Cliente INNER JOIN " +
                    "dbo.adm_tm_Financiador_Cliente ON dbo.ast_tm_Cliente.Cod_Empresa = dbo.adm_tm_Financiador_Cliente.Cod_Empresa " +
                    "AND dbo.ast_tm_Cliente.Cod_Cliente = dbo.adm_tm_Financiador_Cliente.Cod_Cliente INNER JOIN " +
                    "dbo.adm_tc_Financiador ON dbo.adm_tm_Financiador_Cliente.Cod_Empresa = dbo.adm_tc_Financiador.Cod_Empresa " +
                    "AND dbo.adm_tm_Financiador_Cliente.Cod_Financiador = dbo.adm_tc_Financiador.Cod_Financiador INNER JOIN " +
                    "dbo.adm_tc_Sucursal ON dbo.adm_tm_Financiador_Cliente.Cod_Empresa = dbo.adm_tc_Sucursal.Cod_Empresa AND " +
                    "dbo.adm_tm_Financiador_Cliente.Cod_Sucursal = dbo.adm_tc_Sucursal.Cod_Sucursal INNER JOIN " +
                    "dbo.adm_tm_Personal_Sucursal ON dbo.adm_tm_Financiador_Cliente.Cod_Empresa = dbo.adm_tm_Personal_Sucursal.Cod_Empresa AND " +
                    "dbo.adm_tm_Financiador_Cliente.Cod_Sucursal = dbo.adm_tm_Personal_Sucursal.Cod_Sucursal INNER JOIN " +
                    "dbo.ast_tm_Personal ON dbo.adm_tm_Personal_Sucursal.Cod_Empresa = dbo.ast_tm_Personal.Cod_Empresa AND " +
                    "dbo.adm_tm_Personal_Sucursal.Cod_Personal = dbo.ast_tm_Personal.Cod_Personal WHERE NOT EXISTS " +
                    "(select * from ast_tt_Clientes_Asignados WHERE " +
                    "adm_tm_Financiador_Cliente.Cod_Empresa = ast_tt_Clientes_Asignados.Cod_Empresa AND " +
                    "adm_tm_Financiador_Cliente.Cod_Cliente = ast_tt_Clientes_Asignados.Cod_Cliente AND " +
                    "adm_tm_Financiador_Cliente.Cod_Sucursal = ast_tt_Clientes_Asignados.Cod_Sucursal) AND Cod_Usuario='" + elUsuario +"';";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvClientesARegionales.DataSource = te;
            }
            this.gvClientesARegionales.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void LlenarListadoDePersonal()
    //{
    //    var df = new DataTable();
    //    df = Personal.Obtener_TablaPersonalParaDdl();
    //    //df = EventosxATecnica.Obtener_TablaTipoEventoParaDdl();
    //    DropDownList ddlPersonal = new DropDownList();
    //    ddlPersonal.Items.Clear();
    //    if (df.Rows.Count > 0)
    //    {
    //        ddlPersonal.DataSource = df;
    //        ddlPersonal.DataValueField = "Cod_Personal";
    //        ddlPersonal.DataTextField = "Cad_Nombre_Completo";
    //        ddlPersonal.DataBind();
    //    }
    //}

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

    protected void btnActualizar_cr_Click(object sender, EventArgs e)
    {
        MostrarListaDeClientesNuevos();
    }

    protected void gvEventosProgramados_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvClientesARegionales.PageIndex = e.NewPageIndex;
        MostrarListaDeClientesNuevos();
    }
}