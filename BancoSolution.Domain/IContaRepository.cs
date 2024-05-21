using System;
using System.Collections.Generic;

namespace BancoSolution.Domain
{
    public interface IContaRepository
    {

                /// <summary>
        /// Busca contas pelo CPF
        /// </summary>
        /// <param name="novaConta"></param>
        /// <returns> Lista de contas </returns>
        void CadastraNovaConta(Conta novaConta);  
        /// <summary>
        /// Busca todos os contas
        /// </summary>
        /// <returns> Lista de contas </returns>
        List<Conta> BuscarTodasContas();  

        /// <summary>
        /// Busca contas pelo CPF
        /// </summary>
        /// <param name="cpfCliente"></param>
        /// <returns> Lista de contas </returns>
        List<Conta> BuscarContasPorCliente(long cpfCliente);     
    }
}