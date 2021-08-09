using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class KtitsInfoDBContext : DbContext
    {
        public KtitsInfoDBContext()
        {
        }

        public KtitsInfoDBContext(DbContextOptions<KtitsInfoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Couple> Couples { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<LessonsShedule> LessonsShedules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-52BNT37;Database=KtitsInfoDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Couple>(entity =>
            {
                entity.ToTable("Couple");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.TimeStart).HasColumnType("datetime");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Couples)
                    .HasForeignKey(d => d.DayId)
                    .HasConstraintName("FK_Couple_Day");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_User");
            });

            modelBuilder.Entity<LessonsShedule>(entity =>
            {
                entity.ToTable("LessonsShedule");

                entity.HasOne(d => d.Couple)
                    .WithMany(p => p.LessonsShedules)
                    .HasForeignKey(d => d.CoupleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonsShedule_Couple");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonsShedules)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonsShedule_Lesson");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_User_Group");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
