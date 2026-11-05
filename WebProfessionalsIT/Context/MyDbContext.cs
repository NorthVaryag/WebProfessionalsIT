using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microting.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebProfessionalsIT.Entities;

namespace WebProfessionalsIT.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<LevelSkill> LevelSkills { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<ResultEducation> ResultEducations { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tehnology> Tehnologies { get; set; }

    public virtual DbSet<TypeEducation> TypeEducations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public virtual DbSet<Verification> Verifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.200.13;uid=student;pwd=student;database=ProfessionalsIT", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.InstitutionName, "Educations_Institution_FK");

            entity.HasIndex(e => e.ResultEducation, "Educations_ResultEducation_FK");

            entity.HasIndex(e => e.TypeEducations, "Educations_TypeEducation_FK");

            entity.HasIndex(e => e.User, "Educations_Users_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.EndEducation).HasColumnName("end_education");
            entity.Property(e => e.InstitutionName)
                .HasColumnType("int(11)")
                .HasColumnName("institution_name");
            entity.Property(e => e.ResultEducation)
                .HasColumnType("int(11)")
                .HasColumnName("result_education");
            entity.Property(e => e.StartEducation).HasColumnName("start_education");
            entity.Property(e => e.TypeEducations)
                .HasColumnType("int(11)")
                .HasColumnName("type_educations");
            entity.Property(e => e.User).HasColumnType("int(11)");

            entity.HasOne(d => d.InstitutionNameNavigation).WithMany(p => p.Educations)
                .HasForeignKey(d => d.InstitutionName)
                .HasConstraintName("Educations_Institution_FK");

            entity.HasOne(d => d.ResultEducationNavigation).WithMany(p => p.Educations)
                .HasForeignKey(d => d.ResultEducation)
                .HasConstraintName("Educations_ResultEducation_FK");

            entity.HasOne(d => d.TypeEducationsNavigation).WithMany(p => p.Educations)
                .HasForeignKey(d => d.TypeEducations)
                .HasConstraintName("Educations_TypeEducation_FK");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Educations)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Educations_Users_FK");
        });

        modelBuilder.Entity<EmploymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("EmploymentType");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.NameType)
                .HasMaxLength(100)
                .HasColumnName("name_type");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Experience");

            entity.HasIndex(e => e.EmploymentType, "Experience_EmploymentType_FK");

            entity.HasIndex(e => e.User, "Experience_Users_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .HasColumnName("company");
            entity.Property(e => e.EmploymentType)
                .HasColumnType("int(11)")
                .HasColumnName("employment_type");
            entity.Property(e => e.EndWork).HasColumnName("end_work");
            entity.Property(e => e.PositionJob)
                .HasMaxLength(100)
                .HasColumnName("position_job");
            entity.Property(e => e.StartWork).HasColumnName("start_work");
            entity.Property(e => e.User)
                .HasColumnType("int(11)")
                .HasColumnName("user");

            entity.HasOne(d => d.EmploymentTypeNavigation).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.EmploymentType)
                .HasConstraintName("Experience_EmploymentType_FK");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Experience_Users_FK");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Institution");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(100)
                .HasColumnName("institution_name");
        });

        modelBuilder.Entity<LevelSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("LevelSkill");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Level)
                .HasMaxLength(100)
                .HasColumnName("level");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Rating");

            entity.HasIndex(e => e.User, "Rating_Users_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Mark)
                .HasColumnType("int(11)")
                .HasColumnName("mark");
            entity.Property(e => e.User)
                .HasColumnType("int(11)")
                .HasColumnName("user");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Rating_Users_FK");
        });

        modelBuilder.Entity<ResultEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ResultEducation");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Result)
                .HasMaxLength(75)
                .HasColumnName("result");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Level, "Skills_LevelSkill_FK");

            entity.HasIndex(e => e.Tehnology, "Skills_Tehnology_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Level)
                .HasColumnType("int(11)")
                .HasColumnName("level");
            entity.Property(e => e.Tehnology)
                .HasColumnType("int(11)")
                .HasColumnName("tehnology");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Level)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Skills_LevelSkill_FK");

            entity.HasOne(d => d.TehnologyNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Tehnology)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Skills_Tehnology_FK");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Status1)
                .HasMaxLength(100)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Tehnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Tehnology");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Tehnology1)
                .HasMaxLength(100)
                .HasColumnName("tehnology");
        });

        modelBuilder.Entity<TypeEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TypeEducation");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.NameType)
                .HasMaxLength(100)
                .HasColumnName("name_type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Role, "Users_UserRoles_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateReg).HasColumnName("date_reg");
            entity.Property(e => e.EMail)
                .HasMaxLength(75)
                .HasColumnName("e_mail");
            entity.Property(e => e.FirstName)
                .HasMaxLength(75)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.NumberPhone)
                .HasColumnType("int(11)")
                .HasColumnName("number_phone");
            entity.Property(e => e.Role)
                .HasColumnType("int(11)")
                .HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_UserRoles_FK");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .HasColumnName("role");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("UserSkill");

            entity.HasIndex(e => e.Skill, "UserSkillVerification_Skills_FK");

            entity.HasIndex(e => e.User, "UserSkillVerification_Users_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Skill)
                .HasColumnType("int(11)")
                .HasColumnName("skill");
            entity.Property(e => e.User)
                .HasColumnType("int(11)")
                .HasColumnName("user");

            entity.HasOne(d => d.SkillNavigation).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.Skill)
                .HasConstraintName("UserSkillVerification_Skills_FK");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserSkillVerification_Users_FK");
        });

        modelBuilder.Entity<Verification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Status, "Verifications_Statuses_FK");

            entity.HasIndex(e => e.UserSkills, "Verifications_UserSkill_FK");

            entity.HasIndex(e => e.UserConfirming, "Verifications_Users_FK");

            entity.HasIndex(e => e.UserConfirmated, "Verifications_Users_FK_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasColumnType("int(11)")
                .HasColumnName("status");
            entity.Property(e => e.UserConfirmated)
                .HasColumnType("int(11)")
                .HasColumnName("user_confirmated");
            entity.Property(e => e.UserConfirming)
                .HasColumnType("int(11)")
                .HasColumnName("user_confirming");
            entity.Property(e => e.UserSkills)
                .HasColumnType("int(11)")
                .HasColumnName("user_skills");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Verifications)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Verifications_Statuses_FK");

            entity.HasOne(d => d.UserConfirmatedNavigation).WithMany(p => p.VerificationUserConfirmatedNavigations)
                .HasForeignKey(d => d.UserConfirmated)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Verifications_Users_FK_1");

            entity.HasOne(d => d.UserConfirmingNavigation).WithMany(p => p.VerificationUserConfirmingNavigations)
                .HasForeignKey(d => d.UserConfirming)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Verifications_Users_FK");

            entity.HasOne(d => d.UserSkillsNavigation).WithMany(p => p.Verifications)
                .HasForeignKey(d => d.UserSkills)
                .HasConstraintName("Verifications_UserSkill_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
