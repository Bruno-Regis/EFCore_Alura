using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ScreenSoundContext: DbContext
{
    // criando um DBSet de artista, nome da variável tem que ser o mesmo do banco de dados...
    // Agora posso retornar um context.Artistas após instanciada a classe.
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
        "Initial Catalog=ScreenSoundV0;" +
        "Integrated Security=True;Encrypt=False;" +
        "TrustServerCertificate=False;" +
        "ApplicationIntent=ReadWrite;" +
        "MultiSubnetFailover=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
    }
}
