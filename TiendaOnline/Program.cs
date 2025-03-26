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

using TiendaOnline;

class Program
{
    static void Main(string[] args)
    {
        // Crear categorías y productos
        var categoria = new Categoria(1, "Electrónica");
        var categoria2 = new Categoria(2, "Juegos");
        var categoria3 = new Categoria(3, "Zapatos");
        var producto1 = new Producto("Televisor", 101, 500.99m, 10);
        var producto2 = new Producto("Smartphone", 102, 300.50m, 20);
        var producto3 = new Producto("PlayStation 5 Pro", 505, 600.10m, 100);
        var producto4 = new Producto("Jordan Retro 4 Red", 23, 1000.00m, 50);

        // Agregar productos a la categoría
        categoria.AgregarProducto(producto1);
        categoria.AgregarProducto(producto2);
        categoria2.AgregarProducto(producto3);
        categoria3.AgregarProducto(producto4);

        // Crear cliente y carrito
        var cliente = new Cliente(1, "Juan Pérez", "juan@example.com", "tarjeta");
        cliente.Carrito.AddItem(producto1);
        cliente.Carrito.AddItem(producto2);
        var cliente2 = new Cliente(1, "Anuel", "anuelAA@example.com", "efectivo");
        cliente2.Carrito.AddItem(producto3);
        cliente2.Carrito.AddItem(producto4);

        // Procesar venta
        var venta = new Venta();
        venta.ProcesarVenta(cliente);

        var venta2 = new Venta();
        venta2.ProcesarVenta(cliente2);
    }
}

