using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Cliente.Aggregate.Entities
{
	public abstract class Conta : Shared.Entity
	{
		public int Numero { get; internal set; }
		public int Agencia { get; internal set; }
		public int AgenciaDigito { get; internal set; }
		public decimal Saldo { get; internal set; }
		public Guid ClienteId { get; set; }

		[JsonIgnore]
		public Cliente Cliente { get; set; }
		public IList<Transacao> Transacoes { get; set; }


		public Conta() : base(null)
		{

		}

		protected Conta(int numero, int agencia, int digitoAg, decimal saldo, Guid clienteId) : base(null)
		{
			Numero = numero;
			Agencia = agencia;
			AgenciaDigito = digitoAg;
			Saldo = saldo;
			ClienteId = clienteId;
		}

		abstract public void Sacar(Transacao saque);
		abstract public void Depositar(Transacao deposito);
		abstract public void Transferir(Transacao transferencia);

		public void ValidarExcluirConta()
		{
			//conta não pode ser exluido com saldo existente;
			if (this.Saldo > 0)
			{
				throw new Exception("Esta conta não pode ser excluida pois possui saldo.");
			}
		}
	}
}
