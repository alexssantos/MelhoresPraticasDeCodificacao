using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaPoupanca : Conta
	{
		public float TaxaDeJutos { get; set; }

		public ContaPoupanca(int numero, int agencia, int saldo) : base(numero, agencia, saldo)
		{
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
