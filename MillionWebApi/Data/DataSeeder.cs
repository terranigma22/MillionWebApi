using System;
using Microsoft.EntityFrameworkCore;
using MillionWebApi.Domain;

namespace MillionWebApi.Data;

public class DataSeeder
{
    private readonly DataContext _context;
    private static readonly string[] names = { "Alexis", "Juan", "Yiliana", "Sofia", "Pedro", "Juana", "Maria", "Adrian", "Pablo", "Marta" };

    public DataSeeder(DataContext context)
    {
        _context = context;
    }

    public void InitialiseDataContext()
    {
        try
        {
            if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Seed()
    {
        SeedPeoples();
    }

    private void SeedPeoples()
    {
        int count = _context.Peoples.Count();
        if (!_context.Peoples.Any())
        {
            List<People> peoples = new List<People>();
            for (int i = 0; i < 100000; i++)
            {
                peoples.Add(new People
                {
                    Name = names[Random.Shared.Next(names.Length)],
                    Age = Random.Shared.Next(8, 70)
                });
            }

            _context.Peoples.AddRange(peoples);
            _context.SaveChanges();
        }
    }
}
