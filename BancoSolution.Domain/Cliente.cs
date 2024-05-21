using System;

namespace BancoSolution.Domain
{
    public class Cliente
    {
        public long CpfCliente { get; set; }
        public string Nome { get; set; }
        public int Idade { get { return CalculaIdade(); } }
        public DateTime DataNascimento { get; set; }

        //NOVO CLIENTE
        public Cliente(long cpf, string nome, DateTime dataNascimento)
        {
            CpfCliente = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public Cliente() { }

        public override string ToString()
        {
            return $"Nome: {Nome} - CPF: {CpfCliente} - Idade: {Idade}";
        }

        private int CalculaIdade()
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }
    }
}
