﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Domain.Cliente.Aggregate.Entities
{
	[ExcludeFromCodeCoverage]
	public class ContaCorrente : Conta
	{
		private readonly int MaxDepositoPorMes = 5;
		//private readonly int MaxTransacaoPorMes = 30;
		private readonly decimal MaxValorTransacaoPorMes = 1000;

		public ContaCorrente()
		{

		}

		public ContaCorrente(int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId) : base(numero, agencia, digitoAg, saldo, clienteId)
		{
		}

		public ContaCorrente(decimal? maxValorTransacaoPorMes, int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId) : this(numero, agencia, digitoAg, saldo, clienteId)
		{
			MaxValorTransacaoPorMes = maxValorTransacaoPorMes ?? MaxValorTransacaoPorMes;
		}

		public override void Depositar(Transacao deposito)
		{
			AddTransacaoContaCorrente(deposito);
			this.Saldo += deposito.Valor;
		}

		public override void Sacar(Transacao saque)
		{
			AddTransacaoContaCorrente(saque);
			this.Saldo -= saque.Valor;
		}

		public override void Transferir(Transacao transferencia)
		{
			AddTransacaoContaCorrente(transferencia);
			this.Saldo -= transferencia.Valor;
		}

		private int PegarQtddTransacaoNoMesAtual(Enums.ETipoTransacao? tipo)
		{
			int anoAtual = new DateTime().Year;
			int mesAtual = new DateTime().Month;

			return this.Transacoes.Where(x =>
				x.Data.Year == anoAtual
				&& x.Data.Month == mesAtual
				&& ((tipo != null) ? x.Tipo == tipo : true)
			).Count();
		}

		private void AddTransacaoContaCorrente(Transacao transacao)
		{
			if (PegarQtddTransacaoNoMesAtual(Enums.ETipoTransacao.Deposito) >= MaxDepositoPorMes)
			{
				throw new Exception($"Quantidade maxima de depositos por mês excedida.");
			}
			if (PegarQtddTransacaoNoMesAtual(null) >= MaxDepositoPorMes)
			{
				throw new Exception($"Quantidade maxima de movimentação por mês excedida.");
			}

			this.Transacoes.Add(transacao);
		}
	}
}
