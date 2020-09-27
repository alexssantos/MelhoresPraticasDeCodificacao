using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Collections.Generic;

namespace Repository.Repositories
{
	public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
	{
		private BankContext Context { get; set; }


		public ClienteRepositorio(BankContext context) : base(context)
		{
			this.Context = context;
		}

		public IList<Cliente> GetAllWithChildren()
		{
			var taskList = this.Context.Clientes
				.Include(x => x.Contas)
				.AsNoTracking()
				.ToListAsync();
			return taskList.Result;
		}
	}
}
