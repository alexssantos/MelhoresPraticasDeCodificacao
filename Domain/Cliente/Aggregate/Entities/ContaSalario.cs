using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.Entities
{
	[ExcludeFromCodeCoverage]
	public class ContaSalario : Conta
	{
		private readonly decimal MaxSaquePorMes = 3;
		private decimal QtdSaqueNoMes = 0;


		public ContaSalario()
		{

		}
		public ContaSalario(int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId) : base(numero, agencia, digitoAg, saldo, clienteId)
		{
		}

		public decimal SaqueTotalRestante()
		{
			return MaxSaquePorMes - QtdSaqueNoMes;
		}

		public override void Sacar(Transacao saque)
		{
			decimal totalSaqueNoMes = saque.Valor + QtdSaqueNoMes;

			if (totalSaqueNoMes > MaxSaquePorMes)
				throw new Exception($"Valor de saque por mês excedido. Valor restante para saque no mês: R${SaqueTotalRestante()}");
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
