using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Diplom1;

public partial class DiplomBdContext : DbContext
{
    public DiplomBdContext()
    {
    }

    public DiplomBdContext(DbContextOptions<DiplomBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersPasswd> UsersPasswds { get; set; }

    public virtual DbSet<UsersStatus> UsersStatuses { get; set; }

    public virtual DbSet<OrgCode> OrgsCodes { get; set; }
    public virtual DbSet<addinfo> Addinfos { get; set; }
    public virtual DbSet<AddFunction> Addfunctions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=rc1b-tedf5g2vl4ivc4me.mdb.yandexcloud.net;Port=6432;Database=diplom_bd;Username=admin1;Password=12345678");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrgId).HasName("organization_pkey");

            entity.ToTable("organization");

            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.DistantCode).HasColumnName("distant_code");
            entity.Property(e => e.OrgCodes).HasColumnName("org_code");
            entity.Property(e => e.OrgName)
                .HasMaxLength(250)
                .HasColumnName("org_name");
            entity.Property(e => e.TrainingStatus).HasColumnName("training_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.StatusCode).HasColumnName("status_code");
        });

        modelBuilder.Entity<UsersPasswd>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_passwd_pkey");

            entity.ToTable("users_passwd");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.StatusCode).HasColumnName("status_code");
        });

        modelBuilder.Entity<UsersStatus>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_status_pkey");

            entity.ToTable("users_status");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.StatusCode).HasColumnName("status_code");
        });

        
        modelBuilder.Entity<OrgCode>(entity =>
        {
            entity.HasKey(e => e.CodeID).HasName("org_code_pkey");

            entity.ToTable("org_code");

            entity.Property(e => e.CodeID).HasColumnName("cod_id");
            entity.Property(e => e.Orgcode).HasColumnName("org_code");
            entity.Property(e => e.CodeName).HasMaxLength(30).HasColumnName("code_name");

        });

        modelBuilder.Entity<addinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addinfo_pkey");

            entity.ToTable("addinfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrgId).HasColumnName("org_ig");
            entity.Property(e => e.InfoCode).HasColumnName("info_code");
            entity.Property(e => e.MoreInfo).HasMaxLength(3000).HasColumnName("moreinfo");
            entity.Property(e => e.Addres).HasMaxLength(3000).HasColumnName("addres");

        });

        modelBuilder.Entity<AddFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("add_function_pkey");

            entity.ToTable("add_function");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.OrgID).HasColumnName("org_id");
            entity.Property(e => e.Recommend).HasMaxLength(3000).HasColumnName("recommend");
            entity.Property(e => e.Favor).HasColumnName("favor");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
