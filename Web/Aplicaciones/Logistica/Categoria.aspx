<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categoria.aspx.cs" Inherits="Aplicaciones_Logistica_Categoria" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Categorias</title>
    <% Response.WriteFile("/Includes/filesCss.html"); %>    <% Response.WriteFile("/Includes/filesJs.html"); %>
      <script type="text/javascript">
        function Dcate(id,f) {
            document.getElementById("Hdcate").value = id;
            var objD = document.getElementById("BtnEliminar");
                if (objD){
                    objD.click();
                }
            $('#' + f).remove();
        }
        function Ucate(f) {
            document.getElementById("Hdcate").value = f;
            var objU = document.getElementById("BtnUpdate");
            if (objU) {
                objU.click();
            }
        }
    </script>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HctblCategoria" runat="server" />
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">Control Categorias</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm">
                    <table class="table table-bordered" id="tblCategoria">
                        <thead class="bg-dark" runat="server">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                <th class="text-center font-weight-light" style="display: none;">IdCateg</th>
                                <th class="text-center font-weight-light">
                                    <div id="divControlCat" runat="server">
                                        <input type="text" id="txtBusCat" name='txtBusCat' placeholder='Buscar Categoria' class='form - control' runat="server" />
                                        <asp:Button ID="btnBusCat" Text="Buscar" runat="server" OnClick="btnBusCat_Click" />
                                    </div>
                                </th>
                                <th class="text-center font-weight-light">Familia</th>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyCol" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td style="display: none;"><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtIdCat1" class="form-control" /></div></td>
                                <td><div id="campo3" class="input-group input-group-sm"><input type="text" runat="server" id="txtCategoria1" class="form-control" /></div></td>
                                <td><div id="campo4" class="input-group input-group-sm"><select runat="server" class="form-control" id="cmbFam1"></select></div></td>
                                <td class="text-center"><div id="campo5"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
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
        <asp:HiddenField ID="Hdcate" runat="server" />
    </form>
    </body>
</html>
