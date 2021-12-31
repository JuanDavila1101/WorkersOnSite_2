﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2_API.Model
{
  public interface ISiteRepository
  {
    IEnumerable<Site> GetAllSites();
    Task<Site> GetSiteByID(string siteID);
  }
}