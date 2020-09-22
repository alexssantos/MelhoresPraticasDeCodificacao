using Domain.Cliente.Aggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Cliente : Shared.Entity
	{
		public string Nome { get; set; }
		public DataNascimento DataNascimento { get; set; }
		public CPF CPF { get; set; }
		public Filiacao Pai { get; set; }
		public Filiacao Mae { get; set; }
		public Email Email { get; set; }
		public Password SenhaCliente { get; set; }
		public string Login { get; set; }
		public IList<Endereco> Enderecos { get; set; }
		public IList<Telefone> Telefones { get; set; }
		public IList<Conta> Contas { get; set; }


		public Cliente() { }

		public Cliente(string nome, CPF cpf, DataNascimento dataNascimento)
		{
			this.DataNascimento = dataNascimento;
			this.CPF = cpf;
			this.Nome = nome;
		}

		public Cliente(string nome, CPF cpf, DataNascimento dataNascimento, Filiacao pai, Filiacao mae) : this(nome, cpf, dataNascimento)
		{
			this.Mae = mae;
			this.Pai = pai;
		}


		public List<Conta> ObterContas()
		{
			return this.Contas.ToList();
		}

		public Conta ObterConta(Guid id)
		{
			return this.Contas.FirstOrDefault(x => x.Id == id);
		}

		public void AdicionarConta(Conta conta)
		{
			if (this.ObterConta(conta.Id) != null)
			{
				throw new Exception("Não é permitido inserir duas contas iguais");
			}

			if (this.DataNascimento.Idade < 18)
			{
				throw new Exception("Cliente deve ser maior 18");
			}

			this.Contas.Add(conta);
		}
	}
}
