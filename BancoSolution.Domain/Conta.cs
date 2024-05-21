using System;

namespace BancoSolution.Domain
{
    public class Conta
    {
        public long Numero { get; set; }
        public int Digito { get; set; }
        public string Agencia { get; set; }
        public TipoConta TipoConta { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public CestaServico CestaServico { get; set; }
        public DateTime DataAbertura { get; set; }
        public Cliente Cliente { get; set; }


        public override string ToString()
        {
            return $"Conta: {Numero}-{Digito} AG: {Agencia} - Data Abertura: {DataAbertura.ToShortDateString()} - Cliente: {Cliente.Nome} ";
        }

        public Conta()
        {
            Cliente = new Cliente();
            DataAbertura = DateTime.Now;
        }

    }

    public enum TipoConta
    {
        Corrente = 001,
        Poupanca = 013,
        Facil = 1288

    }

    public enum CestaServico
    {
        Nenhuma = 0,
        Ouro = 1,
        Prata = 2,
        Platina = 3

    }
}