using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace BackEnd.Models
{
    public partial class ManagementGamesDB : DbContext
    {
        public ManagementGamesDB()
        {
        }

        public ManagementGamesDB(DbContextOptions<ManagementGamesDB> options)
            : base(options)
        {
        }

        public virtual DbSet<JuryInPanel> JuryInPanels { get; set; }
        public virtual DbSet<JuryPanel> JuryPanels { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantInSchool> ParticipantInSchools { get; set; }
        public virtual DbSet<ParticipantInTournament> ParticipantInTournaments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentFormat> TournamentFormats { get; set; }
        public virtual DbSet<TournamentGridType> TournamentGridTypes { get; set; }
        public virtual DbSet<TournamentType> TournamentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CRVD7EK;Initial Catalog=kub;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<JuryInPanel>(entity =>
            {
                entity.HasOne(d => d.JuryPanel)
                    .WithMany(p => p.JuryInPanels)
                    .HasForeignKey(d => d.JuryPanelId)
                    .HasConstraintName("FK_Судьи в коллегиях_Коллегии судей");

                entity.HasOne(d => d.JuryParticipant)
                    .WithMany(p => p.JuryInPanels)
                    .HasForeignKey(d => d.JuryParticipantId)
                    .HasConstraintName("FK_Судьи в коллегиях_Участники1");

                entity.HasOne(d => d.TournamentWithJury)
                    .WithMany(p => p.JuryInPanels)
                    .HasForeignKey(d => d.TournamentWithJuryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Судьи в коллегиях_Турниры");
            });

            modelBuilder.Entity<JuryPanel>(entity =>
            {
                entity.HasKey(e => e.PanelId)
                    .HasName("PK_Коллегии судей");
            });

            modelBuilder.Entity<ParticipantInSchool>(entity =>
            {
                entity.HasOne(d => d.ParticipantInSchoolNavigation)
                    .WithOne(p => p.ParticipantInSchool)
                    .HasForeignKey<ParticipantInSchool>(d => d.ParticipantInSchoolId)
                    .HasConstraintName("FK_Участники в школах_Участники");

                entity.HasOne(d => d.ParticipantSchool)
                    .WithMany(p => p.ParticipantInSchools)
                    .HasForeignKey(d => d.ParticipantSchoolId)
                    .HasConstraintName("FK_Участники в школах_Школы");
            });

            modelBuilder.Entity<ParticipantInTournament>(entity =>
            {
                entity.HasKey(e => new { e.TournamentWithParticipantId, e.ParticipantInTournamentId })
                    .HasName("PK_Участники в турнирах");

                entity.HasOne(d => d.ParticipantInTournamentNavigation)
                    .WithMany(p => p.ParticipantInTournaments)
                    .HasForeignKey(d => d.ParticipantInTournamentId)
                    .HasConstraintName("FK_Участники в турнирах_Участники");

                entity.HasOne(d => d.ParticpantRole)
                    .WithMany(p => p.ParticipantInTournaments)
                    .HasForeignKey(d => d.ParticpantRoleId)
                    .HasConstraintName("FK_Участники в турнирах_Роли");

                entity.HasOne(d => d.TournamentWithParticipant)
                    .WithMany(p => p.ParticipantInTournaments)
                    .HasForeignKey(d => d.TournamentWithParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Участники в турнирах_Турниры");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.EndTime).IsFixedLength(true);

                entity.Property(e => e.StartTime).IsFixedLength(true);

                entity.HasOne(d => d.TournamentFormat)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TournamentFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Турниры_Формат проведения");

                entity.HasOne(d => d.TournamentGrid)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TournamentGridId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Турниры_Вариант сетки турнира");

                entity.HasOne(d => d.TournamentLocation)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TournamentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Турниры_Место1");

                entity.HasOne(d => d.TournamentType)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TournamentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Турниры_Типы турниров");
            });

            modelBuilder.Entity<TournamentFormat>(entity =>
            {
                entity.HasKey(e => e.FormatId)
                    .HasName("PK_Формат проведения");
            });

            modelBuilder.Entity<TournamentGridType>(entity =>
            {
                entity.HasKey(e => e.GridId)
                    .HasName("PK_Вариант сетки турнира");
            });

            modelBuilder.Entity<TournamentType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_Типы турниров");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
