using apiwithpomelo.Entities;

namespace apiwithpomelo.Repositories 
{
    internal class ClienteRepository : Repository<TbCliente>, IRepository<TbCliente>
    {
        public ClienteRepository(mysql_17753_devmonkContext context) : base(context)
        {
        }
    }
}