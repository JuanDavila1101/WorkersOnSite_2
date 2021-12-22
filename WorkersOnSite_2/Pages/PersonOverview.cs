using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Model;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Pages
{
  public partial class PersonOverview : ComponentBase
  {
    [Inject]
    public IPersonService PersonService { get; set; }

    [Parameter]
    // public string person
    //public Person Person { get; set; } = new Person();

    public string PersonID { get; set; }
    public Person Person { get; set; } = new Person();
    public IEnumerable<Person> Persons { get; set; }


    protected async override Task OnInitializedAsync()
    {
      Persons = await PersonService.GetAllPersons();
      Person = Persons.FirstOrDefault(p => p.PersonID == PersonID);
      
      await base.OnInitializedAsync();

      return;
    }

    //public PersonOverview(IPersonService personRepo)
    //{
    //  _personRepo = personRepo;

    //  Persons = _personRepo.GetAllPersons();

    //  Person = Persons.FirstOrDefault(p => p.PersonID == PersonID);

    //}

    //private void InitializePerson()
    //{

    //  var person1 = new Person
    //  {
    //    PersonID = "1",
    //    PersonFireBaseKey = "1",
    //    PersonFName = "Juan",
    //    PersonMInitial = 'I',
    //    PersonLName = "Davila",
    //    PersonBirthday = new DateTime(1976, 7, 13),
    //    Salary = 120000,
    //    PersonPhoneNumber1 = "910-546-1061",
    //    PersonPhoneNumber2 = "910-545-3304",
    //    _PersonType = PersonType.Manager
    //  };

    //  var person2 = new Person
    //  {
    //    PersonID = "2",
    //    PersonFireBaseKey = "2",
    //    PersonFName = "Danielle",
    //    PersonMInitial = 'I',
    //    PersonLName = "Davila",
    //    PersonBirthday = new DateTime(1975, 10, 4),
    //    Salary = 120000,
    //    PersonPhoneNumber1 = "910-543-3304",
    //    PersonPhoneNumber2 = "910-546-1061",
    //    _PersonType = PersonType.Employee
    //  };

    //  Persons = new List<Person> { person1, person2 };
    //}

   


  }
}
