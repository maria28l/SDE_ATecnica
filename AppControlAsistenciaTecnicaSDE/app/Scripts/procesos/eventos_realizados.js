$().ready(function () {
    $('input[name*="dtpFecha_er"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
    $('input[name*="dtpFecRealizada_er"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'mm-dd-yy' });
    moment().format();
});

function MostrarFormEventoRealizado(empresa, codEvento, codTipoEvento, fecProgramada, fecRealizada, desVisita, estado) {
    $('#cCodEmpresa_er').hide();
    $('#cCodEvento_er').show();
    $('#cFecProgramada_er').show();
    $('#cCodTipoEvento_er').show();
    $('#cDesVisita_er').show();
    $('#cFecRealizada_er').show();
    $('#cEstadoEvento_er').hide();
    $('#cEstado_er').show();
    $('#cFechas_er').hide();

    $('#dlgFormEventosRealizados').modal();
    $('#btnGuardar_er').show();

    $('#btnGuardar_er').unbind("click");
    $('#btnGuardar_er').on('click', function () { return GuardarEventosRealizados(); });

    $('#txtCodEmpresa_er').val(empresa.toString());
    $('#txtCodEvento_er').val(codEvento.toString());
    var FP_Date = Date.parse(fecProgramada);
    fecha_p = new Date(FP_Date);
    $('#dtpFecProgramada_er').val(fecha_p.getDate() + "-" + (fecha_p.getMonth() + 1) + "-" + fecha_p.getFullYear()).toString();
    $('[name*="ddlTipoEvento_er"]').val(codTipoEvento.toString());
    $('#txtDesVisita_er').val(desVisita.toString());
    var FR_Date = Date.parse(fecRealizada);

    if (fecRealizada != "undefined" && fecRealizada != "" && fecRealizada != null)
    {
        fecha_r = new Date(FR_Date);
        $('#dtpFecRealizada_er').val(fecha_r.getDate() + "-" + (fecha_r.getMonth() + 1) + "-" + fecha_r.getFullYear()).toString();
    }

//    $('[name*="ddlEstadoEvento_er"]').val(tipEstadoEvento.toString());
    $('#ddlEstado_er').val(estado.toString());

    return false;
}

function GuardarEventosRealizados() {
    var params = new Object();
    var CodEvento = $('#txtCodEvento_er').val();
    var FecRealizada = $('#dtpFecRealizada_er').val();
    var DesVisita = $('#txtDesVisita_er').val();
    var TipEstadoReg = $("#ddlEstado_er option:selected").text();

    params.cod_evento = CodEvento;
    params.fec_realizada = FecRealizada;
    params.des_visita = DesVisita;
    params.tip_estado = TipEstadoReg;

    params = JSON.stringify(params);
    LaUrl = "/SdeAtWebService.asmx/Editar_EventoRealizado"
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
                __doPostBack('ctl00$MainContent$btnActualizar_er', "OnClick");
                                $("#dlgFormEventosRealizados").modal("hide");
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
