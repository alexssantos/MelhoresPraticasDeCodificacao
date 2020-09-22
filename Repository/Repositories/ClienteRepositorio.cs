using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;

namespace Repository.Repositories
{
	public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
	{
		public ClienteRepositorio()
		{
			//empty
		}
	}
}
