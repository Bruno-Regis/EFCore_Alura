using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class Connection
{
    private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
        "Initial Catalog=ScreenSound;" +
        "Integrated Security=True;Encrypt=False;" +
        "TrustServerCertificate=False;" +
        "ApplicationIntent=ReadWrite;" +
        "MultiSubnetFailover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(_connectionString);
    }

    public IEnumerable<Artista> Listar()
    {
        /* A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente. 
        Quando declaramos uma variável local como using, ela é descartada no final do escopo em que ela foi declarada */
        var lista = new List<Artista>();
        using var connection = ObterConexao();
        connection.Open();

        string sql = "SELECT * FROM Artistas";
        SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read()) 
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);
            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }
        return lista;
    }
}
