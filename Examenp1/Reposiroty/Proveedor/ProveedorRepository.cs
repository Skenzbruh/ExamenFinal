using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Examenp1.Reposiroty.Proveedor
{
    public class ProveedorRepository
    {
        private IDbConnection connection;

        public ProveedorRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            string sql = @"INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Direccion, Mail, Celular, Estado)
                           VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Direccion, @Mail, @Celular, @Estado)";
            int filasAfectadas = connection.Execute(sql, proveedor);
            return filasAfectadas > 0;
        }

        public bool EliminarProveedor(int id)
        {
            string sql = "DELETE FROM Proveedor WHERE Id = @Id";
            int filasAfectadas = connection.Execute(sql, new { Id = id });
            return filasAfectadas > 0;
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            string sql = @"UPDATE Proveedor 
                           SET RazonSocial = @RazonSocial,
                               TipoDocumento = @TipoDocumento,
                               NumeroDocumento = @NumeroDocumento,
                               Direccion = @Direccion,
                               Mail = @Mail,
                               Celular = @Celular,
                               Estado = @Estado
                           WHERE Id = @Id";
            int filasAfectadas = connection.Execute(sql, proveedor);
            return filasAfectadas > 0;
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            string sql = "SELECT * FROM Proveedor WHERE Id = @Id";
            Proveedor proveedor = connection.QuerySingleOrDefault<Proveedor>(sql, new { Id = id });
            return proveedor;
        }

        public List<Proveedor> ListarProveedores()
        {
            string sql = "SELECT * FROM Proveedor";
            List<Proveedor> proveedores = connection.Query<Proveedor>(sql).ToList();
            return proveedores;
        }
    }
}
