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

		public override void Depositar()
		{
			//Logica de Negocio aqui

			throw new NotImplementedException();
		}

		public override void Sacar()
		{
			//Logica de Negocio aqui

			throw new NotImplementedException();
		}

		public override void Transferir()
		{
			//Logica de Negocio aqui

			throw new NotImplementedException();
		}
	}
}
