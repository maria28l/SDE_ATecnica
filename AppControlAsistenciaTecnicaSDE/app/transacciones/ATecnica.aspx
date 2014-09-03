<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="ATecnica.aspx.cs" EnableEventValidation="false" Inherits="transacciones_ATecnica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/procesos/atecnica.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:HiddenField ID="hfCodUsuario" runat="server" />
<asp:Panel ID="Panel1" ScrollBars= "Horizontal" runat="server">
<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-body table-responsive">
                <asp:Button ID="btnActualizar" runat="server" Text="..." 
                    CssClass="btn btn-primary" onclick="btnActualizar_Click" Visible="False"/>
                <%--<HeaderTemplate>--%>                    
                    <a href="javascript:void(0)" onclick="MostrarFormNuevaATecnica()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                <%--</HeaderTemplate>--%>
                <asp:UpdatePanel ID="upGridATecnica" runat="server">
                <ContentTemplate >
                <asp:GridView ID="gvATecnica" runat="server" CssClass="table table-bordered table-hover" 
                    AutoGenerateColumns="False"  AllowPaging="True" onpageindexchanging="gvATecnica_PageIndexChanging" PageSize="10" 
                    AlternatingRowStyle-BackColor= "Beige">
                    <Columns>
                       <asp:TemplateField>
                            <ItemTemplate>                                          
                                <a href="javascript:void(0)" onclick="MostrarEventosDeATecnica('<%# Eval("Cod_ATecnica") %>')"><img alt="Mostrar Eventos" src="/assets/img/icons/show.png" /></a>                                        
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="MostrarFormEliminar('<%# Eval("Cod_Registro") %>','<%# Eval("Cod_ATecnica") %>','<%# Eval("Cod_Usuario") %>','<%# Eval("Cod_Financiador") %>','<%# Eval("Cod_Cliente") %>','<%# Eval("Cod_Facilitador") %>','<%# Eval("Cod_ProductoFinanciero") %>','<%# Eval("Des_ATecnica") %>','<%# Eval("Val_Eventos") %>','<%# Eval("Fec_Inicio_Asistencia") %>','<%# Eval("Tip_EstadoReg") %>')"><img src="/assets/img/icons/delete.png" alt="Eliminar" /></a>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <%--<HeaderTemplate>                    
                                <a href="javascript:void(0)" onclick="MostrarFormNuevaATecnica()"><img alt="Nuevo registro" src="/assets/img/icons/add.gif" /></a>
                            </HeaderTemplate>--%>
                            <ItemTemplate>
                               <a href="javascript:void(0)" onclick="MostrarFormEditar('<%# Eval("Cod_Registro") %>','<%# Eval("Cod_Empresa") %>','<%# Eval("Cod_Usuario") %>','<%# Eval("Cod_ATecnica") %>','<%# Eval("Cod_Financiador") %>','<%# Eval("Cod_Cliente") %>','<%# Eval("Cod_Credito_Financiador") %>','<%# Eval("Cod_Facilitador") %>','<%# Eval("Cod_ProductoFinanciero") %>','<%# Eval("Des_ATecnica") %>','<%# Eval("Des_Propiedad") %>','<%# Eval("Cod_Departamento") %>','<%# Eval("Cod_Municipio") %>','<%# Eval("Cod_Sucursal") %>','<%# Eval("Cod_Territorio") %>','<%# Eval("Cad_Direccion") %>','<%# Eval("Val_CoordX") %>','<%# Eval("Val_CoordY") %>','<%# Eval("Val_Eventos") %>','<%# Eval("Fec_Inicio_Asistencia") %>','<%# Eval("Tip_EstadoReg") %>','<%# Eval("Fec_Creado") %>')"><img src="/assets/img/icons/edit.gif" alt="Editar" /></a>                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Cod_Registro" HeaderText="Cod Registro" />--%>
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
                        <%--<asp:BoundField DataField="Cod_Departamento" HeaderText="Departamento" />--%>
                        <asp:BoundField DataField="Des_Departamento" HeaderText="Departamento" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Municipio" HeaderText="Municipio" />--%>
                        <asp:BoundField DataField="Des_Municipio" HeaderText="Municipio" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Sucursal" HeaderText="Sucursal" />--%>
                        <asp:BoundField DataField="Des_Sucursal" HeaderText="Sucursal" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Cod_Territorio" HeaderText="Territorio" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Cad_Direccion" HeaderText="Direccion" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Val_CoordY" HeaderText="Coordenada Y" />--%>
                        <%--<asp:BoundField DataField="Val_CoordX" HeaderText="Coordenada X" />--%>
                        <asp:BoundField DataField="Val_Eventos" HeaderText="Cant. Eventos" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Fec_Inicio_Asistencia" HeaderText="Fecha Inicio AT" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Tip_EstadoReg" HeaderText="Estado" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Cod_Usuario_Creo" HeaderText="Cod. Usuario Creo" HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Fec_Creado" HeaderText="Fecha Creado" HeaderStyle-BackColor="Beige" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-Wrap="false" />
                        <%--<asp:BoundField DataField="Cod_Usuario_Modifico" HeaderText="Cod. Usuario Modifico" />
                        <asp:BoundField DataField="Fec_Modificado" HeaderText="Fecha Modificado" />--%>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
               </ContentTemplate>
               <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvATecnica" EventName="PageIndexChanging"/>
                        <asp:AsyncPostBackTrigger ControlID="btnActualizar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
</asp:Panel>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormularioATecnica" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Asistencia T&eacute;cnica</h4>
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
                        <div id="cCodUsuario" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label"></label>
                                    <div class="col-lg-6">
                                        <input id="txtCodUsuario" name="txtCodUsuario" type="text" readonly="readonly" disabled="disabled" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                        
                        <div id="cCodATecnica" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Cod. Asistencia Tecnica</label>
                                    <div class="col-lg-6">
                                        <input id="txtCodATecnica" name="txtCodATecnica" type="text" readonly="true" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cCodFinanciador" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Financiador</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlFinanciador" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                        <div id="cCodCliente" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Cliente</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlCliente" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                        <div id="cCodCreditoFinanciador" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">Cod. Cred. Financiador</label>
                                    <div class="col-lg-8">
                                        <input id="txtCodCreditoFinanciador" name="txtCodCreditoFinanciador" type="text" class="form-control" maxlength="10"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cCodProductoFinanciero" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Producto Financiero</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlProductoFinanciero" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div id="cDesATecnica" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Descripcion</label>
                                    <div class="col-lg-8">
                                        <input id="txtDesATecnica" name="txtDesATecnica" type="text" class="form-control" maxlength="200"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div id="cDesPropiedad" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Descrip. de Propiedad</label>
                                    <div class="col-lg-8">
                                        <input id="txtDesPropiedad" name="txtDesPropiedad" type="text" class="form-control" maxlength="100"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div class="row">
                            <div id="cCodDepartamento" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">*Depto.</label>
                                    <div class="col-lg-9">
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
                        <div class="row">
                            <div id="cCodSucursal" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">*Sucursal</label>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlSucursal" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div> 
                               <div id="cCodTerritorio" class="col-lg-6">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">*Territ.</label>
                                        <div class="col-lg-9">
                                            <asp:DropDownList ID="ddlTerritorio" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                            </div>
                         </div>          
                         <div id="cCadDireccion" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Direccion</label>
                                    <div class="col-lg-8">
                                        <input id="txtCadDireccion" name="txtCadDireccion" type="text" class="form-control" maxlength="100"/>
                                    </div>
                                </div>
                            </div>  
                        </div> 
                        <div class="row">
                             <div id="cValCoordX" class="col-lg-6">
                                    <div class="form-group">
                                        <label class="col-lg-6 control-label">Coordenada-X</label>
                                        <div class="col-lg-6">
                                            <input id="txtValCoordX" name="txtValCoordX" type="text" class="form-control" />
                                        </div>
                                    </div>
                            </div> 
                             <div id="cValCoordY" class="col-lg-6">
                                    <div class="form-group">
                                        <label class="col-lg-6 control-label">Coordenada-Y</label>
                                        <div class="col-lg-6">
                                            <input id="txtValCoordY" name="txtValCoordY" type="text" class="form-control"/>
                                        </div>
                                    </div>
                            </div> 
                        </div>
                        <div class="row">
                             <div id="cValEventos" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">*Cant. Eventos</label>
                                    <div class="col-lg-6">
                                        <input id="txtValEventos" name="txtValEventos" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>
                            <div id="cFecInicioAsistencia" class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label">Fec Inicio Asist.</label>
                                    <div class="col-lg-6">
                                        <input id="dtpFecInicioAsistencia" name="dtpFecInicioAsistencia" type="text" class="form-control"/>
                                    </div>
                                </div>
                            </div>       
                        </div>                                                             
                        <div id="cCodFacilitador" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Facilitador</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlFacilitador" CssClass="form-control" runat="server">
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
                                    <label class="col-lg-6 control-label">Fecha Creacion</label>
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
<div id="dlgEventosxATecnica" style="display:none"></div>
</asp:Content>

