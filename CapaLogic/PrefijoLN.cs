using CapaAccesoTNS;
using DePrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogic
{
    public class PrefijoLN
    {
        #region "PATRON SINGLETON#
        private static PrefijoLN objPrefijo = null;
        private PrefijoLN() { }
        public static PrefijoLN getInstance()
        {
            if (objPrefijo == null)
            {
                objPrefijo = new PrefijoLN();
            }
            return objPrefijo;
        }
        #endregion
        public Prefijo ObtenerPrefijo()
        {
            try
            {
                return PrefijoDAO.getInstance().ObtenerPrefijo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
