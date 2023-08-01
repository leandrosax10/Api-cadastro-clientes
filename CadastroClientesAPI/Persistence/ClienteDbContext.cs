using CadastroClientesAPI.Entities;

namespace CadastroClientesAPI.Persistence
{
    public class ClienteDbContext
    {
        public List<Clientes> Clientes { get; set; }

        public ClienteDbContext()
        {
            Clientes = new List<Clientes>();
        }
    }
}
