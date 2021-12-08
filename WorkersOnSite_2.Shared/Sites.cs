using System;

namespace WorkersOnSite_2.Shared
{
  class Sites
  {
    public Guid     SitesID         { get; set; }
    public string   SiteName        { get; set; }
    public string   SiteLocation    { get; set; }
    public string   SiteNumber      { get; set; }
    public DateTime SiteStartTime   { get; set; }
    public bool     SiteIsCompleted { get; set; }
    public Guid     TeamID          { get; set; }
    public Team     TeamAssigned    { get; set; }
    public Guid     PersonID        { get; set; }
    public Person   SitePOCPerson   { get; set; }
  }
}
