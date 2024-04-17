using JalaTodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JalaTodoApi.Database;

public class TodoDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}
