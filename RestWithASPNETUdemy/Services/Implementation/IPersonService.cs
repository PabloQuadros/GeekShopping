﻿using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public interface IPersonService
    {
        Person Create (Person person);
        Person FindByID (int id);
        List<Person> FindAll ();
        Person Update (Person person);
        void Delete (int id);
    }
}