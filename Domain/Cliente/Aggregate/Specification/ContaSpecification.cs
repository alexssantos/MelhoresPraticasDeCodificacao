using Domain.Cliente.Aggregate.Entities;
using Domain.Specification;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.Specification
{
	[ExcludeFromCodeCoverage]
	public static class ContaSpecification
	{
		public static ISpecification<Conta> GetByAgencia(int agencia)
		{
			ISpecification<Conta> spec = new Specification<Conta>(x => x.Agencia == agencia);
			return spec;
		}

		public static ISpecification<Conta> GetByNumero(int NumeroConta)
		{
			ISpecification<Conta> spec = new Specification<Conta>(x => x.Numero == NumeroConta);
			return spec;
		}

		public static ISpecification<Conta> GetByContaENumero(int agencia, int NumeroConta)
		{
			ISpecification<Conta> spec = GetByAgencia(agencia).And(GetByNumero(NumeroConta));
			return spec;
		}
	}
}
