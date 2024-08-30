using Microsoft.EntityFrameworkCore;
using VuDinhLam_1721030651.Database.Models;

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}