using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenp1.Reposiroty.factura
{
    public class RepositorioFactura
    {
        private IDbConnection connection;

        public RepositorioFactura(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AgregarFactura(factura factura)
        {
            try
            {
                string sql = "INSERT INTO Factura (Idcliente, Nrofact, Fechahora, Total, " +
                             "Total5, Total10, Totaliva, Totalletras, Sucursal) " +
                             "VALUES (@Idcliente, @Nrofact, @Fechahora, @Total, @Total5, " +
                             "@Total10, @Totaliva, @Totalletras, @Sucursal)";
                connection.Execute(sql, factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFactura(factura factura)
        {
            try
            {
                string sql = "UPDATE Factura SET Idcliente = @Idcliente, Nrofact = @Nrofact, " +
                             "Fechahora = @Fechahora, Total = @Total, Total5 = @Total5, " +
                             "Total10 = @Total10, Totaliva = @Totaliva, Totalletras = @Totalletras, " +
                             "Sucursal = @Sucursal WHERE id = @Id";
                connection.Execute(sql, factura);
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
                string sql = "DELETE FROM Factura WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public factura ObtenerFactura(int id)
        {
            try
            {
                string sql = "SELECT * FROM Factura WHERE id = @Id";
                return connection.QueryFirstOrDefault<factura>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<factura> ObtenerTodasFacturas()
        {
            try
            {
                string sql = "SELECT * FROM Factura";
                return connection.Query<factura>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
