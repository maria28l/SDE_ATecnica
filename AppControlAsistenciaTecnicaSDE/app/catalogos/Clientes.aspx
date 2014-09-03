<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" EnableEventValidation="false" Inherits="catalogos_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/general/util.js" type="text/javascript"></script>
    <script src="../Scripts/catalogos/clientes.js" type="text/javascript"></script>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="smdclientes" runat="server" /> 
<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:Button ID="btnActualizar" runat="server" Text="..." 
                    CssClass="btn btn-primary" onclick="btnActualizar_Click" Visible="False"/>
                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvCliente" runat="server" CssClass="table table-bordered table-hover" 
                            AutoGenerateColumns="False" AllowPaging="True" 
                            onpageindexchanging="gvCliente_PageIndexChanging" PageSize="5"  >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="javascript:void(0)" onclick="MostrarFormEliminar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Cliente") %>','<%# Eval("Cad_Nombre_Completo") %>','<%# Eval("Cad_Identificacion") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                                    </ItemTemplate>                            
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="op">
                                    <HeaderTemplate>                    
                                        <a href="javascript:void(0)" onclick="MostrarFormNuevoCliente()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                       <a href="javascript:void(0)" onclick="MostrarFormEditar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Cliente") %>','<%# Eval("Cad_Primer_Nombre") %>','<%# Eval("Cad_Segundo_Nombre") %>','<%# Eval("Cad_Primer_Apellido") %>','<%# Eval("Cad_Segundo_Apellido") %>','<%# Eval("Cad_Nombre_Completo") %>','<%# Eval("Cad_Identificacion") %>','<%# Eval("Tip_Genero") %>','<%# Eval("Cod_Departamento") %>','<%# Eval("Cod_Municipio") %>','<%# Eval("Cod_Territorio") %>','<%# Eval("Cad_Direccion") %>','<%# Eval("Cad_Telefono") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cod_Cliente" HeaderText="Codigo Cliente" />
                                <asp:BoundField DataField="Cad_Nombre_Completo" HeaderText="Nombre" />
                                <asp:BoundField DataField="Cad_Identificacion" HeaderText="Identificacion" />
                                <asp:BoundField DataField="Cod_Departamento" HeaderText="Departamento" />
                                <asp:BoundField DataField="Cod_Municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="Cod_Territorio" HeaderText="Territorio" />
                                <asp:BoundField DataField="Cad_Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Cad_Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado" />
                                <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Codigo Usuario Creo" />
                                <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" />
                                <asp:BoundField DataField="Cod_Usuario_Modifico" 
                                    HeaderText="Codigo Usuario Modifico" />
                                <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvCliente" 
                            EventName="PageIndexChanging"/>
                        <asp:AsyncPostBackTrigger ControlID="btnActualizar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel> 
            </div>
        </div>
    </div>
</div>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormularioCliente" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Cliente</h4>
            </div>
            <div class="modal-body">
                <div class="system-form2">
                    <div class="form-horizontal">
                        <div class="row">
                            <div id="cCodRegistro" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Registro</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodRegistro" name="txtCodRegistro" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                            <div id="cCodEmpresa" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Empresa</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodEmpresa" name="txtCodEmpresa" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="cCodCliente" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Cliente</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodCliente" name="txtCodCliente" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div class="row">
                            <div id="cCadPrimerNombre" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Primer Nombre</label>
                                    <div class="col-lg-8">                                   
                                       <input id="txtCadPrimerNombre" name="txtCadPrimerNombre" type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div id="cCadSegundoNombre" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Segundo Nombre</label>
                                    <div class="col-lg-9">
                                        <input id="txtCadSegundoNombre" name="txtCadSegundoNombre" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>                               
                        </div>  
                         <div class="row">
                            <div id="cCadPrimerApellido" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Primer Apellido</label>
                                    <div class="col-lg-8">
                                        <input id="txtCadPrimerApellido" name="txtCadPrimerApellido" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                             <div id="cCadSegundoApellido" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Segundo Apellido</label>
                                    <div class="col-lg-9">
                                        <input id="txtCadSegundoApellido" name="txtCadSegundoApellido" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                  
                        <div id="cCadNombreCompleto" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">*Nombre</label>
                                    <div class="col-lg-10">
                                        <input id="txtCadNombreCompleto" name="txtCadNombreCompleto" type="text" readonly="true"  class="form-control" />
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div class="row">
                            <div id="cCadIdentificacion" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Identificacion</label>
                                    <div class="col-lg-8">
                                        <input id="txtCadIdentificacion" name="txtCadIdentificacion" type="text" class="form-control" maxlength="14"  />
                                    </div>
                                </div>
                            </div>
                            <div id="cGenero" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">*Genero</label>
                                    <div class="col-lg-9">
                                        <select id="ddlGenero" class='form-control'>
                                            <option>FEMENINO</option>
                                            <option>MASCULINO</option>
                                        </select>                                        
                                    </div>
                                </div>
                            </div>                             
                        </div>
                        <div class="row">
                            <div id="cCodDepartamento" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Departamento</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="cCodMunicipio" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">*Municipio</label>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlMunicipio" CssClass="form-control" runat="server"> 
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>                                
                        </div>          
                         <div id="cCodTerritorio" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">*Territorio</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList ID="ddlTerritorio" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>   
                         <div id="cCadDireccion" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">*Direccion</label>
                                    <div class="col-lg-10">
                                        <input id="txtCadDireccion" name="txtCadDireccion" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                         <div class="row">
                            <div id="cCadTelefono" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">Telefono</label>
                                    <div class="col-lg-8">
                                        <input id="txtCadTelefono" name="txtCadTelefono"  type="text" class="form-control"  />
                                    </div>
                                </div>
                            </div>  
                            <div id="cEstado" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Estado</label>
                                    <div class="col-lg-9">
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
                <button class='btn btn-success' id="btnGuardar" name="btnGuardar" >
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

