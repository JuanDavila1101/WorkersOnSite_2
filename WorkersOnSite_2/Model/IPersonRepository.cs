using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public interface IPersonRepository
  {
    IEnumerable<Person> GetAllPersons();
    Task<Person> GetPersonByID(string personID);
  }
}