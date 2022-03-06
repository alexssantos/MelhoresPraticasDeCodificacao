using Domain.Cliente.Aggregate.Enums;
using Domain.Cliente.Aggregate.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.Entities
{
	[ExcludeFromCodeCoverage]
	public class Telefone : Shared.Entity
	{
		public Numero Numero { get; set; }
		public ETipoTelefone Tipo { get; set; }

		public Telefone() : base(null)
		{

		}
	}
}
