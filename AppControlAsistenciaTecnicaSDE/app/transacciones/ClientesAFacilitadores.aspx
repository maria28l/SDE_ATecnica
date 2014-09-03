<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="ClientesAFacilitadores.aspx.cs" EnableEventValidation="false" Inherits="transacciones_ClientesAFacilitadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/procesos/clientes_facilitadores.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="content">
        <div class="row">        
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-body table-responsive">
                        <asp:Button ID="btnActualizar_cf" runat="server" Text="..." CssClass="btn btn-primary" onclick="btnActualizar_cf_Click" Visible="False"/>
                        <asp:GridView ID="gvClientesAFacilitadores" runat="server" CssClass="table table-bordered table-hover" AlternatingRowStyle-BackColor= "Beige" AutoGenerateColumns="false">
                            <Columns>
                               <asp:TemplateField>
                                    <ItemTemplate>                                          
                                        <a href="javascript:void(0)" onclick="AgregarAsignacionAFacilitadores('<%# Eval("Cod_Personal_Asigna") %>','<%# Eval("Cod_Cliente") %>','<%# Eval("Cod_Sucursal") %>','<%# Eval("Cod_Facilitador") %>')"><img alt="Mostrar Eventos" src="/assets/img/icons/show.png" /></a>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>    
                                <asp:BoundField DataField="Cod_Cliente" HeaderText="Cod_Cliente" 
                                    HeaderStyle-BackColor="Beige"  ItemStyle-Wrap="false"  />
                                <asp:BoundField DataField="Cad_Nombre_Completo" 
                                    HeaderText="Nombre Cliente" HeaderStyle-BackColor="Beige" 
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Des_Sucursal" HeaderText="Sucursal" HeaderStyle-BackColor="Beige" 
                                    ItemStyle-Wrap="false"/>
                                <%--<asp:BoundField DataField="Des_Financiador" HeaderText="Financiador" HeaderStyle-BackColor="Beige" 
                                    ItemStyle-Wrap="false"/>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
<!-- VENTANA MODAL. OCULTA INICIALMENTE -->            
<div class="modal fade" id="dlgFormClientesAFacilitadores" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Asignar a Facilitador</h4>
            </div>
            <div class="modal-body">
                <div class="system-form2">
                    <div class="form-horizontal">
                        <%--<div id="cCargoRegional" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label"></label>
                                    <div class="col-lg-6">
                                        <input id="txtCargoRegional" name="txtCargoRegional" type="text" readonly="readonly" disabled="disabled" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>--%>                        
                        <div id="cCodPersonalAsigna" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-6 control-label"></label>
                                    <div class="col-lg-6">
                                        <input id="txtCodPersonalAsigna" name="txtCodPersonalAsigna" type="text" readonly="readonly" disabled="disabled" class="form-control"/>
                                    </div>
                                </div>
                            </div>  
                        </div>                        
                        <div id="cCodCliente" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Cliente</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlCliente" CssClass="form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>  
                        </div>  
                        <div id="cCodSucursal" class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">*Sucursal</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlSucursal" CssClass="form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
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
                    </div>
                </div>
            </div>            
            <div class="modal-footer">
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
</asp:Content>
