using Domain.Specification;

namespace Domain.Cliente.Aggregate.Specification
{
	public static class ClienteSpecification
	{
		public static ISpecification<Entities.Cliente> GetByCPF(string cpf)
		{
			//expression
			Specification<Entities.Cliente> spec = new Specification<Entities.Cliente>(x => x.CPF.Valor == cpf);
			//condiction
			spec.And(new Specification<Entities.Cliente>(x => !string.IsNullOrWhiteSpace(x.CPF.Valor)));

			return spec;
		}

		public static ISpecification<Entities.Cliente> GetByEmail(string email)
		{
			//expression
			Specification<Entities.Cliente> spec = new Specification<Entities.Cliente>(x => x.Email.Valor == email);
			//condiction
			spec.And(new Specification<Entities.Cliente>(x => !string.IsNullOrWhiteSpace(x.Email.Valor)));

			return spec;
		}


	}
}
