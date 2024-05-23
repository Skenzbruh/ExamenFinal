using System;
using System.Security;
using System.Text.RegularExpressions;

namespace Examenp1.Reposiroty.factura
{
    public class factura
    {
        public int Idfact { get; set; }
        public int Idcliente { get; set; }
        public string Nrofact { get; set; }
        public DateTime Fechahora { get; set; }
        public decimal Total { get; set; }
        public decimal Total5 { get; set; }
        public decimal Total10 { get; set; }
        public decimal Totaliva { get; set; }
        public string Totalletras { get; set; }
        public string Sucursal { get; set; }

        // Constructor
        public factura(string numeroFactura, DateTime fechahora, decimal total, decimal totalIva5, decimal totalIva10, decimal totaliva, string totalEnLetras, string sucursal)
        {
            Nrofact = numeroFactura;
            Fechahora = fechahora;
            Total = total;
            Total5 = totalIva5;
            Total10 = totalIva10;
            Totaliva = totaliva;
            Totalletras = totalEnLetras;
            Sucursal = sucursal;
        }
    }


}