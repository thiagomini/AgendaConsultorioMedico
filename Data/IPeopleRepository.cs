using System.Collections.Generic;

namespace AgendaConsultorioMedico.Data
{
    public interface IPeopleRepository
    {
         bool SaveChanges();

         IEnumerable<Person> GetAllPeople();

         Person GetPersonById(int id);

         void CreatePerson(Person newPerson, bool save=true);

         void UpdatePerson(Person updatedPerson, bool save=true);

         void DeletePerson(Person targetPerson, bool save=true);
    }
}