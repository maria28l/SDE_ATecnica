<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="Municipios.aspx.cs" Inherits="catalogos_Municipios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/catalogos/municipio.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <asp:GridView ID="gvMunicipios" runat="server" CssClass="table table-bordered table-hover" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>                    
                    <a href="javascript:void(0)" onclick="MostrarFormNuevoMunicipio()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                </HeaderTemplate>
                <ItemTemplate>
                   <a href="javascript:void(0)" onclick="MostrarFormEditar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Departamento") %>','<%# Eval("Cod_Municipio") %>','<%# Eval("Des_Municipio") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Cod_Departamento" HeaderText="Codigo Departamento" />
            <asp:BoundField DataField="Cod_Municipio" HeaderText="Codigo Municipio" />
            <asp:BoundField DataField="Des_Municipio" HeaderText="Municipio" />
            <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado" />
            <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Codigo Usuario Creo" />
            <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" />
            <asp:BoundField DataField="Cod_Usuario_Modifico" 
                HeaderText="Codigo Usuario Modifico" />
            <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />
        </Columns>
    </asp:GridView>
</div>
    <!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormularioMunicipio" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Municipio</h4>
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
                        <div id="cCodMunicipio" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Municipio</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodMunicipio" name="txtCodMunicipio" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>    
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Municipio</label>
                                    <div class="col-lg-6">
                                        <input id="txtDesMunicipio" name="txtDesMunicipio" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>   
                        <div id="cCodDepartamento" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Departamento</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
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
                <Button Class='btn btn-success' ID="btnGuardar" name="btnGuardar">
                    <i class='fa fa-save'></i>&nbsp;Guardar
                </Button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCancelar">
                    <i class='fa fa-exclamation-circle'></i>&nbsp;Cancelar
                </button>
            </div>
        </div>
     </div>
</div>
<!-- END VENTANA MODAL -->
</asp:Content>

