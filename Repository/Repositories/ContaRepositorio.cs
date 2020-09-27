using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;
using Repository.Context;

namespace Repository.Repositories
{
	public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
	{
		public BankContext Context { get; set; }

		public ContaRepositorio(BankContext context) : base(context)
		{
			this.Context = context;
		}
	}
}
