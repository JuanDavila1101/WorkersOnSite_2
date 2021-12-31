using System;
using System.Collections.Generic;

namespace WorkersOnSite_2.Shared
{
  public class Team
  {
    public string       TeamID            { get; set; }
    public string       TeamName          { get; set; }
    public string       TeamLocation      { get; set; }
    public string       TeamPhoneNumber   { get; set; }
    public List<Person> TeamWorkers       { get; set; } = new List<Person>();
  }
}
