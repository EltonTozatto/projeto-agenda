using projeto_agenda.Entidades;
using System;
using System.Collections.Generic;

namespace projeto_agenda
{
    class Program
    {
        static string nome, endereco, telefone;
        static void Main(string[] args)
        {
            bool continuarExecucao = true;
            List<Contato> contatos = new List<Contato>();
            Console.WriteLine("MINHA AGENDA");
            Console.WriteLine("Lista de contatos vazia.");
            Console.WriteLine();

            while (continuarExecucao)
            {
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
                            nome = Console.ReadLine();
                            Console.Write("Endereço: ");
                            endereco = Console.ReadLine();
                            Console.Write("Telefone(Obrigatório): ");
                            telefone = Console.ReadLine();
                            if (ValidarContato())
                            {
                                contatos.Add(new Contato(contatos.Count + 1, nome, endereco, telefone));
                                Console.WriteLine("Contato inserido!");
                            }

                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 2:
                            Console.Write("Digite o ID do contato que deseja alterar: ");
                            int idAlterar = int.Parse(Console.ReadLine());
                            if (idAlterar <= contatos.Count)
                            {
                                Console.WriteLine("Entre com os novos dados (Caso não deseje alterar um dos campos, mantenha o valor em branco.)");

                                Console.Write("Nome: ");
                                nome = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nome))
                                    contatos[idAlterar - 1].Nome = nome;

                                Console.Write("Endereço: ");
                                endereco = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(endereco))
                                    contatos[idAlterar - 1].Endereco = endereco;

                                Console.Write("Telefone: ");
                                telefone = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(telefone))
                                    contatos[idAlterar - 1].Telefone = telefone;

                                Console.WriteLine("Contato Alterado!");
                            }
                            else
                                Console.WriteLine("Esse ID de contato não existe!");

                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 3:
                            Console.Write("Digite o ID do contato que deseja excluir: ");
                            int idExcluir = int.Parse(Console.ReadLine());
                            if (idExcluir <= contatos.Count)
                            {
                                contatos.RemoveAt(idExcluir - 1);
                                Console.WriteLine("Contato excluído!");
                            }
                            else
                                Console.WriteLine("Esse ID de contato não existe!");
                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 4:
                            Console.Write("Digite o ID do contato para consultar: ");
                            int idConsulta = int.Parse(Console.ReadLine());
                            Contato contato = contatos.Find(x => x.Id == idConsulta);
                            if (contato != null)
                            {
                                Console.WriteLine("Nome: " + contato.Nome);
                                if (!string.IsNullOrWhiteSpace(contato.Endereco))
                                    Console.WriteLine("Endereço: " + contato.Endereco);
                                Console.WriteLine(Utilidades.FormatarTelefone(contato.Telefone));
                            }
                            else
                                Console.WriteLine("Esse ID de contato não existe!");

                            Utilidades.ExibirContatos(contatos);

                            break;
                        case 5:
                            continuarExecucao = false;
                            break;
                        default:
                            Console.WriteLine("Ação inválida!");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro de formatação: " + e.Message);
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
            if (string.IsNullOrWhiteSpace(telefone))
            {
                Console.WriteLine("O telefone não pode ser vazio.");
                return false;
            }
            if (telefone.Length < 10 || telefone.Length > 11 || telefone.Length != Utilidades.somenteNumeros(telefone).Length)
            {
                Console.WriteLine("Telefone inválido.");
                return false;
            }
            return true;
        }
    }
}
