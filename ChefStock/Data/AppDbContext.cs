using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChefStock.Models;
using Microsoft.AspNetCore.Identity;
using SeuProjeto.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> // Usando ApplicationUser
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<PedidoCompra> PedidosCompra { get; set; }
    public DbSet<ItemPedidoCompra> ItensPedidoCompra { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<ItemCompra> ItensCompra { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definindo precisão e escala para as propriedades decimais
        modelBuilder.Entity<ItemPedidoCompra>()
            .Property(i => i.PrecoUnitario)
            .HasColumnType("decimal(18,2)"); // 18 dígitos totais e 2 dígitos após a vírgula

        modelBuilder.Entity<PedidoCompra>()
            .Property(p => p.Total)
            .HasColumnType("decimal(18,2)");

         modelBuilder.Entity<Produto>()
            .Property(p => p.PrecoUnitario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ItemPedidoCompra>()
            .Property(i => i.PrecoUnitario)
            .HasColumnType("decimal(18,2)");
        
        // Configurações adicionais para relacionamentos e restrições, se necessário.
        modelBuilder.Entity<ItemPedidoCompra>()
            .HasOne(i => i.Produto)
            .WithMany()
            .HasForeignKey(i => i.ProdutoId);

        modelBuilder.Entity<ItemPedidoCompra>()
            .HasOne(i => i.PedidoCompra)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoCompraId);

        base.OnModelCreating(modelBuilder);
    }
}
