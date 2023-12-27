using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPFDecstop.Models;

public partial class TimetableContext : DbContext
{
    public TimetableContext()
    {
    }

    public TimetableContext(DbContextOptions<TimetableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CabinetType> CabinetTypes { get; set; }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonNumber> LessonNumbers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }
    public virtual DbSet<Key> Keys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=timetable;connection timeout=20;persist security info=False;port=3306;allow user variables=True;connect timeout=120;user=root;password=1212", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cabinet");

            entity.HasIndex(e => e.IdCabinetType, "fk_cabinet_type_idx");

            entity.Property(e => e.Id)
              //  .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AmmountOfPlaces).HasColumnName("ammount_of_places");
            entity.Property(e => e.CabinetNumber).HasMaxLength(20).HasColumnName("cabinet_number");
            entity.Property(e => e.IdCabinetType).HasColumnName("id_cabinet_type");

            entity.HasOne(d => d.IdCabinetTypeNavigation).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.IdCabinetType)
                .HasConstraintName("fk_cabinet_type");
        });
        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.idKey).HasName("idKey");

            entity.ToTable("key");

            entity.Property(e => e.idKey).HasColumnName("idKey");
            entity.Property(e => e.key)
                .HasMaxLength(45)
                .HasColumnName("key");
          
        });
        modelBuilder.Entity<CabinetType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cabinet_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CabinetName)
                .HasMaxLength(45)
                .HasColumnName("cabinet_name");
            entity.Property(e => e.Discription)
                .HasMaxLength(45)
                .HasColumnName("discription");
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.HasKey(e => new { e.IdWeek, e.IdWeekday })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("day");

            entity.HasIndex(e => e.Date, "date_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdWeekday, "fk_weekday_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.IdWeek).HasColumnName("id_week");
            entity.Property(e => e.IdWeekday).HasColumnName("id_weekday");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdWeekNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.IdWeek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_weeks");

            entity.HasOne(d => d.IdWeekdayNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.IdWeekday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_weekday");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("groups");

            entity.Property(e => e.Id)
              //  .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GroupNumber).HasMaxLength(45).HasColumnName("group_number");
            entity.Property(e => e.ShortNumber)
                .HasMaxLength(45)
                .HasColumnName("short_number");
            entity.Property(e => e.StudentAmmount)
                .HasColumnName("student_ammount");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => new { e.IdDay, e.IdLessonNumber, e.IdCabinet, e.IdGroup, e.IdSubject, e.IdTeacher })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });

            entity.ToTable("lesson");

            entity.HasIndex(e => e.IdCabinet, "fk_id_cabinet_idx");

            entity.HasIndex(e => e.IdDay, "fk_id_day_idx");

            entity.HasIndex(e => e.IdGroup, "fk_id_group_idx");

            entity.HasIndex(e => e.IdLessonNumber, "fk_id_lesson_number_idx");

            entity.HasIndex(e => e.IdSubject, "fk_id_subject_idx");

            entity.HasIndex(e => e.IdTeacher, "fk_id_teacher_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.IdDay).HasColumnName("id_day");
            entity.Property(e => e.IdLessonNumber).HasColumnName("id_lesson_number");
            entity.Property(e => e.IdCabinet).HasColumnName("id_cabinet");
            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");
            entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdCabinetNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdCabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_cabinet");

            entity.HasOne(d => d.IdDayNavigation).WithMany(p => p.Lessons)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.IdDay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_day");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_group");

            entity.HasOne(d => d.IdLessonNumberNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdLessonNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_lesson_number");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_subject");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_teacher");
        });

        modelBuilder.Entity<LessonNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lesson_number");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LessonNumber1).HasColumnName("lesson_number");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("semester");

            entity.Property(e => e.Id)
              //  .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EnenOrNot).HasColumnName("enen_or_not");
            entity.Property(e => e.Year).HasMaxLength(4).HasColumnName("year");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.Property(e => e.Id)
                 .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Attestation).HasColumnName("attestation");
            entity.Property(e => e.Consultation).HasColumnName("consultation");
            entity.Property(e => e.ConsultationHoursAmmount).HasColumnName("consultation_hours_ammount");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.LabAmount).HasColumnName("lab_amount");
            entity.Property(e => e.PracticHoursAmmount).HasColumnName("practic_hours_ammount");
            entity.Property(e => e.SemesterNum).HasColumnName("semester_num");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(70)
                .HasColumnName("subject_name");
            entity.Property(e => e.TotalHours).HasColumnName("total_hours");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(45)
                .HasColumnName("patronomic");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Week>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("weeks");

            entity.HasIndex(e => e.IdSemester, "fk_id_semestr_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdSemester).HasColumnName("id_semester");

            entity.HasOne(d => d.IdSemesterNavigation).WithMany(p => p.Weeks)
                .HasForeignKey(d => d.IdSemester)
                .HasConstraintName("fk_id_semester");
        });

        modelBuilder.Entity<Weekday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("weekday");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
