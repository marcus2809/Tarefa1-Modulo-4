namespace TarefaAula3.Core
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }

        public List<string> Validations { get; set; }
        public bool IsValid { get; set; }

        public Pessoa(string nome, string cidade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cidade = cidade;
            Validations = new List<string>();
            Validate();
        }

        public Pessoa(Guid id, string nome, string cidade)
        {
            Id = id;
            Nome = nome;
            Cidade = cidade;
            Validations = new List<string>();
            Validate();
        }

        public Pessoa()
        {
            Validations = new List<string>();
            IsValid = true;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                Validations.Add($"{nameof(Nome)} não pode ser nulo");
            }

            if (string.IsNullOrWhiteSpace(Cidade))
            {
                Validations.Add($"{nameof(Cidade)} não pode ser nulo");
            }

            IsValid = !Validations.Any();
        }
    }
}