using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaPoupanca : Conta
	{
		public float TaxaDeJutos { get; set; }

		public ContaPoupanca(int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId)
			: base(numero, agencia, digitoAg, saldo, clienteId)
		{

		}

		public ContaPoupanca(float taxaDeJutos, int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId)
			: this(numero, agencia, digitoAg, saldo, clienteId)
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
