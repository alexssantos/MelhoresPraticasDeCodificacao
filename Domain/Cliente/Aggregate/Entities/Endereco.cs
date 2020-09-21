using Domain.Cliente.Aggregate.Enums;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Endereco : Shared.Entity
	{
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string CEP { get; set; }
		public ETipoEndereco Tipo { get; set; }
	}
}
