using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;

namespace NitlapanTic.Sdeat.Catalogos
{
    /// <summary>
    /// Summary description for Cargo
    /// </summary>
    public class Cargo : ICloneable
    {

        private string mCod_Empresa = "";
        private string mCod_Cargo = "";
        private int mCod_Registro = 0;
        private string mDes_Cargo = "";
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

        public string Cod_Cargo
        {
            get
            {
                return mCod_Cargo;
            }
            set
            {
                mCod_Cargo = value;
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

        public string Des_Cargo
        {
            get
            {
                return mDes_Cargo;
            }
            set
            {
                mDes_Cargo = value;
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
        public  Cargo ()
        {
        }
        public Cargo(string Des_Cargo)
        {
            mDes_Cargo = Des_Cargo;
        }
        public Cargo(string Cod_Empresa, string Cod_Cargo, int Cod_Registro, string Des_Cargo, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Cargo = Cod_Cargo;
            mCod_Registro = Cod_Registro;
            mDes_Cargo = Des_Cargo;
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
        public Retorno Registrar_Cargo()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_Cargo", CommandType = CommandType.StoredProcedure };

                //cmd.Parameters.Add("Cod_Empresa", SqlDbType.Char, 2);
                //cmd.Parameters["Cod_Empresa"].Direction = ParameterDirection.Input;
                //cmd.Parameters["Cod_Empresa"].Value =  this.Cod_Empresa;

                cmd.Parameters.Add("Des_Cargo", SqlDbType.NVarChar, 100);
                cmd.Parameters["Des_Cargo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Cargo"].Value = this.Des_Cargo;

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

        public Retorno Editar_Cargo()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Cargo";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Empresa", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Empresa"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Empresa"].Value = this.mCod_Empresa;

                cmd.Parameters.Add("Cod_Cargo", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Cargo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cargo"].Value = this.mCod_Cargo;


                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.mCod_Registro;

                cmd.Parameters.Add("Des_Cargo", SqlDbType.NVarChar, 70);
                cmd.Parameters["Des_Cargo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Cargo"].Value = this.mDes_Cargo;

                cmd.Parameters.Add("Tip_EstadoReg", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_EstadoReg"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_EstadoReg"].Value = this.mTip_EstadoReg;

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
        public Retorno Eliminar_Cargo()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Eliminar_Cargo";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.mCod_Registro;

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

        public static DataTable Obtener_TablaCargoParaDdl()
        {
            DataTable dc;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerCargoParaDdl", CommandType = CommandType.StoredProcedure };

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
}
