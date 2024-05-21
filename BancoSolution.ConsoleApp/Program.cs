using System;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;

namespace BancoSolution.ConsoleApp
{
    class Program
    {
        static IClienteRepository _clienteRepository = new ClienteRepository();
        static IContaRepository _contaRepository = new ContaRepository();

        static string _opcaoCliente = "";
        static string _opcaoConta = "";
        static string _opcaoPrincipal = "";

        static void Main(string[] args)
        {
            EscolherUmaOpcaoPrincipal();
        }

        public static void EscolherUmaOpcaoPrincipal()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PRINCIPAL         -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Gerenciar Cliente");
            Console.WriteLine(" 2 - Gerenciar Contas");
            Console.WriteLine(" 3 - Sair");
            Console.Write("=> ");
            _opcaoPrincipal = Console.ReadLine();

            switch (_opcaoPrincipal)
            {
                case "1":
                    Console.Clear();
                    GerenciarCliente();
                    break;
                case "2":
                    Console.Clear();
                    GerenciarConta();
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }

        public static void VoltarMenuCliente()
        {
            GerenciarCliente();
        }

        public static void VoltarMenuConta()
        {
            GerenciarConta();
        }

        public static void GerenciarCliente()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CLIENTE       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Buscar todos os cliente");
            Console.WriteLine(" 2 - Buscar cliente por CPF");
            Console.WriteLine(" 3 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoCliente = Console.ReadLine();

            FuncionalidadesCliente();
        }

        public static void GerenciarConta()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CONTA       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar uma nova conta");
            Console.WriteLine(" 2 - Buscar todas as contas");
            Console.WriteLine(" 3 - Buscar conta por cliente");
            Console.WriteLine(" 4 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoConta = Console.ReadLine();

            FuncionalidadesConta();
        }

        public static void FuncionalidadesCliente()
        {
            switch (_opcaoCliente)
            {
                case "1":
                    Console.Clear();
                    BuscarTodosClientes();
                    VoltarMenuCliente();
                    break;
                case "2":
                    Console.Clear();
                    BuscarClientePorCpf();
                    VoltarMenuCliente();
                    break;
                case "3":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuCliente();
                    break;
            }

        }

        public static void FuncionalidadesConta()
        {
            switch (_opcaoConta)
            {
                case "1":
                    Console.Clear();
                    CadastraConta();
                    VoltarMenuConta();
                    break;
                case "2":
                    Console.Clear();
                    BuscarTodasContas();
                    VoltarMenuConta();
                    break;
                case "3":
                    Console.Clear();
                    BuscarContaPorCliente();
                    VoltarMenuConta();
                    break;
                case "4":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuConta();
                    break;
            }

        }

        public static void BuscarTodosClientes()
        {
            Console.WriteLine("--           LISTA CLIENTES         -- \n");

            foreach (var item in _clienteRepository.BuscarTodosClientes())
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }

        public static void BuscarClientePorCpf()
        {
            Console.WriteLine("--           CLIENTE         -- \n");

            Console.WriteLine("Digite o CPF do cliente que será buscado:");
            var cpfCliente = long.Parse(Console.ReadLine());

            var clienteEncontrado = _clienteRepository.BuscarClientePorCpf(cpfCliente);
            Console.WriteLine("Cliente encontrado:");
            Console.WriteLine("--------------------------------------");
            if (clienteEncontrado != null)
            {
                Console.WriteLine(clienteEncontrado);
            }
            Console.ReadKey();
        }

        public static void CadastraConta()
        {
            Conta novaConta = new Conta();
            Console.WriteLine("--                   CADASTRO DE CONTA                -- ");

            Console.WriteLine("Digite o CPF do cliente:");
            var cpfCliente = long.Parse(Console.ReadLine());


            novaConta.Cliente = _clienteRepository.BuscarClientePorCpf(cpfCliente);

            if (novaConta.Cliente == null)
            {
                Console.WriteLine("Cliente não existente. Cadastre-o para cadastrar a conta.\nPressione qualquer tecla para continuar.");
                Console.ReadKey();
                VoltarMenuConta();
            }

            else
            {
                Console.WriteLine("Digite o número da conta:");
                novaConta.Numero = long.Parse(Console.ReadLine());

                var buscaContas = _contaRepository.BuscarTodasContas();

                foreach (var item in buscaContas)
                {
                    if (item.Numero == novaConta.Numero)
                    {
                        Console.WriteLine("Número de conta já existente. Pressione qualquer tecla para voltar ao menu de cadastro de contas.");
                        Console.ReadKey();
                        VoltarMenuConta();
                    }
                }

                Console.WriteLine("Digite a agência:");
                novaConta.Agencia = Console.ReadLine();

                Console.WriteLine("Digite o digito:");
                novaConta.Digito = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o limite:");
                novaConta.Limite = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o tipo de conta: 001 - 013 - 1288");
                novaConta.TipoConta = (TipoConta)Convert.ToInt16(Console.ReadLine());

                if (novaConta.TipoConta == TipoConta.Corrente)
                {
                    Console.WriteLine("Digite a cesta serviço: Ouro -> 1 - Prata -> 2 - Platina -> 3");
                    novaConta.CestaServico = (CestaServico)Convert.ToInt16(Console.ReadLine());
                }
                else
                {
                    novaConta.CestaServico = CestaServico.Nenhuma;
                }
                _contaRepository.CadastraNovaConta(novaConta);
            }
        }

        public static void BuscarTodasContas()
        {

            Console.WriteLine("--           LISTA CONTAS         -- \n");

            foreach (var item in _contaRepository.BuscarTodasContas())
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }


        public static void BuscarContaPorCliente()
        {

            Console.WriteLine("--           CONTA         -- \n");

            Console.WriteLine("Digite o CPF do cliente da conta:");
            var cpfCliente = long.Parse(Console.ReadLine());

            try
            {
                var contaEncontrada = _contaRepository.BuscarContasPorCliente(cpfCliente);
                Console.WriteLine("Conta encontrada:");
                Console.WriteLine("--------------------------------------");
                if (contaEncontrada != null)
                {
                    Console.WriteLine(contaEncontrada);
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                VoltarMenuConta();
            }
        }
    }
}
