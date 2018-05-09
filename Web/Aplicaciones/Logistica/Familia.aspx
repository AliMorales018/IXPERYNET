<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Familia.aspx.cs" Inherits="Familia" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_familia</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/Resources/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Resources/css/icons/styles.css">
    <link rel="stylesheet" href="/Resources/css/core.css">
    <link rel="stylesheet" href="/Resources/css/colors.css">
    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }
    </style>
</head>
<body class="bg-light">
    <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="">
                <h1 class="text-center mt-5">REGISTRO DE FAMILIAS</h1>
                <asp:HiddenField ID="Hc" runat="server" />
                <div class="container">
                    <div class="form-group">
                        <div class="table-responsive-lg text-size-sm">
                            <table class="table" id="tblFamilia" runat="server" visible="true">
                                <thead class="thead-light">
                                    <tr>
                                        <th class="text-center">N°</th>
                                        <th class="text-center">Familia</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <p>1</p>
                                        </td>

                                        <td>

                                            <div class="input-group input-group-sm">
                                                <input type="text" id="txtNomFam1" class="form-control" runat="server" />
                                            </div>
                                        </td>
                                        <td class="auto-style1">
                                            <label for="">
                                                <div>
                                                    <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                                                </div>
                                            </label>
                                        </td>
                                        <td class="text-center">
                                            <button type="button" class="btn btn-danger mr-sm-2 btn-sm">Eliminar</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <asp:Button ID="btnSave" runat="server" Text="Guardar" class="btn btn-dark btn-lg mb-5" OnClick="btnSave_Click" />
                </div>
            </form>
        </div>

    </div>

    <% Response.WriteFile("/Includes/filesCss.html"); %>    <% Response.WriteFile("/Includes/filesJs.html"); %>
</body>
</html>
