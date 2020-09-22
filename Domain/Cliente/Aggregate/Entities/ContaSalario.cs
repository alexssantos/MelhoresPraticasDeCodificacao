namespace Domain.Cliente.Aggregate.Entities
{
	public class ContaSalario : Conta
	{
		public float MaxSaquePorMes { get; set; }


		public ContaSalario(int numero, int agencia, int saldo) : base(numero, agencia, saldo)
		{
		}


		public override void Depositar()
		{
			//Logica de Negocio aqui

			throw new System.NotImplementedException();
		}

		public override void Sacar()
		{
			//Logica de Negocio aqui

			throw new System.NotImplementedException();
		}

		public override void Transferir()
		{
			//Logica de Negocio aqui

			throw new System.NotImplementedException();
		}
	}
}
