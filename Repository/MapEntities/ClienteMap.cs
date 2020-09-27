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
			builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
			builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
			builder.Property(x => x.Login).IsRequired().HasMaxLength(250);


			//ValueObjects
			builder.OwnsOne(c => c.Email, email =>
			{
				email.Property(c => c.Valor);
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

			builder.OwnsOne(
				o => o.Mae,
				mae =>
			{
				mae.Property(o => o.Nome).UsePropertyAccessMode(PropertyAccessMode.Property);
				mae.OwnsOne(
					o => o.DataNascimento,
					dt =>
					{
						dt.Property(o => o.Data).UsePropertyAccessMode(PropertyAccessMode.Property);
						dt.Property(o => o.Idade).UsePropertyAccessMode(PropertyAccessMode.Property);
					});
				//mae.Ignore(x => x.DataNascimento);
				//mae.Ignore(x => x.DataNascimento);

			});

			builder.OwnsOne(
				c => c.Pai,
				pai =>
			{
				pai.Property(c => c.Nome).UsePropertyAccessMode(PropertyAccessMode.Property);
				pai.OwnsOne(
					o => o.DataNascimento,
					dt =>
					{
						dt.Property(o => o.Data).UsePropertyAccessMode(PropertyAccessMode.Property);
						dt.Property(o => o.Idade).UsePropertyAccessMode(PropertyAccessMode.Property);
					});
				//pai.Ignore(o => o.DataNascimento);
			});


			builder.OwnsOne(
				o => o.CPF,
				cpf =>
			{
				cpf.Property(x => x.Valor)
					.UsePropertyAccessMode(PropertyAccessMode.Property)
					.IsRequired();
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
