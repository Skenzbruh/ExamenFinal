using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Examenp1.Reposiroty.DetalleFactura
{
    public class repositorioDetalleFactura
    {
        private readonly string _connectionString;

        public repositorioDetalleFactura(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AgregarDetalleFactura(DetalleFactura detalleFactura)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string insertQuery = "INSERT INTO detalle_factura (factura_id, producto_id, cantidad, precio) VALUES (@FacturaId, @ProductoId, @Cantidad, @Precio)";
                db.Execute(insertQuery, detalleFactura);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string deleteQuery = "DELETE FROM detalle_factura WHERE id = @Id";
                db.Execute(deleteQuery, new { Id = id });
            }
        }

        public List<DetalleFactura> List()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string selectQuery = "SELECT * FROM detalle_factura";
                return db.Query<DetalleFactura>(selectQuery).ToList();
            }
        }
    }
}
