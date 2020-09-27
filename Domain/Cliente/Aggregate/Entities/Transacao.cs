using Domain.Cliente.Aggregate.Enums;
using System;

namespace Domain.Cliente.Aggregate.Entities
{
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