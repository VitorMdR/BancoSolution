using System;
using System.Collections.Generic;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaDao _contaDao;
        private readonly ClienteDao _clienteDao;

        public ContaRepository()
        {
            _contaDao = new ContaDao();
            _clienteDao = new ClienteDao();
        }

        public void CadastraNovaConta(Conta novaConta)
        {
            _contaDao.Inserir(novaConta);
        }

        public List<Conta> BuscarContasPorCliente(long cpfCliente)
        {
            var clienteEncontrado = _clienteDao.BuscarPorCpf(cpfCliente);

            if (clienteEncontrado == null)
                throw new Exception("Cliente não encontrado!");
                
            return _contaDao.BuscarPorCliente(clienteEncontrado);
        }

        public List<Conta> BuscarTodasContas()
        {
            return _contaDao.BuscarTodas();
        }    
    }
}
