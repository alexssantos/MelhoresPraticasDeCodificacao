using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Respositories
{
	public interface IClienteRepositorio : IRepositorioBase<Entities.Cliente>
	{
		public IList<Entities.Cliente> GetAllWithChildren();
	}
}
