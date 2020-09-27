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

		//public IList<Endereco> Enderecos { get; internal set; }

		//public IList<Telefone> Telefones { get; internal set; }

		public virtual ICollection<Conta> Contas { get; internal set; }


		public Cliente() : base(null)
		{
			this.Contas = new List<Conta>();
		}

		internal Cliente(Guid? id, string nome, CPF cpf, DataNascimento dataNascimento) : base(id)
		{
			this.Contas = new List<Conta>();
			this.DataNascimento = dataNascimento;
			this.CPF = cpf;
			this.Nome = nome;
		}

		internal Cliente(string nome, CPF cpf, DataNascimento dataNascimento, Filiacao pai, Filiacao mae)
			: this(null, nome, cpf, dataNascimento)
		{
			this.Mae = mae;
			this.Pai = pai;
		}

		internal Cliente(Guid? id, string nome, CPF cpf, Email email, DataNascimento dataNascimento, Filiacao pai, Filiacao mae)
			: this(id, nome, cpf, dataNascimento)
		{
			this.Email = email;
			this.Mae = mae;
			this.Pai = pai;
		}


		public List<Conta> ObterContas()
		{
			return Contas.ToList();
		}

		public Conta ObterConta(Guid id)
		{
			return this.Contas.FirstOrDefault(x => x.Id == id);
		}

		public void RemoverConta(Guid id)
		{
			var conta = ObterConta(id);
			Contas.Remove(conta);
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
