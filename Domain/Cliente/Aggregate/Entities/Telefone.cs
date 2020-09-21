using Domain.Cliente.Aggregate.Enums;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Telefone : Shared.Entity
	{
		public int Numero { get; set; }
		public ETipoTelefone Tipo { get; set; }
	}
}
