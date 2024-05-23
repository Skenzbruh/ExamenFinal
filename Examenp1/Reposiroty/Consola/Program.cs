using Examenp1.Reposiroty.Cliente;
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

            Console.WriteLine("Ingrese: \n 1 - Para insertar un nuevo cliente \n 2 - Para listar clientes \n 3 - Para actualizar un cliente \n 4 - Para eliminar un cliente \n 5 - Para insertar una nueva factura \n 6 - Para listar facturas \n 7 - Para actualizar una factura \n 8 - Para eliminar una factura");
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
                    $"Nombre: {cliente.Nombre} \n" +
                    $"Apellido: {cliente.Apellido} \n" +
                    $"Documento: {cliente.Documento} \n" +
                    $"Mail: {cliente.Mail} \n" +
                    $"Direccion: {cliente.Direccion} \n" +
                    $"Celular: {cliente.Celular} \n" +
                    $"Estado: {cliente.Estado} \n"
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

            // Aquí sigue la lógica para actualizar el cliente...
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
            // Aquí sigue la lógica para insertar una factura...
        }

        static void ListarFacturas(ServFactura ServFactura)
        {
            // Aquí sigue la lógica para listar las facturas...
        }

        static void ActualizarFactura(ServFactura ServFactura)
        {
            // Aquí sigue la lógica para actualizar una factura...
        }

        static void EliminarFactura(ServFactura ServFactura)
        {
            // Aquí sigue la lógica para eliminar una factura...
        }
    }
}
