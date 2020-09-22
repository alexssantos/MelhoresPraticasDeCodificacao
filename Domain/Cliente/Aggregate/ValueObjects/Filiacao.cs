using System;
using System.Globalization;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	public class Filiacao : Shared.ValueObject
	{
		public string Nome { get; set; }
		public DataNascimento DataNascimento { get; set; }
		public string NomeFormatado => ValorFormatado(this.Nome);

		public Filiacao()
		{

		}

		public Filiacao(string nome)
		{
			this.Nome = nome ?? throw new ArgumentNullException(nameof(Filiacao));
		}

		private string ValorFormatado(string nome) => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome);

	}
}
