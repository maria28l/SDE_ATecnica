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

public partial class transacciones_ClientesAFacilitadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "ASIGNAR CLIENTES A FACILITADORES";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Asignación de Clientes";
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
                cmd.CommandText = "SELECT dbo.ast_tt_Clientes_Asignados.Cod_Empresa, dbo.ast_tt_Clientes_Asignados.Cod_Registro, " +
                    "(select cod_personal from ast_tm_personal where cod_usuario = '" +
                    elUsuario + "') as Cod_Personal_Asigna, dbo.ast_tt_Clientes_Asignados.Cod_Cliente, " +
                    "dbo.ast_tm_Cliente.Cad_Nombre_Completo, dbo.ast_tt_Clientes_Asignados.Cod_Sucursal, " +
                    "dbo.adm_tc_Sucursal.Des_Sucursal, '00000000' as cod_facilitador " +
                    "FROM dbo.ast_tt_Clientes_Asignados INNER JOIN " +
                    "dbo.ast_tm_Cliente ON dbo.ast_tt_Clientes_Asignados.Cod_Empresa = dbo.ast_tm_Cliente.Cod_Empresa AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Cliente = dbo.ast_tm_Cliente.Cod_Cliente INNER JOIN " +
                    "dbo.adm_tc_Sucursal ON dbo.ast_tt_Clientes_Asignados.Cod_Empresa = dbo.adm_tc_Sucursal.Cod_Empresa AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Sucursal = dbo.adm_tc_Sucursal.Cod_Sucursal INNER JOIN " +
                    "dbo.ast_tm_Personal ON dbo.ast_tt_Clientes_Asignados.Cod_Empresa = dbo.ast_tm_Personal.Cod_Empresa AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Empresa = dbo.ast_tm_Personal.Cod_Empresa AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Personal_Asignado = dbo.ast_tm_Personal.Cod_Personal INNER JOIN " +
                    "dbo.adm_tm_Personal_Sucursal ON dbo.ast_tt_Clientes_Asignados.Cod_Empresa = dbo.adm_tm_Personal_Sucursal.Cod_Empresa AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Personal_Asignado = dbo.adm_tm_Personal_Sucursal.Cod_Personal AND " +
                    "dbo.ast_tt_Clientes_Asignados.Cod_Sucursal = dbo.adm_tm_Personal_Sucursal.Cod_Sucursal " +
                    "WHERE Cod_Usuario='" + elUsuario + "' AND ast_tt_Clientes_Asignados.Tip_Estado_Asignacion='REGIONAL';";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvClientesAFacilitadores.DataSource = te;
            }
            this.gvClientesAFacilitadores.DataBind();
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

    protected void btnActualizar_cf_Click(object sender, EventArgs e)
    {
        MostrarListaDeClientesNuevos();
    }

    //protected void gvEventosProgramados_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    //{
    //    gvClientesAFacilitadores.PageIndex = e.NewPageIndex;
    //    MostrarListaDeClientesNuevos();
    //}
}