using Examenp1.Reposiroty.Cliente;
using Examenp1.Reposiroty.DetalleFactura;
using Examenp1.Reposiroty.Producto;
using Examenp1.Servicio.Logica;
using System;

namespace Examenp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=postgres;Username=postgres;Password=root;";

            ServCliente clienteServices = new ServCliente(connectionString);
            ServFactura facturaServices = new ServFactura(connectionString);
            ServProducto productoServices = new ServProducto(connectionString);
            ServDetalleFactura detalleFacturaServices = new ServDetalleFactura(connectionString);

            Console.WriteLine("Ingrese: \n" +
                              "1 - Para insertar un nuevo cliente \n" +
                              "2 - Para listar clientes \n" +
                              "3 - Para actualizar un cliente \n" +
                              "4 - Para eliminar un cliente \n" +
                              "5 - Para insertar una nueva factura \n" +
                              "6 - Para listar facturas \n" +
                              "7 - Para actualizar una factura \n" +
                              "8 - Para eliminar una factura \n" +
                              "9 - Para insertar un nuevo producto \n" +
                              "10 - Para listar productos \n" +
                              "11 - Para actualizar un producto \n" +
                              "12 - Para eliminar un producto \n" +
                              "13 - Para insertar un nuevo detalle de factura \n" +
                              "14 - Para listar detalles de facturas \n" +
                              "15 - Para actualizar un detalle de factura \n" +
                              "16 - Para eliminar un detalle de factura");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InsertarCliente(clienteServices);
                    break;
                case "2":
                    ListarClientes(clienteServices);
                    break;
                case "3":
                    ActualizarCliente(clienteServices);
                    break;
                case "4":
                    EliminarCliente(clienteServices);
                    break;
                case "5":
                    InsertarFactura(facturaServices);
                    break;
                case "6":
                    ListarFacturas(facturaServices);
                    break;
                case "7":
                    ActualizarFactura(facturaServices);
                    break;
                case "8":
                    EliminarFactura(facturaServices);
                    break;
                case "9":
                    InsertarProducto(productoServices);
                    break;
                case "10":
                    ListarProductos(productoServices);
                    break;
                case "11":
                    ActualizarProducto(productoServices);
                    break;
                case "12":
                    EliminarProducto(productoServices);
                    break;
                case "13":
                    InsertarDetalleFactura(detalleFacturaServices);
                    break;
                case "14":
                    ListarDetallesFacturas(detalleFacturaServices);
                    break;
                case "15":
                    ActualizarDetalleFactura(detalleFacturaServices);
                    break;
                case "16":
                    EliminarDetalleFactura(detalleFacturaServices);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void InsertarCliente(ServCliente ServCliente)
        {
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del cliente:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el documento del cliente:");
            string documento = Console.ReadLine();

            Console.WriteLine("Ingrese el correo electrónico del cliente:");
            string mail = Console.ReadLine();

            Console.WriteLine("Ingrese su dirección:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese el número de celular del cliente:");
            string celular = Console.ReadLine();

            Console.WriteLine("Ingrese el estado del cliente:");
            string estado = Console.ReadLine();

            ServCliente.Insertar(new Cliente(nombre, apellido, documento, direccion, mail, celular, estado));

            Console.WriteLine("Cliente insertado exitosamente.");
        }

        static void ListarClientes(ServCliente ServCliente)
        {
            Console.WriteLine("Lista de clientes:");
            var clientes = ServCliente.Listado();
            clientes.ForEach(cliente =>
                Console.WriteLine(
                    $"ID: {cliente.id} \n" +
                    $"Nombre: {cliente.nombre} \n" +
                    $"Apellido: {cliente.apellido} \n" +
                    $"Documento: {cliente.documento} \n" +
                    $"Mail: {cliente.mail} \n" +
                    $"Direccion: {cliente.direccion} \n" +
                    $"Celular: {cliente.celular} \n" +
                    $"Estado: {cliente.estado} \n"
                )
            );
        }

        static void ActualizarCliente(ServCliente ServCliente)
        {
            Console.WriteLine("Ingrese el ID del cliente que desea actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int idCliente))
            {
                Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                return;
            }

        }

        static void EliminarCliente(ServCliente ServCliente)
        {
            Console.WriteLine("Ingrese el ID del cliente que desea eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int idCliente))
            {
                Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                return;
            }

            ServCliente.Eliminar(idCliente);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }

        static void InsertarFactura(ServFactura ServFactura)
        {

        }

        static void ListarFacturas(ServFactura ServFactura)
        {

        }

        static void ActualizarFactura(ServFactura ServFactura)
        {

        }

        static void EliminarFactura(ServFactura ServFactura)
        {

        }

        static void InsertarProducto(ServProducto ServProducto)
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad mínima:");
            if (!int.TryParse(Console.ReadLine(), out int cantidadMinima))
            {
                Console.WriteLine("Formato de cantidad mínima inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el precio de compra:");
            if (!int.TryParse(Console.ReadLine(), out int precioCompra))
            {
                Console.WriteLine("Formato de precio de compra inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el precio de venta:");
            if (!int.TryParse(Console.ReadLine(), out int precioVenta))
            {
                Console.WriteLine("Formato de precio de venta inválido. Intente nuevamente.");
                return;
            }

            try
            {
                ServProducto.Insertar(new Producto(nombre, cantidadMinima, precioCompra, precioVenta));
                Console.WriteLine("Producto insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListarProductos(ServProducto ServProducto)
        {
            Console.WriteLine("Lista de productos:");
            var productos = ServProducto.Listado();
            productos.ForEach(producto =>
                Console.WriteLine(
                    $"ID: {producto.Id} \n" +
                    $"Nombre: {producto.Nombre} \n" +
                    $"Cantidad Mínima: {producto.CantidadMinima} \n" +
                    $"Precio Compra: {producto.PrecioCompra} \n" +
                    $"Precio Venta: {producto.PrecioVenta} \n"
                )
            );
        }

        static void ActualizarProducto(ServProducto ServProducto)
        {
            // Implementar actualización de producto si es necesario
        }

        static void EliminarProducto(ServProducto ServProducto)
        {
            Console.WriteLine("Ingrese el ID del producto que desea eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int idProducto))
            {
                Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                return;
            }

            ServProducto.Eliminar(idProducto);
            Console.WriteLine("Producto eliminado exitosamente.");
        }

        static void InsertarDetalleFactura(ServDetalleFactura ServDetalleFactura)
        {
            Console.WriteLine("Ingrese el ID de la factura:");
            if (!int.TryParse(Console.ReadLine(), out int facturaId))
            {
                Console.WriteLine("Formato de ID de factura inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el ID del producto:");
            if (!int.TryParse(Console.ReadLine(), out int productoId))
            {
                Console.WriteLine("Formato de ID de producto inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese la cantidad:");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                Console.WriteLine("Formato de cantidad inválido. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el precio:");
            if (!int.TryParse(Console.ReadLine(), out int precio))
            {
                Console.WriteLine("Formato de precio inválido. Intente nuevamente.");
                return;
            }

            try
            {
                ServDetalleFactura.Insertar(new DetalleFactura(facturaId, productoId, cantidad, precio));
                Console.WriteLine("Detalle de factura insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListarDetallesFacturas(ServDetalleFactura ServDetalleFactura)
        {
            Console.WriteLine("Lista de detalles de facturas:");
            var detallesFacturas = ServDetalleFactura.Listado();
            detallesFacturas.ForEach(detalle =>
                Console.WriteLine(
                    $"ID: {detalle.Id} \n" +
                    $"Factura ID: {detalle.FacturaId} \n" +
                    $"Producto ID: {detalle.ProductoId} \n" +
                    $"Cantidad: {detalle.Cantidad} \n" +
                    $"Precio: {detalle.Precio} \n"
                )
            );
        }

        static void ActualizarDetalleFactura(ServDetalleFactura ServDetalleFactura)
        {
            // Implementar actualización de detalle de factura si es necesario
        }

        static void EliminarDetalleFactura(ServDetalleFactura ServDetalleFactura)
        {
            Console.WriteLine("Ingrese el ID del detalle de factura que desea eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int idDetalleFactura))
            {
                Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                return;
            }

            ServDetalleFactura.Eliminar(idDetalleFactura);
            Console.WriteLine("Detalle de factura eliminado exitosamente.");
        }
    }
}
