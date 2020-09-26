using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Factories;
using Domain.Cliente.Aggregate.Respositories;
using Domain.Cliente.Aggregate.Services;
using Domain.Cliente.Aggregate.Specification;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
	public class ClienteService : IClienteService
	{
		private IClienteRepositorio Repositorio { get; set; }

		public ClienteService(IClienteRepositorio repo)
		{
			this.Repositorio = repo;
		}

		public Cliente CriarCliente(string nome, string cpf, DateTime dataNascimento)
		{
			if (this.Repositorio.GetOneByCriteria(ClienteSpecification.GetByCPF(cpf)) != null)
				throw new Exception($"Cliente já existente na base com este cpf: {cpf}");


			Cliente cliente = ClienteFactory.Criar(nome, cpf, dataNascimento);
			this.Repositorio.Save(cliente);
			return cliente;
		}

		public Cliente BuscarCliente(Guid IdCliente)
		{
			var cliente = this.Repositorio.GetById(IdCliente);
			if (cliente == null) throw new Exception($"Cliente não existente na base com este id: {IdCliente}");

			return cliente;
		}

		public Cliente AtualizarCliente(Guid id, string nome, string email, DateTime dataNascimento, string nomePai, string nomeMae)
		{
			var usuarioAntigo = BuscarCliente(id);

			var clienteAtual = ClienteFactory.Criar(nome, usuarioAntigo.CPF, email, dataNascimento, nomePai, nomeMae);
			this.Repositorio.Update(id, clienteAtual);
			return clienteAtual;
		}

		public Cliente ApagarCliente(Guid IdCliente)
		{
			var cliente = BuscarCliente(IdCliente);

			cliente.ApagarCliente();
			this.Repositorio.Delete(IdCliente);
			return cliente;
		}

		public IList<Cliente> ListarTodosClientes()
		{
			return Repositorio.GetAll();
		}
	}
}
