using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;

namespace Repository.Repositories
{
	public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
	{
		public ContaRepositorio()
		{

		}
	}
}
