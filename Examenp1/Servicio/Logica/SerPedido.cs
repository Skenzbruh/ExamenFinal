using System;
using System.Collections.Generic;
using System.Linq;

namespace Examenp1.Models
{
    public class ServicioPedido
    {
        public List<DetalleFactura> DetalleFactura { get; set; }
        public decimal Total { get; set; }

        public ServicioPedido()
        {
            DetalleFactura = new List<DetalleFactura>();
        }

        public void AgregarDetalleFactura(DetalleFactura detalle)
        {
            DetalleFactura.Add(detalle);
        }

        public void CalcularTotal()
        {
            Total = DetalleFactura.Sum(df => df.Precio_Compra);
        }
    }

    public class DetalleFactura
    {
        public int Id_Producto { get; set; }
        public decimal Precio_Compra { get; set; }
    }
}
