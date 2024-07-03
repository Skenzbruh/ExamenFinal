using System;

namespace Examenp1.Models
{
    public class PedidoCompra
    {
        public int Id { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Sucursal { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public decimal Total { get; set; }

        public PedidoCompra(int id_Proveedor, int id_Sucursal, DateTime fecha_Hora, decimal total)
        {
            Id_Proveedor = id_Proveedor;
            Id_Sucursal = id_Sucursal;
            Fecha_Hora = fecha_Hora;
            Total = total;
        }

        public bool ValidarDatosPedido()
        {
            if (Id_Proveedor <= 0)
            {
                Console.WriteLine("El ID del proveedor debe ser mayor que cero.");
                return false;
            }

            if (Id_Sucursal <= 0)
            {
                Console.WriteLine("El ID de la sucursal debe ser mayor que cero.");
                return false;
            }

            if (Fecha_Hora == default(DateTime))
            {
                Console.WriteLine("La fecha y hora del pedido son obligatorias.");
                return false;
            }

            if (Total <= 0)
            {
                Console.WriteLine("El total del pedido debe ser mayor que cero.");
                return false;
            }

            return true;
        }
    }
}
