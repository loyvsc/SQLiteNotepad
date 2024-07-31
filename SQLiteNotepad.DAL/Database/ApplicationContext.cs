using Microsoft.EntityFrameworkCore;
using SQLiteNotepad.ApplicationCore.Primitives.Models;

namespace SQLiteNotepad.DAL.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=database.dat");
        }
    }
}