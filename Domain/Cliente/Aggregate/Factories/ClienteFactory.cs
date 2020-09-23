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
				new ValueObjects.CPF(cpf),
				new ValueObjects.DataNascimento(dataNascimento));
		}


	}
}
