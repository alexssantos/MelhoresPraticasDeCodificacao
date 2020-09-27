using Domain.Cliente.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.MapEntities;

namespace Repository.Context
{
	public class BankContext : DbContext
	{
		public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

		public BankContext(DbContextOptions<BankContext> options) : base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Conta> Contas { get; set; }
		public DbSet<ContaCorrente> ContasCorrente { get; set; }
		public DbSet<ContaPoupanca> ContasPoupanca { get; set; }
		public DbSet<ContaSalario> ContasSalario { get; set; }
		//public DbSet<Endereco> Enderecos { get; set; }
		//public DbSet<Telefone> Telefones { get; set; }
		//public DbSet<Transacao> Transacoes { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ClienteMap());
			builder.ApplyConfiguration(new ContaMap());


			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(_loggerFactory);

			base.OnConfiguring(optionsBuilder);
		}
	}
}
