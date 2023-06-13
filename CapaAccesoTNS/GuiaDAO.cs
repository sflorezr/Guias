using DePrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
namespace CapaAccesoTNS
{
    public class GuiaDAO
    {
        #region "PATRON SINGLETON"
        private static GuiaDAO objGuia = null;
        private GuiaDAO() { }
        public static GuiaDAO getInstance()
        {
            if (objGuia == null)
            {
                objGuia = new GuiaDAO();
            }
            return objGuia;
        }
        #endregion

        public String GuardarGuia(Guia objGuia)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            String VRESULTADO = "";
            String numero = "";
            try
            {
                numero = consecutivo(objGuia);
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("SF_PEDIDO_VENTA", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VCODCOMP", "PV");
                cmd.Parameters.AddWithValue("@VCODPREFIJO", objGuia.Prefijo);
                cmd.Parameters.AddWithValue("@VNUMERO", numero);
                cmd.Parameters.AddWithValue("@VFECHA", objGuia.Fecha);
                cmd.Parameters.AddWithValue("@VFORMAPAGO", "CR");
                cmd.Parameters.AddWithValue("@VNITCLIENTE", objGuia.Nit);
                cmd.Parameters.AddWithValue("@VNITVENDEDOR", "00");
                cmd.Parameters.AddWithValue("@VNITDESPACHAR", "00");
                cmd.Parameters.AddWithValue("@VBANCO", "00");
                cmd.Parameters.AddWithValue("@VMODO", "I");
                cmd.Parameters.AddWithValue("@VUSUARIO", "SISTEMAS");
                cmd.Parameters.AddWithValue("@VAUTORIZACION", objGuia.IdGuia);
                cmd.Parameters.AddWithValue("@VPLACA", objGuia.Placa);
                cmd.Parameters.AddWithValue("@VSICOM", objGuia.CodSicom);
                cmd.Parameters.Add("@VRESULTADO", FbDbType.VarChar, 250);
                cmd.Parameters["@VRESULTADO"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    VRESULTADO = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);                                        
                    if (VRESULTADO == "OK")
                    {
                        VRESULTADO=GuardarDetalle(objGuia, objGuia.ProductoUno, objGuia.CantidadUno,numero);
                        if (objGuia.ProductoDos != "")                        
                        {
                            VRESULTADO=GuardarDetalle(objGuia, objGuia.ProductoDos, objGuia.CantidadDos,numero);
                        }
                    }
                    Refrescar(objGuia, numero);
                }               
            }
            catch(Exception e)
            {
                VRESULTADO = e.ToString();
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return VRESULTADO;
        }

        public String ActualizarGuia(Guia objGuia,String numero)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            String VRESULTADO = "";
            //String numero = "";
            try
            {
                //numero = consecutivo(objGuia);
                //numero = ConsultaGuia(objGuia).Split('-')[1];
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("SF_LIMPIAR_PEDIDO", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VCODPREFIJO", objGuia.Prefijo);                
                cmd.Parameters.AddWithValue("@VNUMERO", numero);
                cmd.Parameters.AddWithValue("@VGUIA", objGuia.IdGuia);
                cmd.Parameters.AddWithValue("@VNITCLIENTE", objGuia.Nit);
                cmd.Parameters.Add("@VRESULTADO", FbDbType.VarChar, 250);
                cmd.Parameters["@VRESULTADO"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    VRESULTADO = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);
                    if (VRESULTADO == "OK")
                    {
                        VRESULTADO = GuardarDetalle(objGuia, objGuia.ProductoUno, objGuia.CantidadUno, numero);
                        if (objGuia.ProductoDos != "")
                        {
                            VRESULTADO = GuardarDetalle(objGuia, objGuia.ProductoDos, objGuia.CantidadDos, numero);
                        }
                    }
                    Refrescar(objGuia, numero);
                }
            }
            catch (Exception e)
            {
                VRESULTADO = e.ToString();
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return VRESULTADO;
        }



        private String GuardarDetalle(Guia objGuia,String Producto,String Cantidad,String numero)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            String VRESULTADO = "";
            String producto = "";
            if (Producto== "GASOLINA CORRIENTE")
            {
                producto = "C04";
            }
            else
            {
                producto = "C02";
            }
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("SF_DETALLEPEDIDO", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VNUMERO", numero);
                cmd.Parameters.AddWithValue("@VCODART", producto);
                cmd.Parameters.AddWithValue("@VDESCUENTO", 0);
                cmd.Parameters.AddWithValue("@CANTIDAD", Int32.Parse(Cantidad));
                cmd.Parameters.AddWithValue("@VVALOR", 0);
                cmd.Parameters.AddWithValue("@VCODPREFIJO", objGuia.Prefijo);
                cmd.Parameters.AddWithValue("@VCODCOMP", "PV");
                cmd.Parameters.AddWithValue("@VBODEGA", "00");                
                cmd.Parameters.AddWithValue("@VMES", objGuia.Fecha.Substring(0,2));
                cmd.Parameters.AddWithValue("@VANO", objGuia.Fecha.Substring(6, 4));
                cmd.Parameters.AddWithValue("@VCUPO", TieneCupo(objGuia));
                cmd.Parameters.Add("@VRESULTADO", FbDbType.VarChar, 250);
                cmd.Parameters["@VRESULTADO"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    VRESULTADO = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);
                }
            }
            catch (Exception e)
            {
                VRESULTADO = e.ToString();
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return VRESULTADO;
        }
        public String ConsultaGuia(Guia objGuia)
        {
            String Respuesta = "";
            FbConnection conexion = null;
            FbCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("SF_CONSULTA_AUTORIZACION",conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VAUTORIZACION", objGuia.IdGuia);
                cmd.Parameters.Add("@VRESULTADO", FbDbType.VarChar, 250);
                cmd.Parameters["@VRESULTADO"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    Respuesta = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Respuesta;
        }

        public void Refrescar(Guia objGuia, String numero)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            FbDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("TNS_ACTTOTALFACT", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VCODCOMP", "PV");
                cmd.Parameters.AddWithValue("@VCODPREFIJO", objGuia.Prefijo);
                cmd.Parameters.AddWithValue("@NUMERO", numero);
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

        }

        public String TieneCupo(Guia objGuia)
        {
            String tieneCupo = "";
            FbConnection conexion = null;
            FbCommand cmd = null;
            FbDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("SF_TIENECUPO", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VNIT", objGuia.Nit);
                cmd.Parameters.AddWithValue("@VCANTIDAD", objGuia.CantidadUno);
                cmd.Parameters.AddWithValue("@VMES", objGuia.Fecha.Substring(0, 2));
                cmd.Parameters.Add("@VRESULTADO", FbDbType.VarChar, 250);
                cmd.Parameters["@VRESULTADO"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    tieneCupo = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return tieneCupo;
        }
        public String consecutivo(Guia objGuia)
        {
            String consecutivo = "";
            List<Guia> Lista = new List<Guia>();
            FbConnection conexion = null;
            FbCommand cmd = null;
            FbDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("TNS_SP_CONSECUTIVO2",conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VCODCOMP", "PV");
                cmd.Parameters.AddWithValue("@VCODPREFIJO", objGuia.Prefijo);
                cmd.Parameters.AddWithValue("@VSUCID", 1);
                cmd.Parameters.Add("@RETORNA", FbDbType.VarChar, 250);
                cmd.Parameters["@RETORNA"].Direction = ParameterDirection.Output;
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    consecutivo = Convert.ToString(cmd.Parameters["@RETORNA"].Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return consecutivo;
        }
    }


}
