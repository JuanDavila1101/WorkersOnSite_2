using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2_API.Model
{
  public interface IPersonRepository
  {
    IEnumerable<Person> GetAllPersons();
    Task<Person> GetPersonByID(string personID);
    Task<Person> AddPerson(Person person);
    Task<Person> UpdatePerson(Person person);
    void DeletePerson(string personID);
    //Person GetPersonByID(string personID);
  }
}