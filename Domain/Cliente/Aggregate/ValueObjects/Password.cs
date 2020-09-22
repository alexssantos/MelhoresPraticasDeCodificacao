using System;
using System.Text.RegularExpressions;

namespace Domain.Cliente.Aggregate.ValueObjects
{
	public class Password : Shared.ValueObject
	{
		public string Valor { get; set; }

		public Password(string valor)
		{
			ValidaPassword(valor);

			this.Valor = valor;

		}

		private void ValidaPassword(string valor)
		{
			var isValid = Regex.IsMatch(valor, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");

			if (!isValid)
				throw new Exception("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número");

		}

		public static Password GerarPassword(int len = 8)
		{
			string res = "";
			Random rnd = new Random();

			while (res.Length < len) res += (new Func<Random, string>((r) =>
			{
				char c = (char)((r.Next(123) * DateTime.Now.Millisecond % 123));
				return (Char.IsLetterOrDigit(c)) ? c.ToString() : "";
			}))(rnd);

			return new Password(res);
		}
	}
}
