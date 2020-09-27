using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;
using Repository.Context;

namespace Repository.Repositories
{
	public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
	{
		private BankContext Context { get; set; }


		public ClienteRepositorio(BankContext context) : base(context)
		{
			this.Context = context;
		}
	}
}
