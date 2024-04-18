using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Examenp1.Reposiroty
{ 
public class Conexionbd
{
    private string conncetionString ="Host=localhost;Username=postgres;Password=1234;Database=postgres;Port=5432";
    private string connectionString;
    public Conexionbd(string connectionString)
    {


        this.connectionString = connectionString;

    }
    public NpgsqlConnection OpenConnection()
    {
        try
        {
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  }
}
