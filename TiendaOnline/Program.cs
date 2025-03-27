// Tienda
/*
    
Modulo 1 .- Inverntario
            Crear producto
            Crear Categoria
            Asociar categoria con producto
            Informacion de productos
            - codigo
            - nombre
            - gestion de stock

Los productos usan CRUD, crear, editar, eliminar, listas prodcutos.

Multiplicidad en los diagramas UML:

0..1 = Cero o uno

1 = Solo uno

0..* = Cero o más

1..* = Uno o más

3 = Solo tres

0..5 = De cero a cinco

5..15 = De cinco a quince

 */

using System;
using TiendaOnline;

class Program
{
    static void Main(string[] args)
    {
        // Crear inventario, categorías y productos
        var inventario = new Inventario();

        var categoria1 = new Categoria(1, "Electrónica");
        var categoria2 = new Categoria(2, "Juegos");
        var categoria3 = new Categoria(3, "Zapatos");
        var categoria4 = new Categoria(4, "Telefonos");

        var producto1 = new Producto("TV SAMSUNG", 101, 500.99m, 10);
        var producto2 = new Producto("Iphone 14 pro", 102, 300.50m, 20);
        var producto3 = new Producto("PlayStation 5 Pro", 505, 600.10m, 5);
        var producto4 = new Producto("Jordan Retro 4 Red", 23, 1000.00m, 3);

        // Agregar productos a las categorías
        categoria1.AgregarProducto(producto1);
        categoria1.AgregarProducto(producto2);
        categoria2.AgregarProducto(producto3);
        categoria3.AgregarProducto(producto4);
        categoria4 .AgregarProducto(producto2);

        // Agregar categorías al inventario
        inventario.AgregarCategoria(categoria1);
        inventario.AgregarCategoria(categoria2);
        inventario.AgregarCategoria(categoria3);
        inventario.AgregarCategoria(categoria4);

        // Crear cliente
        var cliente = new Cliente(1, "Juan Pérez", "juan@example.com", "Tarjeta de Crédito");

        // Menú interactivo
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Tienda Online ===");
            Console.WriteLine("1. Ver productos por categoría");
            Console.WriteLine("2. Agregar producto al carrito");
            Console.WriteLine("3. Buscar producto por nombre");
            Console.WriteLine("4. Ver carrito");
            Console.WriteLine("5. Procesar venta");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    VerProductosPorCategoria(inventario.Categorias);
                    break;

                case "2":
                    AgregarProductoAlCarrito(cliente, inventario);
                    break;

                case "3":
                    BuscarProductoPorNombre(categoria1, categoria2, categoria3);
                    break;

                case "4":
                    VerCarrito(cliente.Carrito);
                    break;

                case "5":
                    ProcesarVenta(cliente);
                    break;

                case "6":
                    Console.WriteLine("¡Gracias por visitar nuestra tienda!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void VerProductosPorCategoria(List<Categoria> categorias)
    {
        Console.Clear();
        Console.WriteLine("=== Productos por Categoría ===");
        foreach (var categoria in categorias)
        {
            Console.WriteLine($"\nCategoría: {categoria.Name} (Código: {categoria.Codigo})");
            foreach (var producto in categoria.Productos)
            {
                Console.WriteLine($"- {producto.Codigo}: {producto.Nombre} - ${producto.Precio} (Stock: {producto.Stock})");
            }
        }
    }

    static void AgregarProductoAlCarrito(Cliente cliente, Inventario inventario)
    {
        Console.Clear();
        Console.WriteLine("=== Agregar Producto al Carrito ===");

        // Mostrar todos los productos
        foreach (var categoria in inventario.Categorias)
        {
            Console.WriteLine($"\nCategoría: {categoria.Name}");
            foreach (var producto in categoria.Productos)
            {
                Console.WriteLine($"- {producto.Codigo}: {producto.Nombre} - ${producto.Precio} (Stock: {producto.Stock})");
            }
        }

        // Solicitar código del producto
        Console.Write("\nIngrese el código del producto que desea agregar: ");
        if (int.TryParse(Console.ReadLine(), out int codigoProducto))
        {
            var productoSeleccionado = inventario.Categorias
                .SelectMany(c => c.Productos)
                .FirstOrDefault(p => p.Codigo == codigoProducto);

            if (productoSeleccionado != null)
            {
                if (productoSeleccionado.Stock > 0)
                {
                    cliente.Carrito.AddItem(productoSeleccionado);
                    productoSeleccionado.Stock--; // Reducir el stock
                    Console.WriteLine($"Producto '{productoSeleccionado.Nombre}' agregado al carrito.");
                }
                else
                {
                    Console.WriteLine("Lo sentimos, este producto no tiene stock disponible.");
                }
            }
            else
            {
                Console.WriteLine("Código de producto no válido.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Ingrese un número.");
        }
    }

    static void VerCarrito(Carrito carrito)
    {
        Console.Clear();
        Console.WriteLine("=== Carrito de Compras ===");

        var productos = carrito.ObtenerProductos();
        if (productos.Any())
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.Nombre} - ${producto.Precio}");
            }

            Console.WriteLine($"\nTotal: BS {carrito.totalventa()}");
        }
        else
        {
            Console.WriteLine("El carrito está vacío.");
        }
    }

    static void ProcesarVenta(Cliente cliente)
    {
        Console.Clear();
        Console.WriteLine("=== Procesar Venta ===");

        if (!cliente.Carrito.ObtenerProductos().Any())
        {
            Console.WriteLine("El carrito está vacío. No se puede procesar la venta.");
            return;
        }

        var venta = new Venta();
        venta.ProcesarVenta(cliente);

        // Limpiar el carrito después de la venta
        cliente.Carrito = new Carrito();
    }

    static void BuscarProductoPorNombre(Categoria categoria1, Categoria categoria2, Categoria categoria3)
    {
        Console.Write("Ingresa el nombre del producto a buscar: ");
        string nombreBuscado = Console.ReadLine() ?? "".ToLower(); // Convertir a minúsculas para búsqueda sin distinción de mayúsculas/minúsculas

        // Buscar en todas las categorías
        var productosEncontrados = categoria1.Productos
            .Concat(categoria2.Productos)
            .Concat(categoria3.Productos)
            .Where(p => p.Nombre.ToLower().Contains(nombreBuscado)) // Buscar si el nombre contiene la cadena introducida
            .ToList();

        if (productosEncontrados.Count > 0)
        {
            Console.WriteLine($"Productos encontrados para '{nombreBuscado}':");
            foreach (var producto in productosEncontrados)
            {
                Console.WriteLine(producto.ToString());
            }
        }
        else
        {
            Console.WriteLine($"No se encontraron productos para '{nombreBuscado}'.");
        }
    }
}


