using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DePrueba;
using CapaLogic;
using System.Web.Security;
using UsuariosTNS.Custom;

namespace UsuariosTNS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSession"] = null;
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
          //  bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);
         /*   if (auth)
            {
                Usuario objUsuario = UsuarioLN.getInstance().AccesoSistem(LoginUser.UserName, LoginUser.Password);
                if (objUsuario != null)
                {
                    SessionManager sessionManager = new SessionManager(Session);
                    
                    Response.Redirect("PanelGeneral.aspx");
                }
                else
                {
                    Response.Write("<script>alert('USUARIO NO CORRECTO !')</script>");
                }
            }
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = UsuarioLN.getInstance().AccesoSistem(Username.Text,Password.Text);
            if (objUsuario != null)
            {
                SessionManager sessionManager = new SessionManager(Session);

                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('USUARIO NO CORRECTO !')</script>");
            }
        }
    }
}