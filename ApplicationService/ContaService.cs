using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Factories;
using Domain.Cliente.Aggregate.Respositories;
using Domain.Cliente.Aggregate.Services;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
	public class ContaService : IContaService
	{
		private IContaRepositorio Repositorio { get; set; }
		private IClienteService ClienteService { get; set; }

		public ContaService(IContaRepositorio repositorio, IClienteService clienteService)
		{
			this.Repositorio = repositorio;
			this.ClienteService = clienteService;
		}

		public IList<Conta> ListarTodosContas()
		{
			return this.Repositorio.GetAll();
		}

		public Conta BuscarConta(Guid IdConta)
		{
			var conta = this.Repositorio.GetById(IdConta);
			if (conta == null) throw new Exception($"Conta não existente na base com este id: {IdConta}");

			return conta;
		}

		public Conta AtualizarConta(Guid id, string nome, string email, DateTime dataNascimento, string nomePai, string nomeMae)
		{
			throw new NotImplementedException();
		}

		public Conta CriarConta(int conta, int agencia, int digitoAg, decimal saldo, Guid idCliente)
		{

			var contaObj = ContaFactory.Criar(conta, agencia, digitoAg, saldo, idCliente);
			this.Repositorio.Save(contaObj);
			return contaObj;
		}

		public Conta ApagarConta(Guid idConta, Guid idCliente)
		{
			var conta = BuscarConta(idConta);

			conta.ValidarExcluirConta();
			var cliente = ClienteService.BuscarCliente(idCliente);
			cliente.RemoverConta(idConta);
			this.Repositorio.Delete(idConta);

			return conta;
		}
	}
}
