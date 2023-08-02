using CadastroClientesAPI.Entities;

namespace CadastroClientesAPI.Persistence
{
    public class ClienteDbContext
    {
        public List<Clientes> Clientes { get; set; }
        public List<Categoria> Categoria { get; set; }

        public ClienteDbContext()
        {
            Clientes = new List<Clientes>();
            Categoria = new List<Categoria>();
        }
    }
}
