using System;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Services
{
	public interface IContaService
	{
		public Entities.Conta CriarConta(string nome, string cpf, DateTime dataNascimento);
		public Entities.Conta AtualizarConta(Guid id, string nome, string email, DateTime dataNascimento, string nomePai, string nomeMae);
		public Entities.Conta ApagarConta(Guid IdConta, Guid idCliente);
		public Entities.Conta BuscarConta(Guid IdConta);
		public IList<Entities.Conta> ListarTodosContas();
	}
}
