using projeto_agenda.Entidades;
using projeto_agenda.Repositorios;
using System;
using System.Collections.Generic;

namespace projeto_agenda
{
    class Program
    {
        static string nome, endereco, telefone;
        static void Main(string[] args)
        {
            Console.Title = "Agenda Telefônica";
            ContatoDAO contatoDAO = new ContatoDAO();
            contatoDAO.CriarBanco();
            bool continuarExecucao = true;
            List<Contato> contatos = contatoDAO.RecuperarTodos();
            Utilidades.ExibirContatos(contatos);
            Console.WriteLine();

            while (continuarExecucao)
            {
                if (contatos.Count == 0)
                    Console.Write("O que deseja fazer (1-Adicionar, 5-Encerrar Aplicação)? ");
                else
                    Console.Write("O que deseja fazer (1-Adicionar, 2-Alterar, 3-Excluir, 4-Consultar, 5-Encerrar Aplicação)? ");

                int acao = 0;
                try
                {
                    acao = int.Parse(Console.ReadLine());
                    switch (acao)
                    {
                        case 1:
                            Console.WriteLine("Insira os dados do contato");
                            Console.Write("Nome(Obrigatório):");
                            nome = Console.ReadLine().Trim();
                            Console.Write("Endereço: ");
                            endereco = Console.ReadLine().Trim();
                            Console.Write("Telefone(Obrigatório): ");
                            telefone = Console.ReadLine().Trim();
                            if (ValidarContato())
                            {
                                Contato contato = new Contato(nome, endereco, telefone);
                                contatos = contatoDAO.Inserir(contato);
                            }

                            Utilidades.LimparTela();
                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 2:
                            Console.Write("Digite o ID do contato que deseja alterar: ");
                            int idAlterar = int.Parse(Console.ReadLine());
                            if (idAlterar <= contatos.Count)
                            {
                                Console.WriteLine("Entre com os novos dados (Caso não deseje alterar um dos campos, mantenha o valor em branco.)");

                                Console.Write("Nome: ");
                                nome = Console.ReadLine().Trim();
                                if (!string.IsNullOrWhiteSpace(nome))
                                    contatos[idAlterar - 1].Nome = nome;

                                Console.Write("Endereço: ");
                                endereco = Console.ReadLine().Trim();
                                if (!string.IsNullOrWhiteSpace(endereco))
                                    contatos[idAlterar - 1].Endereco = endereco;

                                Console.Write("Telefone: ");
                                telefone = Console.ReadLine().Trim();
                                if (!string.IsNullOrWhiteSpace(telefone))
                                    contatos[idAlterar - 1].Telefone = telefone;

                                contatos = contatoDAO.Alterar(contatos[idAlterar -1]);
                            }
                            else
                                Console.WriteLine("Esse ID de contato não existe!");

                            Utilidades.LimparTela();
                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 3:
                            Console.Write("Digite o ID do contato que deseja excluir: ");
                            int idExcluir = int.Parse(Console.ReadLine());
                            if (idExcluir <= contatos.Count)
                                contatos = contatoDAO.Excluir(contatos[idExcluir -1]);
                            else
                                Console.WriteLine("Esse ID de contato não existe!");

                            Utilidades.LimparTela();
                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 4:
                            Console.Write("Digite o ID do contato para consultar: ");
                            int idConsulta = int.Parse(Console.ReadLine());
                            if (idConsulta <= contatos.Count)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nome: " + contatos[idConsulta - 1].Nome);
                                if (!string.IsNullOrWhiteSpace(contatos[idConsulta - 1].Endereco))
                                    Console.WriteLine("Endereço: " + contatos[idConsulta - 1].Endereco);
                                Console.WriteLine("Telefone: " + Utilidades.FormatarTelefone(contatos[idConsulta - 1].Telefone));
                            }
                            else
                                Console.WriteLine("Esse ID de contato não existe!");

                            Utilidades.LimparTela();
                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 5:
                            continuarExecucao = false;
                            break;
                        default:
                            Console.WriteLine("Ação inválida!");
                            Utilidades.LimparTela();
                            Utilidades.ExibirContatos(contatos);
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Dado inválido: " + e.Message);
                    Utilidades.LimparTela();
                    Utilidades.ExibirContatos(contatos);
                }
            }
        }

        public static bool ValidarContato()
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O nome não pode ser vazio.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10 || telefone.Length > 11 || telefone.Length != Utilidades.somenteNumeros(telefone).Length)
            {
                Console.WriteLine("Telefone inválido.");
                return false;
            }
            return true;
        }
    }
}
