using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePrueba
{
    public class Pedido
    {
        public String[] NumPedido { get; set; }

        public Pedido() { }
        public Pedido(String[] NumPedido)
        {
            this.NumPedido = NumPedido;
        }
    }
}
