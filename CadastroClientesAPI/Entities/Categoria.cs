namespace CadastroClientesAPI.Entities
{
    public class Categoria
    {
        public Categoria() 
        {
            IsDeletado = false;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool IsDeletado { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }

        public void Delete()
        {
            IsDeletado = true;
        }
    }
}
