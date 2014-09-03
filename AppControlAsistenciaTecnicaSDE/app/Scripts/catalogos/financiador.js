$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
 
});

function MostrarFormNuevoFinanciador() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').hide();
    $('#cDesFinanciador').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciador').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoFinanciador(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodFinanciador').val('');
    $('#txtDesFinanciador').val('');
    $('#txtTipEstadoReg').val('');

}
function MostrarFormEliminar(codRegistro, cod_Financiador, desc_Financiador) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').show();
    $('#cDesFinanciador').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciador').modal();

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarFinanciador(); });

    $('#txtCodRegistro').val(codRegistro.toString());
    $('#txtCodFinanciador').val(cod_Financiador.toString());
    $('#txtDesFinanciador').val(desc_Financiador.toString());
}
function MostrarFormEditar(registro, empresa, codfinanciador, financiador, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodFinanciador').show();
    $('#cDesFinanciador').show();
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioFinanciador').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeFinanciador(); });

    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodFinanciador').val(codfinanciador.toString());
    $('#txtDesFinanciador').val(financiador.toString());
    $('#txtTipEstadoReg').val(estado.toString());
    $('#dtpFechaCreacion').val(fecha.toString());
    return false;
}
function RegistrarNuevoFinanciador() {
    var params = new Object();
    var Financiador = $('#txtDesFinanciador').val();


    if (Financiador != "") {
        params.des_financiador = Financiador;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Financiador";
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
function GuardarDatosDeFinanciador() {
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
        LaUrl = "/SdeAtWebService.asmx/Editar_Financiador"
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

function EliminarFinanciador() {
   
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Financiador = $('#txtDesFinanciador').val();

    var resp = confirm("¿Estás seguro que deseas eliminar el financiador " + Financiador.toString() + "?");
    
    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Financiador";
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

    return false;
}

function Imprimir() {
    window.open('rptDepartamento.aspx', '_blank');
}