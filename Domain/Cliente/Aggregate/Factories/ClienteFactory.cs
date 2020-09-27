using Domain.Cliente.Aggregate.ValueObjects;
using System;

namespace Domain.Cliente.Aggregate.Factories
{
	public static class ClienteFactory
	{
		//Basic Cliente
		public static Entities.Cliente Criar(string nome, string cpf, DateTime dataNascimento)
		{
			Guid? id = null;
			return new Entities.Cliente(
				id,
				nome,
				new CPF(cpf),
				new DataNascimento(dataNascimento));
		}


		public static Entities.Cliente Criar(Guid id, string nome, string cpf, string email, DateTime dataNascimento, string nomePai, string nomeMae)
		{
			return new Entities.Cliente(
				id,
				nome,
				new CPF(cpf),
				new Email(email),
				new DataNascimento(dataNascimento),
				new Filiacao(nomePai),
				new Filiacao(nomeMae));
		}

	}
}
