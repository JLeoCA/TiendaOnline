using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Producto
    {
        public string Nombre {  get; private set; }
        public int Codigo { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; set; }

        public Producto(string nombre, int codigo, decimal precio, int stock)
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precio;
            Stock = stock;
        }
        public override string ToString() 
        {
            return $"Producto: {Nombre}, Codigo: {Codigo}, Precio: {Precio}, Stock: {Stock}"; 
        }
    }
}
