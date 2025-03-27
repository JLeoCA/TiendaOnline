using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Carrito
    {
        public List <Producto> Productos {  get; set; } = new List <Producto> ();

        public void AddItem(Producto producto) 
        {
            Productos.Add (producto);
        }
        public void DeleteItem(Producto producto) 
        {
            Productos.Remove (producto);
        }
        public decimal totalventa() 
        {
            return Productos.Sum(p => p.Precio * p.Stock);
        }
        public List<Producto> ObtenerProductos()
        {
            return Productos;
        }

    }
}
