using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty
{
    public class ServCliente
    {
        public repositoriocliente RepositorioCliente;

        public ServCliente(string connection)
        {
            RepositorioCliente = new repositoriocliente(connection);
        }

        public void insertar(Cliente cliente)
        {
            if (validacionDatos(cliente))
                RepositorioCliente.Add(cliente);
            else
                throw new Exception("Error en la validacion de dato, favor corroborar");
        }

        private bool validacionDatos(Cliente cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido))
                return false;
            if (string.IsNullOrEmpty(cliente.Documento))
                return false;
            if (string.IsNullOrEmpty(cliente.Direccion))
                return false;
            if (string.IsNullOrEmpty(cliente.Mail))
                return false;
            if (string.IsNullOrEmpty(cliente.Celular))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;

            return true;
        }
    }
}
