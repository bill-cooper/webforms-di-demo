using System;
using di_demo.Data.Entity;

namespace di_demo.Data
{
    public class EmployeeRepository : IPersonRepository
    {
        public Person GetPerson(int id)
        {
            return new Person {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 2, 18)
            };
        }
    }
}