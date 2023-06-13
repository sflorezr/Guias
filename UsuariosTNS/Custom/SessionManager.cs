using DePrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace UsuariosTNS.Custom
{
    public class SessionManager
    {
        #region variables
        private HttpSessionState _currentSession;
        #endregion

        public SessionManager(HttpSessionState session)
        {
            this._currentSession = session;
        }

        #region metodos
        private HttpSessionState CurrentSession
        {
            get { return this._currentSession; }
        }

        public string UserSessionId
        {
            set { CurrentSession["UserSessionId"] = value; }
            get { return (string)CurrentSession["UserSessionId"]; }
        }


        public Usuario UserSessionEmpleado
        {
            set { CurrentSession["UserSessionEmpleado"] = value; }
            get { return (Usuario)CurrentSession["UserSessionEmpleado"]; }
        }

        #endregion
    }
}