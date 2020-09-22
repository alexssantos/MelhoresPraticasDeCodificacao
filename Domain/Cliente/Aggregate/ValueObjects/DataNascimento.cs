using System;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	public class DataNascimento : Shared.ValueObject
	{
		public DateTime Data { get; set; }

		public int Idate => Valor(Data);

		public DataNascimento(DateTime data)
		{
			this.Data = data;
		}

		private int Valor(DateTime data) => new DateTime((DateTime.Now.Date - data).Ticks).Year;
	}
}
