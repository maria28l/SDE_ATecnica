$().ready(function () {
    $('input[name*="dtpFecha"]').datepicker({ changeMonth: true, changeYear: true, showOtherMonths: true, dateFormat: 'dd-mm-yy' });
    moment().format();

    //Evento del dropdownlist Sucursal que invoca el llenado de Facilitadores
    $("[id*='ddlSucursal']").change(function () {
        //este parametro mapeara con el definido en el web service
        var params = new Object();
        params.sucursal = $("[id*='ddlSucursal']").val();
        params.cargo = $('#txtCargoRegional').val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/SdeAtWebService.asmx/ObtenerFacilitadoresxSucursalyCargo",
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
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });

});

function AgregarAsignacionARegionales(cargo_regional, cod_personal_asigna, codcliente, codsucursal, codfacilitador) {

    $('#txtCargoRegional').hide();
    $('#cCodPersonalAsigna').hide();
    $('#cCodCliente').show();
    $('#cCodFacilitador').show();
    $('#cCodSucursal').show();

    $('#dlgFormClientesARegionales').modal();
    $('#btnGuardar').show();

    $('#btnGuardar').unbind("click");
    $('#btnGuardar').on('click', function () { return GuardarAsignacionARegionales(); }); //GuardarDatosDePersonal

    $('#txtCargoRegional').val(cargo_regional.toString());
    $('#txtCodPersonalAsigna').val(cod_personal_asigna.toString());
    $('[name*="ddlCliente"]').val(codcliente.toString());
    $('[name*="ddlSucursal"]').val(codsucursal.toString());
    $('[name*="ddlSucursal"]').change();
    $('[name*="ddlFacilitador"]').val(codfacilitador.toString());
    
        return false;
}

function GuardarAsignacionARegionales() {
    var params = new Object();
    var CodPersonalAsigna = $('#txtCodPersonalAsigna').val();
    var CodCliente = $('[name*="ddlCliente"]').val();
    var CodFacilitador = $('[name*="ddlFacilitador"]').val();
    var CodSucursal = $('[name*="ddlSucursal"]').val();
    var elTipEstadoReg = $("#ddlEstados option:selected").text();

    params.cod_personal_asigna = CodPersonalAsigna;
    params.cod_cliente = CodCliente;
    params.cod_facilitador = CodFacilitador;
    params.cod_sucursal = CodSucursal;

    params = JSON.stringify(params);
    LaUrl = "/SdeAtWebService.asmx/Clientes_ARegionales"
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
                __doPostBack('ctl00$MainContent$btnActualizar_cr', "OnClick");
                $("#dlgFormClientesARegionales").modal("hide");
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
