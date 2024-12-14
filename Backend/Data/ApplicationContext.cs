using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
    {
    }
    public DbSet<Author> Authors {get; set;}
    public DbSet<Producer> Producers {get; set;}
    public DbSet<Series> Series {get; set;}
    public DbSet<Character> Characters {get; set;}
}
