using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SymphonyInstitute.Ltd.Models;

namespace SymphonyInstitute.Ltd.Models
{
    public class StudentDbContext:IdentityDbContext<ApplicationUser>
    {
        public StudentDbContext()
        {
        }

        public StudentDbContext(DbContextOptions<StudentDbContext>option):base (option)
        {

        }

        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public  DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CoursesEnrolled> CoursesEnrolled { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EntryExam> EntryExam { get; set; }
        public virtual DbSet<EntryResult> EntryResult { get; set; }
        public virtual DbSet<MonthlyTest> MonthlyTest { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public DbSet<SymphonyInstitute.Ltd.Models.Login> Login { get; set; }

        public DbSet<Voucher> voucher { get; set; }
        public DbSet<ViewStudentDetails>ViewStudentDetails { get; set; }
        //public DbSet<Rollnumber>Rollnumbers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Voucher>().HasNoKey();
            modelBuilder
               .Entity<Rollnumber>().HasNoKey();
            modelBuilder.Entity<ViewStudentDetails>().HasNoKey();
            
        }
        //public DbSet<Rollnumber>Rollnumbers { get; set; }



    }

    
}
