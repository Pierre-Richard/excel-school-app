using System;
using excel_school_app.Models;
using Microsoft.EntityFrameworkCore;

namespace excel_school_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassSubject> ClassSubject { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<ParentTeacher> ParentTeacher { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}
