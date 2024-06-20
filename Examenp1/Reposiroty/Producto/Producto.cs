using System;

namespace Examenp1.Reposiroty.Producto
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadMinima { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }

        public Producto(string nombre, int cantidadMinima, int precioCompra, int precioVenta)
        {
            Nombre = nombre;
            CantidadMinima = cantidadMinima;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
        }

        public bool ValidarDatosProducto()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.WriteLine("El nombre del producto es obligatorio.");
                return false;
            }

            if (CantidadMinima < 1)
            {
                Console.WriteLine("La cantidad mínima debe ser mayor a 1.");
                return false;
            }

            if (PrecioCompra <= 0 || PrecioVenta <= 0)
            {
                Console.WriteLine("El precio de compra y el precio de venta deben ser enteros positivos.");
                return false;
            }

            return true;
        }
    }
}
