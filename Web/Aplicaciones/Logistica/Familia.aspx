<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Familia.aspx.cs" Inherits="Familia" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Familia</title>
    <% Response.WriteFile("/Includes/filesCss.html"); %>    <% Response.WriteFile("/Includes/filesJs.html"); %>
     <script type="text/javascript">
        function Demple(id,f) {
            document.getElementById("Hdfam").value = id;
            var objD = document.getElementById("BtnEliminar");
                if (objD){
                    objD.click();
                }
            $('#' + f).remove();
        }
        function Uemple(f) {
            document.getElementById("Hdfam").value = f;
            var objU = document.getElementById("BtnUpdate");
            if (objU) {
                objU.click();
            }
        }
    </script>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HctblFamilia" runat="server" />
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">Control Familias</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm">
                    <table class="table table-bordered" id="tblFamilia">
                        <thead class="bg-dark" runat="server">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                 <th class="text-center font-weight-light" style="display: none;">IdFam</th>
                                <th class="text-center font-weight-light"><div id="divControlFam" runat="server">
                                                <input type="text" id="txtBusFam" name='txtBusFam' placeholder='Buscar Familia' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusFam" Text="Buscar" runat="server" OnClick="btnBusFam_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyCol" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td style="display:none;"><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtIdFam1" class="form-control" /></div></td>
                                <td><div id="campo3" class="input-group input-group-sm"><input type="text" runat="server" id="txtFamilia1" class="form-control" /></div></td>
                                <td class="text-center"><div id="campo4"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
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
        <asp:HiddenField ID="Hdfam" runat="server" />
    </form>
    </body>
</html>

