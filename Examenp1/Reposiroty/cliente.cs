using System;
using System.Net.Mail;

namespace Examenp1.Reposiroty
{
    public class Cliente
    {
        
        public int id { get; set; }
        public int idbanco { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }
        
        
        public Cliente(string nombre, string apellido, string documento, string direccion, string mail, string celular, string estado)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Direccion = direccion;
            Mail = mail;
            Celular = celular;
            Estado = estado;
        }

     
        public bool ValidarDatosCliente()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Documento))
            {
                Console.WriteLine("Los campos .");
                return false;
            }

            if (Nombre.Length < 3 || Apellido.Length < 3 || Documento.Length < 3)
            {
                Console.WriteLine("Nombre, Apellido y Cedula deben tener al menos 3 caracteres.");
                return false;
            }

            if (Celular.ToString().Length != 10)
            {
                Console.WriteLine("El celular debe tener 10 dígitos.");
                return false;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Cliente cliente = new Cliente("Juan", "Perez", "1234567890", "direccion ejemplo", "correo@example.com", "1234567890", "Activo");

            if (cliente.ValidarDatosCliente())
            {
                Console.WriteLine("Datos del cliente válidos.");
                
            }
            else
            {
                Console.WriteLine("Datos del cliente no válidos.");
                
            }
        }
    }
}
