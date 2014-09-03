using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NitlapanTic.Sdeat.Util{
/// <summary>
/// Clase utilizada para el retorno de los métodos de ejecución de consulta de la clase clsConexion.
/// </summary>
public class Retorno
{

    #region Variables Privadas

    protected bool _Resultado_;
    protected string _Mensaje_;
    protected int _id_;

    #endregion

    #region Propiedades

    public bool Resultado
    {
        get { return _Resultado_; }
        set { _Resultado_ = value; }
    }

    public string Mensaje
    {
        get { return _Mensaje_; }
        set { _Mensaje_ = value; }
    }

    public int id
    {
        get { return _id_; }
        set { _id_ = value; }
    }

    #endregion


    #region Constructores

    /// <summary>
    /// Constructor por defecto de la clase inicializando con valores por defecto.
    /// </summary>
    public Retorno()
    {
        _Resultado_ = false;
        _Mensaje_ = String.Empty;
        _id_ = 0;
    }

    /// <summary>
    /// Constructor inicializando los valores de la clase.
    /// </summary>
    /// <param name="pRetorno">Valor de retorno (True o False).</param>
    /// <param name="pMensaje">Mensaje que envía la clase de conexión.</param>
    /// <param name="pId">Id del registro creado o actualizado (si se requiere).</param>
    public Retorno(bool pRetorno, string pMensaje, int pId)
    {
        _Resultado_ = pRetorno;
        _Mensaje_ = pMensaje;
        _id_ = pId;
    }
    #endregion
}
}