<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PruebaGrilla.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- Latest compiled and minified CSS -->
    <link rel="shortcut icon" href="images/favicon.ico">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">


<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script>
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
          <div>
              <asp:HiddenField ID="hfIdProduct" runat="server" />
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" ShowFooter="true" 
            ShowHeaderWhenEmpty="true" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"   OnRowCommand="gvProductos_RowCommand">
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

                    <asp:TemplateField HeaderText="Producto">
                        <FooterTemplate>
                            <asp:DropDownList ID="cmbProductNameFooter" runat="server">
                                <asp:ListItem Value="0">Producto1</asp:ListItem>
                                <asp:ListItem Value="1">Producto2</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnAdd" runat="server"/>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="cmbProducto" Text='<%# Eval("ProductName") %>' runat="server" />
                            <asp:Button ID="btnAdd" runat="server"/>
                            <%--<asp:DropDownList ID="cmbProducto" Text='<%# Eval("ProductName") %>' runat="server"/>--%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="cmbProducto" Text='<%# Eval("ProductName") %>' runat="server"/>
                        </EditItemTemplate>
                        <%--<FooterTemplate>
                           <asp:DropDownList ID="txtProductNameFooter" runat="server" />
                       </FooterTemplate>--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPrecio" Text='<%# Eval("PrecioName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecio" Text='<%# Eval("PrecioName") %>' runat="server" />
                        </EditItemTemplate>
                       <FooterTemplate>
                           <asp:TextBox ID="txtPrecioNameFooter" runat="server" />
                       </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidad" Text='<%# Eval("CantidadName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCantidad" Text='<%# Eval("CantidadName") %>' runat="server" />
                        </EditItemTemplate>
                       <FooterTemplate>
                           <asp:TextBox ID="txtCantidadNameFooter" runat="server" />
                       </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <asp:TextBox  ID="txtSubtotal" Text='<%# Eval("SubtotalName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubtotal" Text='<%# Eval("SubtotalName") %>' runat="server" />
                        </EditItemTemplate>
                       <FooterTemplate>
                           <asp:TextBox ID="txtSubtotalNameFooter" runat="server" />
                       </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/images/1.jpg" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/2.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/images/3.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/images/1.jpg" runat="server" CommandName="AddNew" ToolTip="AddNew" Width="20px" Height="20px" />
                        </FooterTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
          <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
    <br/>



        </form>

    <div class="modal fade" role="dialog" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" style="display: none;"> <div class="modal-dialog" role="document"> <div class="modal-content"> <div class="modal-header"> <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button> <h4 class="modal-title" id="myModalLabel">Modal title</h4> </div> <div class="modal-body"> <h4>Text in a modal</h4> <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula.</p> <h4>Popover in a modal</h4> <p>This <a href="#" class="btn btn-default popover-test" role="button" title="" data-content="And here's some amazing content. It's very engaging. right?" data-original-title="A Title">button</a> should trigger a popover on click.</p> <h4>Tooltips in a modal</h4> <p><a href="#" class="tooltip-test" title="" data-original-title="Tooltip">This link</a> and <a href="#" class="tooltip-test" title="" data-original-title="Tooltip">that link</a> should have tooltips on hover.</p> <hr> <h4>Overflowing text to show scroll behavior</h4> <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p> <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p> <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p> <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p> <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p> <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p> <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p> <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p> <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p> </div> <div class="modal-footer"> <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> <button type="button" class="btn btn-primary">Save changes</button> </div> </div> </div> </div>

    </body>
    </html>