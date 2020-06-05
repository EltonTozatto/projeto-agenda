using System.Text;

namespace projeto_agenda.Entidades
{
    class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Contato() { }

        public Contato(string nome, string endereco, string telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return Id + "- Nome: " + Nome;
        }
    }
}
