using CapaAccesoTNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePrueba
{
    public class GuiaLN
    {
        #region "PATRON SINGLETON#
        private static GuiaLN objGuia = null;
        private GuiaLN() { }
        public static GuiaLN getInstance()
        {
            if (objGuia == null)
            {
                objGuia = new GuiaLN();
            }
            return objGuia;
        }
        #endregion

        public string GuardarGuia(Guia objGuia)
        {
            try
            {
                return GuiaDAO.getInstance().GuardarGuia(objGuia);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public string ConsultaGuia(Guia objGuia)
        {
            try
            {
                return GuiaDAO.getInstance().ConsultaGuia(objGuia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string Actualziar(Guia objGuia,String numero)
        {
            try
            {
                return GuiaDAO.getInstance().ActualizarGuia(objGuia,numero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
