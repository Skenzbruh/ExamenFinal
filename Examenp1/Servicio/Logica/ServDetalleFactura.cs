using Examenp1.Reposiroty.DetalleFactura;
using System;
using System.Collections.Generic;

namespace Examenp1.Servicio.Logica
{
    public class ServDetalleFactura
    {
        public repositorioDetalleFactura RepositorioDetalleFactura;

        public ServDetalleFactura(string connection)
        {
            RepositorioDetalleFactura = new repositorioDetalleFactura(connection);
        }

        public void Insertar(DetalleFactura detalleFactura)
        {
            if (ValidacionDatos(detalleFactura))
                RepositorioDetalleFactura.AgregarDetalleFactura(detalleFactura);
            else
                throw new Exception("Error en la validación de datos, favor corroborar");
        }

        public void Eliminar(int id)
        {
            RepositorioDetalleFactura.Delete(id);
        }

        public List<DetalleFactura> Listado()
        {
            return RepositorioDetalleFactura.List();
        }

        private bool ValidacionDatos(DetalleFactura detalleFactura)
        {
            return detalleFactura.ValidarDatosDetalleFactura();
        }
    }
}
