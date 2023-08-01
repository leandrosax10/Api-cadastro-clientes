namespace CadastroClientesAPI.Entities
{
    public class Clientes
    {
        public Clientes()
        {
            IsDeletado = false;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set;}
        public string Cpf { get; set;}
        public DateTime DataNascimento { get; set; }
        public bool IsDeletado { get; set; }

        public void Update(string nome, string endereco, string email, 
            string telefone, string cpf, DateTime dataNascimento) 
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;     
        }

        public void Delete() 
        {
            IsDeletado = true;
        }


    }
}
