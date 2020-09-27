using System;
using System.Text.RegularExpressions;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	public class Email : Shared.ValueObject
	{
		public string Valor { get; set; }

		public Email()
		{

		}

		public Email(string email)
		{
			this.Valor = ValidarEmail(email) ? email : throw new Exception("Email está no formato inválido");
		}

		public static bool ValidarEmail(string strEmail)
		{
			string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
			return Regex.IsMatch(strEmail, strModelo);
		}
	}
}
