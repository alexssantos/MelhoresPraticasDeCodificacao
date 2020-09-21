namespace Domain.Cliente.Aggregate.Entities
{
	public abstract class Conta : Shared.Entity
	{
		public int Numero { get; internal set; }
		public int Agencia { get; internal set; }
		public int AgenciaDigito { get; internal set; }
		public int Saldo { get; internal set; }

		protected Conta(int numero, int agencia, int saldo)
		{
			Numero = numero;
			Agencia = agencia;
			Saldo = saldo;
		}

		abstract public void Sacar();
		abstract public void Depositar();
		abstract public void Transferir();
	}
}
