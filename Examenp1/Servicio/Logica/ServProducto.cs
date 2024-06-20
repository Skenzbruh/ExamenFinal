using Examenp1.Reposiroty.Producto;
using System;
using System.Collections.Generic;

namespace Examenp1.Servicio.Logica
{
    public class ServProducto
    {
        public repositorioproducto RepositorioProducto;

        public ServProducto(string connection)
        {
            RepositorioProducto = new repositorioproducto(connection);
        }

        public void Insertar(Producto producto)
        {
            if (ValidacionDatos(producto))
                RepositorioProducto.AgregarProducto(producto);
            else
                throw new Exception("Error en la validacion de datos, favor corroborar");
        }

        public void Eliminar(int id)
        {
            RepositorioProducto.Delete(id);
        }

        public List<Producto> Listado()
        {
            return RepositorioProducto.List();
        }

        private bool ValidacionDatos(Producto producto)
        {
            return producto.ValidarDatosProducto();
        }
    }
}
