using Examenp1.Reposiroty.sucursal;
using System;
using System.Collections.Generic;

namespace Examenp1.Servicio.Logica
{
    public class ServSucursal
    {
        public SucursalRepository RepositorioSucursal;

        public ServSucursal(string connectionString)
        {
            RepositorioSucursal = new SucursalRepository(connectionString);
        }

        public void AgregarSucursal(Sucursal sucursal)
        {
            if (ValidarDatos(sucursal))
                RepositorioSucursal.Add(sucursal);
            else
                throw new Exception("Error en la validación de datos, favor corregir.");
        }

        public void EliminarSucursal(int id)
        {
            RepositorioSucursal.Delete(id);
        }

        public List<Sucursal> ObtenerTodasLasSucursales()
        {
            return RepositorioSucursal.List();
        }

        private bool ValidarDatos(Sucursal sucursal)
        {

            return true;
        }
    }
}