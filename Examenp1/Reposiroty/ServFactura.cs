﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty
{
    public class ServFactura
    {
        public int Idfact { get; set; }
        public int IdCliente { get; set; }
        public string Nrofact { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal Total5 { get; set; }
        public decimal Total10 { get; set; }
        public decimal Totaliva { get; set; }
        public string Totalletras { get; set; }
        public string Sucursal { get; set; }

        public bool ValidarFactura()
        {
            Regex regexNumeroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");
            if (!regexNumeroFactura.IsMatch(Nrofact))
            {
                Console.WriteLine("El número de factura no cumple con el formato especificado.");
                return false;
            }

            if (Total <= 0 || Total5 < 0 || Total10 < 0)
            {
                Console.WriteLine(" Los totales deben ser valores numericos positivos.");
                return false;
            }
            if (string.IsNullOrEmpty(Totalletras) || Totalletras.Length < 6)
            {
                Console.WriteLine(" El total en letras debe tener al menos 6 caracteres");
                return false;
            }

            return true;
        }

    }
}
 