using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Examenp1.Reposiroty.Cliente
{
    public class repositoriocliente
    {
        private NpgsqlConnection connection;

        public repositoriocliente(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                string sql = "INSERT INTO Cliente (nombre, apellido, documento, direccion, mail, celular, estado) " +
                             "VALUES (@Nombre, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)";
                int rowsAffected = connection.Execute(sql, cliente);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                string sql = "UPDATE Cliente SET nombre = @Nombre, apellido = @Apellido, " +
                             "documento = @Documento, direccion = @Direccion, mail = @Mail, " +
                             "celular = @Celular, estado = @Estado WHERE id = @Id";
                connection.Execute(sql, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente Get(int id)
        {
            try
            {
                string sql = "SELECT * FROM Cliente WHERE id = @Id";
                return connection.QueryFirstOrDefault<Cliente>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> List()
        {
            try
            {
                string sql = "SELECT * FROM Cliente";
                return connection.Query<Cliente>(sql).AsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Add(Cliente cliente)
        {
            AgregarCliente(cliente);
        }
    }
}

