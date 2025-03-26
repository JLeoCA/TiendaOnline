using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Inventario
    {
        public List<Producto> Productos { get; private set; } = new List<Producto>();
        public List<Categoria> Categorias { get; private set; } = new List<Categoria>();


        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }
        public void AgregarCategoria(Categoria categoria)
        {
            Categorias.Add(categoria);
        }
        public void stock()
        {
            foreach (var producto in Productos)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Stock: {producto.Stock}");
            }
        }
    }
}
