using Microsoft.EntityFrameworkCore;
using projeto_agenda.Database;
using projeto_agenda.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace projeto_agenda.Repositorios
{
    class ContatoDAO
    {
        public void CriarBanco()
        {
            using (var context = new AgendaContext())
            {
                Console.WriteLine("Verificando banco de dados.");
                if (!context.Database.CanConnect())
                {
                    Console.WriteLine("Criando banco de dados.");
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    context.Database.Migrate();
                    sw.Stop();
                    Console.WriteLine("Criado com sucesso em: " + sw.Elapsed.ToString(@"mm\:ss"));
                }
                Console.WriteLine("Banco de dados verificado com sucesso.");
                Utilidades.LimparTela();
            }
        }

        public List<Contato> Inserir(Contato contato)
        {
            using (var context = new AgendaContext())
            {
                context.Contatos.Add(contato);
                context.SaveChanges();
                Console.WriteLine("Contato inserido!");
                return context.Contatos.OrderBy(x => x.Nome).ToList();
            }
        }

        public List<Contato> RecuperarTodos()
        {
            using (var context = new AgendaContext())
            {
                return context.Contatos.OrderBy(x => x.Nome).ToList();
            }
        }

        public List<Contato> Alterar(Contato contato)
        {
            using (var context = new AgendaContext())
            {
                context.Contatos.Update(contato);
                context.SaveChanges();
                Console.WriteLine("Contato Alterado!");
                return context.Contatos.OrderBy(x => x.Nome).ToList();
            }
        }

        public List<Contato> Excluir(Contato contato)
        {
            using (var context = new AgendaContext())
            {
                context.Contatos.Remove(contato);
                context.SaveChanges();
                Console.WriteLine("Contato excluído!");
                return context.Contatos.OrderBy(x => x.Nome).ToList();
            }
        }
    }
}
