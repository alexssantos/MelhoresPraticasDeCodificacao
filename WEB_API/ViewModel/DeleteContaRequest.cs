using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_API.ViewModel
{
	public class DeleteContaRequest
	{
		[Required(ErrorMessage = "Campo IdCliente é Obrigatorio")]
		public Guid IdCliente { get; set; }

		[Required(ErrorMessage = "Campo IdConta é Obrigatorio")]
		public Guid IdConta { get; set; }
	}
}
