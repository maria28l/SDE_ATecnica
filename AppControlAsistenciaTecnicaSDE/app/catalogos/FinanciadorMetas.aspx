<%@ Page Title="" Language="C#" MasterPageFile="~/app/mp_sinmenu.master" AutoEventWireup="true" CodeFile="FinanciadorMetas.aspx.cs" Inherits="catalogos_FinanciadorMetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/catalogos/financiadormetas.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:GridView ID="gvFinanciadorMetas" runat="server" CssClass="table table-bordered table-hover" 
                    AutoGenerateColumns="False"  >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>                    
                                <a href="javascript:void(0)" onclick="MostrarFormNuevoFinanciadorMetas()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                            </HeaderTemplate>                            
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="MostrarFormEliminar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Financiador") %>','<%# Eval("Cod_ProdFinanciero") %>','<%# Eval("Cod_Anio") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>                    
                                <a href="javascript:void(0)" onclick="Imprimir()"><img alt="Imprimir" src="/assets/img/icons/print.png" /></a>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <a href="javascript:void(0)" onclick="MostrarFormEditar(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Financiador") %>','<%# Eval("Cod_ProdFinanciero") %>','<%# Eval("Cod_Anio") %>','<%# Eval("Val_ClientesNuevos") %>','<%# Eval("Mto_PagoxEvento") %>','<%# Eval("Val_Tot_Eventos") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cod_Financiador" HeaderText="Codigo Financiador" />
                        <asp:BoundField DataField="Cod_ProdFinanciero" 
                            HeaderText="Codigo Producto Financiero" />
                        <asp:BoundField DataField="Cod_Anio" HeaderText="Año" />
                        <asp:BoundField DataField="Val_ClientesNuevos" 
                            HeaderText="Cantidad Clientes Nuevos" />
                        <asp:BoundField DataField="Mto_PagoxEvento" HeaderText="Mto Pago por Evento" />
                        <asp:BoundField DataField="Val_Tot_Eventos" HeaderText="Total Eventos" />
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
<div class="modal fade" id="dlgFormularioFinanciadorMetas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Financiador</h4>
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
                        <div id="cCodFinanciador" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Financiador</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodFinanciador" name="txtCodFinanciador" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>    
                        <div id="cCodAnio" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Cod_Anio</label>
                                    <div class="col-lg-6">
                                        <select name="CodAnioPicker" id="CodAnioPicker" class="form-control"></select>
                                    </div>
                                </div>
                            </div>  
                        </div>     
                        <div id="cCodProdFinanciero" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Codigo Producto Financiero</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlCodProdFinanciero" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>     
                         <div id="cValClientesNuevos" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Clientes Nuevos</label>
                                    <div class="col-lg-6">
                                        <input id="txtValClientesNuevos" name="txtValClientesNuevos" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                        <div id="cMtoPagoxEvento" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Mto Pago por Evento</label>
                                    <div class="col-lg-6">
                                        <input id="txtMtoPagoxEvento" name="txtMtoPagoxEvento" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                         <div id="cValTotEventos" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Val_Tot_Eventos</label>
                                    <div class="col-lg-6">
                                        <input id="txtValTotEventos" name="txtValTotEventos" type="text" class="form-control"/>
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

