<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empleado.aspx.cs" Inherits="Aplicaciones_Logistica_Empleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Empleados</title>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HctblEmpleado" runat="server" />
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">Control Empleados</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm">
                    <table class="table table-bordered" id="tblProducto">
                        <thead class="bg-dark" runat="server">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                <th class="text-center font-weight-light">Apellido_Paterno</th>
                                <th class="text-center font-weight-light">Apellido_Materno</th>
                                <th class="text-center font-weight-light">Nombre</th>
                                <th class="text-center font-weight-light">Sexo</th>
                                <th class="text-center font-weight-light">Fecha_Nacimiento</th>
                                <th class="text-center font-weight-light"><div id="divControl" runat="server"><%--style="display: none;"--%>
                                                <input type="text" id="txtBusDni" name='txtBusDni' placeholder='Buscar Dni' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusDni" Text="Buscar" runat="server" OnClick="btnBusDni_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light">Direccion</th>
                                <th class="text-center font-weight-light">Telefono</th>
                                <%--<th class="text-center font-weight-light">Estado</th>--%>
                                <th class="text-center font-weight-light">Area</th>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyCol" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtApePat1" class="form-control" /></div></td>
                                <td><div id="campo3" class="input-group input-group-sm"><input type="text" runat="server" id="txtApeMat1" class="form-control" /></div></td>
                                <td><div id="campo4" class="input-group input-group-sm"><input type="text" runat="server" id="txtNombre1" class="form-control" /></div></td>
                                <td><div id="campo5" class="input-group input-group-sm"><select runat="server" class="form-control" id="cmbSex1" style="width:60px;"><option value="M">M</option><option value="F">F</option></select></div></td>
                                <td><div id="campo6" class="input-group input-group-sm"><input type="date" runat="server" id="txtFNac1" class="form-control" /></div></td>
                                <td><div id="campo7" class="input-group input-group-sm"><input type="text" runat="server" id="txtDni1" class="form-control" /></div></td>
                                <td><div id="campo8" class="input-group input-group-sm"><input type="text" runat="server" id="txtDirec1" class="form-control" /></div></td>
                                <td><div id="campo9" class="input-group input-group-sm"><input type="text" runat="server" id="txtTelef1" class="form-control" /></div></td>
                                <%--<td><div id="campo10" class="input-group input-group-sm"><input type="checkbox" runat="server" id="txtEstad1" value="0"  class="form-control"/></div></td>--%>
                                <td><div id="campo10" class="input-group input-group-sm"><select runat="server" class="form-control" id="cmbArea1"></select></div></td>
                                <td class="text-center"><div id="campo11"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
                            </tr>
                        </tbody>
                    </table>
                    <asp:GridView ID="gvEmpleado" runat="server" AutoGenerateColumns="false" ShowFooter="true" Visible="false"
                                ShowHeaderWhenEmpty="true"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gvEmpleado_RowCommand" OnRowUpdating="gvEmpleado_RowUpdating"  OnRowDeleting="gvEmpleado_RowDeleting">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />

                                <Columns>
                                    <asp:TemplateField HeaderText="N°">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdEmpl" Text='<%# Eval("ID EMPLEADO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEmpl" Text='<%# Eval("ID EMPLEADO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paterno">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPaterno" Text='<%# Eval("APELLIDO PATERNO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPaterno" Text='<%# Eval("APELLIDO PATERNO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Materno">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMaterno" Text='<%# Eval("APELLIDO MATERNO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMaterno" Text='<%# Eval("APELLIDO MATERNO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNombre" Text='<%# Eval("NOMBRE") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNombre" Text='<%# Eval("NOMBRE") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sexo">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbSexo"  runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="cmbSexo"  runat="server"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nacimiento">
                                        <ItemTemplate>
                                            <asp:Calendar ID="calenNac"  SelectedDate='<%# Eval("NACIMIENTO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Calendar ID="calenNac"  SelectedDate='<%# Eval("NACIMIENTO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dni">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDni" Text='<%# Eval("DNI") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDni" Text='<%# Eval("DNI") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Direccion">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDireccion" Text='<%# Eval("DIRECCION") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDireccion" Text='<%# Eval("DIRECCION") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Telefono">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTelefono" Text='<%# Eval("TELEFONO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTelefono" Text='<%# Eval("TELEFONO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbEstado"  runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="cmbEstado"  runat="server"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbArea"  runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="cmbArea"  runat="server"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%--<asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />--%>
                                            <%--<asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />--%>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    <div class="container text-center">
                        <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                        <asp:Button ID="BtnGuardar" runat="server" class="btn btn-success btn-sm" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    <% Response.WriteFile("/Includes/filesCss.html"); %>
    <% Response.WriteFile("/Includes/filesJs.html"); %>
    </form>
    </body>
</html>

