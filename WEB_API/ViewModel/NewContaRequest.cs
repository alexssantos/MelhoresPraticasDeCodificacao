using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_API.ViewModel
{
	public class NewContaRequest
	{
		[Required(ErrorMessage = "Campo Conta é Obrigatorio")]
		public int Conta { get; set; }

		[Required(ErrorMessage = "Campo Agencia é Obrigatorio")]
		public int Agencia { get; set; }

		[Required(ErrorMessage = "Campo DigAgencia é Obrigatorio")]
		public int DigAgencia { get; set; }

		[Required(ErrorMessage = "Campo Saldo é Obrigatorio")]
		public decimal Saldo { get; set; }

		[Required(ErrorMessage = "CampoIdCliente é Obrigatorio")]
		public Guid IdCliente { get; set; }
	}
}
