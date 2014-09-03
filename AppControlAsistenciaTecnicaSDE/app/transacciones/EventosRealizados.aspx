<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="EventosRealizados.aspx.cs" EnableEventValidation="false" Inherits="transacciones_EventosRealizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/procesos/eventos_realizados.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--<asp:HiddenField ID="hfCodEvento" runat="server" />--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:Panel ID="Panel3" ScrollBars= "Horizontal" runat="server">
<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:Button ID="btnActualizar_er" runat="server" Text="..." 
                    CssClass="btn btn-primary" onclick="btnActualizar_er_Click" Visible="False"/>
                <asp:UpdatePanel ID="upGridEventosRealizados" runat="server">
                <ContentTemplate >
                <asp:GridView ID="gvEventosRealizados" runat="server" CssClass="table table-bordered table-hover" 
                    AutoGenerateColumns="False"  AllowPaging="True" onpageindexchanging="gvEventosRealizados_PageIndexChanging" PageSize="10" 
                    AlternatingRowStyle-BackColor= "Beige">
                    <Columns>
                       <%--<asp:TemplateField>
                            <ItemTemplate>                                          
                                <a href="javascript:void(0)" onclick="MostrarEventosDeATecnica('<%# Eval("Cod_Evento") %>')"><img alt="Mostrar Eventos" src="/assets/img/icons/show.png" /></a>                                        
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <a href="javascript:void(0)" onclick="MostrarFormEventoRealizado('<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Evento") %>','<%# Eval("Cod_TipoEvento") %>','<%# Eval("Fec_Programada") %>','<%# Eval("Fec_Realizada") %>','<%# Eval("Des_Visita") %>','<%# Eval("Tip_EstadoReg") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Cod_Empresa" HeaderText="Cod Empresa" />--%>
                        <asp:BoundField DataField="Cod_ATecnica" HeaderText="Cod Asist.Tecnica" HeaderStyle-BackColor= "Beige" ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Financiador" HeaderText="Financiador" />--%>
                        <asp:BoundField DataField="Des_Financiador" HeaderText="Financiador"  HeaderStyle-BackColor="Beige" ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Cliente" HeaderText="Cliente" />--%>
                        <asp:BoundField DataField="Des_Cliente" HeaderText="Cliente"  HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Credito_Financiador" HeaderText="Cod. Cred. Financiador" />--%>
                        <%--<asp:BoundField DataField="Cod_Facilitador" HeaderText="Facilitador" />--%>
                        <asp:BoundField DataField="Des_Facilitador" HeaderText="Facilitador" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_ProductoFinanciero" HeaderText="Producto Financiero" />--%>
                        <asp:BoundField DataField="Des_ProdFinanciero" HeaderText="Producto Financiero" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Des_ATecnica" HeaderText="Descripcion AT" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Fec_Inicio_Asistencia" HeaderText="Fecha Inicio AT" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Fec_Programada" HeaderText="Fecha sig. Evento" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Des_Visita" HeaderText="Descripcion Visita" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Fec_Realizada" HeaderText="Fecha Real Evento" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Cod_Evento" HeaderText="Cod Evento" HeaderStyle-BackColor= "Beige" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Cod_TipoEvento" HeaderText="Cod Tipo Evento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Des_TipoEvento" HeaderText="Tipo Evento" HeaderStyle-BackColor="Beige" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Des_Evento" HeaderText="Descrip. Evento" HeaderStyle-BackColor="Beige" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado Registro"  HeaderStyle-BackColor="Beige" ItemStyle-Wrap="false"/>
                        <%--<asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />--%>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
               </ContentTemplate>
               <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEventosRealizados" EventName="PageIndexChanging"/>
                        <asp:AsyncPostBackTrigger ControlID="btnActualizar_er" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
</asp:Panel>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormEventosRealizados" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Evento Realizado</h4>
            </div>
            <div class="modal-body">
                <div class="system-form2">
                    <div class="form-horizontal">
                        <div id="cCodEmpresa_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Empresa</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodEmpresa_er" name="txtCodEmpresa_er" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div id="cCodEvento_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Cod. Evento</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodEvento_er" name="txtCodEvento_er" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                           <div id="cCodTipoEvento_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Tipo Evento</label>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlTipoEvento_er" CssClass="form-control" Enabled="false" readonly="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            </div>
                        <div id="cFecProgramada_er" class="row">
                            <div class="col-lg-12">
                            <div class="form-group">
                                <label class="col-lg-6 control-label">Fec Evento Prog.</label>
                                <div class="col-lg-6">
                                    <input id="dtpFecProgramada_er" name="dtpFecProgramada_er" type="text" readonly="true" class="form-control"/>
                                </div>
                            </div>
                            </div>
                        </div>       
                            <div id="cFecRealizada_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Fec Evento Real</label>
                                    <div class="col-lg-6">
                                        <input id="dtpFecRealizada_er" name="dtpFecRealizada_er" type="text" class="form-control"/>
                                    </div>
                                </div>
                                </div>
                            </div>       
                        <div id="cDesVisita_Er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Descrip. Visita</label>
                                    <div class="col-lg-8">
                                        <input id="txtDesVisita_er" name="txtDesVisita_er" type="text" class="form-control" maxlength="350"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cEstado_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Estado</label>
                                    <div class="col-lg-6">
                                        <select id="ddlEstado_er" class='form-control'>
                                            <option>VIGENTE</option>
                                            <option>BLOQUEADO</option>
                                        </select>                                        
                                    </div>
                                </div>
                            </div>  
                        </div>     
                        <div id="cFechas_er" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Fecha Creacion</label>
                                    <div class="col-lg-6">
                                        <input id="dtpFechaCreacion_er" name="dtpFechaCreacion_Er" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                                                                   
                    </div>
                </div>
            </div>            
            <div class="modal-footer">
                <button class='btn btn-success' id="btnGuardar_er" name="btnGuardar_er">
                    <i class='fa fa-save'></i>&nbsp;Guardar
                </button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCancelar_er">
                    <i class='fa fa-exclamation-circle'></i>&nbsp;Cancelar
                </button>
            </div>
        </div>
     </div>
</div>
<!-- END VENTANA MODAL -->
<div id="dlgInfATecnica" style="display:none"></div>
</asp:Content>


