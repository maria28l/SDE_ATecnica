<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="Cargos.aspx.cs" Inherits="catalogos_Cargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">    
      <script src="../Scripts/catalogos/cargo.js" type="text/javascript"></script> 
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:GridView ID="gvCargos" runat="server" CssClass="table table-bordered table-hover" 
                    AutoGenerateColumns="False"  >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="MostrarFormEliminar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Cargo") %>','<%# Eval("Des_Cargo") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="op">
                            <HeaderTemplate>                    
                                <a href="javascript:void(0)" onclick="MostrarFormNuevoCargo()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <a href="javascript:void(0)" onclick="MostrarFormEditar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Cargo") %>','<%# Eval("Des_Cargo") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cod_Cargo" HeaderText="Codigo Cargo" />
                        <asp:BoundField DataField="Des_Cargo" HeaderText="Cargo" />
                        <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado" />
                        <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Codigo Usuario Creo" />
                        <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" />
                        <asp:BoundField DataField="Cod_Usuario_Modifico"  HeaderText="Codigo Usuario Modifico" />
                        <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormularioCargo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Cargo</h4>
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
                        <div id="cCodCargo" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Cargo</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodCargo" name="txtCodCargo" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>    
                        <div id="cDesCargo" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Cargo</label>
                                    <div class="col-lg-6">
                                        <input id="txtDesCargo" name="txtDesCargo" type="text" class="form-control"/>
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
                                        <input id="Text1" name="dtpFechaCreacion" type="text" class="form-control"/>
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
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCancelar" name="btnCancelar">
                    <i class='fa fa-exclamation-circle'></i>&nbsp;Cancelar
                </button>
            </div>
        </div>
     </div>
</div>
<!-- END VENTANA MODAL -->
</asp:Content>






