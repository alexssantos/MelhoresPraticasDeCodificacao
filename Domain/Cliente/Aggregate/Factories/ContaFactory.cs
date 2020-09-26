using Domain.Cliente.Aggregate.Entities;

namespace Domain.Cliente.Aggregate.Factories
{
	public static class ContaFactory
	{
		public static Conta Criar(Entities.Cliente cliente, int conta, int agencia, int digitoAg, decimal saldo)
		{
			//STRATEGY PATTERN

			Conta novaConta = saldo switch
			{
				_ when (saldo < 50M) => new ContaSalario(conta, agencia, digitoAg, saldo),
				_ when (saldo >= 50M) && (saldo < 500M) => new ContaCorrente(conta, agencia, digitoAg, saldo),
				_ when (saldo >= 500M) => new ContaPoupanca(conta, agencia, digitoAg, saldo),
			};

			return novaConta;
		}
	}
}
