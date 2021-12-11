namespace WorkersOnSite_2.Shared
{
  public enum PersonType
  {
    Manager,
    TeamLead,
    Employee,
    Customer
  }

  //enum PersonType
  //{
  //  Manager (value: "MNG", Description:"Mangaer"),
  //  TeamLead,
  //  Employee,
  //  Customer
  //}


  //public sealed class PersonType : TypeSafeEnum<string, PersonType>
  //{
  //  private PersonType(string representation, string description)
  //  {
  //    Initialize(this, representation, description);
  //  }

  //  public static implicit operator PersonType(string, value) => GetEnumeration(_staticLookupTable, value);

  //  public static readonly PersonType Manager = new PersonType("MNG", "Manager");


  //}


}
