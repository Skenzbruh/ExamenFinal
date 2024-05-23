using Examenp1.Reposiroty.Cliente;
using System;
using System.Collections.Generic;

namespace Examenp1.Servicio.Logica
{
    public class ServCliente
    {
        public repositoriocliente RepositorioCliente;

        public ServCliente(string connection)
        {
            RepositorioCliente = new repositoriocliente(connection);
        }

        public void Insertar(Cliente cliente)
        {
            if (ValidacionDatos(cliente))
                RepositorioCliente.AgregarCliente(cliente);
            else
                throw new Exception("Error en la validacion de dato, favor corroborar");
        }

        public void Eliminar(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public List<Cliente> Listado()
        {
            return RepositorioCliente.List();
        }

        private bool ValidacionDatos(Cliente cliente)
        {
            return cliente.ValidarDatosCliente();
        }
    }
}
