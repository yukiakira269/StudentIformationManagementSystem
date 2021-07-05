using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace SIMS.Models
{
    public partial class SIMSContext : DbContext
    {
        public SIMSContext()
        {
        }

        public SIMSContext(DbContextOptions<SIMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassDetail> ClassDetails { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = builder.Build();
                //optionsBuilder.UseSqlServer("Name=ConnectionStrings:SIMS");
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SIMS"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("adminID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("classes");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("classID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("courseID");

                entity.Property(e => e.NumOfStudent).HasColumnName("numOfStudent");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("teacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_classes_courses");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_classes_teachers");
            });

            modelBuilder.Entity<ClassDetail>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.StudentId });

                entity.ToTable("classDetails");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("classID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassDetails)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_classDetails_classes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassDetails)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_classDetails_students");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("courseID");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.TeacherId });

                entity.ToTable("feedbacks");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("teacherID");

                entity.Property(e => e.Feedback1)
                    .HasColumnType("text")
                    .HasColumnName("feedback");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_feedbacks_students");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_feedbacks_teachers");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_schedules");

                entity.ToTable("grades");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.Component)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("component");

                entity.Property(e => e.ComponentGrade).HasColumnName("componentGrade");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("courseID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_grades_courses");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_parent");

                entity.ToTable("parents");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ParentsPhone)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("parentsPhone");

                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_students_grades");

                entity.HasOne(d => d.Student1)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_students_parents");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("teacherID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Faculty)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("faculty");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
