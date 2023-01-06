using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for(int i = 0; i < 10;)
            {
                Person person = MockPerson(i);
                people.Add(new Person());
            }
            return people;
        }



        public Person FindByID(int id)
        {
            return new Person
            {
                Id = 1,
                FirstName= "Test",
                LastName= "Test",
                Address=   "Test",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Test"+i.ToString(),
                LastName = "Test",
                Address = "Test",
                Gender = "Male"
            };
        }
    }
}
