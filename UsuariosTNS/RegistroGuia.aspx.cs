using System;
using System.Web.UI;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using DePrueba;
using CapaLogic;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace UsuariosTNS
{
    [System.Web.UI.ControlValueProperty("FileBytes")]
    [System.Web.UI.ValidationProperty("FileName")]
    
    public partial class RegistroGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now;
                Prefijo prefijo = PrefijoLN.getInstance().ObtenerPrefijo();
                for (int i = 0; i < prefijo.CodPrefijo.Length; i++)
                {
                    if (prefijo.CodPrefijo[i] != null)
                    {
                        DropDownList2.Items.Add(prefijo.CodPrefijo[i].ToString());
                    }
                }
                ListarPedidos();
            }

            if (IsPostBack)
            {                            
                if (ListPedido.Text == "NUEVO")
                {
                    ListarPedidos();
                }                
            }

        }
        public void DayRender(Object source, DayRenderEventArgs e)
        {

            // Change the background color of the days in the month
            // to yellow.
           /* if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
            {
                e.Cell.BackColor = System.Drawing.Color.Blue;
            }
            else
            {
                e.Cell.Enabled = false;
            }     */           

            // Add custom text to cell in the Calendar control.
           /* if (e.Day.Date.Day == 18)
                e.Cell.Controls.Add(new LiteralControl("<br />Holiday"));*/

        }
        private void ListarPedidos()
        {
                ListPedido.Items.Clear();
                ListPedido.Items.Add("NUEVO");
                Pedido pedido = PedidoLN.getInstance().ObtenerPedidos();
                for (int i = 0; i < pedido.NumPedido.Length; i++)
                {
                    if (pedido.NumPedido[i] != null)
                    {
                        ListPedido.Items.Add(pedido.NumPedido[i].ToString());
                    }
                }
        }

        private Guia GetEntity()
        {
            Guia objGuia = new Guia();
            objGuia.IdGuia = txtNumAutorizacion.Text;
            objGuia.Estado = DropDownList1.Text;
            objGuia.TipoAgente = txtAgente.Text;
            objGuia.NombreComercial = txtNomComercial.Text;
            objGuia.Direccion = txtDireccion.Text;
            objGuia.CodSicom = txtCodSicom.Text;
            objGuia.Nit = txtNit.Text.Substring(0, txtNit.Text.Length - 1) + "%";
                //+ txtNit.Text.Substring(txtNit.Text.Length-1,1); 
            objGuia.TipoTransporte = txtTipoTransporte.Text;
            objGuia.Placa = txtPlaca.Text;
            objGuia.Conductor = txtConductor.Text;
            objGuia.Cedula = txtCedula.Text;
            objGuia.ProductoUno = txtProductoUno.Text;
            objGuia.CantidadUno = txtCantidadUno.Text;
            objGuia.ProductoDos = txtProductoDos.Text;
            objGuia.CantidadDos = txtCantidadDos.Text;
            objGuia.Fecha = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            objGuia.Prefijo = DropDownList2.Text;
            return objGuia;
        }


        protected void btnPDF_Click(object sender, EventArgs e)
        {
            CargarPDF();
        }

        private void CargarPDF()
        {
            ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(".") + "/" + FileUpload1.FileName);
                PdfReader reader = new PdfReader(Server.MapPath(".") + "/" + FileUpload1.FileName);
                StringBuilder text = new StringBuilder();
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, page, its);
                    string[] theLines = thePage.Split('\n');
                    txtNumAutorizacion.Text = theLines[13].Split(' ')[4];
                    txtAgente.Text = theLines[3].Split(':')[1];
                    txtNomComercial.Text = theLines[4].Split(':')[1].Split('-')[0];
                    txtDireccion.Text = theLines[5].Split(':')[1].Split('-')[0] + " - " + theLines[5].Split(':')[1].Split('-')[1] + " - " + theLines[5].Split(':')[1].Split('-')[2];
                    txtCodSicom.Text = theLines[4].Split(':')[2].Split('-')[0];
                    if (theLines[5].Split(':')[1].Split('-').Length == 4)
                    {
                        txtNit.Text = theLines[5].Split(':')[1].Split('-')[3].Split(' ')[2];
                    }
                    if (theLines[5].Split(':')[1].Split('-').Length == 5)
                    {
                        txtNit.Text = theLines[5].Split(':')[1].Split('-')[4].Split(' ')[2];
                    }
                    if (theLines[19].Split(':')[1].Split(' ')[2].Equals("TANQUE"))
                    {
                        txtTipoTransporte.Text = theLines[19].Split(':')[1].Split(' ')[1] + " " + theLines[19].Split(':')[1].Split(' ')[2];
                        txtPlaca.Text = theLines[19].Split(':')[1].Split(' ')[7];
                    }
                    else
                    {
                        txtTipoTransporte.Text = theLines[19].Split(':')[1].Split(' ')[1];
                        txtPlaca.Text = theLines[19].Split(':')[1].Split(' ')[6];
                    }
                    txtConductor.Text = theLines[19].Split('/')[3].Replace(" Conductor  ", "");
                    if (theLines[19].Split('/')[4] == "Cedula")
                    {
                        txtCedula.Text = theLines[20];
                        txtProductoUno.Text = ExtraeProducto(theLines[23]);
                        txtCantidadUno.Text = ExtraeCantidad(theLines[23]);

                        if (theLines.Length == 25)
                        {
                            txtProductoDos.Text = ExtraeProducto(theLines[24]);
                            txtCantidadDos.Text = ExtraeCantidad(theLines[24]);
                        }
                    }
                    else
                    {
                        txtCedula.Text = theLines[19].Split('/')[4].Replace(" Cedula ", "");
                        txtProductoUno.Text = ExtraeProducto(theLines[22]);
                        txtCantidadUno.Text = ExtraeCantidad(theLines[22]);

                        if (theLines.Length == 24)
                        {
                            txtProductoDos.Text = ExtraeProducto(theLines[23]);
                            txtCantidadDos.Text = ExtraeCantidad(theLines[23]);
                        }
                    }
                    
                }
                reader.Close();
            }
        }
        public String ExtraeProducto(String linea)
        {
            String producto = "";
            if (linea.Split(' ')[0] == "GASOLINA")
            {
                producto = linea.Split(' ')[0] + ' ' + linea.Split(' ')[1];
            }
            else
            {
                producto = linea.Split(' ')[0] + ' ' + linea.Split(' ')[2] + ' ' + linea.Split(' ')[3];
            }
            return producto;
        }
        public String ExtraeCantidad(String linea)
        {
            String cantidad = "";
            if (linea.Split(' ')[0] == "GASOLINA")
            {
                cantidad = linea.Split(' ')[4].Replace(",", "");
            }
            else
            {
                cantidad = linea.Split(' ')[5].Replace(",","");
            }
            return cantidad;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string response = "";
            Guia guia = GetEntity();
            if (ListPedido.Text=="NUEVO" && Calendar1.SelectedDate.Day< DateTime.Now.Day)
            {
                Calendar1.SelectedDate = DateTime.Now;
                Response.Write("<script>alert('Debe seleccionar una fecha valida')</script>");

            }
            else
            {
                if (FileUpload1.HasFile|| txtNumAutorizacion.Text!="")
                {
                    if (txtNumAutorizacion.Text == "")
                    {
                        CargarPDF();
                    }

                    if (ListPedido.Text=="NUEVO")
                    {

                        response = GuiaLN.getInstance().GuardarGuia(guia);
                        if (response == "OK")
                        {
                            Response.Write("<script>alert('PEDIDO GUARDADO EXITOSAMENTE !')</script>");
                            Limpiar();
                        }
                        else
                        {
                            Response.Write("<script>alert('" + response + "')</script>");
                            Response.Write("<script>alert('PEDIDO RESITRADO SIN ARTICULOS')</script>");
                        }

                    }
                    else
                    {
                        response = GuiaLN.getInstance().Actualziar(guia,ListPedido.Text);
                        if (response == "OK")
                        {
                            Response.Write("<script>alert('PEDIDO ACTUALIZADO EXITOSAMENTE !')</script>");
                            Limpiar();
                        }
                        else
                        {
                            Response.Write("<script>alert('" + response + "')</script>");
                            Response.Write("<script>alert('PEDIDO YA RESITRADO')</script>");
                        }

                    }

                }
                else
                {
                    Response.Write("<script>alert('Debe seleccionar un archivo')</script>");
                }                
            }
            ListarPedidos();

        }
        public void Limpiar()
        {
            txtAgente.Text = String.Empty;
            txtCantidadDos.Text = String.Empty;
            txtCantidadUno.Text = String.Empty;
            txtCedula.Text = String.Empty;
            txtCodSicom.Text = String.Empty;
            txtConductor.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtNit.Text = String.Empty;
            txtNomComercial.Text = String.Empty;
            txtNumAutorizacion.Text = String.Empty;
            txtPlaca.Text = String.Empty;
            txtProductoDos.Text = String.Empty;
            txtProductoUno.Text = String.Empty;
            txtTipoTransporte.Text = String.Empty;
        }

    }
}