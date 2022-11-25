using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data
{
    public class AgendaApiContext: DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public AgendaApiContext(DbContextOptions<AgendaApiContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Estamos sobreescribiendo la clase padre
        {
            Group Familia = new Group()
            {
                Id = 1,
                GroupName = "Familia",
            };
            Group Amigos = new Group()
            {
                Id = 2,
                GroupName = "Amigos",
            };
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
    
            };
            Contact Juan = new Contact()
            {
                Id = 1,
                Name = "Juan",
                LastName = "Castillo",
                CelularNumber = "+543436789513",
                TelephoneNumber= null,
                Alias = "Juanito",
                Email = "Hijo@gmail.com",
                UserId = Dana.Id,
                GroupId = Familia.Id,
            };
            Contact Maria = new Contact()
            {
                Id = 2,
                Name = "Maria",
                LastName = "Martinez",
                CelularNumber = "+54341345367",
                TelephoneNumber = null,
                Alias = "Mary",
                Email = null,
                UserId = Erica.Id,
                GroupId = Familia.Id,
            };
            Contact Daniela = new Contact()
            {
                Id = 3,
                Name = "Daniela",
                LastName = "Romero",
                CelularNumber = "+54114567789",
                TelephoneNumber = null,
                Alias = null,
                Email = null,
                UserId = Erica.Id,
                GroupId = Amigos.Id,

            };
            Contact Esmeralda = new Contact()
            {
                Id = 4,
                Name = "Esmeralda",
                LastName = "Cruz",
                CelularNumber = "+54341234975",
                TelephoneNumber = "4214587",
                Email = "Amigo@gmail.com",
                Alias = null,
                UserId = Dana.Id,
                GroupId = Amigos.Id,
            };

            modelBuilder.Entity<Contact>().HasData(Esmeralda, Daniela, Maria, Juan);
            modelBuilder.Entity<User>().HasData(Dana, Erica);
            modelBuilder.Entity<Group>().HasData(Familia, Amigos);
            modelBuilder.Entity<User>().HasMany(u => u.Contact).WithOne(c => c.User);
            modelBuilder.Entity<Group>().HasMany(u => u.Contact).WithOne(c => c.Group); //Tabla de 1-N        
            base.OnModelCreating(modelBuilder);
        }
    }
}
