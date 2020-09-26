using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaPoupanca : Conta
	{
		public float TaxaDeJutos { get; set; }

		public ContaPoupanca(int numero, int agencia, int digitoAg, decimal saldo) : base(numero, agencia, digitoAg, saldo)
		{

		}

		public ContaPoupanca(float taxaDeJutos, int numero, int agencia, int digitoAg, decimal saldo) : this(numero, agencia, digitoAg, saldo)
		{
			TaxaDeJutos = taxaDeJutos;
		}

		public override void Sacar(Transacao saque)
		{
			throw new NotImplementedException();
		}

		public override void Depositar(Transacao deposito)
		{
			throw new NotImplementedException();
		}

		public override void Transferir(Transacao transferencia)
		{
			throw new NotImplementedException();
		}
	}
}
