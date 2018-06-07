using di_demo.Data.Entity;
using System.Collections.Generic;

namespace di_demo.Data
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
    }
}