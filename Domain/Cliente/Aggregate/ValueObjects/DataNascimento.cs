using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	[ExcludeFromCodeCoverage]
	public class DataNascimento : Shared.ValueObject
	{
		public DateTime Data { get; set; }

		public int Idade
		{
			get { return Valor(Data); }
			set { }
		}


		public DataNascimento(DateTime data)
		{
			this.Data = data;
		}

		private int Valor(DateTime data) => new DateTime((DateTime.Now.Date - data).Ticks).Year;
	}
}
