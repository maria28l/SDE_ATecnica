<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="Personal.aspx.cs" Inherits="catalogos_Personal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/catalogos/personal.js" type="text/javascript"></script>
     <script type="text/javascript">

         function mayusculanombrecompleto(cad) {
             $("#txtCadNombreCompleto").keyup(function () {
                 $(this).val($(this).val().toUpperCase());
             });
         }
         function mayusculaidentificacion(cad1) {
             $("#txtCadIdentificacion").keyup(function () {
                 $(this).val($(this).val().toUpperCase());
             });
         }
         function mayusculadireccion(cad2) {
             $("#txtCadDireccion").keyup(function () {
                 $(this).val($(this).val().toUpperCase());
             });
         }
         $().ready(function () {//INICIA SECCION READY

             //Evento del dropdownlist departamento que invoca el llenado de municipio
             $("#<%=ddlDepartamento.ClientID%>").change(function () {
                 //este parametro mapeara con el definido en el web service
                 var params = new Object();
                 params.departamento = $("#<%=ddlDepartamento.ClientID%>").val();
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
                         $("#<%=ddlMunicipio.ClientID%>").html("");
                         $.each(municipios, function (index, municipio) {
                             $("#<%=ddlMunicipio.ClientID%>").append($("<option></option>").attr("value", municipio.Cod_Municipio).text(municipio.Des_Municipio));
                         });
                     },
                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                         alert(textStatus + ": " + XMLHttpRequest.responseText);
                     }
                 });
             });
             //Fin del evento ddlMunicipio
             //Evento del dropdownlist Cargo que invoca el llenado de jefe
             $("#<%=ddlCargo.ClientID%>").change(function () {
                 //este parametro mapeara con el definido en el web service
                 var params = new Object();
                 params.cargo = $("#<%=ddlCargo.ClientID%>").val();
                 params = JSON.stringify(params);

                 $.ajax({
                     type: "POST",
                     url: "/SdeAtWebService.asmx/ObtenerJefexCargo",
                     data: params,
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (result) {
                         var personals = result.d;
                         $("#<%=ddlJefe.ClientID%>").html("");
                         $.each(personals, function (index, personal) {
                             $("#<%=ddlJefe.ClientID%>").append($("<option></option>").attr("value", personal.Cod_Personal).text(personal.Cad_Nombre_Completo));
                         });
                     },
                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                         alert(textStatus + ": " + XMLHttpRequest.responseText);
                     }
                 });

             });
             //Fin del evento ddlJefe
             //TERMINA SECCION READY
             mayusculanombrecompleto("input#txtCadNombreCompleto");
             mayusculaidentificacion("input#txtCadIdentificacion");
             mayusculadireccion("input#txtCadDireccion");

             
             
         });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:GridView ID="gvPersonal" runat="server" CssClass="table table-bordered table-hover" 
                    AutoGenerateColumns="False"  >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="MostrarFormEliminar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Personal") %>','<%# Eval("Cad_Nombre_Completo") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="op">
                            <HeaderTemplate>                    
                                <a href="javascript:void(0)" onclick="MostrarFormNuevoPersonal()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <a href="javascript:void(0)" onclick="MostrarFormEditar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Personal") %>','<%# Eval("Cod_Cargo") %>','<%# Eval("Cad_Nombre_Completo") %>','<%# Eval("Cad_Identificacion") %>','<%# Eval("Tip_Genero") %>','<%# Eval("Cod_Departamento") %>','<%# Eval("Cod_Municipio") %>','<%# Eval("Cad_Direccion") %>','<%# Eval("Cad_Telefono") %>','<%# Eval("Cod_Jefe") %>','<%# Eval("Tip_Contratacion") %>','<%# Eval("Bit_Brinda_Asistencia") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cod_Personal" HeaderText="Codigo Personal" />
                        <asp:BoundField DataField="Cad_Nombre_Completo" HeaderText="Nombre" />
                        <asp:BoundField DataField="Cad_Identificacion" HeaderText="Identificacion" />
                        <asp:BoundField DataField="Cod_Departamento" HeaderText="Departamento" />
                        <asp:BoundField DataField="Cod_Municipio" HeaderText="Municipio" />
                        <asp:BoundField DataField="Cad_Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="Cad_Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Cod_Cargo" HeaderText="Codigo Cargo" />
                        <asp:BoundField DataField="Cod_Jefe" HeaderText="Codigo Jefe" />
                        <asp:BoundField DataField="Tip_Contratacion" HeaderText="Tipo Contratacion" />
                        <asp:BoundField DataField="Bit_Brinda_Asistencia" 
                            HeaderText="Brinda Asistencia" />
                        <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado" />
                        <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Codigo Usuario Creo" />
                        <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" />
                        <asp:BoundField DataField="Cod_Usuario_Modifico" 
                            HeaderText="Codigo Usuario Modifico" />
                        <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
   </div>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormularioPersonal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Personal</h4>
            </div>
            <div class="modal-body">
                <div class="system-form2">
                    <div class="form-horizontal">
                        <div id="cCodRegistro" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Registro</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodRegistro" name="txtCodRegistro" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div id="cCodEmpresa" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Empresa</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodEmpresa" name="txtCodEmpresa" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div id="cCodPersonal" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Personal</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodPersonal" name="txtCodPersonal" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cCodCargo" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Cargo</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlCargo" CssClass="form-control" runat="server" 
                                        onselectedindexchanged="ddlCargo_SelectedIndexChanged"
                                            AutoPostBack="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                        <div id="cCadNombreCompleto" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Nombre</label>
                                    <div class="col-lg-6">
                                        <input id="txtCadNombreCompleto" name="txtCadNombreCompleto" onblur="mayusculanombrecompleto" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                         
                        <div id="cCadIdentificacion" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Identificacion</label> 
                                    <div class="col-lg-6">
                                     <input id="txtCadIdentificacion" name="txtCadIdentificacion" onblur="mayusculaidentificacion" type="text" class="form-control" maxlength="14" />

                                      </div>
                                </div>
                            </div>  
                        </div>
                        <div id="cGenero" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Genero</label>
                                    <div class="col-lg-6">
                                        <select id="ddlGenero" class='form-control'>
                                            <option>FEMENINO</option>
                                            <option>MASCULINO</option>
                                        </select>                                        
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cCodDepartamento" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Departamento</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server" 
                                            onselectedindexchanged="ddlDepartamento_SelectedIndexChanged" 
                                            AutoPostBack="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                           <div id="cCodMunicipio" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Municipio</label>
                                    <div class="col-lg-6">
                                        <%--<asp:UpdatePanel ID="upMunicipio" runat="server">
                                            <ContentTemplate>--%>
                                              <asp:DropDownList ID="ddlMunicipio" CssClass="form-control" runat="server" 
                                                   
                                                    AutoPostBack="False">
                                               </asp:DropDownList>
                                           <%-- </ContentTemplate>
                                            <Triggers>                                                
                                                <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" 
                                                    EventName="SelectedIndexChanged" />                                                
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>  
                        </div>           
                         <div id="cCadDireccion" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Direccion</label>
                                    <div class="col-lg-6">
                                        <input id="txtCadDireccion" name="txtCadDireccion" onblur="mayusculadireccion" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                         <div id="cCadTelefono" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Telefono</label>
                                    <div class="col-lg-6">
                                        <input id="txtCadTelefono" name="txtCadTelefono" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cCodJefe" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Jefe</label>
                                    <div class="col-lg-6">
                                    <%--<asp:UpdatePanel ID="UpJefe" runat="server">
                                            <ContentTemplate>--%>
                                        <asp:DropDownList ID="ddlJefe" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <%--</ContentTemplate>
                                            <Triggers>                                                
                                                <asp:AsyncPostBackTrigger ControlID="ddlCargo" 
                                                    EventName="SelectedIndexChanged" />                                                
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                       <div id="cContratacion" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Contratacion</label>
                                    <div class="col-lg-6">
                                        <select id="ddlContratacion" class='form-control'>
                                            <option>PLANILLA</option>
                                            <option>SERVPROF</option>
                                        </select>                                        
                                    </div>
                                </div>
                            </div>  
                        </div>                           
                         <div id="cBitBrindaAsistencia" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Brinda Asistencia</label>
                                    <div class="col-lg-6">                                   
                                        <asp:RadioButtonList ID="rblBitBrindaAsistencia" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" name="rblBitBrindaAsistencia_si">SI</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0" name="rblBitBrindaAsistencia_no">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>  
                        </div>                           
                        <div id="cEstado" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Estado</label>
                                    <div class="col-lg-6">
                                        <select id="ddlEstados" class='form-control'>
                                            <option>VIGENTE</option>
                                            <option>BLOQUEADO</option>
                                        </select>                                        
                                    </div>
                                </div>
                            </div>  
                        </div>     
                        <div id="cFechas" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Fecha Creaci&oacute;n</label>
                                    <div class="col-lg-6">
                                        <input id="dtpFechaCreacion" name="dtpFechaCreacion" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                                                                   
                    </div>
                </div>
            </div>            
            <div class="modal-footer">
                <button class='btn btn-warning' id="btnEliminar" name="btnEliminar">
                    <i class='fa fa-minus-square'></i>&nbsp;Eliminar
                </button>
                <button class='btn btn-success' id="btnGuardar" name="btnGuardar">
                    <i class='fa fa-save'></i>&nbsp;Guardar
                </button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCancelar">
                    <i class='fa fa-exclamation-circle'></i>&nbsp;Cancelar
                </button>
            </div>
        </div>
     </div>
</div>
<!-- END VENTANA MODAL -->
</asp:Content>

