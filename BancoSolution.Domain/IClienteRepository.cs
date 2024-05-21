using System;
using System.Collections.Generic;

namespace BancoSolution.Domain
{
    public interface IClienteRepository
    {
        /// <summary>
        /// Busca todos os clientes
        /// </summary>
        /// <returns> Lista de clientes </returns>
        List<Cliente> BuscarTodosClientes();  

        /// <summary>
        /// Busca cliente pelo CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns> Lista de clientes </returns>
        Cliente BuscarClientePorCpf(long cpf);     
    }
}