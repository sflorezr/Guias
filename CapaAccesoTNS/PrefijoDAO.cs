using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePrueba;
using FirebirdSql.Data.FirebirdClient;

namespace CapaAccesoTNS
{
    public class PrefijoDAO
    {
        #region "PATRON SINGLETON"
        private static PrefijoDAO daoPrefijo = null;
        private PrefijoDAO() { }
        public static PrefijoDAO getInstance()
        {
            if (daoPrefijo == null)
            {
                daoPrefijo = new PrefijoDAO();
            }
            return daoPrefijo;
        }
        #endregion
        public Prefijo ObtenerPrefijo()
        {
            FbConnection conexion = null;
            FbCommand cmd = null;
            Prefijo objPrefijo = null;
            FbDataReader dr = null;
            String[] cadena = null;
            try
            {
                conexion = Conexion.getInstance().ConexionTNS();
                cmd = new FbCommand("select * from CONSECUTIVO where CODCOMP='PV' AND CONSECUTIVO <>'' ", conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                conexion.Open();
                dr = cmd.ExecuteReader();
                int i = 0;
                cadena = new String[dr.FieldCount];
                while(dr.Read())
                {
                    cadena[i] = dr["codprefijo"].ToString();
                    i++;
                }
                objPrefijo = new Prefijo();
                objPrefijo.CodPrefijo = cadena;
            }
            catch (Exception e)
            {
                objPrefijo = null;
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return objPrefijo;
        }
    }


}
