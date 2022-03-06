using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	[ExcludeFromCodeCoverage]
	public class CPF //: Shared.ValueObject
	{
		public string Valor { get; set; }

		//public CPF()
		//{

		//}

		public CPF(string valor)
		{
			//validar CPF 

			this.Valor = valor?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(CPF));
		}

		private string ValorFormatado(string valor) => Convert.ToInt64(valor).ToString(@"000\.000\.000\-00");
	}
}
