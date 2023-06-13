<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistroGuia.aspx.cs" Inherits="UsuariosTNS.RegistroGuia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:center">REGISTRODE GUIA</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>ARCHIVO DE AUTORIZACION</label>
                        </div>
                        <div class="form-group">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="200px"></asp:FileUpload>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnPDF" runat="server" Text="Importar Datos" CssClass="btn btn-primary" Width="200px" OnClick="btnPDF_Click"></asp:Button>
                        </div>
                        <div class="form-group">
                            <label>PREFIJO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>PEDIDO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ListPedido" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>FECHA</label>
                        </div>
                        <div class="form-group">
                            <asp:Calendar ID="Calendar1" CssClass="form-control" OnDayRender="DayRender" runat="server"></asp:Calendar>
                        </div>
                        <div class="form-group">
                            <label>NUMERO DE AUTORIZACION</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNumAutorizacion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>ESTADO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                <asp:ListItem>ACEPTADA</asp:ListItem>
                                <asp:ListItem>EN PEDIDO</asp:ListItem>
                                <asp:ListItem>FACTURADA</asp:ListItem>
                                <asp:ListItem>DEPACHADA</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>TIPO DE AGENTE</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtAgente" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NOMBRE COMERCIAL</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNomComercial" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>DIRECCION</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CODIGO SICOM</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCodSicom" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NIT</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNit" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>TIPO TRANSPORTE</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTipoTransporte" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>PLACA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPlaca" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CONDUCTOR</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtConductor" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CEDULA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCedula" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>PRODUCTO UNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtProductoUno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CANTIDAD UNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidadUno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>PRODUCTO DOS</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtProductoDos" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CANTIDAD DOS</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCantidadDos" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Width="200px" OnClick="btnGuardar_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>