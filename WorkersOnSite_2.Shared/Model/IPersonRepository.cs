using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2_API.Controllers
{
  public interface IPersonRepository
  {
    IEnumerable<Person> GetAllPersons();
    Task<Person> GetPersonByID(string personID);
  }
}