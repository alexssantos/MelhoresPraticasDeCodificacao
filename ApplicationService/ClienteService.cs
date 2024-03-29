﻿using Domain.Cliente.Aggregate.Entities;
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
		private IClienteRepositorio Repositorio { get; set; }

		public ClienteService(IClienteRepositorio repo)
		{
			this.Repositorio = repo;
		}

		public ClienteService()
		{
		}

		public Cliente CriarCliente(string nome, string cpf, DateTime dataNascimento)
		{
			var result = this.Repositorio.GetOneByCriteria(ClienteSpecification.GetByCPF(cpf));
			if (result != null)
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
			var usuario = BuscarCliente(id);

			usuario.Nome = nome;
			usuario.Email = new Email(email);
			usuario.DataNascimento = new DataNascimento(dataNascimento);
			usuario.Pai = new Filiacao(nomePai);
			usuario.Mae = new Filiacao(nomeMae);

			this.Repositorio.Update(id, usuario);
			return usuario;
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
			return Repositorio.GetAllWithChildren();
		}

		public Cliente AdicionarConta(Conta conta)
		{
			var cliente = BuscarCliente(conta.ClienteId);
			cliente.AdicionarConta(conta, conta.Id);
			//this.Repositorio.Update(conta.ClienteId, cliente);
			return cliente;
		}
	}
}
