﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty
{
    public class repositoriocliente
    {
        NpgsqlConnection connection;

        public repositoriocliente(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Cliente (nombre, apellido, documento, mail, celular, estado) " +
                                      "VALUES (@Nombre, @Apellido, @Documento, @Mail, @Celular, @Estado)";
                    cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("Mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("Celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("Estado", cliente.Estado);
                    cmd.ExecuteNonQuery();
                }
                return true;
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
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Cliente SET nombre = @Nombre, apellido = @Apellido, " +
                                      "documento = @Documento, mail = @Mail, celular = @Celular, estado = @Estado " +
                                      "WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("Mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("Celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("Estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("Id", cliente.id);
                    cmd.ExecuteNonQuery();
                }
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
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Cliente WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
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
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Cliente WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                                return new Cliente(
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7)
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> List()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Cliente";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente(
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7)
                               );
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return clientes;
        }

        internal void Add(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}