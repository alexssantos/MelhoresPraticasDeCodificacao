using Domain.Cliente.Aggregate.Services;
using Microsoft.AspNetCore.Mvc;
using WEB_API.ViewModel;

namespace WEB_API.Controllers
{
	[Route("api/cliente")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		public IClienteService ClienteService { get; set; }

		public ClienteController(IClienteService clienteService)
		{
			this.ClienteService = clienteService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var lista = this.ClienteService.ListarTodosClientes();

			return Ok(lista);
		}

		[HttpPost]
		public IActionResult Post([FromBody] AddClienteRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			this.ClienteService.CriarCliente(request.Nome, request.CPF, request.DataNascimento);

			return Ok();
		}


		[HttpPut]
		public IActionResult Update([FromBody] UpdateClienteRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			this.ClienteService.AtualizarCliente(
				request.Id,
				request.Nome,
				request.Email,
				request.DataNascimento,
				request.NomePai,
				request.NomeMae);

			return Ok();
		}
	}

}
