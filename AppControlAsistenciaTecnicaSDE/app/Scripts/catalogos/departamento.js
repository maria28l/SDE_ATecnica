$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
 
});

function MostrarFormNuevoDepartamento() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodDepartamento').hide();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioDepartamento').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoDepartamento(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodDepartamento').val('');
    $('#txtDesDepartamento').val('');
    $('#ddlEstados').val('');

}
function MostrarFormEliminar(codRegistro,cod_Departamento,desc_Departamento) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodDepartamento').show();  
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioDepartamento').modal();

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarDepartamento(); });

    $('#txtCodRegistro').val(codRegistro.toString());    
    $('#txtCodDepartamento').val(cod_Departamento.toString());
    $('#txtDesDepartamento').val(desc_Departamento.toString());
}
function MostrarFormEditar(registro, empresa, coddepartamento, departamento, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodDepartamento').show();
    $('#cDesDepartamento').show();
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioDepartamento').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeDepartamento(); });

    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodDepartamento').val(coddepartamento.toString());
    $('#txtDesDepartamento').val(departamento.toString());
    $('#ddlEstados').val(estado.toString());
    $('#dtpFechaCreacion').val(fecha.toString());
    return false;
}
function RegistrarNuevoDepartamento() {
    var params = new Object();
    var Departamento = $('#txtDesDepartamento').val();


    if (Departamento != "") {
        params.des_departamento = Departamento;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Departamento";
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
                    $("#dlgFormularioDepartamento").modal("hide");
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
        alert("No debe estar vacio la descripcion departamento." );
         }

    return false;
}
function GuardarDatosDeDepartamento() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodDepartamento = $('#txtCodDepartamento').val();
    var Departamento = $('#txtDesDepartamento').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();


     if (Departamento != "") {
   
        params.cod_empresa = CodEmpresa;
        params.cod_departamento = CodDepartamento;
        params.cod_Registro = CodRegistro;
        params.des_departamento = Departamento;
        params.tipo_estado = elTipEstadoReg;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Editar_Departamento"
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
                    $("#dlgFormularioDepartamento").modal("hide");
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
        alert("No debe estar vacio la descripcion departamento.");
    }
    return false;
}

function EliminarDepartamento() {
   
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Departamento = $('#txtDesDepartamento').val();

    var resp = confirm("¿Estás seguro que deseas eliminar el departamento " + Departamento.toString() + "?");
    
    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Departamento";
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
                    $("#dlgFormularioDepartamento").modal("hide");
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