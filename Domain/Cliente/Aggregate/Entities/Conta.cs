using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Entities
{
	public abstract class Conta : Shared.Entity
	{
		public int Numero { get; internal set; }
		public int Agencia { get; internal set; }
		public int AgenciaDigito { get; internal set; }
		public decimal Saldo { get; internal set; }
		public IList<Transacao> Transacoes { get; set; }

		protected Conta(int numero, int agencia, int saldo)
		{
			Numero = numero;
			Agencia = agencia;
			Saldo = saldo;
		}

		abstract public void Sacar(Transacao saque);
		abstract public void Depositar(Transacao deposito);
		abstract public void Transferir(Transacao transferencia);
	}
}
