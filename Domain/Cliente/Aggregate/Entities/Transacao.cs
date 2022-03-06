using Domain.Cliente.Aggregate.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.Entities
{
	[ExcludeFromCodeCoverage]
	public class Transacao : Shared.Entity
	{
		public decimal Valor { get; set; }
		public int IdDestinatario { get; set; }
		public int IdRemetente { get; set; }
		public string Descricao { get; set; }
		public ETipoTransacao Tipo { get; set; }
		public DateTime Data { get; set; }

		public Transacao() : base(null)
		{

		}
	}
}