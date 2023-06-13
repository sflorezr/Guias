using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
namespace CapaAccesoDatos
{
    class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion
        public Usuario AccesoSistem(String usuario,String password)
        {

        }
    }
}
