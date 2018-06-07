using di_demo.Services;
using System;
using System.Web.UI;

namespace di_demo
{
    public partial class SiteMaster : MasterPage
    {
        protected readonly IYearProvider YearProvider;
        public SiteMaster(IYearProvider yearProvider)
        {
            YearProvider = yearProvider;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}