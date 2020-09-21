using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaCorrente : Conta
	{
		public float MaxTransacaoPorMes { get; set; }

		public ContaCorrente(int numero, int agencia, int saldo) : base(numero, agencia, saldo)
		{
		}
		public ContaCorrente(float maxTransacaoPorMes, int numero, int agencia, int saldo) : this(numero, agencia, saldo)
		{
			MaxTransacaoPorMes = maxTransacaoPorMes;
		}

		public override void Depositar()
		{
			throw new NotImplementedException();
		}

		public override void Sacar()
		{
			throw new NotImplementedException();
		}

		public override void Transferir()
		{
			throw new NotImplementedException();
		}
	}
}
