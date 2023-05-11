using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class AttendanceContext : DbContext
{
    public AttendanceContext()
    {
    }

    public AttendanceContext(DbContextOptions<AttendanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MonthlyAttendance> MonthlyAttendances { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MonthlyAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Monthly___20D6A968B8C55902");

            entity.ToTable("Monthly_Attendance");

            entity.Property(e => e.AttendanceId)
                .ValueGeneratedNever()
                .HasColumnName("attendance_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.MonthlyAttendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Monthly_A__stude__3E52440B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__2A33069AC4942C07");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Parent1Id).HasColumnName("parent1_id");
            entity.Property(e => e.Parent2Id).HasColumnName("parent2_id");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("student_name");

            entity.HasOne(d => d.Parent1).WithMany(p => p.StudentParent1s)
                .HasForeignKey(d => d.Parent1Id)
                .HasConstraintName("FK__Student__parent1__3A81B327");

            entity.HasOne(d => d.Parent2).WithMany(p => p.StudentParent2s)
                .HasForeignKey(d => d.Parent2Id)
                .HasConstraintName("FK__Student__parent2__3B75D760");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User Acc__B9BE370F12055ED5");

            entity.ToTable("User Account");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Role");

            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Role__user___37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
