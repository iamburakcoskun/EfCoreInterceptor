using EfCoreInterceptor.DbContext;
using EfCoreInterceptor.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

MyDbContext dbx = new MyDbContext();

//dbx.Students.AddAsync(new Student()
//{
//    FirstName="Burak",
//    LastName="Coskun"
//});

var entity= dbx.Students.FirstOrDefault(x => x.Id == 1);

entity.FirstName = "Fatma";
entity.LastName = "Coşkun";

dbx.SaveChanges();

Console.WriteLine("Done");
Console.ReadLine();
