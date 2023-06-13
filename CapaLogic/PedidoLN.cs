using CapaAccesoTNS;
using DePrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogic
{
    public class PedidoLN
    {
        #region "PATRON SINGLETON#
        private static PedidoLN objPedido = null;
        private PedidoLN() { }
        public static PedidoLN getInstance()
        {
            if (objPedido == null)
            {
                objPedido = new PedidoLN();
            }
            return objPedido;
        }
        #endregion
        public Pedido ObtenerPedidos()
        {
            try
            {
                return PedidoDAO.getInstance().ObtenerPedido();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
