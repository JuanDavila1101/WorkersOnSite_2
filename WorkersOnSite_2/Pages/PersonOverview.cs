using System;
using WorkersOnSite_2.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Linq;



namespace WorkersOnSite_2.Pages
{
  public partial class PersonOverview
  {
    [Parameter]
    // public string person
    //public Person Person { get; set; } = new Person();

    public string PersonID { get; set; }
    public Person Person { get; set; } = new Person();
    public IEnumerable<Person> Persons { get; set; }

    protected override Task OnInitializedAsync()
    {
      InitializePerson();
      Person = Persons.FirstOrDefault(p => p.PersonID == PersonID);
      return base.OnInitializedAsync();
    }

    private void InitializePerson()
    {

      var person1 = new Person
      {
        PersonID = "1",
        PersonFireBaseKey = "1",
        PersonFName = "Juan",
        PersonMInitial = 'I',
        PersonLName = "Davila",
        PersonBirthday = new DateTime(1976, 7, 13),
        Salary = 120000,
        PersonPhoneNumber1 = "910-546-1061",
        PersonPhoneNumber2 = "910-545-3304",
        _PersonType = PersonType.Manager
      };

      var person2 = new Person
      {
        PersonID = "2",
        PersonFireBaseKey = "2",
        PersonFName = "Danielle",
        PersonMInitial = 'I',
        PersonLName = "Davila",
        PersonBirthday = new DateTime(1975, 10, 4),
        Salary = 120000,
        PersonPhoneNumber1 = "910-543-3304",
        PersonPhoneNumber2 = "910-546-1061",
        _PersonType = PersonType.Employee
      };

      Persons = new List<Person> { person1, person2 };
    }

   


  }
}
