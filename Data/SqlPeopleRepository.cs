using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgendaConsultorioMedico.Data
{
    public class SqlPeopleRepository : IPeopleRepository
    {
        private readonly AgendaDBContext _context;

        public SqlPeopleRepository(AgendaDBContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person newPerson, bool save = true)
        {
            if (newPerson == null)
            {
                throw new ArgumentNullException(nameof(newPerson));
            }

            _context.People.Add(newPerson);

            if (save) SaveChanges();
        }

        public void DeletePerson(Person targetPerson, bool save = true)
        {
            if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            _context.People.Remove(targetPerson);

            // Salva automaticamente
            if(save) SaveChanges();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People
                .Include(p => p.Appointments)
                .ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.People
            .Include(p => p.Appointments)
            .FirstOrDefault(person => person.Id == id);
            
        }

        public bool SaveChanges()
        {
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public void UpdatePerson(Person updatedPerson, bool save = true)
        {
            // Sem implementação necessária ainda
            if (save) SaveChanges();
        }
    }
}