using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty
{
    public class RepositorioFactura
    {
        private NpgsqlConnection connection;

        public RepositorioFactura(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AgregarFactura(Factura factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Factura (Idcliente, Nrofact, Fechahora, Total, " +
                                      "Total5, Total10, Totaliva, Totalletras,Sucursal) " +
                                      "VALUES (@Idcliente, @Nrofact, @Fechahora, @Total, @Total5, " +
                                      "@Total10, @Totaliva, @Totalletras, @Sucursal)";
                    cmd.Parameters.AddWithValue("Idcliente", factura.Idcliente);
                    cmd.Parameters.AddWithValue("Nrofact", factura.Nrofact);
                    cmd.Parameters.AddWithValue("Fechahora", factura.Fechahora);
                    cmd.Parameters.AddWithValue("Total", factura.Total);
                    cmd.Parameters.AddWithValue("Total5", factura.Total5);
                    cmd.Parameters.AddWithValue("Total10", factura.Total10);
                    cmd.Parameters.AddWithValue("Totaliva", factura.Totaliva);
                    cmd.Parameters.AddWithValue("Totalletras", factura.Totalletras);
                    cmd.Parameters.AddWithValue("Sucursal", factura.Sucursal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFactura(Factura factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Factura SET Idcliente = @Idcliente, Nrofactura = @NroFactura, " +
                                      "Fechahora = @Fechahora, total = @Total, Total5 = Total5, " +
                                      "Total10 = @Total10, Totaliva = @Totaliva, Totalletras = @Totalletras, " +
                                      "Sucursal = @Sucursal WHERE id = @Id";
                    cmd.Parameters.AddWithValue("IdCliente", factura.Idcliente);
                    cmd.Parameters.AddWithValue("NroFactura", factura.Nrofact);
                    cmd.Parameters.AddWithValue("FechaHora", factura.Fechahora);
                    cmd.Parameters.AddWithValue("Total", factura.Total);
                    cmd.Parameters.AddWithValue("TotalIva5", factura.Total5);
                    cmd.Parameters.AddWithValue("TotalIva10", factura.Total10);
                    cmd.Parameters.AddWithValue("TotalIva", factura.Totaliva);
                    cmd.Parameters.AddWithValue("TotalLetras", factura.Totalletras);
                    cmd.Parameters.AddWithValue("Sucursal", factura.Sucursal);
                    cmd.Parameters.AddWithValue("Id", factura.Idfact);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFactura(int id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Factura WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Factura ObtenerFactura(int id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Factura WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Factura(
                                reader.GetString(0),
                                reader.GetDateTime(1),
                                reader.GetDecimal(2),
                                reader.GetDecimal(3),
                                reader.GetDecimal(4),
                                reader.GetDecimal(5),
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

        public List<Factura> ObtenerTodasFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Factura";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factura factura = new Factura(
                                reader.GetString(0),
                                reader.GetDateTime(1),
                                reader.GetDecimal(2),
                                reader.GetDecimal(3),
                                reader.GetDecimal(4),
                                reader.GetDecimal(5),
                                reader.GetString(6),
                                reader.GetString(7)
                            );
                            facturas.Add(factura);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return facturas;
        }
    }
}