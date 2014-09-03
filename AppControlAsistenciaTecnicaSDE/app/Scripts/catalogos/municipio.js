$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();

});

function MostrarFormNuevoMunicipio() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodMunicipio').hide();
    $('#cCodDepartamento').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioMunicipio').modal();
    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoMunicipio(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodMunicipio').val('');
    $('#txtDesMunicipio').val('');
    $('#ddlDepartamento').val('');
    $('#ddlEstados').val('');

}
function MostrarFormEditar(registro, empresa, CodDepartamento, codMunicipio, Municipio, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodMunicipio').show();
    $('#cCodDepartamento').show();
    $('#cEstado').show();
    $('#cFechas').hide();

    
    $('#dlgFormularioMunicipio').modal();
    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeMunicipio(); });

    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodMunicipio').val(codMunicipio.toString());
    $('#txtDesMunicipio').val(Municipio.toString());
    $('[name*="ddlDepartamento"]').val(CodDepartamento.toString());
    $('#ddlEstados').val(estado.toString());
    $('#ddlEstados').change();
    $('#dtpFechaCreacion').val(fecha.toString());

    return false;
}
function RegistrarNuevoMunicipio() {
    var params = new Object();
    var Municipio = $('#txtDesMunicipio').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val();

        if (Municipio != "" || (typeof CodDepartamento != "undefined") || CodDepartamento != "" || CodDepartamento != null || CodDepartamento != '00') 
        {
        params.cod_Departamento = CodDepartamento; 
        params.des_Municipio = Municipio;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Municipio";
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
                    $("#dlgFormularioMunicipio").modal("hide");
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
                alert('El departamento y Municipio son requeridos');
                 }
    return false;
}
function GuardarDatosDeMunicipio() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val();
    var CodMunicipio = $('#txtCodMunicipio').val();
    var Municipio = $('#txtDesMunicipio').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();

    if (Municipio != "" || (typeof CodDepartamento != "undefined") || CodDepartamento != "" || CodDepartamento == null || CodDepartamento != '00') 
    {
    params.cod_empresa = CodEmpresa;
    params.cod_Departamento = CodDepartamento;
    params.cod_Municipio = CodMunicipio;
    params.cod_Registro = CodRegistro;
    params.des_Municipio = Municipio;
    params.tipo_estado = elTipEstadoReg;

    params = JSON.stringify(params);
    LaUrl = "/SdeAtWebService.asmx/Editar_Municipio"
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
                $("#dlgFormularioMunicipio").modal("hide");
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
    alert("Debe seleccionar un departamento y no dejar vacia la descripcion de municipio.");
}
    return false;
}