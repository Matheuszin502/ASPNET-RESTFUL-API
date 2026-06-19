using RestWithASPNET.Model;

namespace RestWithASPNET.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
