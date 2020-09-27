using Domain.Cliente.Aggregate.Enums;
using Domain.Cliente.Aggregate.ValueObjects;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Endereco : Shared.Entity
	{
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public CEP CEP { get; set; }
		public ETipoEndereco Tipo { get; set; }

		public Endereco() : base(null)
		{

		}
	}
}
