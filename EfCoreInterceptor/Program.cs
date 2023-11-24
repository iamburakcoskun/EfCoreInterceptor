// See https://aka.ms/new-console-template for more information
using EfCoreInterceptor.DbContext;

Console.WriteLine("Hello, World!");

MyDbContext dbContext = new MyDbContext();

dbContext.Students.AddAsync(new EfCoreInterceptor.Entities.Student()
{
    FirstName="Burak",
    LastName="Coskun"
});

dbContext.SaveChanges();

Console.WriteLine("Done");
Console.ReadLine();
