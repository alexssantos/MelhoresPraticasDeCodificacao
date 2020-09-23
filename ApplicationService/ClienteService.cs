using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Factories;
using Domain.Cliente.Aggregate.Respositories;
using Domain.Cliente.Aggregate.Services;
using Domain.Cliente.Aggregate.Specification;
using Domain.Cliente.Aggregate.ValueObjects;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
	public class ClienteService : IClienteService
	{
		public IClienteRepositorio Repositorio { get; set; }

		public ClienteService(IClienteRepositorio repo)
		{
			this.Repositorio = repo;
		}

		public void CreateCliente(string nome, string cpf, DateTime dataNascimento)
		{
			if (this.Repositorio.GetOneByCriteria(ClienteSpecification.GetByCPF(cpf)) != null)
				throw new Exception($"Cliente já existente na base com este cpf {typeof(CPF)}");

			Cliente cliente = ClienteFactory.Criar(nome, cpf, dataNascimento);

			this.Repositorio.Save(cliente);
		}

		public IList<Cliente> ListarTodosClientes()
		{
			return Repositorio.GetAll();
		}
	}
}
