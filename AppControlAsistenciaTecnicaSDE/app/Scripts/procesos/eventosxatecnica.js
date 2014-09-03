$().ready(function () {
    $('input[name*="dtpFecha_ep"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
    $('input[name*="dtpFecProgramada_ep"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'mm-dd-yy' });
    moment().format();
});

function MostrarFormNuevoEventoProgramado() {
    $('#cCodRegistro_ep').hide();
    $('#cCodEmpresa_ep').hide();
    $('#cCodATecnica_ep').show();
    $('#cCodEvento_ep').hide();
    $('#cFecProgramada_ep').show();
    $('#cCodTipoEvento_ep').show();
    $('#cDesEvento_ep').show();
    $('#cEstadoEvento_ep').hide();
    $('#cEstado_ep').hide();
    $('#cFechas_ep').hide();

    $('#dlgFormEventosxATecnica').modal();

    $('#btnGuardar_ep').show();
    $('#btnEliminar_ep').hide();

    $('#btnGuardar_ep').unbind("click");
    $('#btnGuardar_ep').on('click', function () { return RegistrarNuevoEvento(); });//    RegistrarNuevoPersonal;

    var codigo_atecnica = $("[id*='hfCodATecnica']").val();

    $('#txtCodRegistro_ep').val('');
    $('#txtCodEmpresa_ep').val('');
    $('#txtCodATecnica_ep').val(codigo_atecnica);
    $('#txtCodEvento_ep').val('');
    $('#dtpFecProgramada_ep').val('');
    $('#ddlTipoEvento_ep').val('');
    $('#txtDesEvento_ep').val('');
    $('#ddlEstadoEvento_ep').val('');
    $('#ddlEstados_ep').val('');
}

function MostrarFormEditarEvento(registro, empresa, codATecnica, codEvento, fecProgramada, codTipoEvento, desEvento, tipEstadoEvento, estado, fecha) {
    $('#cCodRegistro_ep').hide();
    $('#cCodEmpresa_ep').hide();
    $('#cCodATecnica_ep').hide();
    $('#cCodEvento_ep').show();
    $('#cFecProgramada_ep').show();
    $('#cCodTipoEvento_ep').show();
    $('#cDesEvento_ep').show();
    $('#cEstadoEvento_ep').hide();
    $('#cEstado_ep').show();
    $('#cFechas_ep').hide();

    $('#dlgFormEventosxATecnica').modal();
    $('#btnGuardar_ep').show();
    $('#btnEliminar_ep').hide();

    $('#btnGuardar_ep').unbind("click");
    $('#btnGuardar_ep').on('click', function () { return GuardarDatosDeEventos(); }); 

    $('#txtCodRegistro_ep').val(registro.toString());
    $('#txtCodEmpresa_ep').val(empresa.toString());
    $('#txtCodATecnica_ep').val(codATecnica.toString());
    $('#txtCodEvento_ep').val(codEvento.toString());
    var FP_Date = Date.parse(fecProgramada);
    fecha_p = new Date(FP_Date);
    $('#dtpFecProgramada_ep').val(fecha_p.getDate() + "-" + (fecha_p.getMonth() + 1) + "-" + fecha_p.getFullYear()).toString();
    $('[name*="ddlTipoEvento_ep"]').val(codTipoEvento.toString());
    $('#txtDesEvento_ep').val(desEvento.toString());
    $('[name*="ddlEstadoEvento_ep"]').val(tipEstadoEvento.toString());
    $('#ddlEstados_ep').val(estado.toString());
    $('#dtpFechaCreacion_ep').val(fecha.toString());

    return false;
}

function MostrarFormEliminarEvento(codRegistro, codATecnica, codEvento, fecProgramada, codTipoEvento, desEvento, tipEstadoEvento, tipEstadoReg) {
    $('#cCodRegistro_ep').hide();
    $('#cCodEmpresa_ep').hide();
    $('#cCodATecnica_ep').hide();
    $('#cCodEvento_ep').show();
    $('#cFecProgramada_ep').show();
    $('#cCodTipoEvento_ep').show();
    $('#cDesEvento_ep').show();
    $('#cEstadoEvento_ep').show();
    $('#cEstado_ep').show();
    $('#cFechas_ep').hide();

    $('#dlgFormEventosxATecnica').modal();

    $('#btnGuardar_ep').hide();
    $('#btnEliminar_ep').show();

    $('#btnEliminar_ep').unbind("click");
    $('#btnEliminar_ep').on('click', function () { return EliminarEvento(); });  //EliminarPersonal

    $('#txtCodRegistro_ep').val(codRegistro.toString());
    $('#txtCodATecnica_ep').val(codATecnica.toString());
    $('#txtCodEvento_ep').val(codEvento.toString());
    var FP_Date = Date.parse(fecProgramada);
    fecha_p = new Date(FP_Date);
    $('#dtpFecProgramada_ep').val(fecha_p.getDate() + "-" + (fecha_p.getMonth() + 1) + "-" + fecha_p.getFullYear()).toString();
    $('[name*="ddlTipoEvento_ep"]').val(codTipoEvento.toString());
    $('#txtDesEvento_ep').val(desEvento.toString());
//    $('[name*="ddlEstadoEvento_ep"]').val(tipEstadoEvento.toString());
//    $('#ddlEstados_ep').val(tipEstadoReg.toString());
}

function GuardarDatosDeEventos() {
    var params = new Object();
//    var CodRegistro = $('#txtCodRegistro_ep').val();
//    var CodEmpresa = $('#txtCodEmpresa_ep').val();
    var CodEvento = $('#txtCodEvento_ep').val();
    var CodATecnica = $('#txtCodATecnica_ep').val();
    var FecProgramada = $('#dtpFecProgramada_ep').val();
    var CodTipoEvento = $('[name*="ddlTipoEvento_ep"]').val();
    var DesEvento = $('#txtDesEvento_ep').val();
//    var TipEstadoEvento = $("#ddlEstadoEvento_ep option:selected").text();
    var TipEstadoReg = $("#ddlEstados_ep option:selected").text();

//    params.cod_empresa = CodEmpresa;
    params.cod_atecnica = CodATecnica;
    params.cod_evento = CodEvento;
    params.fec_programada = FecProgramada;
    params.cod_tipoevento = CodTipoEvento;
    params.des_evento = DesEvento;
//    params.tip_estadoevento = TipEstadoEvento;
    params.tip_estado = TipEstadoReg;

    params = JSON.stringify(params);
    LaUrl = "/SdeAtWebService.asmx/Editar_EventoProgramado"
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
                __doPostBack('ctl00$MainContent$btnActualizar_ep', "OnClick");
//                $("#dlgFormEventosxATecnica").modal("hide");
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

function RegistrarNuevoEvento() {
    var params = new Object();
    var CodATecnica = $('#txtCodATecnica_ep').val();
    var FecProgramada = $('#dtpFecProgramada_ep').val();
    var CodTipoEvento = $('[name*="ddlTipoEvento_ep"]').val();
    var DesEvento = $('#txtDesEvento_ep').val();
    //    var TipEstadoEvento = $('[name*="ddlEstadoEvento_ep"]').val();

    if ((typeof CodTipoEvento != "undefined") && CodTipoEvento != "" && CodTipoEvento != null && CodTipoEvento != "00"
    //        && (typeof TipEstadoEvento != "undefined") && TipEstadoEvento != "" && TipEstadoEvento != null && TipEstadoEvento != "00"
        && DesEvento != "" && FecProgramada != "") {
        params.cod_atecnica = CodATecnica;
        params.fec_programada = FecProgramada;
        params.cod_tipoevento = CodTipoEvento;
        params.des_evento = DesEvento;
        //         params.tip_estadoevento = TipEstadoEvento;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Evento";
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
                    __doPostBack('ctl00$MainContent$btnActualizar_ep', "OnClick");
//                    $("#dlgFormEventosxATecnica").modal("hide");

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

function EliminarEvento() {
    var params = new Object();
    var CodATecnica = $('#txtCodATecnica_ep').val();
    var CodEvento = $('#txtCodEvento_ep').val();

    var resp = confirm("¿Está seguro que desea eliminar el Registro de Evento " + CodEvento.toString() + "?");

    if (resp == true) {
//        params.cod_atecnica = CodATecnica;
        params.cod_evento = CodEvento;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Evento";
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
                    __doPostBack('ctl00$MainContent$btnActualizar_ep', "OnClick");
//                    $("#dlgFormEventosxATecnica").modal("hide");
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
}

