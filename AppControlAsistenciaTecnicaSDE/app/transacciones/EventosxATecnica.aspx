<%@  Page Language="C#" AutoEventWireup="true" CodeFile="EventosxATecnica.aspx.cs" Inherits="transacciones_EventosxATecnica"  EnableEventValidation="false"%>

<!DOCTYPE html>
<html>
<head>
    <title></title>    
    <script  type="text/javascript" src="../Scripts/procesos/eventosxatecnica.js"></script>
</head>          
<body>   
<form id="frmFormularioEventosProgramados" runat="server">
<asp:HiddenField ID="hfCodATecnica" runat="server" />
  <div class="content"> 
    <asp:Panel ID="Panel2" ScrollBars= "Horizontal" runat="server">
        <div class="row">        
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-body table-responsive">
                        <asp:Button ID="btnActualizar_ep" runat="server" Text="..." 
                    CssClass="btn btn-primary" onclick="btnActualizar_ep_Click" Visible="False"/>
                        <a href="javascript:void(0)" onclick="MostrarFormNuevoEventoProgramado()" > <img alt="Nuevo registro" src="/assets/img/icons/add.gif" /> </a>
                        <ContentTemplate >
                        <asp:GridView ID="gvEventosProgramados" runat="server" CssClass="table table-bordered table-hover" 
                            AutoGenerateColumns="False" AlternatingRowStyle-BackColor= "Beige">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="javascript:void(0)" onclick="MostrarFormEliminarEvento(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_ATecnica") %>','<%# Eval("Cod_Evento") %>','<%# Eval("Fec_Programada") %>','<%# Eval("Cod_TipoEvento") %>','<%# Eval("Des_Evento") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                                    </ItemTemplate>                            
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <%--<HeaderTemplate>                    
                                        <a href="javascript:void(0)" onclick="MostrarFormNuevoSucursalPersonal()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                                    </HeaderTemplate>--%>
                                    <ItemTemplate>
                                       <a href="javascript:void(0)" onclick="MostrarFormEditarEvento(<%# Eval("Cod_Registro") %>,'<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_ATecnica") %>','<%# Eval("Cod_Evento") %>','<%# Eval("Fec_Programada") %>','<%# Eval("Cod_TipoEvento") %>','<%# Eval("Des_Evento") %>','<%# Eval("Tip_Estado_Evento") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cod_ATecnica" HeaderText="Codigo Asistencia Tecnica" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Cod_Evento" HeaderText="Codigo Evento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Fec_Programada" HeaderText="Fecha Programada" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="Cod_TipoEvento" HeaderText="Tipo de Evento" />--%>
                                <asp:BoundField DataField="Des_TipoEvento" HeaderText="Tipo de Evento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Des_Evento" HeaderText="Descripción Evento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Tip_Estado_Evento" HeaderText="Estado Evento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado Registro" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Codigo Usuario Creo" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="Cod_Usuario_Modifico" HeaderText="Codigo Usuario Modifico" />
                                <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />--%>
                            </Columns>
                        </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnActualizar_ep" EventName="Click" />
                        </Triggers>
                    </div>
                </div>
            </div>
           </div>
        </asp:Panel>
        <!-- VENTANA MODAL. OCULTA INICIALMENTE -->   
        <div class="modal fade" id="dlgFormEventosxATecnica" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Eventos x Asistencia Tecnica</h4>
                    </div>
                    <div class="modal-body">
                        <div class="system-form2">
                            <div class="form-horizontal">                           
                                <div id="cCodRegistro_ep" class="row" >
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Registro</label>
                                            <div class="col-lg-6">
                                                <input id="txtCodRegistro_ep" name="txtCodRegistro_ep" type="text" readonly="true" class="form-control" disabled="disabled" />
                                            </div>
                                        </div>
                                    </div>  
                                </div>
                                <div id="cCodEmpresa_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Empresa</label>
                                            <div class="col-lg-6">
                                                <input id="txtCodEmpresa_ep" name="txtCodEmpresa_ep" type="text" readonly="true" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>  
                                </div>
                                <div id="cCodATecnica_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Cod. Asistencia Tecnica</label>
                                            <div class="col-lg-6">
                                                <input id="txtCodATecnica_ep" name="txtCodATecnica_ep" type="text" readonly="true" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>  
                                </div> 
                                <div id="cCodEvento_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Codigo Evento</label>
                                            <div class="col-lg-6">
                                                <input id="txtCodEvento_ep" name="txtCodEvento_ep" type="text" readonly="true" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>  
                                </div>
                                <div id="cFecProgramada_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">*Fecha Programada</label>
                                            <div class="col-lg-6">
                                                <input id="dtpFecProgramada_ep" name="dtpFecProgramada_ep" type="text" class="form-control"/>                                                
                                            </div>
                                        </div>
                                    </div>  
                                </div> 
                                <div id="cCodTipoEvento_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">*Tipo de Evento</label>
                                            <div class="col-lg-6">
                                            <asp:DropDownList ID="ddlTipoEvento_ep" CssClass="form-control"  runat="server">                                                
                                                </asp:DropDownList>                                                
                                            </div>
                                        </div>
                                    </div>  
                                </div> 
                                <div id="cDesEvento_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">*Descripcion</label>
                                            <div class="col-lg-6">
                                                <input id="txtDesEvento_ep" name="txtDesEvento_ep" type="text" class="form-control" maxlength="200"/>
                                            </div>
                                        </div>
                                    </div>  
                                </div>           
                                <div id="cEstadoEvento_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Estado Evento</label>
                                            <div class="col-lg-6">
                                                <select id="ddlEstadoEvento_ep" class='form-control'>
                                                    <option>PENDIENTE</option>
                                                    <option>REALIZADO</option>
                                                    <option>REVISADO</option>
                                                    <option>AUTORIZADO</option>
                                                    <option>REPORTADO</option>
                                                </select>                                        
                                            </div>
                                        </div>
                                    </div>  
                                </div>     
                                <div id="cEstado_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Estado</label>
                                            <div class="col-lg-6">
                                                <select id="ddlEstados_ep" class='form-control'>
                                                    <option>VIGENTE</option>
                                                    <option>BLOQUEADO</option>
                                                </select>                                        
                                            </div>
                                        </div>
                                    </div>  
                                </div>     
                                <div id="cFechas_ep" class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="col-lg-6 control-label">Fecha Creaci&oacute;n</label>
                                            <div class="col-lg-6">
                                                <input id="dtpFechaCreacion_ep" name="dtpFechaCreacion_ep" type="text" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>  
                                </div>                                                                   
                            </div>
                        </div>
                    </div>            
                    <div class="modal-footer">
                        <button class='btn btn-warning' id="btnEliminar_ep" name="btnEliminar_ep">
                            <i class='fa fa-minus-square'></i>&nbsp;Eliminar
                        </button>
                        <button class='btn btn-success' id="btnGuardar_ep" name="btnGuardar_ep">
                            <i class='fa fa-save'></i>&nbsp;Guardar
                        </button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCancelar_ep">
                            <i class='fa fa-exclamation-circle'></i>&nbsp;Cancelar
                        </button>
                    </div>
                </div>
             </div>
        </div>
         <!-- END VENTANA MODAL -->
  </div>
 </form>    
</body>
</html>


