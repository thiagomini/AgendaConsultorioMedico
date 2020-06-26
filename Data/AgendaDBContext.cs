using Microsoft.EntityFrameworkCore;

namespace AgendaConsultorioMedico.Data

{
    public class AgendaDBContext : DbContext
    {
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options): base(options)
        {

        }

        // Tabelas
        public DbSet<Person> People { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}