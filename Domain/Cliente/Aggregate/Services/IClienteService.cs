using Domain.Cliente.Aggregate.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Services
{
	public interface IClienteService
	{
		public Entities.Cliente CriarCliente(string nome, string cpf, DateTime dataNascimento);
		public Entities.Cliente AtualizarCliente(Guid id, string nome, string email, DateTime dataNascimento, string nomePai, string nomeMae);
		public Entities.Cliente ApagarCliente(Guid IdCliente);
		public Entities.Cliente BuscarCliente(Guid IdCliente);
		public IList<Entities.Cliente> ListarTodosClientes();
		public Entities.Cliente AdicionarConta(Conta conta);
	}
}
