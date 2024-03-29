﻿using Domain.Cliente.Aggregate.Entities;
using System;

namespace Domain.Cliente.Aggregate.Factories
{
	public static class ContaFactory
	{
		public static Conta Criar(int conta, int agencia, int digitoAg, decimal saldo, Guid idCliente)
		{
            //STRATEGY PATTERN

            Conta novaConta = saldo switch
            {
				_ when (saldo < 50M) 
					=> new ContaSalario(conta, agencia, digitoAg, saldo, idCliente),
				_ when (saldo >= 50M) && (saldo < 500M) 
					=> new ContaCorrente(conta, agencia, digitoAg, saldo, idCliente),
				_ when (saldo >= 500M) 
					=> new ContaPoupanca(conta, agencia, digitoAg, saldo, idCliente),				
			};

			return novaConta;
		}
	}
}
