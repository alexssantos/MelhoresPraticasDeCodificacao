using System;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Services
{
	public interface IClienteService
	{
		public void CreateCliente(string nome, string cpf, DateTime dataNascimento);
		public IList<Entities.Cliente> ListarTodosClientes();
	}
}
