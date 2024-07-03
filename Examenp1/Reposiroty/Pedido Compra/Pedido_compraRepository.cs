using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Examenp1.Models;
using Npgsql;

namespace Examenp1.Repositories
{
    public class PedidoCompraRepository
    {
        private readonly string _connectionString;

        public PedidoCompraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AgregarPedido(PedidoCompra pedido)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string insertQuery = @"INSERT INTO pedido_compra (id_proveedor, id_sucursal, fecha_hora, total)
                                       VALUES (@Id_Proveedor, @Id_Sucursal, @Fecha_Hora, @Total)";
                db.Execute(insertQuery, pedido);
            }
        }

        public PedidoCompra ObtenerPedidoPorId(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string selectQuery = "SELECT * FROM pedido_compra WHERE id = @Id";
                return db.QueryFirstOrDefault<PedidoCompra>(selectQuery, new { Id = id });
            }
        }

        public List<PedidoCompra> ObtenerTodosLosPedidos()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string selectQuery = "SELECT * FROM pedido_compra";
                return db.Query<PedidoCompra>(selectQuery).ToList();
            }
        }

        public void EliminarPedido(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string deleteQuery = "DELETE FROM pedido_compra WHERE id = @Id";
                db.Execute(deleteQuery, new { Id = id });
            }
        }
    }
}
