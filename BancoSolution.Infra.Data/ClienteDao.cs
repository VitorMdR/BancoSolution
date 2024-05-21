using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ClienteDao
    {
        private readonly string _connectionString =
         @"data source=.\SQLEXPRESS;initial catalog=Agencia_Bancaria_DB;uid=sa;pwd=bocaum24;";

        public ClienteDao()
        {

        }

        public List<Cliente> BuscarTodos()
        {
            var listaCliente = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT NOME, CPF, DATA_NASCIMENTO FROM CLIENTE";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var clienteBuscado = new Cliente
                        {
                            CpfCliente = long.Parse(leitor["CPF"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString()),
                        };

                        listaCliente.Add(clienteBuscado);
                    }
                }
            }

            return listaCliente;
        }

        public Cliente BuscarPorCpf(long cpf)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT NOME, CPF, DATA_NASCIMENTO FROM CLIENTE WHERE CPF = @CPF_CLIENTE";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var clienteBuscado = new Cliente
                        {
                            CpfCliente = long.Parse(leitor["CPF"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString()),
                        };

                        return clienteBuscado;
                    }
                }
            }

            return null;
        }

    }
}
