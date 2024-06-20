using System;

namespace Examenp1.Reposiroty.DetalleFactura
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public DetalleFactura(int facturaId, int productoId, int cantidad, int precio)
        {
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }

        public bool ValidarDatosDetalleFactura()
        {
            // Validación de campos obligatorios
            if (ProductoId <= 0)
            {
                Console.WriteLine("El ID del producto es obligatorio y debe ser mayor a 0.");
                return false;
            }

            if (Cantidad <= 0)
            {
                Console.WriteLine("La cantidad debe ser mayor a 0.");
                return false;
            }

            if (Precio <= 0)
            {
                Console.WriteLine("El precio debe ser un entero positivo.");
                return false;
            }

            return true;
        }
    }
}
