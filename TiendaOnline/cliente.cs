using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Cliente
    {
        public int IDCliente {  get; private set; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        public string Metpay { get; private set; }
        public Carrito Carrito { get; set; } = new Carrito();

        public Cliente(int idCliente, string nombre, string email, string metpay)
        {
            IDCliente = idCliente;
            Nombre = nombre;
            Email = email;
            Metpay = metpay;
        }
        public void metodoPago() 
        {
            Console.WriteLine($"Metodo de Pago {Metpay}");
        }
        public void llamarCarrito() 
        {
            Console.WriteLine($"Carrito de {Nombre} tiene {Carrito.ObtenerProductos().Count} productos");
        }
    }
}
