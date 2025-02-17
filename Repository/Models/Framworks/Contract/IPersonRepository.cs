using Repository.Models.DomainModels;

namespace Repository.Models.Framworks.Contract
{
    public interface IPersonRepository
    {
        Task<List<Person>> Select();
        Task Insert (Person person);
       Task Delete (Person person);
       Task Edit (Person person);
        Task<Person> Details(Guid? Id);
    }
}
