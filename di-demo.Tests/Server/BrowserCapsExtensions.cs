using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace di_demo.Tests.Server
{
    internal static class BrowserCapsExtensions
  {

    internal static void SetItems(this HttpBrowserCapabilities caps, IDictionary items)
    {

      var theField = typeof(HttpCapabilitiesBase).GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
      theField.SetValue(caps, items);

      var browserCaps = new HttpBrowserCapabilities();

    }

  }

}
