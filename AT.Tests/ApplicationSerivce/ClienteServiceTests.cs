using ApplicationService;
using Domain.Cliente.Aggregate.Entities;
using Domain.Cliente.Aggregate.Factories;
using Domain.Cliente.Aggregate.Respositories;
using Domain.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AT.Tests.ApplicationSerivce
{
	[TestClass]
	public class ClienteServiceTests
	{
		//Red, Green, Refactor.

		private ClienteService ClienteService { get; set; }
		private Mock<IClienteRepositorio> MockRepositorio { get; set; }
		public Cliente cliente { get; set; }
		public Conta conta { get; set; }

		[TestInitialize]
		public void TearUp()
		{
			this.MockRepositorio = new Mock<IClienteRepositorio>();
			ClienteService = new ClienteService(MockRepositorio.Object);

			cliente = ClienteFactory.Criar(
				new Guid(),
				"Alex Santos",
				"12345678900",
				"alex.silva@al.infnet.edu.br",
				new DateTime(2000, 10, 25),
				"Maria",
				"Alexandre"
			);

			conta = ContaFactory.Criar(1234, 123456, 9, 450.00M, cliente.Id);
		}

		//CADASTRAR CLIENTE ============================================

		[TestMethod]
		[DataTestMethod]
		[DataRow("Alex Santos", "12345678900")]
		[DataRow("Marcio Santos", "99988877700")]
		[DataRow("Lucas Pitol", "11122233344")]
		[DataRow("Bruno Furtado", "12312312300")]
		public void SecessoAoCadastrarCliente(string nome, string cpf)
		{
			//Arrange
			MockRepositorio.Setup(x => x.GetOneByCriteria(It.IsAny<ISpecification<Cliente>>()))
							.Returns<Cliente>(null);

			MockRepositorio.Setup(x => x.Save(It.IsAny<Cliente>()));

			var dataNascimento = new DateTime(1990, 10, 25);

			//Act
			var cliente = ClienteService.CriarCliente(nome, cpf, dataNascimento);

			//Assert
			Assert.IsNotNull(cliente);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("12345678900")]
		[DataRow("12345678922")]
		[DataRow("11122233300")]
		[ExpectedException(typeof(System.Exception))]
		public void ErroAoCadastrarClienteQuandoJaExisteCpf(string cpf)
		{
			//Arrange
			MockRepositorio.Setup(x => x.GetOneByCriteria(It.IsAny<ISpecification<Cliente>>()))
							.Returns(this.cliente);

			string nome = "Alex Teste 1";
			var dataNascimento = new DateTime(1990, 10, 25);

			//Act
			var cliente = ClienteService.CriarCliente(nome, cpf, dataNascimento);

			//Assert
			Assert.IsTrue(cliente.Nome == String.Empty);
		}

		//BUSCAR CLIENTE ============================================

		[TestMethod]
		public void SucessoAoBuscarCliente()
		{
			//Arrange
			MockRepositorio.Setup(x => x.GetById(It.IsAny<Guid>()))
							.Returns(this.cliente);

			//Act
			var clienteBuscado = ClienteService.BuscarCliente(this.cliente.Id);

			//Assert
			Assert.IsTrue(clienteBuscado == this.cliente);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void ErroAoBuscarClienteQuandoIdNaoExistirNaBase()
		{
			//Arrange
			MockRepositorio.Setup(x => x.GetById(It.IsAny<Guid>()))
							.Returns<Cliente>(null);

			//Act
			var clienteBuscado = ClienteService.BuscarCliente(this.cliente.Id);

			//Assert
			Assert.IsNull(clienteBuscado);
		}

		//ATUALIZAR CLIENTE ============================================

		//[TestMethod]
		public void SucessoAoAtualizarCliente()
		{
			Assert.IsTrue(true);
		}

		//[TestMethod]		
		public void ErroAoAtualizarClienteQuandoAlgumParametroInvalido()
		{
			Assert.IsTrue(true);
		}

		//APAGAR CLIENTE ============================================

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void SucessoAoApagarCliente()
		{
			//Arrange			
			MockRepositorio.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(cliente);

			MockRepositorio.Setup(x => x.Delete(It.IsAny<Guid>()));

			MockRepositorio.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns<Cliente>(null);

			//Act
			var clienteApagado = ClienteService.ApagarCliente(this.cliente.Id);
			var clienteBuscado = ClienteService.BuscarCliente(this.cliente.Id);

			//Assert
			Assert.IsNull(clienteBuscado);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void ErroAoApagarClienteQuandoTiverContaAssociada()
		{
			//Arrange
			cliente.AdicionarConta(conta, conta.Id);
			MockRepositorio.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(cliente);

			//Act
			var clienteBuscado = ClienteService.ApagarCliente(this.cliente.Id);

			//Assert
			Assert.IsNull(clienteBuscado);
		}

		//ADICIONAR CONTA ============================================

		[TestMethod]
		[DataTestMethod]
		[DataRow(123, 123456, 0, 200.50)]
		[DataRow(456, 111222, 1, 100.15)]
		[DataRow(789, 333444, 2, 10.10)]
		[DataRow(987, 555666, 3, 1200)]
		[DataRow(321, 777888, 4, 0)]
		public void SucessoAoAdicionarContaAoCliente(int numeroConta, int agencia, int digito, double saldoD)
		{
			//Arrange
			Decimal saldo = Convert.ToDecimal(saldoD);
			cliente.AdicionarConta(conta, conta.Id);
			var contaNova = ContaFactory.Criar(numeroConta, agencia, digito, saldo, cliente.Id);

			//Act
			cliente.AdicionarConta(contaNova, contaNova.Id);

			//Assert
			Assert.IsTrue(cliente.Contas.Count == 2);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void ErroAoAdicionarContaAoClienteQueJaExiste()
		{
			//Arrange
			cliente.AdicionarConta(conta, conta.Id);
			var contaNova = ContaFactory.Criar(conta.Numero, conta.Agencia, conta.AgenciaDigito, 1000.00M, cliente.Id);

			//Act
			cliente.AdicionarConta(contaNova, conta.Id);


			//Assert
			Assert.IsFalse(cliente.Contas.Count == 2);
		}
	}
}
