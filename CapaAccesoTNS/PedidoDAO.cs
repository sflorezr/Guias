using DePrueba;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoTNS
{
    public class PedidoDAO
    {
        #region "PATRON SINGLETON"
        private static PedidoDAO daoPedido = null;
        private PedidoDAO() { }
        public static PedidoDAO getInstance()
        {
            if (daoPedido == null)
            {
                daoPedido = new PedidoDAO();
            }
            return daoPedido;
        }
        #endregion
        public Pedido ObtenerPedido()
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            Pedido objPedido = null;
            FbDataReader dr = null;
            String[] cadena = null;
            ArrayList aList = new ArrayList();
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("select DISTINCT NUMERO from KARDEX where CODCOMP='PV' AND CODPREFIJO='CO' and fecasentad is null ", conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                conexion.Open();
                dr = cmd.ExecuteReader();
                int i = 0;
                cadena = new String[dr.FieldCount];
                while (dr.Read())
                {
                    aList.Add ( dr[0]);
                   // cadena[i] = dr["NUMERO"].ToString();
                   // i++;
                }
                objPedido = new Pedido();
                objPedido.NumPedido = (string[])aList.ToArray(typeof(string)) ;
            }
            catch (Exception e)
            {
                objPedido = null;
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return objPedido;
        }

    }
}
