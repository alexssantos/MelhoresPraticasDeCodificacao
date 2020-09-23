using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaPoupanca : Conta
	{
		public float TaxaDeJutos { get; set; }

		public ContaPoupanca(int numero, int agencia, int saldo) : base(numero, agencia, saldo)
		{

		}

		public ContaPoupanca(float taxaDeJutos, int numero, int agencia, int saldo) : this(numero, agencia, saldo)
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
