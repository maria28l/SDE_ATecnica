$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
 
});

function MostrarFormNuevoCargo() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodCargo').hide();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioCargo').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoCargo(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodCargo').val('');
    $('#txtDesCargo').val('');
    $('#txtTipEstadoReg').val('');

}

function MostrarFormEliminar(codRegistro, cod_Cargo, desc_Cargo) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodCargo').show();  
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioCargo').modal();

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarCargo(); });

    $('#txtCodRegistro').val(codRegistro.toString());    
    $('#txtCodCargo').val(cod_Cargo.toString());
    $('#txtDesCargo').val(desc_Cargo.toString());
}
function MostrarFormEditar(registro, empresa, codcargo, cargo, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodcargo').hide();
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioCargo').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeCargo(); });

    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodCargo').val(codcargo.toString());
    $('#txtDesCargo').val(cargo.toString());
    $('#txtTipEstadoReg').val(estado.toString());
    $('#dtpFechaCreacion').val(fecha.toString());
    return false;
}
function RegistrarNuevoCargo() {
    var params = new Object();
    var Cargo = $('#txtDesCargo').val();


    if (Cargo != "") {
        params.des_cargo = Cargo;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Cargo";
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
                    $("#dlgFormularioCargo").modal("hide");
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
        alert("No debe estar vacio la descripcion cargo.");
    }

    return false;
}
function GuardarDatosDeCargo() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodCargo = $('#txtCodCargo').val();
    var Cargo = $('#txtDesCargo').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();


    if (Cargo != "") {
        params.cod_empresa = CodEmpresa;
        params.cod_cargo = CodCargo;
        params.cod_Registro = CodRegistro;
        params.des_cargo = Cargo;
        params.tipo_estado = elTipEstadoReg;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Editar_Cargo"
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
                    $("#dlgFormularioCargo").modal("hide");
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
        alert("No debe estar vacio la descripcion cargo.");
    }
    return false;
}

function EliminarCargo() {
   
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Cargo = $('#txtDesCargo').val();

    var resp = confirm("¿Estás seguro que deseas eliminar el cargo " + Cargo.toString() + "?");
    
    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Cargo";
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
                    $("#dlgFormularioCargo").modal("hide");
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