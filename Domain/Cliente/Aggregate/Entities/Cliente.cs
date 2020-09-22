using Domain.Cliente.Aggregate.ValueObjects;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Cliente : Shared.Entity
	{
		public string Nome { get; set; }
		public DataNascimento DataNscimento { get; set; }
		public CPF CPF { get; set; }
		public Filiacao Pai { get; set; }
		public Filiacao Mae { get; set; }
		public Email Email { get; set; }
		public Password SenhaCliente { get; set; }
		public string Login { get; set; }
		public IList<Endereco> Enderecos { get; set; }
		public IList<Telefone> Telefones { get; set; }
		public IList<Conta> Contas { get; set; }
	}
}
