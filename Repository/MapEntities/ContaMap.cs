using Domain.Cliente.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.MapEntities
{
	public class ContaMap : IEntityTypeConfiguration<Conta>
	{
		public void Configure(EntityTypeBuilder<Conta> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

			builder.Property(x => x.Numero).IsRequired();
			builder.Property(x => x.Agencia).IsRequired();
			builder.Property(x => x.AgenciaDigito).IsRequired();
			builder.Property(x => x.Saldo).IsRequired();			
		}
	}
}
