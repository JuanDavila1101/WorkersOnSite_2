using System;

namespace WorkersOnSite_2.Shared
{
  public class Site
  {
    public string   SiteID          { get; set; }
    public string   SiteName        { get; set; }
    public string   SiteLocation    { get; set; }
    public string   SiteNumber      { get; set; }
    public DateTime SiteStartTime   { get; set; }
    public bool     SiteIsCompleted { get; set; }
    public string   SiteTeamID      { get; set; }
    public Team     TeamAssigned    { get; set; }
    public string   SitePersonID    { get; set; }
    public Person   SitePOCPerson   { get; set; }
  }
}
