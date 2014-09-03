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
    /// Summary description for Territorio
    /// </summary>
 public class Territorio : ICloneable
    {
        
        private string mCod_Empresa = "";
        private string mCod_Territorio = "";
        private string mCod_Departamento = "";
        private int mCod_Registro = 0;        
        private string mTip_EstadoReg = "";
        private string mCod_Usuario_Creo = "";
        private DateTime mFec_Creado = DateTime.Now;
        private string mCod_Usuario_Modifico = "";
        private DateTime mFec_Modificado = DateTime.Now;
        private string mCad_Equipo = "";
        private string mCod_Municipio = "";
        private string mDes_Territorio = "";

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


        public string Des_Territorio
        {
            get
            {
                return mDes_Territorio;
            }
            set
            {
                mDes_Territorio = value;
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
        public Territorio()
        {
        }
        public Territorio(string Des_Territorio)
        {
            mDes_Territorio = Des_Territorio;
        }
        public Territorio(string Cod_Empresa, string Cod_Territorio, string Cod_Departamento, string Cod_Municipio, int Cod_Registro, string Des_Territorio, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Departamento = Cod_Departamento;
            mCod_Territorio = Cod_Territorio;
            mCod_Municipio = Cod_Municipio;
            mCod_Registro = Cod_Registro;
            mDes_Territorio = Des_Territorio;
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
        public Retorno Registrar_Territorio()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_Territorio", CommandType = CommandType.StoredProcedure };


                cmd.Parameters.Add("Cod_Territorio", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.Cod_Territorio;

                cmd.Parameters.Add("Des_Territorio", SqlDbType.NVarChar, 100);
                cmd.Parameters["Des_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Territorio"].Value = this.Des_Territorio;


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

        public Retorno Editar_Territorio()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Territorio";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Cod_Empresa", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Empresa"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Empresa"].Value = this.mCod_Empresa;

                cmd.Parameters.Add("Cod_Departamento", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Departamento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Departamento"].Value = this.mCod_Departamento;

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Municipio"].Value = this.mCod_Municipio;

                cmd.Parameters.Add("Cod_Territorio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.mCod_Territorio;

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.mCod_Registro;

                cmd.Parameters.Add("Des_Municipio", SqlDbType.NVarChar, 100);
                cmd.Parameters["Des_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Territorio"].Value = this.mDes_Territorio;

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


        public static DataTable Obtener_TablaTerritorioParaDdl(string codMunicipio)
        {
            DataTable ds;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerTerritorioParaDdl", CommandType = CommandType.StoredProcedure };                

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Value = codMunicipio;
                using (clsConexion con = new clsConexion())
                {
                    ds = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

     }
        
   }



