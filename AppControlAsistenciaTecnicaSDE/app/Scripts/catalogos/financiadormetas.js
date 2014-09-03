$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();

    //para generar el menu de años
    var i = 0;
    $('#CodAnioPicker').append($('<option />').val(i).html('-SELECCIONA-'));
    for (i = new Date().getFullYear(); i > 2000; i--) {
        $('#CodAnioPicker').append($('<option />').val(i).html(i));
    }
});

function MostrarFormNuevoFinanciadorMetas() {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').show();
    $('#cCodAnio').show();
    $('#cCodProdFinanciero').show();
    $('#cValClientesNuevos').show();
    $('#cMtoPagoxEvento').show();
    $('#cValTotEventos').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciadorMetas').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoFinanciadorMetas(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodFinanciador').val('');

    $('#txtValClientesNuevos').val('');
    $('#txtMtoPagoxEvento').val('');
    $('#txtValTotEventos').val('');
    $('#txtTipEstadoReg').val('');


}
function MostrarFormEliminar(codRegistro, cod_Financiador, desc_Financiador) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').show();
    $('#cCodAnio').show();
    $('#cCodProdFinanciero').show();
    $('#cValClientesNuevos').show();
    $('#cMtoPagoxEvento').show();
    $('#cValTotEventos').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciadorMetas').modal();

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarFinanciadorMetas(); });

    $('#txtCodRegistro').val(codRegistro.toString());
    $('#txtCodFinanciador').val(cod_Financiador.toString());
    $('#txtDesFinanciador').val(desc_Financiador.toString());
}
function MostrarFormEditar(registro, empresa, codfinanciador, codanio, codprodfinanciero, valclientesnuevos, mtopagoxevento, valtoteventos, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').show();
    $('#cCodAnio').show();
    $('#cCodProdFinanciero').show();
    $('#cValClientesNuevos').show();
    $('#cMtoPagoxEvento').show();
    $('#cValTotEventos').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciadorMetas').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeFinanciadorMetas(); });

    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodFinanciador').val(codfinanciador.toString());
    $('#txtCodAnio').val(codanio.toString());
    $('[name*="ddlCodProdFinanciero"]').val(codprodfinanciero.toString());
    $('#txtValClientesNuevos').val(valclientesnuevos.toString());
    $('#txtMtoPagoxEvento').val(mtopagoxevento.toString());
    $('#txtValTotEventos').val(valtoteventos.toString());
    $('#txtTipEstadoReg').val(estado.toString());
    $('#dtpFechaCreacion').val(fecha.toString());

    return false;
}
function RegistrarNuevoFinanciadorMetas() {
    var params = new Object();
    var CodFinanciador = $('#txtCodFinanciador').val();
    var CodProdFinanciador = $('[name*="ddlCodProdFinanciero"]').val();


    if (CodFinanciador != "" || CodProdFinanciador != "") {
        params.cod_financiador = CodFinanciador;
        params.cod_prod_financiadordes_financiador = CodProdFinanciador;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_FinanciadorMetas";
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
                    $("#dlgFormularioFinanciadorMetas").modal("hide");
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
        alert("No debe estar vacio los campos con asteriscos *.");
         }

    return false;
}
function GuardarDatosDeFinanciadorMetas() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodFinanciador = $('#txtCodFinanciador').val();
    var Financiador = $('#txtDesFinanciador').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();


    if (Financiador != "") {
   
        params.cod_empresa = CodEmpresa;
        params.cod_financiador = CodFinanciador;
        params.cod_Registro = CodRegistro;
        params.des_financiador = Financiador;
        params.tipo_estado = elTipEstadoReg;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Editar_FinanciadorMetas"
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
                    $("#dlgFormularioFinanciador").modal("hide");
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
        alert("No debe estar vacio la descripcion financiador.");
    }
    return false;
}

function EliminarFinanciadorMetas() {
   
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Financiador = $('#txtDesFinanciador').val();

    var resp = confirm("¿Estás seguro que deseas eliminar el financiador " + Financiador.toString() + "?");
    
    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_FinanciadorMetas";
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
                    $("#dlgFormularioFinanciadorMetas").modal("hide");
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

function Imprimir() {
    window.open('rptDepartamento.aspx', '_blank');
}