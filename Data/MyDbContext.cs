using Microsoft.EntityFrameworkCore;

namespace Back_End_Employee.Data
{
    // praticar o mecanismo de herança com a superclasse DbContext
    public class MyDbContext : DbContext
{
    // definir o construtor para fazer a referencia direta a superclasse DbContext e suas propriedades 
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    // fazer referencia ao elemento logico para a manipulação da table Departament
    public DbSet<Entities.Departament> Departament { get; set; }

    // fazer referencia ao elemento logico para a manipulação da table Employee
    public DbSet<Entities.Employee> Employee { get; set; }

    // fazer referencia ao elemento logico para a manipulação da table Photo
    public DbSet<Entities.Photo> Photo { get; set; }

    // fazer referencia ao elemento logico para a manipulação da table ViaCep
    public DbSet<Entities.ViaCepAddress> ViaCepAddress  { get; set; }

    }
}

// 6ª passo criar o contexto de banco