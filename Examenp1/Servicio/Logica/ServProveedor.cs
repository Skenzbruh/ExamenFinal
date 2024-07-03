using System;

namespace Examenp1.Models
{
    public class ServicioProveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Celular { get; set; }

        public bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(RazonSocial) || RazonSocial.Length < 3)
            {
                Console.WriteLine("La Razón Social es obligatoria y debe tener al menos 3 caracteres.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TipoDocumento) || TipoDocumento.Length < 3)
            {
                Console.WriteLine("El Tipo de Documento es obligatorio y debe tener al menos 3 caracteres.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(NumeroDocumento) || NumeroDocumento.Length < 3)
            {
                Console.WriteLine("El Número de Documento es obligatorio y debe tener al menos 3 caracteres.");
                return false;
            }

            if (!EsNumeroCelularValido(Celular))
            {
                Console.WriteLine("El número de celular debe ser numérico y tener 10 dígitos.");
                return false;
            }

            return true;
        }

        private bool EsNumeroCelularValido(string celular)
        {
            if (string.IsNullOrWhiteSpace(celular))
                return false;

            if (celular.Length != 10)
                return false;

            if (!long.TryParse(celular, out _))
                return false;

            return true;
        }
    }
}
