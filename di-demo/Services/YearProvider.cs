using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace di_demo.Services
{
    public interface IYearProvider {
        int CurrentYear { get; }
    }
    public class YearProvider : IYearProvider
    {
        public int CurrentYear => DateTime.Now.Year;
    }
}