using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using DePrueba;

namespace CapaAccesoTNS
{
    public class UsuarioDAO
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
        public Usuario AccesoSistem(String usuario, String password)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            Usuario objUsuario = null;
            FbDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("select * from usuarios where  nombre=@usuario and password=@password", conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                usuario = usuario.ToUpper();
                cmd.Parameters.AddWithValue("@usuario",usuario);
                cmd.Parameters.AddWithValue("@password", password);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.Nombre = dr["nombre"].ToString();
                    objUsuario.Password = dr["password"].ToString();
                    objUsuario.Rol = dr["rol"].ToString();
                }
            }
            catch (Exception e) {
                objUsuario = null;
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }

        public Usuario Prueba(String usuario,String password)
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            Usuario objUsuario = null;
            FbDataReader dr = null;
            String VRESULTADO = "";
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("TNS_WS_VERIFICAR_USUARIO", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                usuario = usuario.ToUpper();
                cmd.Parameters.AddWithValue("@CLAVE", password);
                cmd.Parameters.AddWithValue("@USERNAME", usuario);
                cmd.Parameters.Add("@OMENSAJE", FbDbType.VarChar, 250);
                conexion.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas < 0)
                {
                    VRESULTADO = Convert.ToString(cmd.Parameters["@VRESULTADO"].Value);
                }
             }
            catch (Exception e)
            {
                objUsuario = null;
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }
    }
}
