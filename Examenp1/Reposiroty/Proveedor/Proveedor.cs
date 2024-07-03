using System;

namespace Examenp1.Reposiroty.Proveedor
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }

        public Proveedor(string razonSocial, string tipoDocumento, string numeroDocumento, string direccion, string mail, string celular, string estado)
        {
            RazonSocial = razonSocial;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            Mail = mail;
            Celular = celular;
            Estado = estado;
        }

        public bool ValidarDatosProveedor()
        {
            if (string.IsNullOrWhiteSpace(RazonSocial))
            {
                Console.WriteLine("La razón social del proveedor es obligatoria.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TipoDocumento))
            {
                Console.WriteLine("El tipo de documento del proveedor es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(NumeroDocumento))
            {
                Console.WriteLine("El número de documento del proveedor es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Direccion))
            {
                Console.WriteLine("La dirección del proveedor es obligatoria.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Mail))
            {
                Console.WriteLine("El correo electrónico del proveedor es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Celular))
            {
                Console.WriteLine("El número de celular del proveedor es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Estado))
            {
                Console.WriteLine("El estado del proveedor es obligatorio.");
                return false;
            }

            return true;
        }
    }
}
