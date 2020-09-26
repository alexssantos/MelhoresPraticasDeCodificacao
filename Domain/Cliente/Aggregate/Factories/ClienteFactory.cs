using Domain.Cliente.Aggregate.ValueObjects;
using System;

namespace Domain.Cliente.Aggregate.Factories
{
	public static class ClienteFactory
	{
		//Basic Cliente
		public static Entities.Cliente Criar(string nome, string cpf, DateTime dataNascimento)
		{
			return new Entities.Cliente(
				nome,
				new CPF(cpf),
				new DataNascimento(dataNascimento));
		}


		public static Entities.Cliente Criar(string nome, CPF cpf, string email, DateTime dataNascimento, string nomePai, string nomeMae)
		{
			return new Entities.Cliente(
				nome,
				cpf,
				new Email(email),
				new DataNascimento(dataNascimento),
				new Filiacao(nomePai),
				new Filiacao(nomeMae));
		}

	}
}
