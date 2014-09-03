$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
    $('input[name*="dtpFecInicioAsistencia"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'mm-dd-yy' });
    moment().format();

    //Evento del dropdownlist FINANCIADOR que invoca el llenado de Clientes
    $("[id*='ddlFinanciador']").change(function () {
        //este parametro mapeara con el definido en el web service
        var params = new Object();
        params.financiador = $("[id*='ddlFinanciador']").val();
        params.cod_usuario = $('#txtCodUsuario').val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/SdeAtWebService.asmx/ObtenerClientesxFinanciador",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var clientes = result.d;
                $("[id*='ddlCliente']").html("");
                $.each(clientes, function (index, cliente) {
                    $("[id*='ddlCliente']").append($("<option></option>").attr("value", cliente.Cod_Cliente).text(cliente.Cad_Nombre_Completo));
                });
                //ahora el llenado de prodfinanciero
                $.ajax({
                    type: "POST",
                    url: "/SdeAtWebService.asmx/ObtenerProdFinxFinanciador",
                    data: params,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        var productos = result.d;
                        $("[id*='ddlProductoFinanciero']").html("");
                        $.each(productos, function (index, producto) {
                            $("[id*='ddlProductoFinanciero']").append($("<option></option>").attr("value", producto.Cod_ProdFinanciero).text(producto.Des_ProdFinanciero));
                        });
                        //ahora la búsqueda de cantidad de eventos
                        var CodFinanciador = $('[name*="ddlFinanciador"]').val();
                        var CodProductoFinanciero = $('[name*="ddlProductoFinanciero"]').val();

                        if (typeof CodFinanciador != "undefined" && CodFinanciador != "" && CodFinanciador != null && CodFinanciador != "00"
                            && typeof CodProductoFinanciero != "undefined" && CodProductoFinanciero != "" && CodProductoFinanciero != null && CodProductoFinanciero != "00") {
                            //este parametro mapeara con el definido en el web service
                            var params2 = new Object();
                            params2.financiador = $("[id*='ddlFinanciador']").val();
                            params2.prodfinanciero = $("[id*='ddlProductoFinanciero']").val();
                            params2 = JSON.stringify(params2);

                            $.ajax({
                                type: "POST",
                                url: "/SdeAtWebService.asmx/ObtenerEventosAProgramar",
                                data: params2,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function (result) {
                                    var eventos = result.d; //.toString();
                                    $('#txtValEventos').val(eventos.toString());
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                                }
                            });

                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
                //
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
    //Fin del evento ddlFINANCIADOR

    //Evento del dropdownlist Sucursal que invoca el llenado de Facilitadores
    $("[id*='ddlSucursal']").change(function () {
        //este parametro mapeara con el definido en el web service
        var params = new Object();
        params.sucursal = $("[id*='ddlSucursal']").val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/SdeAtWebService.asmx/ObtenerFacilitadoresxSucursal",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var facilitadores = result.d;
                $("[id*='ddlFacilitador]").html("");
                $.each(facilitadores, function (index, facilitador) {
                    $("[id*='ddlFacilitador']").append($("<option></option>").attr("value", facilitador.Cod_Personal).text(facilitador.Cad_Nombre_Completo));
                });
                $('#ddlFacilitador').$('#txtCodUsuario').val(); ;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
    //Fin del evento ddlFINANCIADOR

    //Evento del dropdownlist departamento que invoca el llenado de municipio
    $("[id*='ddlDepartamento']").change(function () {
        //este parametro mapeara con el definido en el web service
        var params = new Object();
        params.departamento = $("[id*='ddlDepartamento']").val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/SdeAtWebService.asmx/ObtenerMunicipiosxDepartamento",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var municipios = result.d;
                $("[id*='ddlMunicipio']").html("");
                $.each(municipios, function (index, municipio) {
                    $("[id*='ddlMunicipio']").append($("<option></option>").attr("value", municipio.Cod_Municipio).text(municipio.Des_Municipio));
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
    //Fin del evento ddlDepartamento

    //Evento del dropdownlist municipio que invoca el llenado de territorio
    $("[id*='ddlMunicipio']").change(function () {
        //este parametro mapeara con el definido en el web service
        var params = new Object();
        params.municipio = $("[id*='ddlMunicipio']").val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/SdeAtWebService.asmx/ObtenerTerritoriosxMunicipio",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                var territorios = result.d;
                $("[id*='ddlTerritorio']").html("");
                $.each(territorios, function (index, territorio) {
                    $("[id*='ddlTerritorio']").append($("<option></option>").attr("value", territorio.Cod_Territorio).text(territorio.Des_Territorio));
                });
                //ahora el llenado de sucursal
                $.ajax({
                    type: "POST",
                    url: "/SdeAtWebService.asmx/ObtenerSucursalesxMunicipio",
                    data: params,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        var sucursales = result.d;
                        $("[id*='ddlSucursal']").html("");
                        $.each(sucursales, function (index, sucursal) {
                            $("[id*='ddlSucursal']").append($("<option></option>").attr("value", sucursal.Cod_Sucursal).text(sucursal.Des_Sucursal));
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
                //

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });

    });
    //Fin del evento ddlMunicipio

    //Evento del dropdownlist ProdFinanciero para buscar cantidad de eventos propuestos
    $("[id*='ddlProductoFinanciero']").change(function () {
        var CodFinanciador = $('[name*="ddlFinanciador"]').val();
        var CodProductoFinanciero = $('[name*="ddlProductoFinanciero"]').val();

        if (typeof CodFinanciador != "undefined" && CodFinanciador != "" && CodFinanciador != null && CodFinanciador != "00"
            && typeof CodProductoFinanciero != "undefined" && CodProductoFinanciero != "" && CodProductoFinanciero != null && CodProductoFinanciero != "00") {
            //este parametro mapeara con el definido en el web service
            var params = new Object();
            params.financiador = $("[id*='ddlFinanciador']").val();
            params.prodfinanciero = $("[id*='ddlProductoFinanciero']").val();
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "/SdeAtWebService.asmx/ObtenerEventosAProgramar",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    var eventos = result.d; //.toString();
                    $('#txtValEventos').val(eventos.toString());
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });

        }
    });
    //Fin del evento ddlProdFinanciero

});

function MostrarEventosDeATecnica(cod_atecnica) {
    $('#dlgEventosxATecnica').dialog({
        modal: true,
        height: 400,
        width: 800,
        title: 'Eventos x Asistencia Tecnica',
        open: function () {
            $(this).load('EventosxATecnica.aspx?Cod_ATecnica=' + cod_atecnica.toString());
        },
        close: function (ev, ui) { $(this).dialog("destroy"); }
    });
}

function MostrarFormNuevaATecnica() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodUsuario').hide();
    $('#cCodATecnica').hide();
    $('#cCodFinanciador').show();
    $('#cCodCliente').show();
    $('#cCodCreditoFinanciador').show();
    $('#cCodFacilitador').show();
    $('#cCodProductoFinanciero').show();
    $('#cDesATecnica').show();
    $('#cDesPropiedad').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCodSucursal').show();
    $('#cCadDireccion').show();
    $('#cValCoordX').show();
    $('#cValCoordY').show();
    $('#cValEventos').show();
    $('#cFecInicioAsistencia').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioATecnica').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevaATecnica(); });//    RegistrarNuevoPersonal;

    var codusuario = $("[id*='hfCodUsuario']").val();

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodUsuario').val(codusuario.toString());
    $('#txtCodATecnica').val('');
    $('#ddlFinanciador').val('');
    $('#ddlCliente').val('');
    $('#txtCodCreditoFinanciador').val('');
    $('#ddlFacilitador').val('');
    $('#ddlProductoFinanciero').val('');
    $('#txtDesATecnica').val('');
    $('#txtDesPropiedad').val('');
    $('#ddlDepartamento').val('');
    $('#ddlMunicipio').val('');
    $('#ddlSucursal').val('');
    $('#ddlTerritorio').val('');
    $('#txtCadDireccion').val('');
    $('#txtValCoordX').val('');
    $('#txtValCoordY').val('');
    $('#txtValEventos').val('');
//    $('#dtpFecInicioAsistencia').val('');
    $('#ddlEstados').val('');

}

function MostrarFormEliminar(codRegistro, codATecnica, codUsuario, codFinanciador, codCliente, codFacilitador, codProductoFinanciero, desATecnica, valEventos, fecInicioAsistencia, tipEstadoReg ) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodUsuario').hide();
    $('#cCodATecnica').show();
    $('#cCodFinanciador').show();
    $('#cCodCliente').show();
    $('#cCodCreditoFinanciador').hide();
    $('#cCodFacilitador').show();
    $('#cCodProductoFinanciero').show();
    $('#cDesATecnica').show();
    $('#cDesPropiedad').hide();
    $('#cCodDepartamento').hide();
    $('#cCodMunicipio').hide();
    $('#cCodSucursal').hide();
    $('#cCodTerritorio').hide();
    $('#cCadDireccion').hide();
    $('#cValCoordX').hide();
    $('#cValCoordY').hide();
    $('#cValEventos').show();
    $('#cFecInicioAsistencia').show();
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioATecnica').modal();    

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarATecnica(); });  //EliminarPersonal

    $('#txtCodRegistro').val(codRegistro.toString());
    $('#txtCodATecnica').val(codATecnica.toString());
    $('#txtCodUsuario').val(codUsuario.toString());

    $('[name*="ddlFinanciador"]').val(codFinanciador.toString());
    $('[name*="ddlCliente"]').val(codCliente.toString());
    $('[name*="ddlFacilitador"]').val(codFacilitador.toString());
    $('[name*="ddlProductoFinanciero"]').val(codProductoFinanciero.toString());
    $('#txtDesATecnica').val(desATecnica.toString());
    $('#txtValEventos').val(valEventos.toString());
    var FIA_Date = Date.parse(fecInicioAsistencia);
    fecha_ia = new Date(FIA_Date);
    //    $('#dtpFecInicioAsistencia').val(fecha_ia.getDate() + "-" + (fecha_ia.getMonth() + 1) + "-" + fecha_ia.getFullYear()).toString();
    $('#dtpFecInicioAsistencia').val((fecha_ia.getMonth() + 1) + "-" + fecha_ia.getDate() + "-" + fecha_ia.getFullYear()).toString();
    $('#ddlEstados').val(tipEstadoReg.toString());
   
}

function MostrarFormEditar(registro, empresa, codusuario, codatecnica, codfinanciador, codcliente, codcreditofinanciador, codfacilitador, codproductofinanciero, desatecnica, despropiedad, coddepartamento, codmunicipio, codsucursal, codterritorio, caddireccion, valcoordx, valcoordy, valeventos, fecinicioasistencia, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodUsuario').hide();
    $('#cCodATecnica').show();
    $('#cCodFinanciador').show();
    $('#cCodCliente').show();
    $('#cCodCreditoFinanciador').show();
    $('#cCodFacilitador').show();
    $('#cCodProductoFinanciero').show();
    $('#cDesATecnica').show();
    $('#cDesPropiedad').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCodSucursal').show();
    $('#cCodTerritorio').show();
    $('#cCadDireccion').show();
    $('#cValCoordX').show();
    $('#cValCoordY').show();
    $('#cValEventos').show();
    $('#cFecInicioAsistencia').show();
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioATecnica').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeATecnica(); }); //GuardarDatosDePersonal
   
    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodUsuario').val(codusuario.toString());
    $('#txtCodATecnica').val(codatecnica.toString());
    $('[name*="ddlFinanciador"]').val(codfinanciador.toString());
    $('[name*="ddlFinanciador"]').change();
    $('[name*="ddlCliente"]').val(codcliente.toString());
    $('#txtCodCreditoFinanciador').val(codcreditofinanciador.toString());
    $('[name*="ddlProductoFinanciero"]').val(codproductofinanciero.toString());
    $('#txtDesATecnica').val(desatecnica.toString());
    $('#txtDesPropiedad').val(despropiedad.toString());
    $('[name*="ddlDepartamento"]').val(coddepartamento.toString());
    $('[name*="ddlDepartamento"]').change();
    $('[name*="ddlMunicipio"]').val(codmunicipio.toString());
    $('[name*="ddlMunicipio"]').change();
    $('[name*="ddlSucursal"]').val(codsucursal.toString());
    $('[name*="ddlSucursal"]').change();
    $('[name*="ddlTerritorio"]').val(codterritorio.toString());
    $('[name*="ddlFacilitador"]').val(codfacilitador.toString());
    $('#txtCadDireccion').val(caddireccion.toString());
    $('#txtValCoordX').val(valcoordx.toString());
    $('#txtValCoordY').val(valcoordy.toString());
    $('#txtValEventos').val(valeventos.toString());
    var FIA_Date = Date.parse(fecinicioasistencia);
    fecha_ia = new Date(FIA_Date);
    $('#dtpFecInicioAsistencia').val(fecha_ia.getDate() + "-" + (fecha_ia.getMonth() + 1) + "-" + fecha_ia.getFullYear()).toString();
//    $('#dtpFecInicioAsistencia').val(fecinicioasistencia.toString());
    $('#ddlEstados').val(estado.toString());
    $('#dtpFechaCreacion').val(fecha.toString());  
    
        return false;
}

function RegistrarNuevaATecnica() { //ESTA FUNCIÓN MÁS BIEN PARECE EDITAR Y NO NUEVA
    var params = new Object();
    var CodFinanciador = $('[name*="ddlFinanciador"]').val(); 
    var CodCliente = $('[name*="ddlCliente"]').val();
    var CodCreditoFinanciador = $('#txtCodCreditoFinanciador').val();
    var CodFacilitador = $('[name*="ddlFacilitador"]').val();
    var CodProductoFinanciero = $('[name*="ddlProductoFinanciero"]').val();
    var DesATecnica = $('#txtDesATecnica').val();
    var DesPropiedad = $('#txtDesPropiedad').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val(); 
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();   
    var CodSucursal = $('[name*="ddlSucursal"]').val();
    var CodTerritorio = $('[name*="ddlTerritorio"]').val();  
    var CadDireccion = $('#txtCadDireccion').val();
    var ValCoordX = $('#txtValCoordX').val();
    var ValCoordY = $('#txtValCoordY').val();
    var ValEventos = $('#txtValEventos').val();
    var FecInicioAsistencia = $('#dtpFecInicioAsistencia').val();

    if ((typeof CodFinanciador != "undefined") && CodFinanciador != "" && CodFinanciador != null && CodFinanciador != "00"
        && (typeof CodCliente != "undefined") && CodCliente != "" && CodCliente != null && CodCliente != "00"
//        && CodCreditoFinanciador != ""
        && typeof CodFacilitador != "undefined"  && CodFacilitador != "" && CodFacilitador != null && CodFacilitador != "00"
        && typeof CodProductoFinanciero != "undefined" && CodProductoFinanciero != "" && CodProductoFinanciero != null && CodProductoFinanciero != "00"
        && DesATecnica != "" && DesPropiedad != ""
        && (typeof CodDepartamento != "undefined") && CodDepartamento != "" && CodDepartamento != null && CodDepartamento != "00"
        && (typeof CodMunicipio != "undefined") && CodMunicipio != "" && CodMunicipio != null && CodMunicipio != "00"
        && (typeof CodSucursal != "undefined") && CodSucursal != "" && CodSucursal != null && CodSucursal != "00"
        && CadDireccion != "" && ValCoordX != "" && ValCoordY != "" && ValEventos != "" && FecInicioAsistencia != "")
//        && (typeof CodTerritorio != "undefined") && CodTerritorio != "" && CodTerritorio != null && CodTerritorio != "00"
         
     {
        params.cod_financiador = CodFinanciador;
        params.cod_cliente = CodCliente;
        params.cod_credito_financiador = CodCreditoFinanciador;
        params.cod_facilitador = CodFacilitador;
        params.cod_productofinanciero = CodProductoFinanciero;
        params.des_atecnica = DesATecnica;
        params.des_propiedad = DesPropiedad;
        params.cod_departamento = CodDepartamento;
        params.cod_municipio = CodMunicipio;
        params.cod_sucursal = CodSucursal;
        if((typeof CodTerritorio != "undefined") && CodTerritorio != "" && CodTerritorio != null && CodTerritorio != "00")
        {
            params.cod_territorio = CodTerritorio;
        }
        params.cad_direccion = CadDireccion;
        params.val_coordx = ValCoordX;
        params.val_coordy = ValCoordY;
        params.val_eventos = ValEventos;
        params.fec_inicio_asistencia = FecInicioAsistencia;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_ATecnica";
        $.ajax({
            type: 'POST', //Tipo de petición
            url: LaUrl, // Url y metodo que se invoca
            data: params, //Necesario cuando queremos mandar algun parametro
            contentType: 'application/json; charset=utf-8',
            dataType: 'json', //Tipo de dato con el que se realiza la llamada
            success: function (data) { //Procesar el valor del método invocado
                var valor = data.d.Resultado;
                if (valor == "1" || valor == "true") {
                    alert(data.d.Mensaje);
                    __doPostBack('ctl00$MainContent$btnActualizar', "OnClick");
                    $("#dlgFormularioATecnica").modal("hide");

                }
                else {
                    alert(data.d.Mensaje);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(textStatus + ": " + jqXHR.responseText);
            }

        });
    }
    else {
        alert("Los Campos con asterisco *son obligatorios.");
          }

    return false;
}

function GuardarDatosDeATecnica() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodUsuario = $('#txtCodUsuario').val();
    var CodFinanciador = $('[name*="ddlFinanciador"]').val(); 
    var CodCliente = $('[name*="ddlCliente"]').val();
    var CodCreditoFinanciador = $('#txtCodCreditoFinanciador').val();
    var CodFacilitador = $('[name*="ddlFacilitador"]').val();
    var CodProductoFinanciero = $('[name*="ddlProductoFinanciero"]').val();
    var DesATecnica = $('#txtDesATecnica').val();
    var DesPropiedad = $('#txtDesPropiedad').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val(); 
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();   
    var CodSucursal = $('[name*="ddlSucursal"]').val();
    var CodTerritorio = $('[name*="ddlTerritorio"]').val();  
    var CadDireccion = $('#txtCadDireccion').val();
    var ValCoordX = $('#txtValCoordX').val();
    var ValCoordY = $('#txtValCoordY').val();
    var ValEventos = $('#txtValEventos').val();
    var FecInicioAsistencia = $('#dtpFecInicioAsistencia').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();
    var CodATecnica = $('#txtCodATecnica').val();

    params.cod_empresa = CodEmpresa;
    params.cod_registro = CodRegistro;
    params.cod_financiador = CodFinanciador;
    params.cod_cliente = CodCliente;
    params.cod_credito_financiador = CodCreditoFinanciador;
    params.cod_facilitador = CodFacilitador;
    params.cod_productofinanciero = CodProductoFinanciero;
    params.des_atecnica = DesATecnica;
    params.des_propiedad = DesPropiedad;
    params.cod_departamento = CodDepartamento;
    params.cod_municipio = CodMunicipio;
    params.cod_sucursal = CodSucursal;
    if((typeof CodTerritorio != "undefined") && CodTerritorio != "" && CodTerritorio != null && CodTerritorio != "00")
    {
        params.cod_territorio = CodTerritorio;
    }
    params.cad_direccion = CadDireccion;
    params.val_coordx = ValCoordX;
    params.val_coordy = ValCoordY;
    params.val_eventos = ValEventos;
    params.fec_inicio_asistencia = FecInicioAsistencia;
    params.tipo_estado = elTipEstadoReg;
    params.cod_atecnica = CodATecnica;

    params = JSON.stringify(params);
    LaUrl = "/SdeAtWebService.asmx/Editar_ATecnica"
    $.ajax({
        type: 'POST', //Tipo de petición
        url: LaUrl, // Url y metodo que se invoca
        data: params, //Necesario cuando queremos mandar algun parametro
        contentType: 'application/json; charset=utf-8',
        dataType: 'json', //Tipo de dato con el que se realiza la llamada
        success: function (data) { //Procesar el valor del método invocado
            var valor = data.d.Resultado;
            if (valor == "1" || valor == "true") {
                alert(data.d.Mensaje);
                __doPostBack('ctl00$MainContent$btnActualizar', "OnClick");
                $("#dlgFormularioATecnica").modal("hide");
            }
            else {
                alert(data.d.Mensaje);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus + ": " + jqXHR.responseText);
        }
    });
        
    return false;
}

//AQUI VOY EN LA PERSONALIZACIÓN PARA ATECNICA.
function EliminarATecnica() {
    var params = new Object();
    var CodATecnica = $('#txtCodATecnica').val();

    var resp = confirm("¿Estás seguro que deseas eliminar el Registro de Asistencia Técnica " + CodATecnica.toString() + "?");
    
    if (resp == true) {
        params.cod_atecnica = CodATecnica;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_ATecnica";
        $.ajax({
            type: 'POST', //Tipo de petición
            url: LaUrl, // Url y metodo que se invoca
            data: params, //Necesario cuando queremos mandar algun parametro
            contentType: 'application/json; charset=utf-8',
            dataType: 'json', //Tipo de dato con el que se realiza la llamada
            success: function (data) { //Procesar el valor del método invocado
                var valor = data.d.Resultado;
                if (valor == "1" || valor == "true") {
                    alert(data.d.Mensaje);
                    __doPostBack('ctl00$MainContent$btnActualizar', "OnClick");
                    $("#dlgFormularioATecnica").modal("hide");
                }
                else {
                    alert(data.d.Mensaje);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(textStatus + ": " + jqXHR.responseText);
            }
        });
    }
    
    return false;
}//-->