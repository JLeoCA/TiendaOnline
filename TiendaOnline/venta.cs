using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Venta
    {
       public void ProcesarVenta(Cliente cliente)
        {
            var total = cliente.Carrito.totalventa();
            Console.WriteLine($"Venta procesada para {cliente.Nombre}, Total BS: {total}, Pago con: {cliente.Metpay}");
        }
    }
}
