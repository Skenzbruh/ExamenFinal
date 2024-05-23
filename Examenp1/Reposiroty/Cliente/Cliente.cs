using System;

namespace Examenp1.Reposiroty.Cliente
{
    public class Cliente
    {
        public int id { get; set; }
        public int idbanco { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }

        public Cliente(string nombre, string apellido, string documento, string direccion, string mail, string celular, string estado)
        {
            nombre = nombre;
            apellido = apellido;
            documento = documento;
            direccion = direccion;
            mail = mail;
            celular = celular;
            estado = estado;
        }

        public bool ValidarDatosCliente()
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(documento))
            {
                Console.WriteLine("Los campos Nombre, Apellido y Documento son obligatorios.");
                return false;
            }

            if (nombre.Length < 3 || apellido.Length < 3 || documento.Length < 3)
            {
                Console.WriteLine("Nombre, Apellido y Documento deben tener al menos 3 caracteres.");
                return false;
            }

            if (celular.Length != 10)
            {
                Console.WriteLine("El celular debe tener 10 dígitos.");
                return false;
            }

            return true;
        }
    }
}
