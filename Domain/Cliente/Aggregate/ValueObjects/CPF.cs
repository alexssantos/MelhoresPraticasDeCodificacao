using System;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	public class CPF : Shared.ValueObject
	{
		public string Valor { get; set; }

		public CPF()
		{

		}

		public CPF(string valor)
		{
			this.Valor = valor?.Replace(".", "").Replace("-", "") ?? throw new ArgumentException(nameof(CPF));
		}

		private string ValorFormatado(string valor) => Convert.ToInt64(valor).ToString(@"000\.000\.000\-00");
	}
}
