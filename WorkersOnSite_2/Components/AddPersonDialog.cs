using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Model;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Components
{
  public partial class AddPersonDialog
  {
    public Person Person { get; set; } = new Person
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

    [Inject]
    public IPersonService PersonService { get; set; }

    public bool ShowDialog { get; set; } // this is a bootstrap component

    [Parameter]
    public EventCallback<bool> CloseEventCallback { get; set; }


    // Adding a show method
    public void Show()
    {
      ResetDialog();
      ShowDialog = true;

      // Built in method
      // StateHasChanged this is to ask Blazor to redraw the component/ to refresh the UI

      StateHasChanged();
    }

    public void Close()
    {
      ShowDialog = false;
      StateHasChanged();
    }

    private void ResetDialog()
    {
      // Resetting the Person to the default values
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

    public async Task HandleValidationSubmit()
    {
      await PersonService.AddPerson(Person);
      ShowDialog = false;

      await CloseEventCallback.InvokeAsync(true);
      StateHasChanged();
    }
  }
}
