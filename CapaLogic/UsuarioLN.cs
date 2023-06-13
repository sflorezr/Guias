using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoTNS;
using DePrueba;
namespace CapaLogic
{
    public class UsuarioLN
    {
        #region "PATRON SINGLETON#
        private static UsuarioLN objUsuario = null;
        private UsuarioLN() { }
        public static UsuarioLN getInstance()
        {
            if (objUsuario == null)
            {
                objUsuario = new UsuarioLN();
            }
            return objUsuario;
        }
        #endregion
        public Usuario AccesoSistem(String usuario, String password)
        {
            try
            {
                return UsuarioDAO.getInstance().AccesoSistem(usuario, password);
                //return UsuarioDAO.getInstance().Prueba(usuario, password);
            }  catch(Exception ex)
            {
                throw ex;
            }          
        }
    }
}
