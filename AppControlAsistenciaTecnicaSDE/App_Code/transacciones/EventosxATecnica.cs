using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;

namespace NitlapanTic.Sdeat.transacciones
{
    /// <summary>
    /// Descripción breve de EventosxATecnica
    /// </summary>
    public class EventosxATecnica:ICloneable
    {
        private string mCod_Empresa = "";
        private int mCod_Evento = 0;
        private int mCod_Registro = 0;
        private int mCod_ATecnica = 0;
        private string mCod_TipoEvento = "";
        private string mCod_Facilitador = "";
        private DateTime mFec_Programada = DateTime.Now;
        private DateTime mFec_Realizada = DateTime.Now;
        private DateTime mFec_Reporte_a_Finan = DateTime.Now;
        private string mDes_Evento = "";
        private float mMto_Evento_Tecnico = 0;
        private float mMto_Evento_Financiador = 0;
        private int mBit_Pagado_a_Tecnico = 0;
        private string mDes_Visita = "";
        private string mTip_Estado_Evento = "";
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
        public int Cod_Evento
        {
            get
            {
                return mCod_Evento;
            }
            set
            {
                mCod_Evento = value;
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
        public string Cod_TipoEvento
        {
            get
            {
                return mCod_TipoEvento;
            }
            set
            {
                mCod_TipoEvento = value;
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
        public DateTime Fec_Programada
        {
            get
            {
                return mFec_Programada;
            }
            set
            {
                mFec_Programada = value;
            }
        }
        public DateTime Fec_Realizada
        {
            get
            {
                return mFec_Realizada;
            }
            set
            {
                mFec_Realizada = value;
            }
        }
        public DateTime Fec_Reporte_a_Finan
        {
            get
            {
                return mFec_Reporte_a_Finan;
            }
            set
            {
                mFec_Reporte_a_Finan = value;
            }
        }
        public string Des_Evento
        {
            get
            {
                return mDes_Evento;
            }
            set
            {
                mDes_Evento = value;
            }
        }
        public float Mto_Evento_Tecnico
        {
            get
            {
                return mMto_Evento_Tecnico;
            }
            set
            {
                mMto_Evento_Tecnico = value;
            }
        }
        public float Mto_Evento_Financiador
        {
            get
            {
                return mMto_Evento_Financiador;
            }
            set
            {
                mMto_Evento_Financiador = value;
            }
        }
        public int Bit_Pagado_a_Tecnico
        {
            get
            {
                return mBit_Pagado_a_Tecnico;
            }
            set
            {
                mBit_Pagado_a_Tecnico = value;
            }
        }
        public string Des_Visita
        {
            get
            {
                return mDes_Visita;
            }
            set
            {
                mDes_Visita = value;
            }
        }
        public string Tip_Estado_Evento
        {
            get
            {
                return mTip_Estado_Evento;
            }
            set
            {
                mTip_Estado_Evento = value;
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

        public EventosxATecnica()
        {
        }

        public EventosxATecnica(string Cod_Empresa, int Cod_Evento, int Cod_Registro, int Cod_ATecnica, string Cod_TipoEvento, string Cod_Facilitador, DateTime Fec_Programada, DateTime Fec_Realizada, DateTime Fec_Reporte_a_Finan, string Des_Evento, float Mto_Evento_Tecnico, float Mto_Evento_Financiador, int Bit_Pagado_a_Tecnico, string Tip_Estado_Evento, string Tip_EstadoReg,             string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Evento = Cod_Evento;
            mCod_Registro = Cod_Registro;
            mCod_ATecnica = Cod_ATecnica;
            mCod_TipoEvento = Cod_TipoEvento;
            mCod_Facilitador = Cod_Facilitador;
            mFec_Programada = Fec_Programada;
            mFec_Realizada = Fec_Realizada;
            mFec_Reporte_a_Finan = Fec_Reporte_a_Finan;
            mDes_Evento = Des_Evento;
            mMto_Evento_Tecnico = Mto_Evento_Tecnico;
            mMto_Evento_Financiador = Mto_Evento_Financiador;
            mBit_Pagado_a_Tecnico = Bit_Pagado_a_Tecnico;
            mDes_Visita = Des_Visita;
            mTip_Estado_Evento = Tip_Estado_Evento;
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

        public Retorno Registrar_EventosxATecnica()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_Eventos_ATecnica", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cod_ATecnica", SqlDbType.Int, 2);
                cmd.Parameters["Cod_ATecnica"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_ATecnica"].Value = this.Cod_ATecnica;

                cmd.Parameters.Add("Cod_TipoEvento", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_TipoEvento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_TipoEvento"].Value = this.Cod_TipoEvento;

                cmd.Parameters.Add("Fec_Programada", SqlDbType.DateTime);
                cmd.Parameters["Fec_Programada"].Direction = ParameterDirection.Input;
                cmd.Parameters["Fec_Programada"].Value = this.Fec_Programada;

                cmd.Parameters.Add("Des_Evento", SqlDbType.NVarChar, 200);
                cmd.Parameters["Des_Evento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Evento"].Value = this.Des_Evento;

                cmd.Parameters.Add("Cod_Usuario_Creo", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cod_Usuario_Creo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Usuario_Creo"].Value = "";//HttpContext.Current.User.Identity.Name;        

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

        public Retorno Editar_Eventos_Programados()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Eventos_Programados";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_TipoEvento", SqlDbType.Char, 5);
                cmd.Parameters["Cod_TipoEvento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_TipoEvento"].Value = this.Cod_TipoEvento;

                cmd.Parameters.Add("Fec_Programada", SqlDbType.DateTime);
                cmd.Parameters["Fec_Programada"].Direction = ParameterDirection.Input;
                cmd.Parameters["Fec_Programada"].Value = this.Fec_Programada;

                cmd.Parameters.Add("Des_Evento", SqlDbType.NVarChar, 200);
                cmd.Parameters["Des_Evento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Evento"].Value = this.Des_Evento;

                cmd.Parameters.Add("Tip_EstadoReg", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_EstadoReg"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_EstadoReg"].Value = this.mTip_EstadoReg;

                cmd.Parameters.Add("Cod_Evento", SqlDbType.Int);
                cmd.Parameters["Cod_Evento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Evento"].Value = this.Cod_Evento;

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

        public Retorno Editar_Eventos_Realizados()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Eventos_Realizados";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Fec_Realizada", SqlDbType.DateTime);
                cmd.Parameters["Fec_Realizada"].Direction = ParameterDirection.Input;
                cmd.Parameters["Fec_Realizada"].Value = this.Fec_Realizada;

                cmd.Parameters.Add("Des_Visita", SqlDbType.NVarChar, 350);
                cmd.Parameters["Des_Visita"].Direction = ParameterDirection.Input;
                cmd.Parameters["Des_Visita"].Value = this.Des_Visita;

                cmd.Parameters.Add("Tip_EstadoReg", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_EstadoReg"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_EstadoReg"].Value = this.mTip_EstadoReg;

                cmd.Parameters.Add("Cod_Evento", SqlDbType.Int);
                cmd.Parameters["Cod_Evento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Evento"].Value = this.Cod_Evento;

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

        public Retorno Eliminar_Eventos_Programados()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Eliminar_Evento_Programado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Evento", SqlDbType.Int);
                cmd.Parameters["Cod_Evento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Evento"].Value = this.Cod_Evento;

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

        public static DataTable Obtener_TablaTipoEventoParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerTiposEventosParaDdl", CommandType = CommandType.StoredProcedure };

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
        
        public static DataTable Obtener_TablaTipoEventoxConvParaDdl(int codATecnica)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerTiposEventosxConvenioParaDdl", CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("cod_ATecnica", SqlDbType.Int);
                cmd.Parameters["cod_ATecnica"].Value = codATecnica;
 
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
    }
}