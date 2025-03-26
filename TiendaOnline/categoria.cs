using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline
{
    public class Categoria
    {
        public int Codigo { get; set; }
        public string Name { get; set; }
        public List<Producto> Productos { get; private set; } = new List<Producto>();

        public Categoria(int codigo, string name)
        {
            Codigo = codigo;
            Name = name;
        }
        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }
        public void obtenerInfo() 
        {
            Console.WriteLine($"Categoria: {Name}, Codigo: {Codigo}, Productos: {Productos.Count}");
        }
    }
}
