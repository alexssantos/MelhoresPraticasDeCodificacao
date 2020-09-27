using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Services;
using Microsoft.AspNetCore.Mvc;
using WEB_API.ViewModel;

namespace WEB_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContaController : ControllerBase
	{
		public IContaService ContaService { get; set; }

		public ContaController(IContaService clienteService)
		{
			this.ContaService = clienteService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var lista = this.ContaService.ListarTodasContas();

			return Ok(lista);
		}

		[HttpPost]
		public IActionResult Post([FromBody] NewContaRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			Cliente cliente = this.ContaService.CriarConta(request.Conta, request.Agencia, request.DigAgencia, request.Saldo, request.IdCliente);

			return Ok(cliente);
		}


		[HttpPut]
		public IActionResult Update([FromBody] UpdateClienteRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			//this.ContaService.AtualizarCliente();

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromBody] DeleteContaRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			this.ContaService.ApagarConta(request.IdConta, request.IdCliente);


			return Ok();
		}
	}
}
