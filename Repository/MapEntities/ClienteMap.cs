using Domain.Cliente.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.MapEntities
{
	public class ClienteMap : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
			builder.Property(x => x.Login).IsRequired().HasMaxLength(250);

			//ValueObjects
			builder.OwnsOne(c => c.Email, email =>
			{
				email.Property(c => c.Valor);
			});

			builder.OwnsOne(c => c.CPF, cpf =>
			{
				cpf.Property(c => c.Valor)
				.IsRequired()
				.HasMaxLength(11);
			});

			builder.OwnsOne(c => c.DataNascimento, dt =>
			{
				dt.Property(c => c.Data)
				.IsRequired();
			});

			builder.OwnsOne(c => c.SenhaCliente, senha =>
			{
				senha.Property(c => c.Valor);
			});

			builder.OwnsOne(c => c.Mae, mae =>
			{
				mae.Property(c => c.Nome);
			});

			builder.OwnsOne(c => c.Pai, pai =>
			{
				pai.Property(c => c.Nome);
			});


			//Relationship

			//1 cliente => N contas
			builder.HasMany(g => g.Contas)
				.WithOne(s => s.Cliente)
				.HasForeignKey(s => s.ClienteId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
