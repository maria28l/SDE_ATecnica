$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();
 
});

function MostrarFormNuevoPersonal() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodPersonal').hide();
    $('#cCodCargo').show();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCadDireccion').show();
    $('#cCadTelefono').show();
    $('#cCodJefe').show();
    $('#cContratacion').show();
    $('#cBitBrindaAsistencia').show();
    $('#cGenero').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioPersonal').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoPersonal(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodPersonal').val('');
    $('#ddlCargo').val('');
    $('#txtCadNombreCompleto').val('');
    $('#txtCadIdentificacion').val('');
    $('#ddlDepartamento').val('');
    $('#ddlMunicipio').val('');
    $('#txtCadDireccion').val('');
    $('#txtCadTelefono').val('');
    $('#ddlContratacion').val('');
    $('#ddlJefe').val('');
    $('#txtBitBrindaAsistencia').val('');
    $('#ddlGenero').val('');
//    $('#txtTipEstadoReg').val('');

}
function MostrarFormEliminar(codRegistro, cod_Personal, desc_Persona) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodPersonal').show();
    $('#cCodCargo').hide();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').hide();
    $('#cGenero').hide();
    $('#cCodDepartamento').hide();
    $('#cCodMunicipio').hide();
    $('#cCadDireccion').hide();
    $('#cCadTelefono').hide();
    $('#cCodJefe').hide();
    $('#cContratacion').hide();
    $('#cBitBrindaAsistencia').hide();
    $('#cEstado').hide();
    $('#cFechas').hide();
    
    $('#dlgFormularioPersonal').modal();    

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarPersonal(); });

    $('#txtCodRegistro').val(codRegistro.toString());
    $('#txtCodPersonal').val(cod_Personal.toString());
    $('#txtCadNombreCompleto').val(desc_Persona.toString());
   
}

function MostrarFormEditar(registro, empresa, persona, codcargo, cadnombrecompleto, cadidentificacion, genero, coddepartamento, codmunicipio, caddireccion, cadtelefono, codjefe, contratacion, bitbrindaasistencia, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodPersonal').show();  
    $('#cCodCargo').show();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').show();
    $('#cGenero').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCadDireccion').show();
    $('#cCadTelefono').show();
    $('#cCodJefe').show();
    $('#cContratacion').show();
    $('#cBitBrindaAsistencia').show();   
    $('#cEstado').show();
    $('#cFechas').hide();

    $('#dlgFormularioPersonal').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDePersonal(); });


   
    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodPersonal').val(persona.toString());
    $('[name*="ddlCargo"]').val(codcargo.toString());
    $('[name*="ddlCargo"]').change();
    $('#txtCadNombreCompleto').val(cadnombrecompleto.toString());
    $('#txtCadIdentificacion').val(cadidentificacion.toString());
    $('#ddlGenero').val(genero.toString());
    $('#ddlGenero').change();
    $('[name*="ddlDepartamento"]').val(coddepartamento.toString());
    $('[name*="ddlDepartamento"]').change();
    $('[name*="ddlMunicipio"]').val(codmunicipio.toString());
    $('[name*="ddlMunicipio"]').change();
    $('#txtCadDireccion').val(caddireccion.toString());
    $('#txtCadTelefono').val(cadtelefono.toString());
    $('[name*="ddlJefe"]').val(codjefe.toString());
    $('[name*="ddlJefe"]').change();
    $('#ddlContratacion').val(contratacion.toString());
    $('#ddlContratacion').change();

    if (bitbrindaasistencia == '1') {
        $('input:radio[name=rblBitBrindaAsistencia_si]').prop('checked', 'checked');
    } else {
        $('input:radio[name=rblBitBrindaAsistencia_no]').prop('checked', 'checked');
    }

    $('#ddlEstados').val(estado.toString());
    $('#ddlEstados').change();
    $('#dtpFechaCreacion').val(fecha.toString());  
    
        return false;
}

function RegistrarNuevoPersonal() {
    var params = new Object();
    var Cargo = $('[name*="ddlCargo"]').val(); 
    var Nombre = $('#txtCadNombreCompleto').val();
    var CadIdentificacion = $('#txtCadIdentificacion').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val(); 
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();    
    var CadDireccion = $('#txtCadDireccion').val();
    var CadTelefono = $('#txtCadTelefono').val();
    var TipContratacion = $("#ddlContratacion option:selected").text();
    var BitBrindaAsistencia = $("input[name*='rblBitBrindaAsistencia']:checked").val(); 
    var TipGenero = $("#ddlGenero option:selected").text();
    var CodJefe = $('[name*="ddlJefe"]').val();


    if ((typeof Cargo != "undefined") && Cargo != "" && Cargo != null && Cargo != "00"
    && Nombre != "" && CadIdentificacion != "" && (typeof CodDepartamento != "undefined")
    && CodDepartamento != "" && CodDepartamento != null && CodDepartamento != "00"
    && (typeof CodMunicipio != "undefined") && CodMunicipio != "" && CodMunicipio != null && CodMunicipio != "00"
    && (typeof TipContratacion != "undefined") && TipContratacion != "" && TipContratacion != null && TipContratacion != "00"
    && CadDireccion != "" && BitBrindaAsistencia != ""
    && (typeof TipGenero != "undefined") && TipGenero != "" && TipGenero != null && TipGenero != "00"
    && (typeof CodJefe != "undefined") && CodJefe != "" && CodJefe != null && CodJefe != "00")
     {
        params.cod_cargo = Cargo;
        params.cad_nombre_completo = Nombre;
        params.cad_identificacion = CadIdentificacion;
        params.cod_departamento = CodDepartamento;
        params.cod_municipio = CodMunicipio;
        params.cad_direccion = CadDireccion;
        params.cad_telefono = CadTelefono;
        params.bit_brinda_asistencia = BitBrindaAsistencia;
        params.tip_contratacion = TipContratacion;
        params.tip_genero = TipGenero;
        params.cod_jefe = CodJefe;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Registrar_Personal";
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
                    $("#dlgFormularioPersonal").modal("hide");
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
        alert("Los Campos con asteriscos *, campos requeridos.");
          }

    return false;
}
function GuardarDatosDePersonal() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CodPersonal = $('#txtCodPersonal').val();
    var Cargo = $('[name*="ddlCargo"]').val();
    var Nombre = $('#txtCadNombreCompleto').val();
    var CadIdentificacion = $('#txtCadIdentificacion').val();
    var TipGenero = $("#ddlGenero option:selected").text();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val();
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();
    var CadDireccion = $('#txtCadDireccion').val();
    var CadTelefono = $('#txtCadTelefono').val();
    var CodJefe = $('[name*="ddlJefe"]').val();
    var TipContratacion = $("#ddlContratacion option:selected").text();
    var BitBrindaAsistencia = $("input[name*='rblBitBrindaAsistencia']:checked").val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();

    if ((typeof Cargo != "undefined") && Cargo != "" && Cargo != null && Cargo != "00"
    && Nombre != "" && CadIdentificacion != "" && (typeof CodDepartamento != "undefined")
    && CodDepartamento != "" && CodDepartamento != null && CodDepartamento != "00"
    && (typeof CodMunicipio != "undefined") && CodMunicipio != "" && CodMunicipio != null && CodMunicipio != "00"
    && (typeof TipContratacion != "undefined") && TipContratacion != "" && TipContratacion != null && TipContratacion != "00"
    && CadDireccion != "" && BitBrindaAsistencia != ""
    && (typeof TipGenero != "undefined") && TipGenero != "" && TipGenero != null && TipGenero != "00"
    && (typeof CodJefe != "undefined") && CodJefe != "" && CodJefe != null && CodJefe != "00") {
       
        params.cod_Registro = CodRegistro;
        params.cod_empresa = CodEmpresa;
        params.cod_personal = CodPersonal;
        params.cod_cargo = Cargo;
        params.cad_nombre_completo = Nombre;
        params.cad_identificacion = CadIdentificacion;
        params.tip_genero = TipGenero;
        params.cod_departamento = CodDepartamento;
        params.cod_municipio = CodMunicipio;
        params.cad_direccion = CadDireccion;
        params.cad_telefono = CadTelefono;
        params.cod_jefe = CodJefe;
        params.tip_contratacion = TipContratacion;
        params.bit_brinda_asistencia = BitBrindaAsistencia;
        params.tipo_estado = elTipEstadoReg;

        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Editar_Personal"
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
                    $("#dlgFormularioPersonal").modal("hide");
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
        alert("Los Campos con asteriscos *, campos requeridos.");
    }
    return false;
}

function EliminarPersonal() {
   
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Personal = $('#txtCadNombreCompleto').val();

    var resp = confirm("¿Estás seguro que deseas eliminar la persona " + Personal.toString() + "?");
    
    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Personal";
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
                    $("#dlgFormularioPersonal").modal("hide");
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