using Domain.Cliente.Aggregate.Enums;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Transacao : Shared.Entity
	{
		public float Valor { get; set; }
		public int IdDestinatario { get; set; }
		public int IdRemetente { get; set; }
		public string Descricao { get; set; }
		public ETipoTransacao Tipo { get; set; }
	}
}
