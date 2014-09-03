using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;
using System.Configuration;

namespace NitlapanTic.Sdeat.transacciones
{
    /// <summary>
    /// Summary description for ATecnica
    /// </summary>
    public class ATecnica : ICloneable
    {
        private string mCod_Empresa = "";
        private int mCod_ATecnica = 0;
        private int mCod_Registro = 0;
        private string mCod_Financiador = "";
        private string mCod_Cliente = "";
        private string mCod_Credito_Financiador = "";
        private string mCod_Facilitador = "";
        private string mCod_ProductoFinanciero = "";
        private string mDes_ATecnica = "";
        private string mDes_Propiedad = "";
        private string mCod_Departamento= "";
        private string mCod_Municipio= "";
        private string mCod_Sucursal = "";
        private string mCod_Territorio = "";
        private string mCad_Direccion = "";
        private float mVal_CoordX = 0;
        private float mVal_CoordY = 0;
        private int mVal_Eventos = 0;
        private DateTime mFec_Inicio_Asistencia = DateTime.Now;
        private string mTip_EstadoReg = "";
        private string mCod_Usuario_Creo = "";
        private DateTime mFec_Creado = DateTime.Now;
        private string mCod_Usuario_Modifico = "";
        private DateTime mFec_Modificado = DateTime.Now;
        private string mCad_Equipo = "";

        public string Cod_Empresa
        {
            get
            {
                return mCod_Empresa;
            }
            set
            {
                mCod_Empresa = value;
            }
        }

        public int Cod_ATecnica
        {
            get
            {
                return mCod_ATecnica;
            }
            set
            {
                mCod_ATecnica = value;
            }
        }

        public int Cod_Registro
        {
            get
            {
                return mCod_Registro;
            }
            set
            {
                mCod_Registro = value;
            }
        }

        public string Cod_Financiador
        {
            get
            {
                return mCod_Financiador;
            }
            set
            {
                mCod_Financiador = value;
            }
        }

        public string Cod_Cliente
        {
            get
            {
                return mCod_Cliente;
            }
            set
            {
                mCod_Cliente = value;
            }
        }

        public string Cod_Credito_Financiador
        {
            get
            {
                return mCod_Credito_Financiador;
            }
            set
            {
                mCod_Credito_Financiador = value;
            }
        }

        public string Cod_Facilitador
        {
            get
            {
                return mCod_Facilitador;
            }
            set
            {
                mCod_Facilitador = value;
            }
        }

        public string Cod_ProductoFinanciero
        {
            get
            {
                return mCod_ProductoFinanciero;
            }
            set
            {
                mCod_ProductoFinanciero = value;
            }
        }

        //klk
        public string Des_ATecnica
        {
            get
            {
                return mDes_ATecnica;
            }
            set
            {
                mDes_ATecnica = value;
            }
        }

        public string Des_Propiedad
        {
            get
            {
                return mDes_Propiedad;
            }
            set
            {
                mDes_Propiedad = value;
            }
        }

        public string Cod_Departamento
        {
            get
            {
                return mCod_Departamento;
            }
            set
            {
                mCod_Departamento = value;
            }
        }

        public string Cod_Municipio
        {
            get
            {
                return mCod_Municipio;
            }
            set
            {
                mCod_Municipio = value;
            }
        }

        public string Cod_Sucursal
        {
            get
            {
                return mCod_Sucursal;
            }
            set
            {
                mCod_Sucursal = value;
            }
        }

        public string Cod_Territorio
        {
            get
            {
                return mCod_Territorio;
            }
            set
            {
                mCod_Territorio = value;
            }
        }

        public string Cad_Direccion
        {
            get
            {
                return mCad_Direccion;
            }
            set
            {
                mCad_Direccion = value;
            }
        }
        
        public float Val_CoordX
        {
            get
            {
                return mVal_CoordX;
            }
            set
            {
                mVal_CoordX = value;
            }
        }

        public float Val_CoordY
        {
            get
            {
                return mVal_CoordY;
            }
            set
            {
                mVal_CoordY = value;
            }
        }

        public int Val_Eventos
        {
            get
            {
                return mVal_Eventos;
            }
            set
            {
                mVal_Eventos = value;
            }
        }

        public DateTime Fec_Inicio_Asistencia
        {
            get
            {
                return mFec_Inicio_Asistencia;
            }
            set
            {
                mFec_Inicio_Asistencia = value;
            }
        }

        public string Tip_EstadoReg
        {
            get
            {
                return mTip_EstadoReg;
            }
            set
            {
                mTip_EstadoReg = value;
            }
        }

        public string Cod_Usuario_Creo
        {
            get
            {
                return mCod_Usuario_Creo;
            }
            set
            {
                mCod_Usuario_Creo = value;
            }
        }

        public DateTime Fec_Creado
        {
            get
            {
                return mFec_Creado;
            }
            set
            {
                mFec_Creado = value;
            }
        }

        public string Cod_Usuario_Modifico
        {
            get
            {
                return mCod_Usuario_Modifico;
            }
            set
            {
                mCod_Usuario_Modifico = value;
            }
        }

        public DateTime Fec_Modificado
        {
            get
            {
                return mFec_Modificado;
            }
            set
            {
                mFec_Modificado = value;
            }
        }

        public string Cad_Equipo
        {
            get
            {
                return mCad_Equipo;
            }
            set
            {
                mCad_Equipo = value;
            }
        }

        public ATecnica()
        {
        }

        public ATecnica(string Cod_Empresa, int Cod_ATecnica, string Cod_Financiador, string Cod_Cliente, string Cod_Credito_Financiador, string Cod_Facilitador, string Cod_ProductoFinanciero, string Des_ATecnica, string Des_Propiedad, string Cod_Departamento, string Cod_Municipio, string Cod_Sucursal, string Cod_Territorio, string Cad_Direccion, float Val_CoordX, float Val_CoordY, int Val_Eventos, DateTime Fec_Inicio_Asistencia, int Cod_Registro, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_ATecnica = Cod_ATecnica;
            mCod_Financiador = Cod_Financiador;
            mCod_Cliente = Cod_Cliente;
            mCod_Credito_Financiador = Cod_Credito_Financiador;
            mCod_Facilitador = Cod_Facilitador;
            mCod_ProductoFinanciero = Cod_ProductoFinanciero;
            mDes_ATecnica = Des_ATecnica;
            mDes_Propiedad = Des_Propiedad;
            mCod_Departamento = Cod_Departamento;
            mCod_Municipio = Cod_Municipio;
            mCod_Sucursal = Cod_Sucursal;
            mCod_Territorio = Cod_Territorio;
            mCad_Direccion = Cad_Direccion;
            mVal_CoordX = Val_CoordX;
            mVal_CoordY = Val_CoordY;
            mVal_Eventos = Val_Eventos;
            mFec_Inicio_Asistencia = Fec_Inicio_Asistencia;
            mCod_Registro = Cod_Registro;
            mTip_EstadoReg = Tip_EstadoReg;
            mCod_Usuario_Creo = Cod_Usuario_Creo;
            mFec_Creado = Fec_Creado;
            mCod_Usuario_Modifico = Cod_Usuario_Modifico;
            mFec_Modificado = Fec_Modificado;
            mCad_Equipo = Cad_Equipo; 
        
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public Retorno Registrar_ATecnica()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_ATecnica", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cod_Financiador", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Financiador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Financiador"].Value = this.Cod_Financiador;

                cmd.Parameters.Add("Cod_Cliente", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Cliente"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cliente"].Value = this.Cod_Cliente;

                cmd.Parameters.Add("Cod_Credito_Financiador", SqlDbType.NVarChar, 10);
                cmd.Parameters["Cod_Credito_Financiador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Credito_Financiador"].Value = this.Cod_Credito_Financiador;

                cmd.Parameters.Add("Cod_Facilitador", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Facilitador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Facilitador"].Value = this.Cod_Facilitador;

                cmd.Parameters.Add("Cod_ProductoFinanciero", SqlDbType.Char, 4);
                cmd.Parameters["Cod_ProductoFinanciero"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_ProductoFinanciero"].Value = this.Cod_ProductoFinanciero;

                cmd.Parameters.Add("Des_ATecnica", SqlDbType.NVarChar, 200);
                cmd.Parameters["Des_ATecnica"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_ATecnica"].Value = this.Des_ATecnica;

                cmd.Parameters.Add("Des_Propiedad", SqlDbType.NVarChar, 100);
                cmd.Parameters["Des_Propiedad"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Propiedad"].Value = this.Des_Propiedad;

                cmd.Parameters.Add("Cod_Departamento", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Departamento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Departamento"].Value = this.Cod_Departamento;

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Municipio"].Value = this.Cod_Municipio;

                cmd.Parameters.Add("Cod_Sucursal", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Sucursal"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Sucursal"].Value = this.Cod_Sucursal;

                cmd.Parameters.Add("Cod_Territorio", SqlDbType.NVarChar, 5);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.Cod_Territorio;

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;

                cmd.Parameters.Add("Val_CoordX", SqlDbType.Decimal, 2);
                cmd.Parameters["Val_CoordX"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_CoordX"].Value = this.Val_CoordX;

                cmd.Parameters.Add("Val_CoordY", SqlDbType.Decimal, 2);
                cmd.Parameters["Val_CoordY"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_CoordY"].Value = this.Val_CoordY;

                cmd.Parameters.Add("Val_Eventos", SqlDbType.Int);
                cmd.Parameters["Val_Eventos"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_Eventos"].Value = this.Val_Eventos;

                cmd.Parameters.Add("Fec_Inicio_Asistencia", SqlDbType.DateTime);
                cmd.Parameters["Fec_Inicio_Asistencia"].Direction = ParameterDirection.Input;
                cmd.Parameters["Fec_Inicio_Asistencia"].Value = this.Fec_Inicio_Asistencia;

                cmd.Parameters.Add("Cod_Usuario_Creo", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cod_Usuario_Creo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Usuario_Creo"].Value = "REBECA";//HttpContext.Current.User.Identity.Name;        

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;

                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd, "Cod_Registro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public Retorno Editar_ATecnica()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_ATecnica";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Financiador", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Financiador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Financiador"].Value = this.Cod_Financiador;

                cmd.Parameters.Add("Cod_Cliente", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Cliente"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cliente"].Value = this.Cod_Cliente;

                cmd.Parameters.Add("Cod_Credito_Financiador", SqlDbType.NVarChar, 10);
                cmd.Parameters["Cod_Credito_Financiador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Credito_Financiador"].Value = this.Cod_Credito_Financiador;

                cmd.Parameters.Add("Cod_Facilitador", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Facilitador"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Facilitador"].Value = this.Cod_Facilitador;

                cmd.Parameters.Add("Cod_ProductoFinanciero", SqlDbType.Char, 4);
                cmd.Parameters["Cod_ProductoFinanciero"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_ProductoFinanciero"].Value = this.Cod_ProductoFinanciero;

                cmd.Parameters.Add("Des_ATecnica", SqlDbType.NVarChar, 200);
                cmd.Parameters["Des_ATecnica"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_ATecnica"].Value = this.Des_ATecnica;

                cmd.Parameters.Add("Des_Propiedad", SqlDbType.NVarChar, 100);
                cmd.Parameters["Des_Propiedad"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Propiedad"].Value = this.Des_Propiedad;

                cmd.Parameters.Add("Cod_Departamento", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Departamento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Departamento"].Value = this.Cod_Departamento;

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Municipio"].Value = this.Cod_Municipio;

                cmd.Parameters.Add("Cod_Sucursal", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Sucursal"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Sucursal"].Value = this.Cod_Sucursal;

                cmd.Parameters.Add("Cod_Territorio", SqlDbType.NVarChar, 5);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.Cod_Territorio;

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;

                cmd.Parameters.Add("Val_CoordX", SqlDbType.Decimal, 2);
                cmd.Parameters["Val_CoordX"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_CoordX"].Value = this.Val_CoordX;

                cmd.Parameters.Add("Val_CoordY", SqlDbType.Decimal, 2);
                cmd.Parameters["Val_CoordY"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_CoordY"].Value = this.Val_CoordY;

                cmd.Parameters.Add("Val_Eventos", SqlDbType.Int);
                cmd.Parameters["Val_Eventos"].Direction = ParameterDirection.Input;
                cmd.Parameters["Val_Eventos"].Value = this.Val_Eventos;

                cmd.Parameters.Add("Fec_Inicio_Asistencia", SqlDbType.DateTime);
                cmd.Parameters["Fec_Inicio_Asistencia"].Direction = ParameterDirection.Input;
                cmd.Parameters["Fec_Inicio_Asistencia"].Value = this.Fec_Inicio_Asistencia;

                cmd.Parameters.Add("Tip_EstadoReg", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_EstadoReg"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_EstadoReg"].Value = this.mTip_EstadoReg;

                cmd.Parameters.Add("Cod_ATecnica", SqlDbType.Int);
                cmd.Parameters["Cod_ATecnica"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_ATecnica"].Value = this.Cod_ATecnica;

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.Cod_Registro;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;

                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public Retorno Eliminar_ATecnica()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Eliminar_ATecnica";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_ATecnica", SqlDbType.Int);
                cmd.Parameters["Cod_ATecnica"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_ATecnica"].Value = this.Cod_ATecnica;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;

                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public static DataTable Obtener_TablaProductoFinancieroParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerProductosFinancierosParaDdl", CommandType = CommandType.StoredProcedure };

                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

         public static DataTable Obtener_TablaDepartamentosParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerDepartamentosParaDdl", CommandType = CommandType.StoredProcedure };
     
                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable Obtener_TablaMunicipioParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerMunicipioParaDdl", CommandType = CommandType.StoredProcedure };

                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable Obtener_TablaSucursalParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerSucursalParaDdl", CommandType = CommandType.StoredProcedure };

                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable Obtener_TablaTerritorioParaDdl(string codMunicipio)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerTerritorioParaDdl", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Value = codMunicipio;
                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static int  Obtener_EventosAProgramar(string codFinanciador, string codProdFinanciero)
        {

            try
            {
                 SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand("select dbo.ufn_CantEventos_a_Planificar('" + codFinanciador + "','" + codProdFinanciero + "') as cant_ev;", con );
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
