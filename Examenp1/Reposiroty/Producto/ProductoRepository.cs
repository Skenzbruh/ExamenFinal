using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Examenp1.Reposiroty.Producto
{
    public class repositorioproducto
    {
        private readonly string _connectionString;

        public repositorioproducto(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AgregarProducto(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Productos (Nombre, CantidadMinima, PrecioCompra, PrecioVenta) VALUES (@Nombre, @CantidadMinima, @PrecioCompra, @PrecioVenta)";
                connection.Execute(query, producto);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Productos WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public List<Producto> List()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Productos";
                return connection.Query<Producto>(query).ToList();
            }
        }
    }
}
