using Domain.Cliente.Aggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Cliente.Aggregate.Entities
{
	public class Cliente : Shared.Entity
	{
		public string Nome { get; internal set; }
		public DataNascimento DataNascimento { get; internal set; }
		public CPF CPF { get; internal set; }
		public Filiacao Pai { get; internal set; }
		public Filiacao Mae { get; internal set; }
		public Email Email { get; internal set; }
		public Password SenhaCliente { get; internal set; }
		public string Login { get; internal set; }
		public IList<Endereco> Enderecos { get; internal set; }
		public IList<Telefone> Telefones { get; internal set; }
		public IList<Conta> Contas { get; internal set; }


		public Cliente() { }

		internal Cliente(string nome, CPF cpf, DataNascimento dataNascimento)
		{
			this.DataNascimento = dataNascimento;
			this.CPF = cpf;
			this.Nome = nome;
		}

		internal Cliente(string nome, CPF cpf, DataNascimento dataNascimento, Filiacao pai, Filiacao mae) : this(nome, cpf, dataNascimento)
		{
			this.Mae = mae;
			this.Pai = pai;
		}

		internal Cliente(string nome, CPF cpf, Email email, DataNascimento dataNascimento, Filiacao pai, Filiacao mae) : this(nome, cpf, dataNascimento)
		{
			this.Email = email;
			this.Mae = mae;
			this.Pai = pai;
		}


		public List<Conta> ObterContas()
		{
			return this.Contas.ToList();
		}

		internal Conta ObterConta(Guid id)
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

		public void ApagarCliente()
		{
			//cliente não pode ser exluido com conta existente;
			if (this.Contas.Any())
			{
				throw new Exception("Este cliente possui contas ativas");
			}
		}
	}
}
