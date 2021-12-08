using System;
using System.Collections.Generic;

namespace WorkersOnSite_2.Shared
{
  class Team
  {
    public Guid         TeamID       { get; set; }
    public string       TeamName     { get; set; }
    public string       TeamLocation { get; set; }
    public string       TeamNumber   { get; set; }
    public List<Person> TeamWorkers  { get; set; }
  }
}
