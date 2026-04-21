using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador2.API.Entities;
using System.Globalization;

namespace ProjetoIntegrador2.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("produtos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                  .HasColumnName("id")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(p => p.Codigo)
                  .HasColumnName("codigo")
                  .IsRequired();

            entity.Property(p => p.Descricao)
                  .HasColumnName("descricao")
                  .IsRequired();

            entity.Property(p => p.Ativo)
                  .HasColumnName("ativo");

            entity.Property(p => p.Unid)
                  .HasColumnName("unid")
                  .IsRequired();

            entity.Property(p => p.Custo)
                  .HasColumnName("custo")
                  .HasColumnType("numeric(18,4)");

            entity.Property(p => p.Preco)
                  .HasColumnName("preco")
                  .HasColumnType("numeric(18,4)");

            entity.Property(p => p.Estoque)
                  .HasColumnName("estoque")
                  .HasColumnType("numeric(18,4)");
        });


        //Seed do CSV de Produtos
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ","
        };

        string path = Path.Combine(AppContext.BaseDirectory, "Data", "Seeds", "produtos_com_uuid.csv");
        if (!File.Exists(path))
        {
            // Fallback para ambiente de Design/Migrations caso o BaseDirectory varie
            path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Seeds", "produtos_com_uuid.csv");
        }

        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, config))
        {
            var records = csv.GetRecords<Produto>().ToList();

            modelBuilder.Entity<Produto>().HasData(records);
        }
    }
}
