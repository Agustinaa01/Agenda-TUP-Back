using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data
{
    public class AgendaApiContext: DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Contact> Contacts { get; set; }

        public AgendaApiContext(DbContextOptions<AgendaApiContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Estamos sobreescribiendo la clase padre
        {
            User Erica = new User()
            {
                Id = 1,
                UserName = "Erica",
                LastName = "Lechuga",
                Password = "123abc",
                Email = "ericaGomez@gmail.com",
                Rol = Rol.Admin,

            };
            User Dana = new User()
            {
                Id = 2,
                UserName = "Dana",
                LastName = "Molina",
                Password = "456def",
                Email = "danaMolina@gmail.com",
                Rol = Rol.Admin,
    
            };
            Contact Juan = new Contact()
            {
                Id = 1,
                Name = "Juan",
                LastName = "Castillo",
                CelularNumber = "+543436789513",
                Email = "Hijo@gmail.com",
                UserId = Dana.Id,
                state = State.Active
            };
            Contact Maria = new Contact()
            {
                Id = 2,
                Name = "Maria",
                CelularNumber = "+54341345367",
                UserId = Erica.Id,
                state = State.Active
            };
            Contact Daniela = new Contact()
            {
                Id = 3,
                Name = "Daniela",
                LastName = "Romero",
                CelularNumber = "+54114567789",
                UserId = Erica.Id,
                state = State.Active
            };
            Contact Esmeralda = new Contact()
            {
                Id = 4,
                Name = "Esmeralda",
                LastName = "Cruz",
                CelularNumber = "+54341234975",
                Email = "Amigo@gmail.com",
                UserId = Dana.Id,
                state = State.Active

            };
            modelBuilder.Entity<Contact>().HasData(Esmeralda, Daniela, Maria, Juan);
            modelBuilder.Entity<User>().HasData(Dana, Erica);
            modelBuilder.Entity<User>().HasMany(u => u.Contact).WithOne(c => c.User); //Tabla de 1-N        
            base.OnModelCreating(modelBuilder);
        }
    }
}
