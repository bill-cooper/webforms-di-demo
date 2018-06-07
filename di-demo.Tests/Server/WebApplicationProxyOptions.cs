using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace di_demo.Tests.Server
{
  public class WebApplicationProxyOptions
  {

    public bool SkipCrawl { get; set; } = true;

    public bool SkipPrecompile { get; set; } = true;

    /// <summary>
    /// Location of the website on disk, overrides the auto-locator
    /// </summary>
    public string WebFolder { get; set; }


  }

}
