using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql;

using Vendor.Models;

namespace Vendor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => entity.HasIndex(k => k.UserName).IsUnique(true));
            //builder.Entity<ApplicationUser>(entity => entity.HasIndex(k => k.Email).IsUnique(true));
            builder.Entity<ApplicationUser>().ToTable("ems_users").HasKey(k => new { k.Id });
            builder.Entity<ApplicationRole>().ToTable("ems_roles").HasKey(k => new { k.Id });
            builder.Entity<ApplicationUserRole>(userRole => {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });
            builder.Entity<ApplicationUserRole>().ToTable("ems_user_roles").HasKey(k => new { k.UserId, k.RoleId });
            builder.Entity<IdentityUserLogin<string>>().ToTable("ems_user_logins").HasKey(k => new { k.LoginProvider, k.ProviderKey, k.UserId });
            builder.Entity<IdentityUserClaim<string>>().ToTable("ems_user_claims").HasKey(k => new { k.Id });
            builder.Entity<IdentityUserToken<string>>().ToTable("ems_user_tokens").HasKey(k => new { k.UserId });
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ems_role_claims").HasKey(k => new { k.Id });

            builder.Entity<Student>(e => e.HasIndex("StdSicno").IsUnique(true));
            builder.Entity<Student>(e => e.HasIndex("StdStrno").IsUnique(true));
            builder.Entity<Student>(e => e.HasIndex("StdPhone").IsUnique(true));

            builder.Entity<Passport>(e => e.HasKey(k => new { k.PptStdid, k.PptStrno }));

            builder.Entity<Visa>(e => e.HasKey(k => new { k.VisStrid, k.VisStdid }));

            builder.Entity<Country>(e => e.HasIndex("CntSname").IsUnique(true));

            builder.Entity<Programme>(e => e.HasIndex("PrgSname").IsUnique(true));
            builder.Entity<Programme>(e => e.HasIndex("PrgScode").IsUnique(true));

            builder.Entity<Subject>(e => e.HasIndex("SubScode").IsUnique(true));

            builder.Entity<ProgrammeSubject>(e => e.HasKey(k => new { k.PsbPrgid, k.PsbSbjid}));

            builder.Entity<Staff>(e => e.HasIndex("StfStrid").IsUnique(true));

            builder.Entity<Application>(e => e.HasIndex("AppStrno").IsUnique(true));

            builder.Entity<Passport>(e => e.HasIndex("PptStrno").IsUnique(true));

            builder.Entity<Visa>(e => e.HasIndex("VisStrid").IsUnique(true));

            builder.Entity<AcademicCalendar>(e => e.HasIndex("AcaScode").IsUnique(true));

            builder.Entity<AcademicCalendarDetail>(e => e.HasIndex("AclEvent").IsUnique(true));

            builder.Entity<ExamResult>(e => e.HasKey(k => new { k.ExrPrgid, k.ExrSbjid, k.ExrStdid }));

            builder.Entity<LibraryDetails>(e => e.HasKey(k => new { k.LidBokid, k.LidStdid }));

            builder.Entity<Bursary>(e => e.HasKey(k => new { k.BrsStdid, k.BrsTypid }));

            builder.Entity<TimeTable>(e => e.HasKey(k => new { k.TtbWkday, k.TtbDstme }));

            builder.Entity<Intake>(e => e.HasIndex("IntScode").IsUnique(true));

            builder.Entity<Staff>(e => e.HasIndex("StfEmail").IsUnique(true));
            builder.Entity<Staff>(e => e.HasIndex("StfIcpno").IsUnique(true));
            builder.Entity<Staff>(e => e.HasIndex("StfStrid").IsUnique(true));
            builder.Entity<Staff>(e => e.HasIndex("StfMobno").IsUnique(true));

            builder.Entity<Hostel>(e => e.HasKey(k => new { k.HstStrno, k.HstRomno, k.HstBedno, k. HstWrbno }));

            builder.Entity<ProgrammeSubject>(e => e.HasKey(k => new { k.PsbPrgid, k.PsbSbjid }));

            builder.Entity<FeeSemester>(e => e.HasKey(k => new { k.FesPrgid, k.FesSemid }));

            builder.Entity<ExamDocket>(e => e.HasKey(k => new { k.ExdStdid }));
        }

        public DbSet<CompanyProfile> GetCompanyProfiles { get; set; }
        public DbSet<Country> GetCountries { get; set; }
        public DbSet<State> GetStates { get; set; }
        public DbSet<City> GetCities { get; set; }
        public DbSet<Parameter> GetParameters { get; set; }
        public DbSet<Subject> GetSubjects { get; set; }
        public DbSet<Programme> GetProgrammes { get; set; }
        public DbSet<Grade> GetGrades { get; set; }
        public DbSet<Staff> GetStaffs { get; set; }
        public DbSet<Application> GetApplications { get; set; }
        public DbSet<ApplicationNextKin> GetApplicationNextKins { get; set; }
        public DbSet<Qualification> GetQualifications { get; set; }
        public DbSet<LanguageQualification> GetLanguageQualifications { get; set; }
        public DbSet<Student> GetStudents { get; set; }
        public DbSet<NextKin> GetNextKins { get; set; }
        public DbSet<Passport> GetPassports { get; set; }
        public DbSet<StudentCourse> GetStudentCourses { get; set; }
        public DbSet<Bursary> GetBursaries { get; set; }
        public DbSet<AcademicCalendar> GetAcademicCalendars { get; set; }
        public DbSet<Visa> GetVisas { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<StaffAttendance> StaffAttendance { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<ClassRoomBooking> ClassRoomBooking { get; set; }
        public DbSet<Hostel> Hostel { get; set; }
        public DbSet<StudentAttendance> StudentAttendance { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<Intake> Intake { get; set; }
        public DbSet<Counselling> Counselling { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<LibraryDetails> LibraryDetails { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Transcript> Transcript { get; set; }
        public DbSet<ForumTopic> ForumTopic { get; set; }
        public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<UsersInRoleViewModel> UsersInRoleViewModel { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<AcademicCalendarDetail> AcademicCalendarDetail { get; set; }
        public DbSet<FeeSchedule> FeeSchedule { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<TranscriptRequest> TranscriptRequest { get; set; }
        public DbSet<ApplicationDeclaration> ApplicationDeclaration { get; set; }
        public DbSet<ApplicationOfficial> ApplicationOfficial { get; set; }
        public DbSet<CounsellingRequest> CounsellingRequest { get; set; }
        public DbSet<MaterialSales> MaterialSales { get; set; }
        public DbSet<ExamDocket> ExamDocket { get; set; }
        public DbSet<FeeSemester> GetFeeSemesters { get; set; }
        public DbSet<WebApp.Models.ProgrammeSubject> ProgrammeSubject { get; set; }

    }
}
