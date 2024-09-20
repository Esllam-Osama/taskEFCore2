using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.P01__StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.P01__StudentSystem.Data
{
  internal class ApplicationDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Homework> homeworks { get; set; }
    public DbSet<StudentCourse> studentCourses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer("Server=.;Initial Catalog=StudentSystemContext; Integrated Security=True; TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      //student
      modelBuilder.Entity<Student>(e =>e.Property(p => p.Name).HasColumnType("nvarchar(100)").IsUnicode(true));
      modelBuilder.Entity<Student>(e =>e.Property(p => p.PhoneNumber).HasColumnType("varchar(10)").IsUnicode(false).IsRequired(false).HasMaxLength(10));
      modelBuilder.Entity<Student>(e =>e.Property(p => p.RegisteredOn).HasColumnType("datetime2"));
      modelBuilder.Entity<Student>(e =>e.Property(p => p.Birthday).IsRequired(false));
      //Course
      modelBuilder.Entity<Course>().Property(e => e.Name).HasColumnType("varchar(80)").IsUnicode(false);
      modelBuilder.Entity<Course>().Property(e => e.Description).IsRequired(false).HasColumnType("nvarchar").IsUnicode(true);
      //Resource
      modelBuilder.Entity<Resource>().Property(e=>e.Name).HasColumnType("nvarchar").IsUnicode(true);
      modelBuilder.Entity<Resource>().Property(e=>e.Url).IsUnicode(false);
      //relations...
      //student and cources
      modelBuilder.Entity<Student>()
        .HasMany(e => e.Courses)
        .WithMany(e => e.Students);
      modelBuilder.Entity<Course>()
        .HasMany(e => e.Students)
        .WithMany(e => e.Courses);
      modelBuilder.Entity<StudentCourse>()
        .HasKey(e => new {e.StudentId , e.CourseId});
      //student & homework
      modelBuilder.Entity<Student>()
        .HasMany(e => e.Homeworks)
        .WithOne(e => e.Student)
        .HasForeignKey(e => e.StudentId);
      //Course & resource
      modelBuilder.Entity<Course>()
        .HasMany(e => e.Resources)
        .WithOne(e => e.Course)
        .HasForeignKey(e => e.CourseId);
      //Course & homework
      modelBuilder.Entity<Course>()
        .HasMany(e => e.Homeworks)
        .WithOne(e => e.Course)
        .HasForeignKey(e => e.CourseId);
    }
  }
}
