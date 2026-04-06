using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VolunteerCenter.Models;

public partial class VolunteerCenterContext : DbContext
{
    public VolunteerCenterContext()
    {
    }

    public VolunteerCenterContext(DbContextOptions<VolunteerCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<RegistrationStatus> RegistrationStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerRegistration> VolunteerRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volunteer_center;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EventName).HasColumnName("event_name");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdEventStatus).HasColumnName("id_event_status");
            entity.Property(e => e.IdPlace).HasColumnName("id_place");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.RequiredAmount).HasColumnName("required_amount");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("events_id_category_fkey");

            entity.HasOne(d => d.IdEventStatusNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdEventStatus)
                .HasConstraintName("events_id_event_status_fkey");

            entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdPlace)
                .HasConstraintName("events_id_place_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("events_id_user_fkey");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_statuses_pkey");

            entity.ToTable("event_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventStatusName).HasColumnName("event_status_name");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("places_pkey");

            entity.ToTable("places");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlaceName).HasColumnName("place_name");
        });

        modelBuilder.Entity<RegistrationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_statuses_pkey");

            entity.ToTable("registration_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RegistrationStatusName).HasColumnName("registration_status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        modelBuilder.Entity<VolunteerRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("volunteer_registrations_pkey");

            entity.ToTable("volunteer_registrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdRegistrationStatus).HasColumnName("id_registration_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("volunteer_registrations_id_event_fkey");

            entity.HasOne(d => d.IdRegistrationStatusNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdRegistrationStatus)
                .HasConstraintName("volunteer_registrations_id_registration_status_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("volunteer_registrations_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
