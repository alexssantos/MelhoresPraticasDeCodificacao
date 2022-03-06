using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	[ExcludeFromCodeCoverage]
	public class Numero
	{
		public string Valor { get; set; }
		public string Formatado => ValorFormatado(Valor);

		public Numero()
		{

		}

		public Numero(string numero)
		{
			this.Valor = numero;
		}

		private string ValorFormatado(string valor) => Convert.ToInt64(valor).ToString(@"(00) 00000-0000");

	}
}
