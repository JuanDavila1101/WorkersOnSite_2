using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public interface IPersonService
  {
    Task<IEnumerable<Person>> GetAllPersons();
    Task<Person> GetPersonByID(string personID);
    //Person GetPersonByID(string personID);
    Task<Person> AddPerson(Person person);
    Task<Person> UpdatePerson(Person person);
    Task<bool> DeletePerson(string personID);
  }
}