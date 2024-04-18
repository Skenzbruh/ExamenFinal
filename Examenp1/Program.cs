using System;
using Examenp1.Reposiroty;

namespace Examenp1.program
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=postgres;Username=postgres;Password=bubuchona;";

            repositoriocliente RepositorioCliente = new repositoriocliente(connectionString);
            RepositorioFactura RepositorioFactura = new RepositorioFactura(connectionString);

            Cliente nuevoCliente = new Cliente("William", "Acosta", "1234567890", "Dirección", "mail@example.com", "1234567890", "activo");
            RepositorioCliente.AgregarCliente(nuevoCliente);

            // Obtener todas las facturas y mostrarlas en la consola
            Console.WriteLine("Lista de facturas:");
            foreach (var factura in RepositorioFactura.ObtenerTodasFacturas())
            {
                Console.WriteLine($"ID: {factura.Idfact}, Número: {factura.Nrofact}, Total: {factura.Total}");
            }
            // servicioCliente.AgregarCliente(new ClienteModelo(...));
            // servicioFactura.AgregarFactura(new FacturaModelo(...));



            Console.WriteLine("Operaciones completadas con éxito.");
        }
    }
}