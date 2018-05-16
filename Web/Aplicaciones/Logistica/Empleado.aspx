<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empleado.aspx.cs" Inherits="Aplicaciones_Logistica_Empleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Empleados</title>
    <% Response.WriteFile("/Includes/filesCss.html"); %>
    <% Response.WriteFile("/Includes/filesJs.html"); %>
      <script type="text/javascript">
        function Demple(id,f) {
            document.getElementById("Hdemp").value = id;
            var objD = document.getElementById("BtnEliminar");
                if (objD){
                    objD.click();
                }
            $('#' + f).remove();
            //BtnEliminar_Click($(this), e);
        }
        function Uemple(f) {
            document.getElementById("Hdemp").value = f;
            var objU = document.getElementById("BtnUpdate");
            if (objU) {
                objU.click();
            }
        }
    </script>
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
                    <table class="table table-bordered" id="tblEmpleado">
                        <thead class="bg-dark" runat="server">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                <th class="text-center font-weight-light" style="display: none;">IdEmpleado</th>
                                <th class="text-center font-weight-light">Area</th>
                                <th class="text-center font-weight-light"><div id="divControlDni" runat="server">
                                                <input type="text" id="txtBusDni" name='txtBusDni' placeholder='Buscar Dni' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusDni" Text="Buscar" runat="server" OnClick="btnBusDni_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light"><div id="divControlNom" runat="server">
                                                <input type="text" id="txtBusNom" name='txtBusNom' placeholder='Buscar Nombre' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusNom" Text="Buscar" runat="server" OnClick="btnBusNom_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light"><div id="divControlPat" runat="server">
                                                <input type="text" id="txtBusPat" name='txtBusPat' placeholder='Buscar A. Paterno' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusPat" Text="Buscar" runat="server" OnClick="btnBusPat_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light"><div id="divControlMat" runat="server">
                                                <input type="text" id="txtBusMat" name='txtBusMat' placeholder='Buscar A. Materno' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusMat" Text="Buscar" runat="server" OnClick="btnBusMat_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light">Telefono</th>
                                <th class="text-center font-weight-light">Direccion</th>
                                <th class="text-center font-weight-light">Fecha_Nacimiento</th>
                                <th class="text-center font-weight-light">Sexo</th>
                                <%--<th class="text-center font-weight-light">Estado</th>--%>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyCol" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td style="display: none;"><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtId1" class="form-control" /></div></td>
                                <td><div id="campo3" class="input-group input-group-sm"><select runat="server" class="form-control" id="cmbArea1"></select></div></td>
                                <td><div id="campo4" class="input-group input-group-sm"><input type="text" runat="server" id="txtDni1" class="form-control" /></div></td>
                                <td><div id="campo5" class="input-group input-group-sm"><input type="text" runat="server" id="txtNombre1" class="form-control" /></div></td>
                                <td><div id="campo6" class="input-group input-group-sm"><input type="text" runat="server" id="txtApePat1" class="form-control" /></div></td>
                                <td><div id="campo7" class="input-group input-group-sm"><input type="text" runat="server" id="txtApeMat1" class="form-control" /></div></td>
                                <td><div id="campo8" class="input-group input-group-sm"><input type="text" runat="server" id="txtTelef1" class="form-control" /></div></td>
                                <td><div id="campo9" class="input-group input-group-sm"><input type="text" runat="server" id="txtDirec1" class="form-control" /></div></td>
                                <td><div id="campo10" class="input-group input-group-sm"><input type="date" value="2018-05-15" runat="server" id="txtFNac1" class="form-control" /></div></td>
                                <td><div id="campo11" class="input-group input-group-sm"><select runat="server" id="cmbSex1" class="form-control" ><option value="M">M</option><option value="F">F</option></select></div></td>
                                <%--<td><div id="campo10" class="input-group input-group-sm"><input type="checkbox" runat="server" id="txtEstad1" value="0"  class="form-control"/></div></td>--%>
                                <td class="text-center"><div id="campo12"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
                            </tr>
                        </tbody>
                    </table>
                    <div class="container text-center">
                        <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                        <asp:Button ID="BtnGuardar" runat="server" class="btn btn-success btn-sm" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
                        <asp:Button ID="BtnEliminar" runat="server"  class="btn btn-success btn-sm" Text="Eliminar" OnClick="BtnEliminar_Click"></asp:Button>
                        <asp:Button ID="BtnUpdate" runat="server"  class="btn btn-success btn-sm" Text="Update" OnClick="BtnUpdate_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="Hdemp" runat="server" />
    </form>
    </body>
</html>

