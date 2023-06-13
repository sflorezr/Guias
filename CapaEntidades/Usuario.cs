using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{    
    class Usuario
    {
        public String Nombre { get; set; }
        public String Password { get; set; }
        public String Rol { get; set; }

        public Usuario() { }
        public Usuario(String Nombre,String Password,String Rol)
        {
            this.Nombre = Nombre;
            this.Password = Password;
            this.Rol = Rol;
        }
    }
}
