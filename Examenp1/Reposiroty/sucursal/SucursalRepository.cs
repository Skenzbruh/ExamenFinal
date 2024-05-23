using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Examenp1.Reposiroty.sucursal
{
    public class SucursalRepository
    {
        private IDbConnection connection;

        public SucursalRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public bool Add(Sucursal sucursal)
        {
            string sql = "INSERT INTO Sucursal (descripcion, direccion, telefono, whatsapp, mail, estado) VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
            int rowsAffected = connection.Execute(sql, sucursal);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM Sucursal WHERE id = @Id";
            int rowsAffected = connection.Execute(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public bool Update(Sucursal sucursal)
        {
            string sql = "UPDATE Sucursal SET descripcion = @Descripcion, direccion = @Direccion, telefono = @Telefono, whatsapp = @Whatsapp, mail = @Mail, estado = @Estado WHERE id = @Id";
            int rowsAffected = connection.Execute(sql, sucursal);
            return rowsAffected > 0;
        }

        public Sucursal GetSucursalById(int id)
        {
            string sql = "SELECT * FROM Sucursal WHERE id = @Id";
            Sucursal sucursal = connection.QuerySingleOrDefault<Sucursal>(sql, new { Id = id });
            return sucursal;
        }

        public List<Sucursal> List()
        {
            string sql = "SELECT * FROM Sucursal";
            List<Sucursal> sucursales = connection.Query<Sucursal>(sql).ToList();
            return sucursales;
        }
    }
}

