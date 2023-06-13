using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
namespace CapaAccesoDatos
{
    class Conexion
    {
        #region "PATRON SINGLERON"
        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if(conexion==null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public FbConnection ConexionTNS()
        {
            FbConnection conexion = new FbConnection();
            conexion.ConnectionString = "User=SYSDBA;" +
            "Password=masterkey;" +
            "Database=c:\\datos tns\\DIPROMEDICOS 2017.GDB;" +
            "DataSource=LOCALHOST;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=NONE;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=true;" +
            "MinPoolSize=0;" +
            "MaxPoolSize=50;" +
            "Packet Size=8192;" +
            "ServerType=0";
            return conexion;
        }
    }
}
