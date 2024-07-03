using System;

namespace Examenp1.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad_Producto { get; set; }
        public decimal Subtotal { get; set; }

        public DetallePedido(int id_Pedido, int id_Producto, int cantidad_Producto, decimal subtotal)
        {
            Id_Pedido = id_Pedido;
            Id_Producto = id_Producto;
            Cantidad_Producto = cantidad_Producto;
            Subtotal = subtotal;
        }
    }
}
