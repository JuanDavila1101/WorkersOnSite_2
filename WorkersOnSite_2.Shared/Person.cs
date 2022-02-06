using System;
using System.ComponentModel.DataAnnotations;

namespace WorkersOnSite_2.Shared
{
  public class Person
  {
    public string     PersonID           { get; set; }
    public string     PersonFireBaseKey  { get; set; }
    public string     PersonFName        { get; set; }
    //[Required]
    //[StringLength(50, ErrorMessage = "The first name is to long.")]

    public char       PersonMInitial     { get; set; }
    public string     PersonLName        { get; set; }
    //[Required]
    //[StringLength(50, ErrorMessage = "The last name is to long.")]
    public string     PersonSSN          { get; set; }
    public DateTime   PersonBirthday     { get; set; }
    public int        Salary             { get; set; }
    public string     PersonPhoneNumber1 { get; set; }
    //[Required]
    //[Phone]
    public string     PersonPhoneNumber2 { get; set; }
    //[Phone]
    public PersonType _PersonType        { get; set; }
    public string     TeamID             { get; set; }
  }
}
