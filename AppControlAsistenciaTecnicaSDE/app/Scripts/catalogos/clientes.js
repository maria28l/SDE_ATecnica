$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();

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
    //Fin del evento ddlMunicipio

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
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
    //Fin del evento ddlTerritorio

    // inicio de aplicar funcion de poner en mayuscula
    Mayuscula("input#txtCadPrimerNombre");
    Mayuscula("input#txtCadSegundoNombre");
    Mayuscula("input#txtCadPrimerApellido");
    Mayuscula("input#txtCadSegundoApellido");
    Mayuscula("input#txtCadNombreCompleto");
    Mayuscula("input#txtCadIdentificacion");
    Mayuscula("input#txtCadDireccion");
    //fin de aplicar funcion de poner en mayuscula 

    $("#txtCadPrimerNombre").keyup(function () {
        var pn = $(this).val().toUpperCase();
        var sn = $("#txtCadSegundoNombre").val().toUpperCase();
        var pa = $("#txtCadPrimerApellido").val().toUpperCase();
        var sa = $("#txtCadSegundoApellido").val().toUpperCase();
        var nc = pn + ' ' + sn + ' ' + pa + ' ' + sa;
        $("#txtCadNombreCompleto").val(nc);
    });

    $("#txtCadSegundoNombre").keyup(function () {
        var pn = $("#txtCadPrimerNombre").val().toUpperCase();
        var sn = $(this).val().toUpperCase();
        var pa = $("#txtCadPrimerApellido").val().toUpperCase();
        var sa = $("#txtCadSegundoApellido").val().toUpperCase();
        var nc = pn + ' ' + sn + ' ' + pa + ' ' + sa;
        $("#txtCadNombreCompleto").val(nc);
    });

    $("#txtCadPrimerApellido").keyup(function () {
        var pn = $("#txtCadPrimerNombre").val().toUpperCase();
        var sn = $("#txtCadSegundoNombre").val().toUpperCase();
        var pa = $(this).val().toUpperCase();
        var sa = $("#txtCadSegundoApellido").val().toUpperCase();
        var nc = pn + ' ' + sn + ' ' + pa + ' ' + sa;
        $("#txtCadNombreCompleto").val(nc);
    });

    $("#txtCadSegundoApellido").keyup(function () {
        var pn = $("#txtCadPrimerNombre").val().toUpperCase();
        var sn = $("#txtCadSegundoNombre").val().toUpperCase();
        var pa = $("#txtCadPrimerApellido").val().toUpperCase();
        var sa = $(this).val().toUpperCase();
        var nc = pn + ' ' + sn + ' ' + pa + ' ' + sa;
        $("#txtCadNombreCompleto").val(nc);
    });

});

function MostrarFormNuevoCliente() {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodCliente').hide();
    $('#cCadPrimerNombre').show();
    $('#cCadSegundoNombre').show();
    $('#cCadPrimerApellido').show();
    $('#cCadSegundoApellido').show();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCodTerritorio').show();
    $('#cCadDireccion').show();
    $('#cCadTelefono').show();
    $('#cGenero').show();
    $('#cEstado').hide();
    $('#cFechas').hide();

    $('#dlgFormularioCliente').modal();

    $('#btnGuardar').show();
    $('#btnEliminar').hide();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return RegistrarNuevoCliente(); });

    $('#txtCodRegistro').val('');
    $('#txtCodEmpresa').val('');
    $('#txtCodCliente').val('');
    $('#txtCadPrimerNombre').val('');
    $('#txtCadSegundoNombre').val('');
    $('#txtCadPrimerApellido').val('');
    $('#txtCadSegundoApellido').val('');
    $('#txtCadNombreCompleto').val('');
    $('#txtCadIdentificacion').val('');
    $('#ddlDepartamento').val('');
    $('#ddlMunicipio').val('');
    $('#ddlTerritorio').val('');
    $('#txtCadDireccion').val('');
    $('#txtCadTelefono').val('');
    $('#ddlGenero').val('');
    $('#ddlEstados').val('');


}
function MostrarFormEliminar(codRegistro, cod_Cliente, desc_Cliente, cad_Identificacion) {
    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodCliente').show();
    $('#cCadPrimerNombre').hide();
    $('#cCadSegundoNombre').hide();
    $('#cCadPrimerApellido').hide();
    $('#cCadSegundoApellido').hide();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').show();
    $('#cCodDepartamento').hide();
    $('#cCodMunicipio').hide();
    $('#cCodTerritorio').hide();
    $('#cCadDireccion').hide();
    $('#cCadTelefono').hide();
    $('#cGenero').hide();
    $('#cEstado').hide();
    $('#cFechas').hide();


    $('#dlgFormularioCliente').modal();

    $('#btnGuardar').hide();
    $('#btnEliminar').show();

    $('#btnEliminar').unbind("click");
    $('#btnEliminar').on('click', function () { return EliminarCliente(); });

    $('#txtCodRegistro').val(codRegistro.toString());
    $('#txtCodCliente').val(cod_Cliente.toString());
    $('#txtCadNombreCompleto').val(desc_Cliente.toString());
    $('#txtCadIdentificacion').val(cad_Identificacion.toString());

}

function MostrarFormEditar(registro, empresa, cliente,
cadprimernombre, cadsegundonombre, cadprimerapellido,
cadsegundoapellido, cadnombrecompleto, cadidentificacion,
genero, coddepartamento, codmunicipio,
codterritorio, caddireccion, cadtelefono, estado, fecha) {

    $('#cCodRegistro').hide();
    $('#cCodEmpresa').hide();
    $('#cCodCliente').show();
    $('#cCadPrimerNombre').show();
    $('#cCadSegundoNombre').show();
    $('#cCadPrimerApellido').show();
    $('#cCadSegundoApellido').show();
    $('#cCadNombreCompleto').show();
    $('#cCadIdentificacion').show();
    $('#cGenero').show();
    $('#cCodDepartamento').show();
    $('#cCodMunicipio').show();
    $('#cCodTerritorio').show();
    $('#cCadDireccion').show();
    $('#cCadTelefono').show();
    $('#cEstado').show();
    $('#cFechas').hide();


    $('#dlgFormularioCliente').modal();
    $('#btnGuardar').show();
    $('#btnEliminar').hide();


    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarDatosDeCliente(); });


    $('#txtCodRegistro').val(registro.toString());
    $('#txtCodEmpresa').val(empresa.toString());
    $('#txtCodCliente').val(cliente.toString());
    $('#txtCadPrimerNombre').val(cadprimernombre.toString());
    $('#txtCadSegundoNombre').val(cadsegundonombre.toString());
    $('#txtCadPrimerApellido').val(cadprimerapellido.toString());
    $('#txtCadSegundoApellido').val(cadsegundoapellido.toString());
    $('#txtCadNombreCompleto').val(cadnombrecompleto.toString());
    $('#txtCadIdentificacion').val(cadidentificacion.toString());
    $('#ddlGenero').val(genero.toString());
    $('#ddlGenero').change();
    $('[name*="ddlDepartamento"]').val(coddepartamento.toString());
    $('[name*="ddlDepartamento"]').change();
    $('[name*="ddlMunicipio"]').val(codmunicipio.toString());
    $('[name*="ddlMunicipio"]').change();
    $('[name*="ddlTerritorio"]').val(codterritorio.toString());
    $('[name*="ddlTerritorio"]').change();
    $('#txtCadDireccion').val(caddireccion.toString());
    $('#txtCadTelefono').val(cadtelefono.toString());
    $('#ddlEstados').val(estado.toString());
    $('#ddlEstados').change();
    $('#dtpFechaCreacion').val(fecha.toString());


    return false;
}

function RegistrarNuevoCliente() {
    var params = new Object();

    var PrimerNombre = $('#txtCadPrimerNombre').val();
    var SegundoNombre = $('#txtCadSegundoNombre').val();
    var PrimerApellido = $('#txtCadPrimerApellido').val();
    var SegundoApellido = $('#txtCadSegundoApellido').val();
    var Nombre = $('#txtCadNombreCompleto').val();
    var CadIdentificacion = $('#txtCadIdentificacion').val();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val();
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();
    var CodTerritorio = $('[name*="ddlTerritorio"]').val();
    var CadDireccion = $('#txtCadDireccion').val();
    var CadTelefono = $('#txtCadTelefono').val();
    var TipGenero = $("#ddlGenero option:selected").text();

    if (Nombre != "" && PrimerNombre != "" && PrimerApellido != "" && CadIdentificacion != "" && CadDireccion != ""
         && (typeof CodDepartamento != "undefined") && CodDepartamento != "" && CodDepartamento != null && CodDepartamento != "00"
         && (typeof CodMunicipio != "undefined") && CodMunicipio != "" && CodMunicipio != null && CodMunicipio != "00"
         && (typeof CodTerritorio != "undefined") && CodTerritorio != "" && CodTerritorio != null && CodTerritorio != "00"
         && (typeof TipGenero != "undefined") && TipGenero != "" && TipGenero != null && TipGenero != "00") {

        if (EsCedula(CadIdentificacion)) {
            params.cad_primer_nombre = PrimerNombre;
            params.cad_segundo_nombre = SegundoNombre;
            params.cad_primer_apellido = PrimerApellido;
            params.cad_segundo_apellido = SegundoApellido;
            params.cad_nombre_completo = Nombre;
            params.cad_identificacion = CadIdentificacion;
            params.cod_departamento = CodDepartamento;
            params.cod_municipio = CodMunicipio;
            params.cod_territorio = CodTerritorio;
            params.cad_direccion = CadDireccion;
            params.cad_telefono = CadTelefono;
            params.tip_genero = TipGenero;


            params = JSON.stringify(params);
            LaUrl = "/SdeAtWebService.asmx/Registrar_Cliente";
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
                        $("#dlgFormularioCliente").modal("hide");
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
            alert('¡El n° de cédula no es válido. Deben ser trece dígitos mas una letra al final, los caracteres del 4to al 9no deben representar una fecha válida!');
        }
    }
    else {
        alert("Los Campos con asteriscos *, campos requeridos.");
    }

    return false;
}
function GuardarDatosDeCliente() {
    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var CodEmpresa = $('#txtCodEmpresa').val();
    var CadPrimerNombre = $('#txtCadPrimerNombre').val();
    var CadSegundoNombre = $('#txtCadSegundoNombre').val();
    var CadPrimerApellido = $('#txtCadPrimerApellido').val();
    var CadSegundoApellido = $('#txtCadSegundoApellido').val();
    var Nombre = $('#txtCadNombreCompleto').val();
    var CadIdentificacion = $('#txtCadIdentificacion').val();
    var TipGenero = $("#ddlGenero option:selected").text();
    var CodDepartamento = $('[name*="ddlDepartamento"]').val();
    var CodMunicipio = $('[name*="ddlMunicipio"]').val();
    var CodTerritorio = $('[name*="ddlTerritorio"]').val();
    var CadDireccion = $('#txtCadDireccion').val();
    var CadTelefono = $('#txtCadTelefono').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();


    if (Nombre != "" && CadPrimerNombre != ""
         && CadPrimerApellido != "" && CadIdentificacion != "" && CadDireccion != ""
         && (typeof CodDepartamento != "undefined") && CodDepartamento != "" && CodDepartamento != null && CodDepartamento != "00"
         && (typeof CodMunicipio != "undefined") && CodMunicipio != "" && CodMunicipio != null && CodMunicipio != "00"
         && (typeof CodTerritorio != "undefined") && CodTerritorio != "" && CodTerritorio != null && CodTerritorio != "00"
         && (typeof TipGenero != "undefined") && TipGenero != "" && TipGenero != null && TipGenero != "00") {

        if (EsCedula(CadIdentificacion)) {
            params.cod_Registro = CodRegistro;
            params.cod_empresa = CodEmpresa;
            params.cad_primer_nombre = CadPrimerNombre;
            params.cad_segundo_nombre = CadSegundoNombre;
            params.cad_primer_apellido = CadPrimerApellido;
            params.cad_segundo_apellido = CadSegundoApellido;
            params.cad_nombre_completo = Nombre;
            params.cad_identificacion = CadIdentificacion;
            params.tip_genero = TipGenero;
            params.cod_departamento = CodDepartamento;
            params.cod_municipio = CodMunicipio;
            params.cod_territorio = CodTerritorio;
            params.cad_direccion = CadDireccion;
            params.cad_telefono = CadTelefono;
            params.tipo_estado = elTipEstadoReg;

            params = JSON.stringify(params);
            LaUrl = "/SdeAtWebService.asmx/Editar_Cliente"
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
                        $("#dlgFormularioCliente").modal("hide");
                    }
                    else {
                        alert('Error sgbd: ' + data.d.Mensaje);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus + ": " + jqXHR.responseText);
                }
            });
        }
        else {
            alert('¡El n° de cédula no es válido. Deben ser trece dígitos mas una letra al final, los caracteres del 4to al 9no deben representar una fecha válida!');
        }

    }
    else {
        alert("Los Campos con asteriscos *, campos requeridos.");
    }

    return false;
}

function EliminarCliente() {

    var params = new Object();
    var CodRegistro = $('#txtCodRegistro').val();
    var Cliente = $('#txtCadNombreCompleto').val();


    var resp = confirm("¿Estás seguro que deseas eliminar al cliente " + Cliente.toString() + "?");

    if (resp == true) {
        params.cod_Registro = CodRegistro;
        params = JSON.stringify(params);
        LaUrl = "/SdeAtWebService.asmx/Eliminar_Cliente";
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
                    $("#dlgFormularioCliente").modal("hide");
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