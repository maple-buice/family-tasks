using family_tasks.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace family_tasks.Repositories;

public class TaskContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<FamilyTask> Tasks { get; set; }
    public DbSet<TaskOccurrence> TaskOccurrences { get; set; }
    public DbSet<TaskSchedule> TaskSchedules { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Tasks");
    }
}