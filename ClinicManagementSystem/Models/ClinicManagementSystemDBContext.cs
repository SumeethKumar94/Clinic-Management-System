using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagementSystem.Models
{
    public partial class ClinicManagementSystemDBContext : DbContext
    {
        public ClinicManagementSystemDBContext()
        {
        }

        public ClinicManagementSystemDBContext(DbContextOptions<ClinicManagementSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<ConsultationBill> ConsultationBill { get; set; }
        public virtual DbSet<DoctorNotes> DoctorNotes { get; set; }
        public virtual DbSet<LabBill> LabBill { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<MedicineAdvice> MedicineAdvice { get; set; }
        public virtual DbSet<MedicineBill> MedicineBill { get; set; }
        public virtual DbSet<MedicineDetails> MedicineDetails { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestDetails> TestDetails { get; set; }
        public virtual DbSet<TestReport> TestReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SREEHARIPRATHAP\\SQLEXPRESS;Database=ClinicManagementSystemDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("appointmentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.ReceptionistId).HasColumnName("receptionistId");

                entity.Property(e => e.TokenNo).HasColumnName("tokenNo");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appointme__docto__440B1D61");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appointme__patie__4316F928");

                entity.HasOne(d => d.Receptionist)
                    .WithMany(p => p.AppointmentReceptionist)
                    .HasForeignKey(d => d.ReceptionistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appointme__recep__44FF419A");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bill");

                entity.Property(e => e.BillId).HasColumnName("billId");

                entity.Property(e => e.BillDate)
                    .HasColumnName("billDate")
                    .HasColumnType("date");

                entity.Property(e => e.ConsultancyBillId).HasColumnName("consultancyBillId");

                entity.Property(e => e.LabTestBillId).HasColumnName("labTestBillId");

                entity.Property(e => e.MedicineBillId).HasColumnName("medicineBillId");

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.HasOne(d => d.ConsultancyBill)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.ConsultancyBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bill__consultanc__72C60C4A");

                entity.HasOne(d => d.LabTestBill)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.LabTestBillId)
                    .HasConstraintName("FK__bill__labTestBil__74AE54BC");

                entity.HasOne(d => d.MedicineBill)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.MedicineBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bill__medicineBi__73BA3083");
            });

            modelBuilder.Entity<ConsultationBill>(entity =>
            {
                entity.ToTable("consultationBill");

                entity.Property(e => e.ConsultationBillId).HasColumnName("consultationBillId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.DateOfBill)
                    .HasColumnName("dateOfBill")
                    .HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ConsultationBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consultat__appoi__6A30C649");
            });

            modelBuilder.Entity<DoctorNotes>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK__doctorNo__03C97EFD11E22838");

                entity.ToTable("doctorNotes");

                entity.Property(e => e.NoteId).HasColumnName("noteId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .IsUnicode(false);

                entity.Property(e => e.PatientId).HasColumnName("patientId");
            });

            modelBuilder.Entity<LabBill>(entity =>
            {
                entity.ToTable("labBill");

                entity.Property(e => e.LabBillId).HasColumnName("labBillId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.TestReportId).HasColumnName("testReportId");

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__labBill__appoint__5812160E");

                entity.HasOne(d => d.TestReport)
                    .WithMany(p => p.LabBill)
                    .HasForeignKey(d => d.TestReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__labBill__testRep__59063A47");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.LoginId)
                    .HasColumnName("loginId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__login__staffId__48CFD27E");
            });

            modelBuilder.Entity<MedicineAdvice>(entity =>
            {
                entity.ToTable("medicineAdvice");

                entity.Property(e => e.MedicineAdviceId).HasColumnName("medicineAdviceId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.PharmacistId).HasColumnName("pharmacistId");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineAdvice)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineA__appoi__5DCAEF64");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicineAdviceDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineA__docto__5EBF139D");

                entity.HasOne(d => d.Pharmacist)
                    .WithMany(p => p.MedicineAdvicePharmacist)
                    .HasForeignKey(d => d.PharmacistId)
                    .HasConstraintName("FK__medicineA__pharm__5FB337D6");
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.ToTable("medicineBill");

                entity.Property(e => e.MedicineBillId).HasColumnName("medicineBillId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.MedicineAdviceId).HasColumnName("medicineAdviceId");

                entity.Property(e => e.MedicineBillDate)
                    .HasColumnName("medicineBillDate")
                    .HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineB__appoi__66603565");

                entity.HasOne(d => d.MedicineAdvice)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.MedicineAdviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineB__medic__6754599E");
            });

            modelBuilder.Entity<MedicineDetails>(entity =>
            {
                entity.ToTable("medicineDetails");

                entity.Property(e => e.MedicineDetailsId).HasColumnName("medicineDetailsId");

                entity.Property(e => e.MedicineAdviceId).HasColumnName("medicineAdviceId");

                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MedicineAdvice)
                    .WithMany(p => p.MedicineDetails)
                    .HasForeignKey(d => d.MedicineAdviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineD__medic__6383C8BA");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medicineD__medic__628FA481");
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__medicine__BA9E65EEF2CD5129");

                entity.ToTable("medicines");

                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.Dose)
                    .HasColumnName("dose")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineDescription)
                    .HasColumnName("medicineDescription")
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicineName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicinePrice).HasColumnName("medicinePrice");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasColumnName("bloodGroup")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("patientName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.ToTable("qualifications");

                entity.Property(e => e.QualificationsId).HasColumnName("qualificationsId");

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Qualifications)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__qualifica__roleI__38996AB5");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Role1)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.QualificationsId).HasColumnName("qualificationsId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Qualifications)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.QualificationsId)
                    .HasConstraintName("FK__staff__qualifica__3B75D760");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__staff__roleId__3C69FB99");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.MaxRange).HasColumnName("maxRange");

                entity.Property(e => e.MinRange).HasColumnName("minRange");

                entity.Property(e => e.TestDescription)
                    .IsRequired()
                    .HasColumnName("testDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("testName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestDetails>(entity =>
            {
                entity.HasKey(e => e.TestDetailId)
                    .HasName("PK__testDeta__2639FF9D10CC90EF");

                entity.ToTable("testDetails");

                entity.Property(e => e.TestDetailId).HasColumnName("testDetailId");

                entity.Property(e => e.TestId).HasColumnName("testID");

                entity.Property(e => e.TestReportId).HasColumnName("testReportId");

                entity.Property(e => e.TestValue)
                    .HasColumnName("testValue")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__testDetai__testI__5441852A");

                entity.HasOne(d => d.TestReport)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.TestReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__testDetai__testR__5535A963");
            });

            modelBuilder.Entity<TestReport>(entity =>
            {
                entity.ToTable("testReport");

                entity.Property(e => e.TestReportId).HasColumnName("testReportId");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.LabTechnicianId).HasColumnName("labTechnicianId");

                entity.Property(e => e.TestAmount).HasColumnName("testAmount");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestReport)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__testRepor__appoi__4F7CD00D");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TestReportDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__testRepor__docto__5070F446");

                entity.HasOne(d => d.LabTechnician)
                    .WithMany(p => p.TestReportLabTechnician)
                    .HasForeignKey(d => d.LabTechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__testRepor__labTe__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
