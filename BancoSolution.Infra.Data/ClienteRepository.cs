using System;
using System.Collections.Generic;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDao _clienteDao;

        public ClienteRepository()
        {
            _clienteDao = new ClienteDao();
        }
        public Cliente BuscarClientePorCpf(long cpf)
        {
            return _clienteDao.BuscarPorCpf(cpf);
        }

        public List<Cliente> BuscarTodosClientes()
        {
            return _clienteDao.BuscarTodos();
        }
    }
}
