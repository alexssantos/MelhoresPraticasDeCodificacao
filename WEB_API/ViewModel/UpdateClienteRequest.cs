using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_API.ViewModel
{
	public class UpdateClienteRequest
	{
		[Required(ErrorMessage = "Campo Id é Obrigatorio")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Campo Nome é Obrigatorio")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo Email é Obrigatorio")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo CPF é Obrigatorio")]
		public string CPF { get; set; }

		[Required(ErrorMessage = "Campo Data Nascimento é Obrigatorio")]
		public DateTime DataNascimento { get; set; }

		[Required(ErrorMessage = "Campo NomePai é Obrigatorio")]
		public string NomePai { get; set; }


		[Required(ErrorMessage = "Campo NomeMae é Obrigatorio")]
		public string NomeMae { get; set; }

	}
}
