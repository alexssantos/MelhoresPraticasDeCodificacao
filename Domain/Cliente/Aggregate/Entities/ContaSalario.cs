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
			throw new System.NotImplementedException();
		}

		public override void Sacar()
		{
			throw new System.NotImplementedException();
		}

		public override void Transferir()
		{
			throw new System.NotImplementedException();
		}
	}
}
