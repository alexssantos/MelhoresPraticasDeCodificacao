using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Respositories;
using Domain.Cliente.Aggregate.Services;
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
			//if (this.Repositorio.GetByCpf(CPF) != null)
			//	throw new Exception($"Cliente já existente na base com este cpf {CPF}");

			CPF cpfObj = new CPF(cpf);
			DataNascimento dt = new DataNascimento(dataNascimento);
			Cliente cliente = new Cliente(nome, cpfObj, dt);

			this.Repositorio.Save(cliente);
		}

		public IList<Cliente> ListarTodos()
		{
			return Repositorio.GetAll();
		}
	}
}
