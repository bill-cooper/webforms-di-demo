using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace di_demo.Tests.Server
{

  /// <summary>
  /// The events from a Page that can be triggered within a TestablePage
  /// </summary>
  public enum WebFormEvent
  {
    None = 0,
    Init,
    Load,
    PreRender,
    Unload
  }

}
