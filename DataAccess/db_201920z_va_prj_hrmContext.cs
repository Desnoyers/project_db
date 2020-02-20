using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace project_bazi.DataAccess
{
    public partial class db_201920z_va_prj_hrmContext : DbContext
    {
        public db_201920z_va_prj_hrmContext()
        {
        }

        public db_201920z_va_prj_hrmContext(DbContextOptions<db_201920z_va_prj_hrmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<CompanyVehicles> CompanyVehicles { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Drive> Drive { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Has> Has { get; set; }
        public virtual DbSet<JobHistory> JobHistory { get; set; }
        public virtual DbSet<Leaves> Leaves { get; set; }
        public virtual DbSet<Payroll> Payroll { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<TakePart> TakePart { get; set; }
        public virtual DbSet<Trainings> Trainings { get; set; }
        public virtual DbSet<WorkOn> WorkOn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=db_201920z_va_prj_hrm;Username=db_201920z_va_prj_hrm_owner;Password=hrm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.AttId)
                    .HasName("attendance_pkey");

                entity.ToTable("attendance", "project");

                entity.Property(e => e.AttId)
                    .HasColumnName("att_id")
                    .HasDefaultValueSql("nextval('project.attendance_att_id_seq'::regclass)");

                entity.Property(e => e.EmpEmbg)
                    .IsRequired()
                    .HasColumnName("emp_embg")
                    .HasMaxLength(15);

                entity.Property(e => e.TimeIn).HasColumnName("time_in");

                entity.Property(e => e.TimeOut).HasColumnName("time_out");

                entity.HasOne(d => d.EmpEmbgNavigation)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.EmpEmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_embg");
            });

            modelBuilder.Entity<CompanyVehicles>(entity =>
            {
                entity.HasKey(e => e.RegNo)
                    .HasName("company_vehicles_pkey");

                entity.ToTable("company_vehicles", "project");

                entity.Property(e => e.RegNo)
                    .HasColumnName("reg_no")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(20);

                entity.Property(e => e.VeType)
                    .IsRequired()
                    .HasColumnName("ve_type")
                    .HasMaxLength(30);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepNo)
                    .HasName("departments_pkey");

                entity.ToTable("departments", "project");

                entity.Property(e => e.DepNo)
                    .HasColumnName("dep_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnName("dep_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocNo)
                    .HasName("documents_pkey");

                entity.ToTable("documents", "project");

                entity.Property(e => e.DocNo)
                    .HasColumnName("doc_no")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.DocTitle)
                    .IsRequired()
                    .HasColumnName("doc_title")
                    .HasMaxLength(50);

                entity.Property(e => e.DocType)
                    .IsRequired()
                    .HasColumnName("doc_type")
                    .HasMaxLength(20);

                entity.Property(e => e.EmpEmbg)
                    .IsRequired()
                    .HasColumnName("emp_embg")
                    .HasMaxLength(15);

                entity.HasOne(d => d.EmpEmbgNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.EmpEmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_embg");
            });

            modelBuilder.Entity<Drive>(entity =>
            {
                entity.HasKey(e => new { e.RegNo, e.Embg })
                    .HasName("drive_pkey");

                entity.ToTable("drive", "project");

                entity.Property(e => e.RegNo)
                    .HasColumnName("reg_no")
                    .HasMaxLength(10);

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(15);

                entity.HasOne(d => d.EmbgNavigation)
                    .WithMany(p => p.Drive)
                    .HasForeignKey(d => d.Embg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("drive_embg_fkey");

                entity.HasOne(d => d.RegNoNavigation)
                    .WithMany(p => p.Drive)
                    .HasForeignKey(d => d.RegNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("drive_reg_no_fkey");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Embg)
                    .HasName("employees_pkey");

                entity.ToTable("employees", "project");

                entity.HasIndex(e => e.Username)
                    .HasName("employees_username_key")
                    .IsUnique();

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(20);

                entity.Property(e => e.DepManager).HasColumnName("dep_manager");

                entity.Property(e => e.DepNo).HasColumnName("dep_no");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsManaged)
                    .IsRequired()
                    .HasColumnName("is_managed")
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("numeric");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNo)
                    .HasColumnName("street_no")
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DepManagerNavigation)
                    .WithMany(p => p.EmployeesDepManagerNavigation)
                    .HasForeignKey(d => d.DepManager)
                    .HasConstraintName("fk_dep_manager");

                entity.HasOne(d => d.DepNoNavigation)
                    .WithMany(p => p.EmployeesDepNoNavigation)
                    .HasForeignKey(d => d.DepNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_no");

                entity.HasOne(d => d.IsManagedNavigation)
                    .WithMany(p => p.InverseIsManagedNavigation)
                    .HasForeignKey(d => d.IsManaged)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_is_managed");
            });

            modelBuilder.Entity<Has>(entity =>
            {
                entity.HasKey(e => new { e.Embg, e.SkillId })
                    .HasName("has_pkey");

                entity.ToTable("has", "project");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(15);

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.HasOne(d => d.EmbgNavigation)
                    .WithMany(p => p.Has)
                    .HasForeignKey(d => d.Embg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("has_embg_fkey");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Has)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("has_skill_id_fkey");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("job_history_pkey");

                entity.ToTable("job_history", "project");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("nextval('project.job_history_job_id_seq'::regclass)");

                entity.Property(e => e.EmpEmbg)
                    .IsRequired()
                    .HasColumnName("emp_embg")
                    .HasMaxLength(15);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasColumnName("job_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.EmpEmbgNavigation)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.EmpEmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_embg");
            });

            modelBuilder.Entity<Leaves>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("leaves_pkey");

                entity.ToTable("leaves", "project");

                entity.Property(e => e.LeaveId)
                    .HasColumnName("leave_id")
                    .HasDefaultValueSql("nextval('project.leaves_leave_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.EmpEmbg)
                    .IsRequired()
                    .HasColumnName("emp_embg")
                    .HasMaxLength(15);

                entity.Property(e => e.Fromdate)
                    .HasColumnName("fromdate")
                    .HasColumnType("date");

                entity.Property(e => e.LeaveStatus)
                    .HasColumnName("leave_status")
                    .HasMaxLength(15);

                entity.Property(e => e.Todate)
                    .HasColumnName("todate")
                    .HasColumnType("date");

                entity.HasOne(d => d.EmpEmbgNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmpEmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_embg");
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("payroll", "project");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('project.payroll_id_seq'::regclass)");

                entity.Property(e => e.EmpEmbg)
                    .IsRequired()
                    .HasColumnName("emp_embg")
                    .HasMaxLength(15);

                entity.Property(e => e.PayDate)
                    .HasColumnName("pay_date")
                    .HasColumnType("date");

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.EmpEmbgNavigation)
                    .WithMany(p => p.Payroll)
                    .HasForeignKey(d => d.EmpEmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payroll_emp_embg_fkey");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProName)
                    .HasName("projects_pkey");

                entity.ToTable("projects", "project");

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DepNo).HasColumnName("dep_no");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DepNoNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DepNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_no");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => e.SkillId)
                    .HasName("skills_pkey");

                entity.ToTable("skills", "project");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasDefaultValueSql("nextval('project.skills_skill_id_seq'::regclass)");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasColumnType("character varying");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasColumnName("skill_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TakePart>(entity =>
            {
                entity.HasKey(e => new { e.Embg, e.TrId })
                    .HasName("take_part_pkey");

                entity.ToTable("take_part", "project");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(15);

                entity.Property(e => e.TrId).HasColumnName("tr_id");

                entity.HasOne(d => d.EmbgNavigation)
                    .WithMany(p => p.TakePart)
                    .HasForeignKey(d => d.Embg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("take_part_embg_fkey");

                entity.HasOne(d => d.Tr)
                    .WithMany(p => p.TakePart)
                    .HasForeignKey(d => d.TrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("take_part_tr_id_fkey");
            });

            modelBuilder.Entity<Trainings>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("trainings_pkey");

                entity.ToTable("trainings", "project");

                entity.Property(e => e.TrId)
                    .HasColumnName("tr_id")
                    .HasDefaultValueSql("nextval('project.trainings_tr_id_seq'::regclass)");

                entity.Property(e => e.DepNo).HasColumnName("dep_no");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.TrName)
                    .IsRequired()
                    .HasColumnName("tr_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DepNoNavigation)
                    .WithMany(p => p.Trainings)
                    .HasForeignKey(d => d.DepNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_no");
            });

            modelBuilder.Entity<WorkOn>(entity =>
            {
                entity.HasKey(e => new { e.Embg, e.ProName })
                    .HasName("work_on_pkey");

                entity.ToTable("work_on", "project");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(15);

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmbgNavigation)
                    .WithMany(p => p.WorkOn)
                    .HasForeignKey(d => d.Embg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_on_embg_fkey");

                entity.HasOne(d => d.ProNameNavigation)
                    .WithMany(p => p.WorkOn)
                    .HasForeignKey(d => d.ProName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_on_pro_name_fkey");
            });

            modelBuilder.HasSequence<int>("attendance_att_id_seq");

            modelBuilder.HasSequence<int>("job_history_job_id_seq");

            modelBuilder.HasSequence<int>("leaves_leave_id_seq");

            modelBuilder.HasSequence<int>("payroll_id_seq");

            modelBuilder.HasSequence<int>("skills_skill_id_seq");

            modelBuilder.HasSequence<int>("trainings_tr_id_seq");
        }
    }
}
