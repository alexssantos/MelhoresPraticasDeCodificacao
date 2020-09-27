using Domain.Cliente.Aggregate.Entities;

namespace Domain.Cliente.Aggregate.Interfaces
{
	public interface IConta
	{
		public void Sacar(Transacao saque);
		public void Depositar(Transacao deposito);
		public void Transferir(Transacao transferencia);
	}
}
