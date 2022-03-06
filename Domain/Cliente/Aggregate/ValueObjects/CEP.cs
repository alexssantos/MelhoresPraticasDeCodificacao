using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	[ExcludeFromCodeCoverage]
	public class CEP : Shared.ValueObject
	{
		public string Valor { get; set; }

		public CEP()
		{

		}

		public CEP(string valor)
		{
			this.Valor = valor?.Replace("-", "") ?? throw new ArgumentNullException(nameof(CEP));
		}


		private string ValorFormatado(string valor) => Convert.ToInt64(valor).ToString(@"00000\-000");
	}
}
