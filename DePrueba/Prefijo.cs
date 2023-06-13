using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePrueba
{
    public class Prefijo
    {
        public String [] CodPrefijo { get; set; }

        public Prefijo() { }
        public Prefijo(String[] codPrefijo)
        {
            this.CodPrefijo = codPrefijo;
        }
    }
}
