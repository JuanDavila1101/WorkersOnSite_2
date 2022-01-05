using System;

namespace WorkersOnSite_2.Shared
{
  public class Person
  {
    public string     PersonID           { get; set; }
    public string     PersonFireBaseKey  { get; set; }
    public string     PersonFName        { get; set; }
    public char       PersonMInitial     { get; set; }
    public string     PersonLName        { get; set; }
    public string     PersonSSN          { get; set; }
    public DateTime   PersonBirthday     { get; set; }
    public int        Salary             { get; set; }
    public string     PersonPhoneNumber1 { get; set; }
    public string     PersonPhoneNumber2 { get; set; }
    public PersonType _PersonType        { get; set; }
    public string     TeamID             { get; set; }
  }
}
