using Domain.Cliente.Aggregate.Enums;
using Domain.Cliente.Aggregate.ValueObjects;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Telefone : Shared.Entity
	{
		public Numero Numero { get; set; }
		public ETipoTelefone Tipo { get; set; }
	}
}
