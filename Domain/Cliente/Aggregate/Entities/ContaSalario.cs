﻿using System;

namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaSalario : Conta
	{
		private readonly decimal MaxSaquePorMes = 3;
		private decimal QtdSaqueNoMes = 0;

		public ContaSalario(int numero, int agencia, int saldo) : base(numero, agencia, saldo)
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
