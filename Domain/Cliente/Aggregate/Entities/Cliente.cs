using System;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Cliente : Shared.Entity
	{
		public string Nome { get; set; }
		public DateTime DataNscimento { get; set; }
		public string NomePai { get; set; }
		public string NomeMae { get; set; }
		public IList<Endereco> Enderecos { get; set; }
		public IList<Telefone> Telefones { get; set; }
	}
}
