﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace projeto_agenda.Entidades
{
    static class Utilidades
    {
        public static void ExibirContatos(List<Contato> contatos)
        {
            Console.Write("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("MINHA AGENDA");
            if (contatos.Count > 0)
            {
                contatos = contatos.OrderBy(x => x.Nome).ToList();
                Console.WriteLine(contatos.Count + " contato(s) encontrado(s).");
                for (int i = 0; i < contatos.Count; i++)
                    Console.WriteLine(i + 1 + "-" + contatos[i].Nome);
            }
            else
                Console.WriteLine("0 contato(s) encontrado(s).");

            Console.WriteLine();
        }

        public static string FormatarTelefone(string telefone)
        {
            try
            {
                telefone = telefone.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
                if (telefone.Length == 10)
                    telefone = Convert.ToUInt64(telefone).ToString(@"(00)0000-0000");
                else
                    telefone = Convert.ToUInt64(telefone).ToString(@"(00)00000-0000");
            }
            catch (Exception)
            {
                telefone = "(  )    -";
            }

            return telefone;
        }

        public static string somenteNumeros(string toNormalize)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        }
    }
}
