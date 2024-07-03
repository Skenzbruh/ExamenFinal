using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Examenp1.Models;
using Npgsql;

namespace Examenp1.Repositories
{
    public class DetallePedidoRepository
    {
        private readonly string _connectionString;

        public DetallePedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AgregarDetallePedido(DetallePedido detallePedido)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string insertQuery = @"INSERT INTO detalle_pedido (id_pedido, id_producto, cantidad_producto, subtotal)
                                       VALUES (@Id_Pedido, @Id_Producto, @Cantidad_Producto, @Subtotal)";
                db.Execute(insertQuery, detallePedido);
            }
        }

        public DetallePedido ObtenerDetallePorId(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string selectQuery = "SELECT * FROM detalle_pedido WHERE id = @Id";
                return db.QueryFirstOrDefault<DetallePedido>(selectQuery, new { Id = id });
            }
        }

        public List<DetallePedido> ObtenerDetallesPorPedido(int idPedido)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string selectQuery = "SELECT * FROM detalle_pedido WHERE id_pedido = @IdPedido";
                return db.Query<DetallePedido>(selectQuery, new { IdPedido = idPedido }).ToList();
            }
        }

        public void EliminarDetallePedido(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string deleteQuery = "DELETE FROM detalle_pedido WHERE id = @Id";
                db.Execute(deleteQuery, new { Id = id });
            }
        }
    }
}
