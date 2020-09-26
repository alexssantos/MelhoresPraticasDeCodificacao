using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_API.ViewModel
{
	public class AddClienteRequest
	{
		[Required(ErrorMessage = "Campo Nome é Obrigatorio")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo CPF é Obrigatorio")]
		public string CPF { get; set; }

		[Required(ErrorMessage = "Campo Data Nascimento é Obrigatorio")]
		public DateTime DataNascimento { get; set; }
	}
}
