using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseStudent> CourseStudent { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffHistory> StaffHistory { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentHistory> StudentHistory { get; set; }
        public virtual DbSet<VwAverageGrade> VwAverageGrade { get; set; }
        public virtual DbSet<VwGradeLastMonth> VwGradeLastMonth { get; set; }
        public virtual DbSet<VwGradesAndCourses> VwGradesAndCourses { get; set; }
        public virtual DbSet<VwLastMonthGrade> VwLastMonthGrade { get; set; }
        public virtual DbSet<VwMaxGrade> VwMaxGrade { get; set; }
        public virtual DbSet<VwMinGrade> VwMinGrade { get; set; }
        public virtual DbSet<VwStudentsbyClass> VwStudentsbyClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = ZANEFINA;Initial Catalog = SchoolDB;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .HasColumnName("ClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Staff1");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.Property(e => e.CourseStudentId).HasColumnName("CourseStudentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseStudent)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseStudent_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseStudent)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseStudent_Student");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Course");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Staff1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Student");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<StaffHistory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.History).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<StudentHistory>(entity =>
            {
                entity.Property(e => e.History).IsRequired();
            });

            modelBuilder.Entity<VwAverageGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAverageGrade");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwGradeLastMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwGradeLastMonth");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwGradesAndCourses>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwGradesAndCourses");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwLastMonthGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwLastMonthGrade");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwMaxGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwMaxGrade");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwMinGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwMinGrade");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VwStudentsbyClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwStudentsbyClass");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
