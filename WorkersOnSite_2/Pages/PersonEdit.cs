using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using WorkersOnSite_2.Model;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Pages
{
  public partial class PersonEdit
  {
    [Inject]
    public IPersonService PersonService { get; set; }
    [Inject]
    public ITeamService TeamService { get; set; }


    [Parameter]
    public string PersonID { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    public Person Person { get; set; } = new Person();
    public List<Team> Teams { get; set; } = new List<Team>();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    private ElementReference personLastName;

    //protected async override Task OnAfterRenderAsync(bool firstRender)
    //{
    //  await personLastName.FocusAsync();
    //}

    protected override async Task OnInitializedAsync()
    {
      Saved = false;
      Teams = (await TeamService.GetAllTeams()).ToList();

      //BigInteger.TryParse(PersonID, out var personID);

      if (string.IsNullOrEmpty(PersonID))
      {
        Person = new Person
        {
          PersonFName = "Joe",
          PersonMInitial = 'I',
          PersonLName = "Doe",
          PersonSSN = "000-00-0000",
          PersonBirthday = new DateTime(1950, 1, 1),
          Salary = 1000,
          PersonPhoneNumber1 = "615-000-0000",
          PersonPhoneNumber2 = "910-000-0000",
          _PersonType = PersonType.Employee,
          TeamID = ""
        };
      }
      else
      {
        Person = await PersonService.GetPersonByID(PersonID);
        //Person = PersonService.GetPersonByID(PersonID);

        // Persons = await PersonService.GetAllPersons();
        // Person = Persons.FirstOrDefault(p => p.PersonID == PersonID);




      }

    }

    protected async Task HandleValidSubmit()
    {
      Saved = false;
      Person.PersonID = PersonID;
      
      if (string.IsNullOrEmpty(Person.PersonID))
      {
        var addedPerson = await PersonService.AddPerson(Person);
        if(addedPerson != null)
        {
          StatusClass = "alert-success";
          Message = "The new person was added successfully.";
          Saved = true;
        }
        else
        {
          StatusClass = "alert-danger";
          Message = $"Something went wrong while trying to add the new person. {Environment.NewLine}Please try again.";
        }
      }
      else
      {
        //await PersonService.UpdatePerson(Person);
        await PersonService.UpdatePerson(Person);
        StatusClass = "alert-success";
        Message = "The Person was updated successfully.";
        Saved = true;

      }

    }

    public void HandleInvalidSubmit()
    {
      StatusClass = "alert-danger";
      Message = $"There is some type of violation error. {Environment.NewLine}Please try again.";
    }

    protected async Task DeletePerson()
    {
      await PersonService.DeletePerson(Person.PersonID);
      StatusClass = "alert-success";
      Message = "Deleted the person successfully.";
      Saved = true;
    }

    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo("/personoverview");
    }



  }
}
