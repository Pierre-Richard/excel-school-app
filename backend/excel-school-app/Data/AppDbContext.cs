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
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Absence> Absence { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var passwordHash = "$2a$11$kbyrwUIt/zQBYxL./q5sResUMegZ.Bet2Ug4vbzHYcmRJp.J8GCa";
            
            modelBuilder.Entity<ClassSubject>()
            .HasKey(cs => new { cs.ClassId, cs.SubjectId });

            modelBuilder.Entity<ParentTeacher>()
            .HasKey(cs => new { cs.ParentId, cs.TeacherId });

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 2,
                    FirstName = "Pierre",
                    LastName = "Mayer",
                    PasswordHash = passwordHash,
                    Email = "mayer_alexandre@yahoo.fr",
                    Role = Enums.UserRole.Admin,
                    CreatedAt = new DateTime(2026, 4, 11, 0, 0, 0, DateTimeKind.Utc)

                }
            );

            modelBuilder.Entity<Student>()
              .HasOne(s => s.User)   // Student a un User
              .WithMany()               // User peut avoir plusieurs Students
              .HasForeignKey(s => s.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
              .HasOne(s => s.Student)   // Une note appartient à 1 student
              .WithMany()              // Un student peut avoir plusieurs notes
              .HasForeignKey(s => s.StudentId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
              .HasOne(s => s.Teacher)   // Un prof appartient à 1 student
              .WithMany()              // Un prof peut avoir plusieurs notes
              .HasForeignKey(s => s.TeacherId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
              .ToTable(t =>
                t.HasCheckConstraint(
                   "CK_Grade_Value", "\"Value\" >= 0 AND \"Value\" <= 20"
                )
              );
              
             modelBuilder.Entity<Absence>()
              .HasOne(s => s.Student)   // Une absence appartient à 1 student
              .WithMany()              // Un eleve peut avoir plusieurs absence
              .HasForeignKey(s => s.StudentId)
              .OnDelete(DeleteBehavior.Cascade);
                
                
        }

    }
    
    
}
