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

		[HttpPost]
		public IActionResult Post([FromBody] ClienteDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			this.ClienteService.CreateCliente(request.Nome, request.CPF, request.DataNascimento);

			return Ok();
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var lista = this.ClienteService.ListarTodosClientes();

			return Ok(lista);
		}
	}

}
