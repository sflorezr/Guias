using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Web;

namespace CapaAccesoTNS
{
    class Conexion
    {
        #region "PATRON SINGLERON"
        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public FbConnection ConexionTNS()
        {
            FbConnection conexion = new FbConnection();
            StreamReader re = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "", "") + "/rutatns.txt");
           // StreamReader re = File.OpenText(HttpContent.Server.MapPath("rutatns.txt") );
            


            conexion.ConnectionString = "User=SYSDBA;" +
            "Password=masterkey;" +
            "Database="+ re.ReadLine()+"; " +
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
